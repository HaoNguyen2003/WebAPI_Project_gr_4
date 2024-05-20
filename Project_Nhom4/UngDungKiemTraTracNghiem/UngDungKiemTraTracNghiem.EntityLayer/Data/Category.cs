using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungKiemTraTracNghiem.EntityLayer.Data
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string CategoryName { get; set; } = null!;

        public ICollection<Exam>Exams { get; set; }
    }
}
