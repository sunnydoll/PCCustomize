using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCCustomize.Models
{
    public class Computer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 99999)]
        public double Price { get; set; }
        public string MotherBoard { get; set; }
        public string CPU { get; set; }
        public string Ram { get; set; }
        public string GraphicCard { get; set; }
        public string Disk { get; set; }
        public string Monitor { get; set; }
        public string DVDdrive { get; set; }
        public string Mouse { get; set; }
        public string KeyBoard { get; set; }
        public int IsDel { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}