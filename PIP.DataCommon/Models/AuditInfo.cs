using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIP.DataCommon.Models
{
    public class AuditInfo:IAudithInfo
    {
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Specifies whether or not the CreatedOn property should be automatically set.
        /// </summary>
        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
