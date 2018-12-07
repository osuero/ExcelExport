using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP.Data.Models
{
    public class RegionData
    {
        [Key]
        public int ID { get; set; }
        public string Year { get; set; }
        public decimal Metropolitana { get; set; }
        public decimal CibaoNorte { get; set; }
        public decimal CibaoSur { get; set; }
        public decimal CibaoNordeste { get; set; }
        public decimal CibaoNoroeste { get; set; }
        public decimal Valdesia { get; set; }
        public decimal Enriquillo { get; set; }
        public decimal DelValle { get; set; }
        public decimal Yuma { get; set; }
        public decimal Higuamo { get; set; }
        public decimal Total { get; set; }

    }
}
