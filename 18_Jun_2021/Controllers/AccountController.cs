using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using _18_Jun_2021.Models;
using _18_Jun_2021.Controllers;
using System.IO.Ports;
using System.Web.Security;
using _18_Jun_2021.Models.Extended;

namespace _18_Jun_2021.Controllers
{
    public class AccountController : Controller
    {
        static private string[] selectedStation;
        #region Login
        static string posterName = "";
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin acc, string ReturnUrl = "")
        {
            string message = "";
            using (AccountEntities1 dc = new AccountEntities1())
            {
                var v = dc.Accounts.Where(a => a.Name == acc.Name).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(acc.Password, v.Password) == 0)
                    {
                        posterName = acc.Name;
                        int timeout = 1; //Timeout 1 Minutes
                        var ticket = new FormsAuthenticationTicket(acc.Name, false, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);
                        return RedirectToAction("SelectClient");
                    }
                    else
                    {
                        message = "Invalid credential provided";
                        return View();
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                    return View();
                }
            }

        }
        #endregion

        #region Logout
        [HttpGet]
        [Authorize]
        public ActionResult Logout()
        {
            return View();
        }

        //Logout
        [HttpPost]
        [Authorize]
        public ActionResult Logout(Account acc)
        {
            posterName = "";
            FormsAuthentication.SignOut();
            return View("Login");
        }
        #endregion

        #region Register new Account

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Account acc)
        {
            string message = "";

            using (AccountEntities1 dc = new AccountEntities1())
            {
                var v = dc.Accounts.Where(a => a.Name == acc.Name).FirstOrDefault();
                if (v == null)
                {
                    dc.Accounts.Add(acc);
                    dc.SaveChanges();
                    message = "Registered this Account already !";
                }
                else
                {
                    message = "Already exist this Name !";
                }
            }
            ViewBag.Message = message;
            return View();
        }
        #endregion

        #region Encrypt and Decrypt
        protected string TestSymMethod(string plainText)
        {
            var rsaHelper = new RsaHelper();
            string symKey = (rsaHelper._publicKey).ToString();

            /* 128 byte of encrypted message */
            string encryptedstring = StringCipher.Encrypt(plainText, symKey);
            string decryptedstring = StringCipher.Decrypt(encryptedstring, symKey);

            return (decryptedstring);
        }
        protected string SymEncryptMethod(string plainText)
        {
            var rsaHelper = new RsaHelper();
            string symKey = (rsaHelper._publicKey).ToString();

            /* 128 byte of encrypted message */
            string encryptedstring = StringCipher.Encrypt(plainText, symKey);

            return (encryptedstring);
        }
        protected string SymDecryptMethod(string encryptedstring)
        {
            var rsaHelper = new RsaHelper();
            string symKey = (rsaHelper._publicKey).ToString();

            /* 128 byte of encrypted message */
            string decryptedstring = StringCipher.Decrypt(encryptedstring, symKey);

            return (decryptedstring);
        }
        protected string TestAsymMethod(string plainText)
        {
            var rsaHelper = new RsaHelper();
            string asymEncrypted = rsaHelper.Encrypt(plainText);
            string asymDecrypt = rsaHelper.Decrypt(asymEncrypted);

            //return ((encrypted.Length).ToString());
            return (asymDecrypt);
        }
        #endregion

        #region Send message to Serial Port
        #region Variable and Fuction for Serial connection
        enum MsgCmd_en
        {
            IDLE,
            REQUEST,
            RESPONSE,
        }
        enum desPortState_en
        {
            OPEN,
            CONNECT,
            ALCONNECTED,
            CONNECT_FAILED,
            WRITE_FAILED,
            READ_FAILED,
        }

        struct GMSDevice_type
        {
            public int totalPCPorts;
            public string[] listPCPorts;
            public SerialPort desPort;
            public string desPortName;
            public desPortState_en desPortState;
            public MsgCmd_en msgCmd;
        };
        static GMSDevice_type GMSDevice;
        SelectListItem drPorts = new SelectListItem()
        {
            Text = "COM7",
            Value = "1",
            Selected = true
        };
        protected void btnCheckPorts_Click()
        {
            /* Lay tat car cac Serial Port */
            GMSDevice.listPCPorts = SerialPort.GetPortNames();
            if (GMSDevice.totalPCPorts != GMSDevice.listPCPorts.Length)
            {
                GMSDevice.totalPCPorts = GMSDevice.listPCPorts.Length;
            }
        }
        #region Initilize the connection to your GMS device first
        protected void OpenSerialPort()
        {
            btnCheckPorts_Click();
            ViewBag.SerialPortItems = drPorts;

            if ((drPorts.Text != "") && (drPorts.Text != GMSDevice.desPortName))
            {
                GMSDevice.desPort = new SerialPort(drPorts.Text, 9600, Parity.None, 8, StopBits.One);
                GMSDevice.desPortState = desPortState_en.OPEN;
                try
                {
                    GMSDevice.desPort.Open();
                    GMSDevice.desPortName = drPorts.Text;
                    GMSDevice.desPortState = desPortState_en.CONNECT;
                }
                catch (UnauthorizedAccessException)
                {
                    GMSDevice.desPortState = desPortState_en.ALCONNECTED;
                }
            }
            else if (drPorts.Text == GMSDevice.desPortName)
            {
                GMSDevice.desPortState = desPortState_en.ALCONNECTED;
            }
            else
            {
                GMSDevice.desPortState = desPortState_en.OPEN;
            }

        }
        #endregion
        #region Send your message to Client(s)
        protected string SendMessageInterProcess(Message msg)
        {
            string message = "";
            
            string cmdSend = (SymEncryptMethod(msg.MessageContent)).Count() + "-"+ SymEncryptMethod(msg.MessageContent);
            string cmdRead = "";
            bool breakLoop = false;

            GMSDevice.msgCmd = MsgCmd_en.REQUEST;

            while (false == breakLoop)
            {
                switch (GMSDevice.msgCmd)
                {
                    case MsgCmd_en.IDLE:
                        break;
                    /* Send Encrypted message to Client */
                    case MsgCmd_en.REQUEST:
                        GMSDevice.desPort.WriteLine(cmdSend);
                        GMSDevice.msgCmd = MsgCmd_en.RESPONSE;
                        break;
                    /* Verify the message from Client */
                    case MsgCmd_en.RESPONSE:
                        try
                        {
                            cmdRead = GMSDevice.desPort.ReadLine();

                            if ((SymDecryptMethod(cmdRead)).Contains("OK"))
                            {
                                message = "Send message successfully !";
                            }
                            else
                            {
                                message = "Something wrong !";
                            }
                            GMSDevice.msgCmd = MsgCmd_en.IDLE;
                            breakLoop = true;
                        }
                        catch (InvalidOperationException)
                        {

                        }
                        catch (TimeoutException)
                        {

                        }
                        break;
                    default:
                        break;
                }
            }
            return (message);
        }
        protected string SendMessageViaSerialPort(Message msg)
        {
            string message = "";
            int count=0;

            switch (GMSDevice.desPortState)
            {
                case desPortState_en.OPEN:
                    message = "Chua ket noi voi thiet bi";
                    break;
                case desPortState_en.CONNECT:
                case desPortState_en.ALCONNECTED:
                    foreach(string client in selectedStation)
                    {
                        message = SendMessageInterProcess(msg);
                        count++;
                    }
                    break;
                default:
                    break;
            }
            return (message + count.ToString());
        }
        #endregion
        #region  Save your message into database
        protected void SaveMessageToDatabase(Message msg)
        {
            using (AccountEntities1 dc = new AccountEntities1())
            {
                var v = dc.Messages.Where(a => a.MessageContent == msg.MessageContent).FirstOrDefault();

                for (int idx = 0; idx < 2; idx++)
                {
                    if ((v == null))
                    {
                        /* Save your message */
                        dc.Messages.Add(msg);
                    }
                    else
                    {
                        /* Already exist this message */
                        v.ToStation = string.Join("-", selectedStation);
                        v.Date = DateTime.Now;
                        v.PosterName = posterName;
                        v.Count = (v.Count == null) ? (1) : (v.Count + 1);
                        idx = 2; /* to ensure that entering this loop only 1 time */
                    }
                    dc.SaveChanges();
                }
            }
        }
        #endregion
        #endregion

        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult SendMessage(Message msg)
        {
            string message = "";
            string txMsg = "Theo thông tin lũ khẩn cấp của Đài khí tượng thủy văn tỉnh Quảng Ngãi cho biết vào lúc 16h ngày 28/10, mực nước trên các con sông Trà Bồng tại trạm Châu Ổ vượt trên báo động 2; nước sông Vệ và sông Trà Câu trên báo động 3; sông Trà Khúc ở dưới mức báo động 3 ở trạm Sơn Giang;";

            OpenSerialPort();
            message = SendMessageViaSerialPort(msg);
            SaveMessageToDatabase(msg);

            ViewBag.Message = message;
            return View();
        }
        #endregion

        #region SelectClient

        [HttpGet]
        public ActionResult SelectClient()
        {
            StationModel stationModel = new StationModel();

            using (AccountEntities1 dc = new AccountEntities1())
            {
                stationModel.ListStation = dc.Stations.ToList<Station>();
            }
            return View(stationModel);
        }

        [HttpPost]
        public ActionResult SelectClient(FormCollection formCollection)
        {
            string message = "";

            if (formCollection.Count < 2)
            {
                message = "Something Wrong !";
                ViewBag.Message = message;
                return RedirectToAction("SelectClient");
            }
            else
            {
                selectedStation = formCollection["StationId"].Split(new char[] { ',' });
                return RedirectToAction("SendMessage");
            }
        }

        #endregion

        #region RegisterClient
        [HttpGet]
        public ActionResult RegisterStation()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult RegisterStation(Station station)
        {
            string message = "";

            using (AccountEntities1 dc = new AccountEntities1())
            {
                var v = dc.Stations.Where(a => a.TargetStation == station.TargetStation).FirstOrDefault();
                if (v == null)
                {
                    dc.Stations.Add(station);
                    dc.SaveChanges();
                    message = "Registered this Station already !";
                }
                else
                {
                    message = "Already exist this Stations !";
                }
            }
            ViewBag.Message = message;
            return View();
        }
        #endregion
    }
}