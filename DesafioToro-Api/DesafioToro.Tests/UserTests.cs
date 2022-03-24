using DesafioToro.Domain;
using DesafioToro.Persistence;
using DesafioToro.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesafioToro.Tests
{
    public class UserTests
    {
        [Fact]
        public void DadoUsuarioDeveAddNoBDTeste()
        {
            string UserAccountExpected = "300123";

            //arrange
            var newUser = new User
            {
                Id = 1,
                Account = "300123",
                TrendId = 1,
                AmountOrder = 5
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("DatabaseTeste")
                .Options;
            var contexto = new DatabaseContext(options);
            var repo = new GeralPersistence(contexto);
            var repoUser = new UserPersistence(contexto);


            //act
            repo.Add(newUser);
            repo.SaveChangesAsync();

            //assert
            var userSelectd = repoUser.GetUserByAccount(newUser.Account);
            Assert.Equal(UserAccountExpected, userSelectd.Result.Account);
        }

        [Fact]
        public void DadoUsuarioDeveAtualizarNoBDTeste()
        {
            int AmountOrderExpected = 10;

            //arrange
            var newUser = new User
            {
                Id = 1,
                Account = "300123",
                TrendId = 1,
                AmountOrder = 10
            };

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("DatabaseTeste")
                .Options;
            var contexto = new DatabaseContext(options);
            var repo = new GeralPersistence(contexto);
            var repoUser = new UserPersistence(contexto);


            //act
            repo.Update(newUser);
            repo.SaveChangesAsync();

            //assert
            var userSelectd = repoUser.GetUserByAccount(newUser.Account);
            Assert.Equal(AmountOrderExpected, userSelectd.Result.AmountOrder);
        }
    }
}
