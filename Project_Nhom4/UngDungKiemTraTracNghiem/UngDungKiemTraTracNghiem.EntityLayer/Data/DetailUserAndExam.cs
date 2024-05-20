using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungKiemTraTracNghiem.EntityLayer.Data
{
    [Table("DetailUserAndExam")]
    public class DetailUserAndExam
    {
        public string UserID {  get; set; }
        public User User { get; set; }
        public int ExamID {  get; set; }
        public Exam Exam { get; set; }

    }
}
