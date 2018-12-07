using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP.Data.Models
{
    public class DataSheet
    {
        [Key]
        public int ID { get; set; }
        public string Indicator { get; set; }

        public string Functionality { get; set; }
        public string Relavance { get; set; }
        public string Feasibility { get; set; }

        public string Periodicity { get; set; }
        public string Metodología { get; set; }
        public string Note { get; set; }

    }
}
