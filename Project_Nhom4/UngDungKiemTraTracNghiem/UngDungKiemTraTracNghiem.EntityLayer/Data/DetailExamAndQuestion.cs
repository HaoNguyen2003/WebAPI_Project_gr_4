using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungKiemTraTracNghiem.EntityLayer.Data
{
    [Table("DetailExamAndQuestion")]
    public class DetailExamAndQuestion
    {
        public int ExamID { get; set; }
        public Exam Exam { get; set; }
        public int QuestionID  { get; set; }
        public Question Question { get; set; }
    }
}
