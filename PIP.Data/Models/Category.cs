using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP.Data.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
        public int SubCategory { get; set; }

    }
}
