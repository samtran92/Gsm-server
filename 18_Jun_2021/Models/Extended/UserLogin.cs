using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _18_Jun_2021.Models.Extended
{
    public partial class UserLogin
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field required")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}