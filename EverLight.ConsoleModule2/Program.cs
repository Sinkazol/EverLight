using EverLight.DC;
using EverLight.Repositories;
using EverLight.BusinessLayer;
using EverLight.DTOs;

namespace EverLight.ConsoleModule2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using DataContext DB = new();
            var repo = new Repository<Order>(DB);
            var empRepo = new Repository<Employee>(DB);
            var businessLogic = new BusinessLogic(repo, empRepo);
           


            foreach (var order in businessLogic.GetOpened())
            {
                Console.WriteLine($"   |     {order.Id}     |  {order.Opened.ToString("yyyy/MM/dd")}   |  {order.PostCode}   |      {order.City}, {order.Address}                ");
            }
            Console.WriteLine("");

            Console.WriteLine("kérem adja meg a munkalapszámot");
            int OrderId = int.Parse(Console.ReadLine());
            Console.Clear();
            foreach (var order in businessLogic.GetOrdersbyID( OrderId))
            {
                Console.WriteLine($"   |     {order.Id}     |  {order.Opened.ToString("yyyy/MM/dd")}   |  {order.PostCode}   |      {order.City}, {order.Address}                ");
            }
            Console.WriteLine("");





        }
    }
}