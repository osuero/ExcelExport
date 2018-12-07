using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP.DataCommon.Models
{
    public interface IAudithInfo
    {
        DateTime CreatedOn { get; set; }

        bool PreserveCreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
