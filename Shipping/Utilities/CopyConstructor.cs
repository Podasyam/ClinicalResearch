using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Utilities
{
    public class CopyConstructor
    {

        string ClassName;
        int Age;
        public CopyConstructor(string A, int B) 
        { ClassName = A; Age = B; }       

        public CopyConstructor(CopyConstructor ObjectName) 
        { ClassName = ObjectName.ClassName; Age = ObjectName.Age; }

        public void CreateCopyConstructor()
        {
            CopyConstructor oldObject = new CopyConstructor("syam",39);
            Console.WriteLine("OldObject ClassName" + oldObject.ClassName);

            CopyConstructor newObject = new CopyConstructor(oldObject);
            Console.WriteLine("new ClassName: " + newObject.ClassName);

        }


    }
}
