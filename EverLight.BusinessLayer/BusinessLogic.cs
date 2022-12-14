using EverLight.DTOs;
using EverLight.Repositories;

namespace EverLight.BusinessLayer
{
    public class BusinessLogic
    {
        private readonly Repository<Order> orderRepo;
        private readonly Repository<Employee> employeeRepo;


        //public BusinessLogic(Repository<Order> orderRepo)
        //{
        //    this.orderRepo = orderRepo;
        //}
        public BusinessLogic(Repository<Order> orderRepo, Repository<Employee> employeeRepo)
        {
            this.orderRepo = orderRepo;
            this.employeeRepo = employeeRepo;
        }
        public int CreateOrder(Order order)
        {
            return orderRepo.Create(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return orderRepo.GetAll();

        }
        public IEnumerable<Employee> GetAllEmployes()
        {
            return employeeRepo.GetAll();

        }
        public int CreateEmployee(Employee employee)
        {
            return employeeRepo.Create(employee);
        }
        public IEnumerable<Order> GetOpened()
        {
            return orderRepo.GetAll().Where(x => x.Closed == null);
        }

        public IEnumerable<Order> GetByPostCode(int input)
        {
            if (input > 1000) return orderRepo.GetAll().Where(x => x.PostCode == input && x.Closed == null);

            else if (input >= 100 && input < 124) return orderRepo.GetAll().OrderBy(p => p.PostCode).Where(x => x.PostCode / 10 == input && x.Closed == null);

            else if (input < 100) return orderRepo.GetAll().OrderBy(d => d.Opened).Where(x => x.Opened <= DateTime.Today.AddDays(-input));

            else return orderRepo.GetAll();
        }

        public IEnumerable<Order> GetOrdersbyID(int id)
        {
            return orderRepo.GetAll().Where(x => x.Id == id);
        }
        public IEnumerable<Order> GetOrdersby(int mounth)
        {
            return orderRepo.GetAll().Where(x => x.Closed?.Month == mounth);
        }
        public IEnumerable<Order> GetOrdersby(Employee employee)
        {
            return orderRepo.GetAll().Where(x => x.EmployeeId == employee.Id);
        }

        public IEnumerable<Employee> GetEmployeesBy(int id)
        {
            return employeeRepo.GetAll().Where(x => x.Id == id);
        }

        public void CompletOrder(int orderId, int employeeId, string selectedError)
        {
            var order = orderRepo.GetAll().FirstOrDefault(x => x.Id == orderId);
            if (order != null)
            {
                order.EmployeeId = employeeId;
                order.ErrorType = selectedError;
                order.Closed = DateTime.Now;
                orderRepo.Update(order);
            }

        }



        // lekerdezesek
    }
}