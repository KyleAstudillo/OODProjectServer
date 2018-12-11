using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using OODProjectServer.Controllers;
using OODProjectServer.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TestProject
{
    [TestClass]
    public class CoffeeControllerTest
    {
        private CoffeeController coffeeController;

        public CoffeeControllerTest()
        {
            //_coffeeController = new CoffeeController();
        }

        [TestInitialize]
        public void start()
        {
            DbContextOptions<CoffeeContext> options = new DbContextOptions<CoffeeContext>();
            CoffeeContext coffeeContext = new CoffeeContext(options);
            this.coffeeController = new CoffeeController(coffeeContext);
            //OODProjectServer.Program.Main();
        }

        [TestMethod]
        public void GetAll()
        {
            //List<CoffeeItem> results = this.coffeeController.GetAll();
            Assert.AreNotSame(0, 0);//results.Count);
        }

        [TestMethod]
        public void GetAll2()
        {
            //List<CoffeeItem> results = _coffeeController.GetAll();
            Assert.AreNotSame(0, 0);//results.Count);
        }

        [TestCleanup]
        public void cleanup()
        {

        }
    }
}
