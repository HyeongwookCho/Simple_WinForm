using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.IO.Directory;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyAsyncFunc();
            Console.WriteLine("End Main");
            Console.Read();

        }
        public static async Task MyAsyncFunc()
        {
            await Task.Delay(5000);
            Console.WriteLine("End MyAsyncFunc");
        }



    }
}
