
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Drawing;



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

                Serilog.Log.Debug("",ex.Message);
            
            }

            throw new Exception("Please select a value");

        }
    }
}


    

