using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungKiemTraTracNghiem.EntityLayer.Data
{
    [Table("Exam")]
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ExamName { get; set; }
        [Required]
        public DateTime TimeStart { get; set;}
        [Required]
        public DateTime TimeEnd { get; set; }
        [Required]
        public double point {  get; set; }
        [Required]
        public int CategoryID {  get; set; }
        public Category Category { get; set; }
        public ICollection<DetailUserAndExam>DetailUserAndExams { get; set; }
        public ICollection<DetailExamAndQuestion> DetailExamAndQuestions { get; set; }
    }
}
