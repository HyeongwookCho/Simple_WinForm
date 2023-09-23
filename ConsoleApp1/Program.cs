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

            string dir = @"C:\Users\조형욱\source\repos\Solution1\WindowsFormsApp1\bin\Export";

            // 디렉토리 일자별 구분을 위한 현재 연월일 파싱

            DateTime currentDateTime = DateTime.Now;

            string year = currentDateTime.Year.ToString();
            string month = currentDateTime.Month.ToString();
            string day = currentDateTime.Day.ToString();
            string hour = currentDateTime.Hour.ToString();
            string minute= currentDateTime.Minute.ToString();
            string second = currentDateTime.Second.ToString();

            string dir_year = @"C:\Users\조형욱\source\repos\Solution1\WindowsFormsApp1\bin\Export\" + year;
            Console.WriteLine(dir_year);

            Console.WriteLine(dir);
            Console.WriteLine(currentDateTime);
            Console.WriteLine(year);
            Console.WriteLine(month);
            Console.WriteLine(day);
            Console.WriteLine(hour);
            Console.WriteLine(minute);
            Console.WriteLine(second);




            /*string dir = @"C:\test";
            if (Exists(dir))
            {
                Console.WriteLine("해당 폴더 존재");
                Delete(dir);
                DateTime currentDateTime = DateTime.Now;
                Console.WriteLine(currentDateTime.ToString());
                Console.WriteLine("폴더 삭제");
            }
            else
            {
                Console.WriteLine("해당 폴더 없음");
                CreateDirectory(dir);
                Console.WriteLine("폴더 생성");
            }*/
        }
    }
}
