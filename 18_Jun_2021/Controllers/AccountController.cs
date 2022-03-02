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
using System.Threading;
using System.Web.Security;
using _18_Jun_2021.Models.Extended;
using System.IO;

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
                        int timeout = (acc.RememberMe == true) ? (60) : (5); //Timeout in Minutes
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
            posterName = "";
            FormsAuthentication.SignOut();
            return View("Login");
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
            Text = "COM4",
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
                GMSDevice.desPort = new SerialPort(drPorts.Text, 115200, Parity.None, 8, StopBits.One);
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
        protected string SendMessageInterProcess(string message, string PhoneNum)
        {
            string result;
            string cmdSend = (SymEncryptMethod(message)).Count() + "-" + SymEncryptMethod(message);
            //string test = "128-Test server chieu 11 thang 10";
            //SendSMS(test);
            result = SendSMS(cmdSend, PhoneNum);

            return (result);
        }
        protected string SendMessageViaSerialPort(string message)
        {
            string result = "";
            int count = 0;

            switch (GMSDevice.desPortState)
            {
                case desPortState_en.OPEN:
                    result = "Chua ket noi voi thiet bi";
                    break;
                case desPortState_en.CONNECT:
                case desPortState_en.ALCONNECTED:
                    foreach (string station in selectedStation)
                    {
                        using (AccountEntities1 dc = new AccountEntities1())
                        {
                            var v = dc.Stations.Where(a => a.TargetStation == station).FirstOrDefault();
                            if (v != null)
                            {
                                result = SendMessageInterProcess(message, v.PhoneNum);
                            }
                        }
                        count++;
                    }
                    break;
                default:
                    break;
            }
            return (result + count.ToString());
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
        public ActionResult SendMessage(Message msg, HttpPostedFileBase fileUpLoad)
        {
            string result;
            string message = ParseWordFile(fileUpLoad);
            OpenSerialPort();
            result = SendMessageViaSerialPort(message);
            SaveMessageToDatabase(msg);

            ViewBag.Message = result;
            return View();
        }
        public string SendSMS(string smstosend, string PhoneNum)
        {
            string result = "NG";
            try
            {
                //serialPort.Open();
                GMSDevice.desPort.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(100);
                GMSDevice.desPort.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                GMSDevice.desPort.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                Thread.Sleep(100);
                //Send sms from textbox
                //serialPort.WriteLine("AT+CMGS=\"" + textBox1.Text + "\""+ Environment.NewLine);
                //GMSDevice.desPort.WriteLine("AT+CMGS=\"" + "+84977413768" + "\"" + Environment.NewLine);
                //GMSDevice.desPort.WriteLine("AT+CMGS=\"" + "+84764316794" + "\"" + Environment.NewLine);      //Số đăng ký gởi nhiều tin nhắn
                GMSDevice.desPort.WriteLine("AT+CMGS=\"" + "+" + PhoneNum + "\"" + Environment.NewLine);        //Sim Mobile nhận
                Thread.Sleep(100);

                GMSDevice.desPort.WriteLine(smstosend + Environment.NewLine);
                Thread.Sleep(100);

                GMSDevice.desPort.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);

                var response = GMSDevice.desPort.ReadExisting();
                if (response.Contains("ERROR"))
                    ;
                //MessageBox.Show("Send faill!", "Messeage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    ;
                //MessageBox.Show("SMS Send", "Messeage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GMSDevice.desPort.Close();
                result = "OK";
            }
            catch (Exception ex)
            {
                ;
                //MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        // Import file
        protected string ParseWordFile(HttpPostedFileBase fileUpLoad)
        {
            string message = "";
            Microsoft.Office.Interop.Word.Application AC = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;

            //foreach (var file in files)
            {
                if ( (fileUpLoad != null) && (fileUpLoad.ContentLength > 0) )
                {
                    var fileName = Path.GetFileName(fileUpLoad.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Files"), fileName);

                    object fileObject = filePath;
                    fileUpLoad.SaveAs(filePath);
                    try
                    {
                        doc = AC.Documents.Open(ref fileObject, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref isVisible, ref missing, ref missing, ref missing);
                        message = doc.Content.Text;
                        AC.Quit(false); /* Close Word file */
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return message;
        }
        #endregion

        #region SelectClient

        [HttpGet]
        [Authorize]
        public ActionResult SelectClient()
        {
            AccountEntities1 entities = new AccountEntities1();
            List<Station> stationModels = entities.Stations.OrderBy(a => a.TargetStation).ToList();
            return View(stationModels.ToList());
        }

        [HttpPost]
        [Authorize]
        public ActionResult SelectClient(string[] ids)
        {
            string message = "";

            if (ids == null)
            {
                message = "Something Wrong !";
                ViewBag.Message = message;
                return RedirectToAction("SelectClient");
            }
            else
            {
                selectedStation = ids;
                return RedirectToAction("SendMessage");
            }
        }

        #endregion

        #region RegisterClient
        [HttpGet]
        [Authorize]
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

        #region Edit Client's information
        [HttpGet]
        [Authorize]
        public ActionResult EditStation(int id)
        {
            AccountEntities1 dc = new AccountEntities1();
            var model = dc.Stations.Find(id);

            UserStation userStation = new UserStation();
            userStation.Id = model.Id;
            userStation.TargetStation = model.TargetStation;
            userStation.PhoneNum = model.PhoneNum;
            userStation.StationInfo = model.StationInfo;

            return View("EditStation", userStation);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditStation(UserStation userStation)
        {
            Station station = new Station();
            station.Id = userStation.Id;
            station.TargetStation = userStation.TargetStation;
            station.PhoneNum = userStation.PhoneNum;
            station.StationInfo = userStation.StationInfo;

            AccountEntities1 dc = new AccountEntities1();
            dc.Entry(station).State = System.Data.Entity.EntityState.Modified;
            try
            {
                dc.SaveChanges();
            }
            catch(Exception)
            {
                /* Input data is wrong > can not save to database */
            }

            return RedirectToAction("SelectClient");
        }
        #endregion

        #region Delete Client's information
        [Authorize]
        public ActionResult Delete(int id)
        {
            AccountEntities1 dc = new AccountEntities1();
            var model = dc.Stations.Find(id);
            dc.Stations.Remove(model);
            dc.SaveChanges();

            return RedirectToAction("SelectClient");
        }
        #endregion
    }
}