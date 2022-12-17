using EverLight.DC;
using EverLight.Repositories;
using EverLight.BusinessLayer;
using EverLight.DTOs;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace EverLight.ConsoleModul1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.UseBusinessLogic();
            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
            var businessLogic = Ioc.Default.GetService<BusinessLayer.BusinessLogic>();
            DateTime Date = DateTime.Now;
            DrawHeader(Date);
            PrintAllOpenedOrders(businessLogic);
            string input = "";

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Kérem adja meg a szürési feltételt:");
                int postCode;
                while (!int.TryParse((input = Console.ReadLine()), out postCode) || (postCode > 123 && postCode < 1000) || postCode < 0)
                {
                    if (input == "x") { return; }
                    DrawHeader(Date);
                    PrintAllOpenedOrders(businessLogic);
                    Console.WriteLine("Rossz formátum kérem adjon meg egy mésikat");
                }
                DrawHeader(Date);
                PrintSortedOrder(businessLogic, postCode);

            }
        }

        public static void DrawHeader(DateTime Date)
        {
            Console.Clear();
            Console.WriteLine("Quit: x");
            Console.SetCursorPosition(43, 1);
            Console.WriteLine("[   EVERLIGHT  ] ");
            Console.SetCursorPosition(42, 3);
            Console.WriteLine("--- Munkalapok ---");
            Console.SetCursorPosition(90, 3);
            Console.Write($"{Date.ToString("yyyy/MM/dd")}");
            Console.WriteLine("");

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("   +-------------+-----------------+---------+-----------------------------------------+");
            Console.WriteLine("   | MunkaLp sz. |       Dátum     | Ir szám |            Cím                          |");
            Console.WriteLine("   +-------------+-----------------+---------+-----------------------------------------+");
        }
        public static void PrintSortedOrder(BusinessLogic businessLogic, int postCode)
        {
            foreach (var order in businessLogic.GetByPostCode(postCode))
            {
                Console.WriteLine($"   |     {order.Id}     |  {order.Opened.ToString("yyyy/MM/dd")}   |  {order.PostCode}   |       {order.City}, {order.Address}                ");
            }
        }
        public static void PrintAllOpenedOrders(BusinessLogic businessLogic)
        {
            foreach (var order in businessLogic.GetOpened())
            {
                Console.WriteLine($"   |     {order.Id}     |  {order.Opened.ToString("yyyy/MM/dd")}   |  {order.PostCode}   |       {order.City},  {order.Address}                ");
            }
            Console.WriteLine("");
        }
    }
}