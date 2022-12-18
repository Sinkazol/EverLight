using EverLight.BusinessLayer;
using EverLight.DTOs;
using EverLight.Repositories;
using Moq;

namespace EverLight.BusinessLogicTest
{
    public class UnitTest1
    {

        [Fact]
        public void GetAllTest()
        {
            List<Order> orders = new List<Order>()
            {
                new Order() { Id = 1, PostCode=1096, City="Budapest", Address = "ulloi ut", Opened=new DateTime(2002,12,25)}
            };
            var MoqOrderRepository = new Mock<IRepository<Order>>();
            var MoqEmployeeRepository = new Mock<IRepository<Employee>>();
            MoqOrderRepository.Setup(x => x.GetAll()).Returns(orders);
            var businessLogic = new BusinessLogic(MoqOrderRepository.Object, MoqEmployeeRepository.Object);

            var order = businessLogic.GetAll();
            Assert.NotNull(order);
            Assert.Equal(orders.Count(), order.Count());
            Assert.Collection(orders, order => Assert.Equal(order.Id, order.Id));
        }
        [Fact]
        public void GetAllEmployesTest()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() {Id=1500,Name="Jhon Doe"}
            };
            var MoqOrderRepository = new Mock<IRepository<Order>>();
            var MoqEmployeeRepository = new Mock<IRepository<Employee>>();
            MoqEmployeeRepository.Setup(x => x.GetAll()).Returns(employees);
            var businessLogic = new BusinessLogic(MoqOrderRepository.Object, MoqEmployeeRepository.Object);

