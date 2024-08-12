using ExcelDataReader;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Utilities
{
    public class ExcelTestData
    {

        //public DataTable ExcelToDatable(string fileName)
        //{
        //    // open file and returns as stream

        //    FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
        //    // create openXmlReader via ExcelReaderFactory
        //    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        //    //Set the first row as column name
        //    var result1 = excelReader.AsDataSet(new ExcelDataSetConfiguration()
        //    {
        //        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
        //        {
        //            UseHeaderRow = true
        //        }
        //    });

        //    // Return as dataset
        //    DataSet result = excelReader.AsDataSet();
        //    // Get all tables
        //    DataTableCollection table = result.Tables;
        //    // Store in Database
        //    DataTable resultTable = table["Sheet1"];
        //}

        //List<DataCollection> dataCol = new List<DataCollection>();
        //public void PopulateInCollection(string fileName)
        //{

        //    DataTable table = ExcelToDatable(fileName);
        //    for (int row = 1; row <= table.Rows.Count; row++)
        //    {

        //        for (int col = 0; col < table.Columns.Count; col++)
        //        {

        //            DataCollection dtTable = new DataCollection()
        //            {



        //                rowNumber = row,
        //                colName = table.Columns[col].ColumnName,
        //                colValue = table.Rows[row - 1][col].ToString()
        //            };
        //            dataCol.Add(dtTable);

        //        }
        //    }
        //}

        //public string ReadData(int rowNumber, string columnName)
        //{
        //    try
        //    {
        //        // Retriving data using LINQ to reduce much of iterations
        //        string data = (from colData in dataCol where colData.colName == columnName && colData.rowNumber == rowNumber
        //                       select colData.colValue).SingleOrDefault();
        //        return data.ToString();
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message;
        //    }
        //}



        //}

        //    internal class DataCollection
        //    {
        //        public int rowNumber { get; internal set; }
        //        public string colName { get; internal set; }
        //        public string colValue { get; internal set; }
        //    }



        //public string ExcelDataReader()
        //{

        //    // Path to your Excel file
        //    string filePath = "path_to_your_excel_file.xlsx";

        //    // Open the file stream
        //    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        //    {
        //        // Create a reader using the ExcelDataReader
        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {
        //            // Iterate through all sheets
        //            do
        //            {
        //                // Iterate through all rows
        //                while (reader.Read())
        //                {
        //                    // Iterate through all columns in a row
        //                    for (int columnIndex = 0; columnIndex < reader.FieldCount; columnIndex++)
        //                    {
        //                        // Get the value of the cell as a string
        //                        string cellValue = reader.GetValue(columnIndex)?.ToString();

        //                        // Print the cell value to the console
        //                        Console.Write($"{cellValue} \t");


        //                    }
        //                    Console.WriteLine();


        //                }


        //            } while (reader.NextResult()); // Move to the next sheet
        //        }
        //    }


        //}
        public string GetCellValue()
        {
            string filePath = "path_to_your_excel_file.xlsx";
            string cellValue = GetCellValue(filePath, 1, 0);

            return cellValue;
        }

        public static string GetCellValue(string filePath, int rowIndex, int columnIndex)
        {
            // Open the file stream
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Create a reader using the ExcelDataReader
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    int currentRow = 0;

                    // Iterate through the rows until the desired row is found
                    while (reader.Read())
                    {
                        if (currentRow == rowIndex)
                        {
                            // Return the value of the cell as a string
                            return reader.GetValue(columnIndex)?.ToString();
                        }
                        currentRow++;
                    }
                }
            }

            // Return null or an appropriate default value if the cell is not found
            return null;
        }


    }






    }

