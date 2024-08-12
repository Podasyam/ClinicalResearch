using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Shipping.PageElements
{
   public class LoginPage
    {
        public void Cal()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4 };
            foreach (int num in numbers)

            {



            }

            int[] arr_array =  {1,2,3,4 };

            for (int i = 0; i < arr_array.Length; i++)

            {

                Console.WriteLine(arr_array[i]);

            }

        public IWebElement TxtUserName
        { get { return _driver.FindElement(By.XPath("//p[contains(text(),'TextBox :')]/descendant::input[@id='fname']")); }}

        }

    }
}
