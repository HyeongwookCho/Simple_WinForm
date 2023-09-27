using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Toast { }
    class Juice { }
    class Bacon { }
    class Egg { }
    class Coffee { }

    class Program
    {
        
        static async Task Main(string[] args)
        {
            // 이것이 비동기 처리다!

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Task.Delay(2000).Wait();

            Coffee cup = PourCoffee();            
            Console.WriteLine("coffee is ready \n");            


            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);

                if(finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon are ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast are ready");
                }
                breakfastTasks.Remove(finishedTask);
            }                 

            Console.WriteLine();
            Juice oj = PourOJ();          

            Console.WriteLine("OrangeJuice is ready");            
            Console.WriteLine("Breakfast is ready! Enjoy your meal! \n");
            stopwatch.Stop();

            TimeSpan timeSpan = stopwatch.Elapsed;
            Console.WriteLine($"걸린 시간 : {timeSpan}");
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring Coffee...");
            Console.WriteLine();
            return new Coffee();
        }

        private static async Task<Egg> FryEggsAsync(int howmanyEgg)
        {
            Console.WriteLine("Warming the pan for frying Egg...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howmanyEgg} eggs...");
            Console.WriteLine("cooking the eggs...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");
            Console.WriteLine();
            return new Egg();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int i = 1; i <= slices; i++)
            {
                Console.WriteLine($"flipping {i} bacon");
                await Task.Delay(1500);
            }
            Console.WriteLine("cooking the other side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");
            Console.WriteLine();
            return new Bacon();
        }

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for(int i = 1; i <= slices; i++)
            {
                Console.WriteLine($"Putting {i} bread in the toaster");
                await Task.Delay(1500);
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");
            Console.WriteLine();
            return new Toast();
        }

        private static async Task ApplyButter(Toast toast)
        {
            Console.WriteLine("Putting butter on the toast");
            Console.WriteLine();
        }

        private static async Task ApplyJam(Toast toast)
        {
            Console.WriteLine("Putting Jam on the toast");
            Console.WriteLine();
        }
        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }
        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            Console.WriteLine();
            return new Juice();
        }

    }
}
