using OfficeOpenXml;
using PIP.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;

namespace PIP.Controllers
{
    public class IndicatorsController : Controller
    {
        // GET: Indicators
        public ActionResult Index()
        {
            return PartialView("_Index");
        }

        public PartialViewResult Selection()
        {
            return PartialView("_Selection");
        }

        public PartialViewResult Display()
        {
            return PartialView("_Display");
        }

        public PartialViewResult Table()
        {
            return PartialView("_Table");
        }

        public PartialViewResult MetaData()
        {
            return PartialView("_MetaData");
        }

        public PartialViewResult Map()
        {
            return PartialView("_Mapael");
        }

        public JsonResult Load(Indicator options)
        {
            var rows    = new List<dynamic>();
            var columns = new List<dynamic>();

            FileInfo filePath = new FileInfo(Server.MapPath("~/App_Data/pnip.indicador-" + options.IndicatorId + ".xlsx"));

            if (System.IO.File.Exists(filePath.ToString()))
            {
                using (ExcelPackage excel = new ExcelPackage(filePath))
                {
                    rows    = GenerateRows(excel, options);
                    columns = GenerateColumns(rows);

                    return Json(new
                    {
                        rows    = rows,
                        columns = columns,
                        map     = MapData(excel, options),
                        legend  = MapLegend(excel, options),
                        metaDato = MetaData(excel, options),
                        source = Source(excel, options)
                    },
                    JsonRequestBehavior.AllowGet);
                }
            }

            return Json(String.Empty, JsonRequestBehavior.AllowGet);
        }

