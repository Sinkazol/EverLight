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
                Console.WriteLine("Szürési lehetőségek: ");
                Console.WriteLine("Irányítószám: Ha az irányítószámot adod meg, akkor az adott településről érkezett hibák listáját fogod megkapni.");
                Console.WriteLine("Kerület: Ha viszont 106-ot adsz meg lekérdezésként, akkor az összes VI. kerületi hiba megjelenik: 1061, 1062, 1063...");
                Console.WriteLine("100 napon belüli keresés: Ha 100 alatti értéket írsz, akkor azoknak a feladatoknak listáját kapod, amik az adott értéknél régebben kerültek be az adatbázisba. (Pl.a 66 beírása esetén a mai dátumhoz képest 67, 68, 69... nappal korábban érkezett hibák listája jelenik meg.)");
                Console.WriteLine("");
                Console.Write("Szürés:  ");
                int postCode;
                while (!int.TryParse((input = Console.ReadLine()), out postCode) || (postCode > 123 && postCode < 1000) || postCode < 0)
                {
                    if (input == "x") { return; }
                    DrawHeader(Date);
                    PrintAllOpenedOrders(businessLogic);
                    Console.WriteLine("Rossz formátum kérem adjon meg egy másikat");
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
            Console.SetCursorPosition(100, 3);
            Console.Write($"{Date.ToString("yyyy/MM/dd")}");
            Console.WriteLine("");

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("   +--------------+-----------------+---------+-----------------------------------------+");
            Console.WriteLine("   |   Munkalap   |       Dátum     | Ir szám |            Cím                          |");
            Console.WriteLine("   +--------------+-----------------+---------+-----------------------------------------+");
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