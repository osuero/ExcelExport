using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP.Data.Models
{
    public class Range
    {
        [Key]
        public int ID { get; set; }
        public int RangeID { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public string ColorCode { get; set; }
        public string LiteralText { get; set; }
    }
}