            var emp = businessLogic.GetAllEmployes();
            Assert.NotNull(emp);
            Assert.Equal(emp.Count(), emp.Count());
            Assert.Collection(employees, emp => Assert.Equal(emp.Id, emp.Id));
            Assert.True(employees.Any());
        }
        [Fact]
        public void GetOpenedTest()
        {
            List<Order> orders = new List<Order>()
            {
                new Order() { Id = 1, PostCode=1096, City="Budapest", Address = "ulloi ut", Opened=new DateTime(2002,12,25), Closed=null}
            };
            var MoqOrderRepository = new Mock<IRepository<Order>>();
            var MoqEmployeeRepository = new Mock<IRepository<Employee>>();
            MoqOrderRepository.Setup(x => x.GetAll()).Returns(orders);
            var businessLogic = new BusinessLogic(MoqOrderRepository.Object, MoqEmployeeRepository.Object);

            var order = businessLogic.GetOpened();
            Assert.NotNull(order);
            Assert.Equal(orders.Count(), order.Count());
            Assert.Collection(orders, order => Assert.Equal(order.Id, order.Id));
            Assert.Collection(orders, order => Assert.True(order.Closed == null));
            Assert.Collection(orders, order => Assert.Null(order.Closed));
        }
        [Fact]
        public void GetByPostCodeTest1()
        {
            List<Order> orders = new List<Order>()
            {
                new Order() { Id = 1, PostCode=1096, City="Budapest", Address = "ulloi ut", Opened=new DateTime(2002,12,25), Closed=null}
            };
            var MoqOrderRepository = new Mock<IRepository<Order>>();
            var MoqEmployeeRepository = new Mock<IRepository<Employee>>();
            MoqOrderRepository.Setup(x => x.GetAll()).Returns(orders);
            var businessLogic = new BusinessLogic(MoqOrderRepository.Object, MoqEmployeeRepository.Object);

            var order = businessLogic.GetByPostCode(1096);
            Assert.NotNull(order);
            Assert.Collection(orders, order => Assert.Equal(order.Id, order.Id));
            Assert.Collection(orders, order => Assert.Null(order.Closed));
            Assert.Collection(orders, order => Assert.Equal(1096, order.PostCode));

        }
        [Fact]
        public void GetByPostCodeTest2()
        {
            List<Order> orders = new List<Order>()
            {
                new Order() { Id = 1, PostCode=1096, City="Budapest", Address = "ulloi ut", Opened=new DateTime(2002,12,25), Closed=null}
            };
            var MoqOrderRepository = new Mock<IRepository<Order>>();
            var MoqEmployeeRepository = new Mock<IRepository<Employee>>();
            MoqOrderRepository.Setup(x => x.GetAll()).Returns(orders);
            var businessLogic = new BusinessLogic(MoqOrderRepository.Object, MoqEmployeeRepository.Object);

            var order = businessLogic.GetByPostCode(109);
            Assert.NotNull(order);
            Assert.Collection(orders, order => Assert.Equal(order.Id, order.Id));
            Assert.Collection(orders, order => Assert.Null(order.Closed));
            Assert.Collection(orders, order => Assert.StartsWith(109.ToString(),order.PostCode.ToString()));
            Assert.Collection(orders, order => Assert.Equal(109,(order.PostCode/10)));

        }
        [Fact]
        public void GetByPostCodeTest3()
        {
            List<Order> orders = new List<Order>()
            {
                new Order() { Id = 1, PostCode=1096, City="Budapest", Address = "ulloi ut", Opened=new DateTime(2002,12,25), Closed=null}
            };
            var MoqOrderRepository = new Mock<IRepository<Order>>();
            var MoqEmployeeRepository = new Mock<IRepository<Employee>>();
            MoqOrderRepository.Setup(x => x.GetAll()).Returns(orders);
            var businessLogic = new BusinessLogic(MoqOrderRepository.Object, MoqEmployeeRepository.Object);

            var order = businessLogic.GetByPostCode(90);
            Assert.NotNull(order);
            Assert.Collection(orders, order => Assert.Equal(order.Id, order.Id));
            Assert.Collection(orders, order => Assert.Null(order.Closed));
            Assert.Collection(orders, order => Assert.True(order.Opened <= DateTime.Today.AddDays(-90)));
            

        }
        [Fact]
        public void GetOrdersbyIDTest()
        {
            List<Order> orders = new List<Order>()
            {
                new Order() { Id = 10, PostCode=1096, City="Budapest", Address = "ulloi ut", Opened=new DateTime(2002,12,25), Closed=null}
            };
            var MoqOrderRepository = new Mock<IRepository<Order>>();
            var MoqEmployeeRepository = new Mock<IRepository<Employee>>();
            MoqOrderRepository.Setup(x => x.GetAll()).Returns(orders);
            var businessLogic = new BusinessLogic(MoqOrderRepository.Object, MoqEmployeeRepository.Object);

            var order = businessLogic.GetOrdersbyID(10);
            Assert.NotNull(order);
            Assert.Equal(orders.Count(), order.Count());
            Assert.Collection(orders, order => Assert.Equal(order.Id, order.Id));
            Assert.Collection(orders, order => Assert.True(order.Id == 10));
            Assert.Collection(orders, order => Assert.False(order.Id == 9));
        }
        [Fact]
        public void GetOrdersbyTest()
        {
            List<Order> orders = new List<Order>()
            {
                new Order() { Id = 10, PostCode=1096, City="Budapest", Address = "ulloi ut", Opened=new DateTime(2002,12,25), Closed=null, EmployeeId=null, ErrorType=null}
            };
            var MoqOrderRepository = new Mock<IRepository<Order>>();
            var MoqEmployeeRepository = new Mock<IRepository<Employee>>();
            MoqOrderRepository.Setup(x => x.GetAll()).Returns(orders);
            var businessLogic = new BusinessLogic(MoqOrderRepository.Object, MoqEmployeeRepository.Object);

            var order = businessLogic.GetOrdersby(12);
            Assert.NotNull(order);
            Assert.Collection(orders, order => Assert.Equal(order.Id, order.Id));
            Assert.Collection(orders, order => Assert.Equal(12, order.Opened.Month));
            Assert.Collection(orders, order => Assert.Null(order.Closed));
            Assert.Collection(orders, order => Assert.Null(order.EmployeeId));
            Assert.Collection(orders, order => Assert.Null(order.ErrorType));
        }
        [Fact]
        public void GetOrdersbyTest2()
        {
            List<Order> orders = new List<Order>()
            {
                new Order() { Id = 10, PostCode=1096, City="Budapest", Address = "ulloi ut", Opened=new DateTime(2002,12,25), Closed=new DateTime(2002,12,25), EmployeeId = 1500, ErrorType="other"}
            };

            var MoqOrderRepository = new Mock<IRepository<Order>>();
            var MoqEmployeeRepository = new Mock<IRepository<Employee>>();
            MoqOrderRepository.Setup(x => x.GetAll()).Returns(orders);
            var businessLogic = new BusinessLogic(MoqOrderRepository.Object, MoqEmployeeRepository.Object);

            var order = businessLogic.GetOrdersby("other");
            Assert.NotNull(order);
            Assert.Collection(orders, order => Assert.Equal(order.Id, order.Id));
            Assert.Collection(orders, order => Assert.NotNull(order.Closed));
            Assert.Collection(orders, order => Assert.NotNull(order.EmployeeId));
            Assert.Collection(orders, order => Assert.NotNull(order.ErrorType));
            Assert.Collection(orders, order => Assert.Equal("other", order.ErrorType));

        }
        [Fact]
        public void GetOrdersbyTest3()
        {
            List<Order> orders = new List<Order>()
            {
                new Order() { Id = 10, PostCode=1096, City="Budapest", Address = "ulloi ut", Opened=new DateTime(2002,12,25), Closed=new DateTime(2002,12,25), EmployeeId = 1500, ErrorType="other"}
            };
            Employee TestEmployee = new Employee() { Id = 1500, Name = "Jhon Doe" };

            var MoqOrderRepository = new Mock<IRepository<Order>>();
            var MoqEmployeeRepository = new Mock<IRepository<Employee>>();
            MoqOrderRepository.Setup(x => x.GetAll()).Returns(orders);
            var businessLogic = new BusinessLogic(MoqOrderRepository.Object, MoqEmployeeRepository.Object);

            var order = businessLogic.GetOrdersby(TestEmployee);
            Assert.NotNull(order);
            Assert.Collection(orders, order => Assert.Equal(order.Id, order.Id));
            Assert.Collection(orders, order => Assert.NotNull(order.Closed));
            Assert.Collection(orders, order => Assert.NotNull(order.EmployeeId));
            Assert.Collection(orders, order => Assert.Equal(TestEmployee.Id, order.EmployeeId));

        }
        [Fact]
        public void EmployeeByTest()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() {Id=1500,Name="Jhon Doe"}
            };
            var MoqOrderRepository = new Mock<IRepository<Order>>();
            var MoqEmployeeRepository = new Mock<IRepository<Employee>>();
            MoqEmployeeRepository.Setup(x => x.GetAll()).Returns(employees);
            var businessLogic = new BusinessLogic(MoqOrderRepository.Object, MoqEmployeeRepository.Object);

            var emp = businessLogic.EmployeeBy(1500);
            Assert.NotNull(emp);
            Assert.Equal(emp.Count(), emp.Count());
            Assert.Collection(employees, emp => Assert.Equal(emp.Id, emp.Id));
            Assert.True(employees.Any());
            Assert.Collection(employees, emp => Assert.Equal(1500, emp.Id));
            Assert.Collection(employees, emp => Assert.NotNull(emp.Name));

        }
        [Fact]
        public void GetErrorTypesTest()
        {
            List<Order> orders = new List<Order>()
            {
                new Order() { Id = 10, PostCode=1096, City="Budapest", Address = "ulloi ut", Opened=new DateTime(2002,12,25), Closed=new DateTime(2002,12,25), EmployeeId = 1500, ErrorType="other"}
            };

            var MoqOrderRepository = new Mock<IRepository<Order>>();
            var MoqEmployeeRepository = new Mock<IRepository<Employee>>();
            MoqOrderRepository.Setup(x => x.GetAll()).Returns(orders);
            var businessLogic = new BusinessLogic(MoqOrderRepository.Object, MoqEmployeeRepository.Object);

            var order = businessLogic.GetErrorTypes();
            Assert.NotNull(order);
            Assert.Collection(orders, order => Assert.Equal(order.Id, order.Id));
            Assert.Collection(orders, order => Assert.NotNull(order.Closed));
            Assert.Collection(orders, order => Assert.NotNull(order.EmployeeId));
            Assert.Collection(orders, order => Assert.NotNull(order.ErrorType));
            Assert.Collection(orders, order => Assert.Equal("other", order.ErrorType));
        }
    }
}