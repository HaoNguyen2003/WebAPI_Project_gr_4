using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungKiemTraTracNghiem.DtoLayer.AddUser
{
    public class SignIn
    {
        [Required(ErrorMessage = "Please Input Email"), EmailAddress]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Please Input PassWord")]
        public string Password { get; set; } = null!;
    }
}
