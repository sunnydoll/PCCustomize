using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCCustomize.Models
{
    public class ComputerListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime LastUpdate { get; set; }
        public int NumberOfTopics { get; set; }
    }
}