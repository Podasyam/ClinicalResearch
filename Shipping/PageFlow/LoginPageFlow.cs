﻿using NUnit.Framework;
using OpenQA.Selenium;
using Shipping.PageElements;
using Shipping.Utilities;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using Shipping.CustomControls;

namespace Shipping.PageFlow
{
    public class LoginPageFlow
    {
        private IWebDriver _driver;
        string filePath = System.IO.Directory.GetParent(@"../../../").FullName
                        + Path.DirectorySeparatorChar + @"Data\" ;

        public LoginPageFlow(IWebDriver driver)// LoginPageFlowconstructor
        {

            _driver = driver;
                
        }
        public void SearchResults()//Enter username by Podasyam-patch-1
        {
            Base.ScrollWindow();

            ExcelOperation excelOperation = new ExcelOperation();
            string value = excelOperation.ReadExcelData(filePath + "TestData.xlsx");

            try
                {                    
                var loginpage = new LoginPage(_driver);              
                var action = new Actions(_driver);
                action.MoveToElement(loginpage.TxtSearch).Click().Build().Perform();
                CustomControl.EnterText(loginpage.TxtSearch, value);
                Serilog.Log.Debug("search keyword"+" "+value +" "+"has been entered in search textbox");
                CustomControl.Click(loginpage.BtnSearch);
                CustomControl.LableMessage(loginpage.LblSearchResult, "Search results for:");
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        //public async void EnterUserName()
        //{
        //   ScrollWindow();

        //  await Task.Run(() =>
        //    {
        //        try
        //        {
        //            ExcelOperation excelOperation = new ExcelOperation();
        //            excelOperation.ReadExcel(filePath + "TestData.xlsx");

        //            LoginPage loginpage = new LoginPage(driver);
        //            loginpage.txtUserName.SendKeys("AB");
        //        }
        //        catch (ElementNotVisibleException ex)
        //        {

        //            Console.WriteLine(ex.Message);

        //        }
        //    }
        //    );


        //}

    }

}

