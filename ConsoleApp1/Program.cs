using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 12341234;

            string b = a.ToString();
            int c = int.Parse(b.Substring(0, 4));
            float d = Convert.ToSingle(c);

            //Console.WriteLine("a's type is "+ a.GetType() +"//   b's type is " + b.GetType() +
            //    " //      and c's type is "+c.GetType() + "//     and d's type is " + d.GetType());


            int i = 123;
            object obj1 = i;
            object obj2 = "안녕하세요.";
            object obj3 = null;
            
            Console.WriteLine(obj1.GetType()+" and "+obj2.GetType() + " and  "+obj3);
            
        }
    }
}
