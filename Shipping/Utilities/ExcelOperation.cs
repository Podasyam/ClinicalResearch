
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Drawing;
using static MongoDB.Driver.WriteConcern;



namespace Shipping.Utilities
{
    public class ExcelOperation
    {

        public string ReadExcel(string filePath)
        {
            try
            {
                using (FileStream file = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(file);

                    ISheet sheet = workbook.GetSheetAt(1);

                    for (int i = 0; i < sheet.LastRowNum; i++)
                    {
                        for (int j = 0; j < sheet.GetRow(i).LastCellNum; j++)
                        {
                            string rowvalue = string.Empty;
                            if (sheet.GetRow(i) != null)
                            {
                                string celldata = sheet.GetRow(i).GetCell(j).StringCellValue;
                                rowvalue = celldata;
                                return rowvalue;
                            }

                            Serilog.Log.Information(rowvalue);

                        }
                    }


                }

            }
            catch (Exception ex)
            {

                Serilog.Log.Debug("", ex.Message);

            }

            throw new Exception("Please select a value");

        }

        public string ReadExcelData(string filePath)
        {
            try
            {   //open the excel
                using (FileStream file = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {

                    IWorkbook workbook = null;

                    // Determine the type of Excel file (.xls or .xlsx)
                    if (filePath.EndsWith(".xlsx"))
                    {
                        workbook = new XSSFWorkbook(file); // For .xlsx files
                    }
                    else if (filePath.EndsWith(".xls"))
                    {
                        workbook = new HSSFWorkbook(file); // For .xls files
                    }

                    if (workbook == null)
                    {
                        Console.WriteLine("Invalid file format.");
                        return null;
                    }

                    // Iterate through all sheets in the workbook
                    for (int i = 0; i < workbook.NumberOfSheets; i++)
                    {
                        // Get the sheet at the current index
                        ISheet sheet = workbook.GetSheetAt(i);
                        Console.WriteLine($"Reading sheet: {sheet.SheetName}");
                        Serilog.Log.Debug($"Reading sheet: {sheet.SheetName}");

                        // Iterate through rows and cells in the sheet
                        for (int row = 0; row <= sheet.LastRowNum; row++)
                        {
                            string rowvalue = string.Empty;
                            IRow currentRow = sheet.GetRow(row);

                            if (currentRow != null)
                            {
                                for (int col = 0; col < currentRow.LastCellNum; col++)
                                {
                                    ICell cell = currentRow.GetCell(col);
                                    if (cell != null)
                                    {
                                        // Print cell value based on its type
                                        switch (cell.CellType)
                                        {
                                            case CellType.String:
                                                string celldata = sheet.GetRow(row).GetCell(col).StringCellValue;
                                                //rowvalue = celldata;
                                                return celldata;
                                                //Console.Write(cell.StringCellValue + "\t");
                                                //break;
                                            case CellType.Numeric:
                                                Console.Write(cell.NumericCellValue + "\t");
                                                break;
                                            case CellType.Boolean:
                                                Console.Write(cell.BooleanCellValue + "\t");
                                                break;
                                            default:
                                                Console.Write("N/A\t");
                                                break;
                                        }
                                    }
                                }
                                
                            }

                            Serilog.Log.Information(rowvalue);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Serilog.Log.Debug("", ex.Message);

            }

            throw new Exception("Please select a value");

        }
    }
}


        



    

