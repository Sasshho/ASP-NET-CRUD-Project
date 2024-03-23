using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Priut_za_jivotni.Controllers;
using Priut_za_jivotni.Data;
using Priut_za_jivotni.Models;

namespace AppTester
{
    [TestFixture]
    public class Tests
    {
        
        public DbContextOptions<Priut_za_jivotniContext> GetDbContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<Priut_za_jivotniContext>()
                .UseInMemoryDatabase("TestDatabase")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [Test]

        public async Task Index_ReturViewWithResult()
        {
            var options=GetDbContextOptions();
            using (var context = new Priut_za_jivotniContext(options))
            {
                context.Dogs.Add(new Dogs { Id = 1, Breed = "Ivcho", Name = "Ivcho", Age = 40, Description = "Bre" });
                context.SaveChanges();
            }
            using(var context=new Priut_za_jivotniContext(options))
            {
                var controller = new DogsController(context);
                var result = await controller.Index();
                Assert.IsInstanceOf<ViewResult>(result);
            }
        }
        [Test]

        public async Task Delete_ReturViewWithResult()
        {
            var options = GetDbContextOptions();
            using (var context = new Priut_za_jivotniContext(options))
            {
                context.Dogs.Add(new Dogs { Id = 1, Breed = "Ivcho", Name = "Ivcho", Age = 40, Description = "Bre" });
                context.SaveChanges();
            }
            using (var context = new Priut_za_jivotniContext(options))
            {
                var controller = new DogsController(context);
                var result = await controller.Delete(1);
                Assert.IsInstanceOf<ViewResult>(result);
            }
        }
        [Test]

        public async Task DeleteConfirm_ReturViewWithResult()
        {
            var options = GetDbContextOptions();
            using (var context = new Priut_za_jivotniContext(options))
            {
                context.Dogs.Add(new Dogs { Id = 1, Breed = "Ivcho", Name = "Ivcho", Age = 40, Description = "Bre" });
                context.SaveChanges();
            }
            using (var context = new Priut_za_jivotniContext(options))
            {
                var controller = new DogsController(context);
                var result = await controller.DeleteConfirmed(1);
                Assert.IsInstanceOf<RedirectToActionResult>(result);
            }
        }
        [Test]

        public async Task Edit_ReturViewWithResult()
        {
            var options = GetDbContextOptions();
            using (var context = new Priut_za_jivotniContext(options))
            {
                context.Dogs.Add(new Dogs { Id = 1, Breed = "Ivcho", Name = "Ivcho", Age = 40, Description = "Bre" });
                context.SaveChanges();
            }
            using (var context = new Priut_za_jivotniContext(options))
            {
                var controller = new DogsController(context);
                var result = await controller.Edit(1);
                Assert.IsInstanceOf<ViewResult>(result);
            }
        }
        [Test]

        public async Task Create_ReturViewWithResult()
        {
            var options = GetDbContextOptions();
            
            using (var context = new Priut_za_jivotniContext(options))
            {
                var controller = new DogsController(context);
                var result = await controller.Create(new Dogs {Id=1,Name="Al",Breed="Kon",Description="tir",Age=3 });
                Assert.IsInstanceOf<RedirectToActionResult>(result);
            }
        }
        [Test]

        public async Task Details_ReturViewWithResult()
        {
            var options = GetDbContextOptions();
            using (var context = new Priut_za_jivotniContext(options))
            {
                context.Dogs.Add(new Dogs { Id = 1, Breed = "Ivcho", Name = "Ivcho", Age = 40, Description = "Bre" });
                context.SaveChanges();
            }
            using (var context = new Priut_za_jivotniContext(options))
            {
                var controller = new DogsController(context);
                var result = await controller.Details(1);
                Assert.IsInstanceOf<ViewResult>(result);
            }
        }
    }
}