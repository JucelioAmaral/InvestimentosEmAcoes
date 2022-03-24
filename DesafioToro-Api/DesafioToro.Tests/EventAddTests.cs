using DesafioToro.Domain;
using DesafioToro.Persistence;
using DesafioToro.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DesafioToro.Tests
{
    public class EventAddTests
    {
        [Fact]
        public void DadoEventTransferDeveAddNoBDTeste()
        {
            string EventNameExpected = "TRANSFER";

            //arrange
            var eventTransfer = new Event
            {
                Id = 1,
                EventName = "TRANSFER",
                TargetId = 1,
                OriginId = 1,
                Amount = 1000
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("DatabaseTeste")
                .Options;
            var contexto = new DatabaseContext(options);
            var repo = new GeralPersistence(contexto);
            var repoEvent = new EventPersistence(contexto);


            //act
            repo.Add(eventTransfer);
            repo.SaveChangesAsync();

            //assert
            var eventSelectd = repoEvent.GetEvent(eventTransfer.Id);
            Assert.Equal(EventNameExpected, eventSelectd.Result.EventName);
        }

        [Fact]
        public void DadoEventDepositDeveAddNoBDTeste()
        {
            string EventNameExpected = "DEPOSIT";

            //arrange
            var eventDeposit = new Event
            {
                Id = 2,
                EventName = "DEPOSIT",
                TargetId = 2,
                OriginId = 2,
                Amount = 1000
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("DatabaseTeste")
                .Options;
            var contexto = new DatabaseContext(options);
            var repo = new GeralPersistence(contexto);
            var repoEvent = new EventPersistence(contexto);


            //act
            repo.Add(eventDeposit);
            repo.SaveChangesAsync();

            //assert
            var eventSelectd = repoEvent.GetEvent(eventDeposit.Id);
            Assert.Equal(EventNameExpected, eventSelectd.Result.EventName);
        }
    }
}
