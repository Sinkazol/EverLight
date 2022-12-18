using EverLight.DC;
using EverLight.Repositories;
using EverLight.BusinessLayer;
using EverLight.DTOs;
using EverLight.ConsoleModul1;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace EverLight.ConsoleModul2
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
            string input = "";
            string selectedError;
            List<string> errorTypes = new()
                {
                   "Izzó csere",
                   "Trafo és gyújtó csere",
                   "Bura csere",
                   "Egyéb"
                };

            int EmployeeId;
            Console.Write("Kérem adja meg a dolgozói azonosító számát: ");
            while (!int.TryParse((input = Console.ReadLine()), out EmployeeId) || IsValidId(businessLogic, EmployeeId) == false)
            {
                Console.WriteLine("nincs ilyen azonosító");
                Console.Write("Kérem adja meg az azonosító számát: ");
            }
            while (true)
            {
                EverLight.ConsoleModul1.Program.DrawHeader(Date);
                EverLight.ConsoleModul1.Program.PrintAllOpenedOrders(businessLogic);

                Console.WriteLine("");
                Console.WriteLine("Kérem adja meg a lezárandó munkalap számot :");
                int OrderId;
                while (!int.TryParse((input = Console.ReadLine()), out OrderId) || OrderId <= 0)
                {
                    if (input == "x") { return; }

                    Console.WriteLine("Rossz formátum, kérem adjon meg másikat");
                }
                EverLight.ConsoleModul1.Program.DrawHeader(Date);
                PrintSortedOrder(businessLogic, OrderId);


                Console.WriteLine(" \n \n \n Kérem adja meg a hiba jellegét: \n");
                PrintErrorType(errorTypes);
                int Error;
                while (!int.TryParse((input = Console.ReadLine()), out Error) || Error > errorTypes.Count + 1 || Error <= 0)
                {
                    if (input == "x") { return; }

                    Console.WriteLine("Rossz formátum, kérem adjon meg másikat");
                }
                selectedError = errorTypes[Error - 1];
                Console.WriteLine(selectedError);
                businessLogic.CompletOrder(OrderId, EmployeeId, selectedError);
                Console.WriteLine($"A {OrderId} számú munkalap lezárva ");
                Console.WriteLine("Akar másik munkalapot lezárni? Enter=Igen n=Nem");
                if (Console.ReadKey().KeyChar == 'n')
                {
                    return;
                }
            }

        }
        public static void PrintSortedOrder(BusinessLogic businessLogic, int id)
        {
            foreach (var order in businessLogic.GetOrdersbyID(id))
            {
                Console.WriteLine($"   |     {order.Id}     |  {order.Opened.ToString("yyyy/MM/dd")}   |  {order.PostCode}   {order.City}, {order.Address}                ");
            }
        }

        public static void PrintErrorType(List<string> errorTypes)
        {
            for (int i = 0; i < errorTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. - {errorTypes[i]}");
            }
        }

        public static bool IsValidId(BusinessLogic businessLogic, int Id)
        {
            foreach (var employee in businessLogic.GetAllEmployes())
            {
                if (employee.Id == Id) return true;
            }
            return false;
        }



    }
}