        private List<dynamic> GenerateRows(ExcelPackage excel, Indicator options)
        {
            List<dynamic> rows = new List<dynamic>();
            List<string> cells = new List<string>();

            var workSheets  = excel.Workbook.Worksheets;
            var sheet       = workSheets[2];
            var noOfCol     = sheet.Dimension.End.Column;
            var noOfRow     = sheet.Dimension.End.Row;
            var firstRow    = 20;
            var firstCol    = 2;

            bool hasYear    = !String.IsNullOrEmpty(options.Year);
            int year        = (hasYear) ? sheet.Cells[20, 3, 20, noOfCol].First(c => c.Value.ToString() == options.Year).Start.Column : 0;

            try
            {
                for (int row = firstRow; row <= noOfRow; row++)
                {
                    cells.Clear();

                    for (int col = firstCol; col <= noOfCol; col++)
                    {
                        if (hasYear)
                        {
                            if (col == firstCol || col == year)
                            {
                                if (row == firstRow)
                                {
                                    cells.Add(sheet.Cells[row, col].Value.ToString());
                                }
                                else
                                {
                                    cells.Add(FormatCell(sheet.Cells[row, col].Value.ToString()));
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (row == firstRow)
                            {
                                cells.Add(sheet.Cells[row, col].Value.ToString());
                            }
                            else
                            {
                                cells.Add(FormatCell(sheet.Cells[row, col].Value.ToString()));
                            }

                        }
                    }

                    rows.Add(cells.ToList());
                }

                return rows.ToList<dynamic>();
            }
            catch (ArgumentOutOfRangeException)
            {
                return new List<dynamic>() { new { } };
            }
        }

        private List<dynamic> GenerateColumns(List<dynamic> rows)
        {
            try
            {
                var firstRow = rows[0];
                var columns = new List<dynamic>();

                foreach (var cell in firstRow)
                {
                    columns.Add(new { title = cell });
                }

                rows.RemoveAt(0);

                return columns;
            }
            catch (ArgumentOutOfRangeException)
            {
                return new List<dynamic>() { new { } };
            }
        }

        private Dictionary<string, object> MapData(ExcelPackage excel, Indicator options)
        {

            var workBook    = excel.Workbook;
            var workSheet   = workBook.Worksheets[2];
            var noOfCol     = workSheet.Dimension.End.Column;
            var noOfRow     = workSheet.Dimension.End.Row;
            var firstRow    = 20;
            var firstCol    = 3;

            var hasYear     = !String.IsNullOrEmpty(options.Year);
            int year        = (hasYear) ? workSheet.Cells[20, 3, 20, noOfCol].First(c => c.Value.ToString() == options.Year).Start.Column : 0;

            var headers     = workSheet.Cells[20, 3, 20, noOfCol].Select(h => h.Value).ToList();
            var dimensions  = workSheet.Cells[20, 2, noOfRow, 2].ToList();

            int index       = 1;

            var series      = new Dictionary<string, object>();
            var regions     = new OrderedDictionary();

            try
            {

                for (int col = firstCol; col <= noOfCol; col++)
                {
                    for (int row = firstRow; row < noOfRow; row++)
                    {
                        if (!headers.Contains(workSheet.Cells[row, col].Value))
                        {
                            regions[dimensions[index].Value] = new
                            {
                                text    = new { content = dimensions[index].Value + "\n" + FormatCell(workSheet.Cells[row, col].Value.ToString()), position = "inner" },
                                value   = FormatCell(workSheet.Cells[row, col].Value.ToString()),
                                
                            };

                            index++;
                        }
                    }

                    series.Add(workSheet.Cells[firstRow, col].Value.ToString(), new { areas = MapAreas(regions) });

                    regions.Clear();
                    index = 1;
                }

                return series;
            }
            catch (ArgumentOutOfRangeException)
            {
                return new Dictionary<string, object>();
            }
        }


        private Dictionary<string, object> MapLegend(ExcelPackage excel, Indicator options)
        {

            var workBook    = excel.Workbook;
            var workSheet   = workBook.Worksheets[2];
            var noOfCol     = workSheet.Dimension.End.Column;
            var firstRow    = 6;
            var firstCol    = 2;
            var area        = new Dictionary<string, object>();
            var slices      = new List<object>();
            var slice       = new OrderedDictionary();

            try
            {

                for (int col = firstCol; col <= noOfCol; col++)
                {
                    slice.Clear();

                    var min     = workSheet.Cells[firstRow, col].Value;
                    var max     = workSheet.Cells[firstRow + 1, col].Value;
                    var attrs   = workSheet.Cells[firstRow + 2, col].Value;
                    var label   = workSheet.Cells[firstRow + 3, col].Value;

                    if (min != null)
                    {
                        slice.Add("min", min);
                    }

                    if (max != null)
                    {
                        slice.Add("max", max);
                    }

                    if (attrs != null)
                    {
                        slice.Add("attrs", new { fill = attrs });
                    }

                    if (label != null)
                    {
                        slice.Add("label", label);
                    }

                    slices.Add(slice.Cast<DictionaryEntry>().ToDictionary(entry => entry.Key, entry => entry.Value));
                }

                area.Add("area", new
                {
                    display = false,
                    title = "Leyenda",
                    marginBottom = 7,
                    slices = slices
                });

                return area;
            }
            catch (ArgumentOutOfRangeException)
            {
                return new Dictionary<string, object>();
            }
        }


        private List<dynamic> MapTimeline(List<dynamic> columns)
        {

            //var timeline = new Dictionary<string, string>();

            if (columns.Count() > 0)
            {

                columns.RemoveAt(0);

                //foreach (var column in columns)
                //{
                //    timeline.Add((string)column.Value, (string)column.Value);
                //}

                return columns;
            }
            else
            {
                return new List<dynamic>();
            }
        }


        private string FormatCell(string cell)
        {

            bool isPercent = cell.Contains("%"),
                 isNumeric = cell.All(c => char.IsDigit(c) || c == '.');

            cell = (isPercent) ? cell.Replace("%", "") : cell;

            if (isNumeric)
            {
                return Double.Parse(cell).ToString("F1");
            }

            return cell;
        }

        private Double FormatCellValue(string cell)
        {

            bool isPercent = cell.Contains("%"),
                 isNumeric = cell.All(c => char.IsDigit(c) || c == '.');

            cell = (isPercent) ? cell.Replace("%", "") : cell;

            if (isNumeric)
            {
                return Math.Round(Double.Parse(cell), 2, MidpointRounding.AwayFromZero);
            }

            return Double.Parse(cell);
        }



        private OrderedDictionary MapAreas(OrderedDictionary regions)
        {
            OrderedDictionary areas = new OrderedDictionary();

            foreach (DictionaryEntry re in regions)
            {
                areas.Add(re.Key, re.Value);
            }

            return areas;
        }
        private OrderedDictionary MetaData(ExcelPackage excel, Indicator options)
        {
            var workBook    = excel.Workbook;
            var workSheet   = workBook.Worksheets[3];
            var noOfCol     = workSheet.Dimension.End.Column;
            var noOfRow     = workSheet.Dimension.End.Row;
            var firstRow    = 1;
            var firstCol    = 2;
            var dimensions  = workSheet.Cells[1, 1, noOfRow, 1].ToList();
            int index       = 0;

            var regions     = new OrderedDictionary();

            try
            {
                for (int row = firstRow; row <= noOfRow; row++)
                {
                    regions[dimensions[index].Value] = new
                    {
                        text = new { content = workSheet.Cells[row, firstCol].Value.ToString() }
                    };

                    index++;
                }
                return regions;
            }
            catch (ArgumentOutOfRangeException)
            {
                return new OrderedDictionary();
            }
        }

        private OrderedDictionary Source(ExcelPackage excel, Indicator options)
        {
            var workBook    = excel.Workbook;
            var workSheet   = workBook.Worksheets[1];
            var noOfCol     = workSheet.Dimension.End.Column;
            var noOfRow     = workSheet.Dimension.End.Row;
            var firstRow    = 1;
            var firstCol    = 2;
            var properties  = workSheet.Cells[1, 1, noOfRow, 1].ToList();
            int index       = 0;

            var dataset     = new OrderedDictionary();

            try
            {
                for (int row = firstRow; row <= noOfRow; row++)
                {
                    if (properties[index].Value != null)
                    {
                        dataset[properties[index].Value] = new
                        {
                            text = new { content = workSheet.Cells[row, firstCol].Value.ToString() }
                        };

                        index++;
                    }
                    else
                    {
                        continue;
                    }
                }
                return dataset;
            }
            catch (ArgumentOutOfRangeException)
            {
                return new OrderedDictionary();
            }
        }


    }
}