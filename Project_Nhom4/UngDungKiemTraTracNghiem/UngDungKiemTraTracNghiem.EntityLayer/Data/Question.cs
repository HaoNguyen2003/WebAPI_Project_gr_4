using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungKiemTraTracNghiem.EntityLayer.Data
{
    [Table("Question")]
    public class Question
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string OptionA {  get; set; }
        [Required] 
        public string OptionB { get; set; }
        [Required] 
        public string OptionC { get; set; }
        [Required] 
        public string OptionD { get; set; }
        [Required]
        public string Answer { get; set; }
        public ICollection<DetailExamAndQuestion> DetailExamAndQuestions { get; set; }

    }
}
