using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_MVC.ViewModels.Account
{
    public class RegisterViewModel
    {
        //[Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        //[Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
       
        //[Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required]
        //[Compare("Password", ErrorMessage = "Password doesn`t confirm")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
