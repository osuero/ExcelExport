using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP.Data.Models
{
    public class TableInformation
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string CategoryId { get; set; }
       
    }
}
