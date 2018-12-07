using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP.ExportModels
{
    public interface IExportMmethods
    {
        void ExportCSV();
        void ExportExcel();
        void ExportPNG();
        void ExportSGV();
        void ExportPDF(DataTable data, string fileName);
    }
}
