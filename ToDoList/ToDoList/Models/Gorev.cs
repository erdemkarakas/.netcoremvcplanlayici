using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Gorev
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]

        public int id { get; set; }
        public string konu { get; set; }
        public string aciklama { get; set; }
        public string oncelik { get; set; }
        public string tur { get; set; }
        public DateTime eklenmeTarihi { get; set; }
        public DateTime bitisTarihi { get; set; }


    }
}
