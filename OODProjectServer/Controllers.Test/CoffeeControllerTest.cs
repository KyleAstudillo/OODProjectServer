using System;
using System.Collections.Generic;
using NUnit.Framework;
using OODProjectServer.Entities;

namespace OODProjectServer.Controllers.Test
{
    [TestFixture]
    public class CoffeeControllerTest
    {
        private CoffeeController _coffeeController;

        public CoffeeControllerTest()
        {
            _coffeeController = new CoffeeController(new CoffeeContext(new Microsoft.EntityFrameworkCore.DbContextOptions<CoffeeContext>()));
        }

        [Test]
        public void GetAll()
        {
            List<CoffeeItem> results = _coffeeController.GetAll();
            Assert.AreNotSame(0, results.Count);
        }
    }
}
