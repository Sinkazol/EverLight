﻿using EverLight.DC;
using EverLight.Repositories;
using EverLight.BusinessLayer;
using EverLight.DTOs;
using EverLight.ConsoleModul1;


namespace EverLight.ConsoleModul2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using DataContext DB = new();
            var repo = new Repository<Order>(DB);
            var empRepo = new Repository<Employee>(DB);
            var businessLogic = new BusinessLogic(repo, empRepo);
            DateTime Date = DateTime.Now;
            string input = "";
            string selectedError;
            List<string> errorTypes = new()
                {
                   "Izzó csere",
                   "Trafo és gyújtó csere",
                   "Bura Csere",
                   "Egyébb"
                };

            int EmployeeId;
            Console.Write("Kérem adja meg az azonosító számát: ");
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
                Console.WriteLine("Kérem adja meg a munkalap számot :");
                int OrderId;
                while (!int.TryParse((input = Console.ReadLine()), out OrderId) || OrderId <= 0)
                {
                    if (input == "x") { return; }

                    Console.WriteLine("Rossz formátum kérem adjon meg egy mésikat");
                }
                EverLight.ConsoleModul1.Program.DrawHeader(Date);
                PrintSortedOrder(businessLogic, OrderId);


                Console.WriteLine(" \n \n \n Kérem adja meg a hiba jellegét: \n");
                PrintErrorType(errorTypes);
                int Error;
                while (!int.TryParse((input = Console.ReadLine()), out Error) || Error > errorTypes.Count + 1 || Error <= 0)
                {
                    if (input == "x") { return; }

                    Console.WriteLine("Rossz formátum kérem adjon meg egy másikat");
                }
                selectedError = errorTypes[Error - 1];
                Console.WriteLine(selectedError);
                businessLogic.CompletOrder(OrderId, EmployeeId, selectedError);
                Console.WriteLine($"A {OrderId} számú munkalap lezárva ");
                Console.WriteLine("Akar másik munkalapot leyárni? n=Nem");
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