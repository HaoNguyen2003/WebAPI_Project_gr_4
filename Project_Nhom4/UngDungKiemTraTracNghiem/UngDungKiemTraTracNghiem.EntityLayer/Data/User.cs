using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungKiemTraTracNghiem.EntityLayer.Data
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; }=null!;
        public string Avatar { get; set; } = null!;
        public ICollection<DetailUserAndExam> DetailUserAndExams { get; set; }
    }
}
