using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _18_Jun_2021.Models.Extended
{
    public partial class UserStation
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field required")]
        public string TargetStation { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field required")]
        public string StationInfo { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d).{8,15}$")]
        public string PhoneNum { get; set; }
    }
    public class StationModel
    {
        public List<Station> ListStation { get; set; }
    }

    public partial class UserMessage
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field required")]
        public string MessageTitle { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "This field required")]
        public string MessageContent { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field required")]
        public string ToStation { get; set; }
        public string PosterName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Count { get; set; }
    }
}