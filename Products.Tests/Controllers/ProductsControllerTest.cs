using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products.Models;
using Products.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Products.Tests.Controllers;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new ProductEntities();
            var controller = new productController();
            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<Product>));
            Assert.AreEqual(db.Products.Count(), (result.Model as List<Product>).Count);
        }

        [TestMethod]
        public void TestEditGet()
        {
            var controller = new productController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            var db = new ProductEntities();
            var item = db.Products.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as Product;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);
        }

        [TestMethod]
        public void TestCreateGet()
        {
            var controller = new productController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreatePost()
        {
            var controller = new productController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestEditPost()
        {
            {
                var controller = new productController();
                var result0 = controller.Edit(0);
                Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

                var db = new ProductEntities();
                var item = db.Products.First();
                var result1 = controller.Edit(item.id) as ViewResult;
                Assert.IsNotNull(result1);
                var model = result1.Model as Product;
                Assert.IsNotNull(model);
                Assert.AreEqual(item.id, model.id);
            }
        }
    }
}