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
    }
}