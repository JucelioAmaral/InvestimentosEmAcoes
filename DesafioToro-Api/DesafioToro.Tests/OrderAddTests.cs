using DesafioToro.Application.DTO;
using DesafioToro.Domain;
using DesafioToro.Persistence;
using DesafioToro.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace DesafioToro.Tests
{
    public class OrderAddTests
    {
        [Fact]
        public void DadaOrderDeveAddNoBDTeste()
        {
            string symbolExpected = "SANB11";

            //arrange
            var order = new Order {
                OrderId = 1,
                Symbol = "SANB11",
                Amount = 3,
                DateOrder = DateTime.Now
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("DatabaseTeste")
                .Options;
            var contexto = new DatabaseContext(options);
            var repo = new GeralPersistence(contexto);
            var repoOrder = new OrderPersistence(contexto);



            //act
            repo.Add(order);
            repo.SaveChangesAsync();

            //assert
            var orders = repoOrder.GetTopFiveOrdersInSevensDays();
            
            Assert.Equal(symbolExpected, orders.Result[0].Symbol);
        }
    }
}
