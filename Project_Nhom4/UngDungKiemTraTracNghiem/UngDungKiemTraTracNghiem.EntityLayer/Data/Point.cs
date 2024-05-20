using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungKiemTraTracNghiem.EntityLayer.Data
{
    [Table("Point")]
    public class Point
    {
        [Key]
        public int ID {  get; set; }
        [Required]
        public int ExamID {  get; set; }
        [Required]
        public double point {  get; set; }


    }
}
