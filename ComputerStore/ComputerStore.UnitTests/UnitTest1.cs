using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;
using ComputerStore.WebUI.Controllers;
using ComputerStore.WebUI.Models;
using ComputerStore.WebUI.HtmlHelpers;

namespace ComputerStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //arrange
            Mock<IComputerComponentRepository> mock = new Mock<IComputerComponentRepository>();
            mock.Setup(m => m.ComputerComponents).Returns(new List<ComputerComponent>
            {
                new ComputerComponent { ComputerComponentId = 1, Name = "ComputerComponent1"},
                new ComputerComponent { ComputerComponentId = 2, Name = "ComputerComponent2"},
                new ComputerComponent { ComputerComponentId = 3, Name = "ComputerComponent3"},
                new ComputerComponent { ComputerComponentId = 4, Name = "ComputerComponent4"},
                new ComputerComponent { ComputerComponentId = 5, Name = "ComputerComponent5"}
            });
            ComputerComponentController controller = new ComputerComponentController(mock.Object);
            controller.pageSize = 3;

            // Act
            ComponentListViewModel result
                = (ComponentListViewModel)controller.List(2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
        [TestMethod]
        public void Can_Generate_Page_Links()
        {

            // Arrange - defining an HTML helper - this is required to apply the extension method
            HtmlHelper myHelper = null;

            // Arrange - creating an object PagingInfo
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Arrange - configuring a delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Организация (arrange)
            Mock<IComputerComponentRepository> mock = new Mock<IComputerComponentRepository>();
            mock.Setup(m => m.ComputerComponents).Returns(new List<ComputerComponent>
        {
        new ComputerComponent { ComputerComponentId = 1, Name = "ComputerComponent1"},
        new ComputerComponent { ComputerComponentId = 2, Name = "ComputerComponent2"},
        new ComputerComponent { ComputerComponentId = 3, Name = "ComputerComponent3"},
        new ComputerComponent { ComputerComponentId = 4, Name = "ComputerComponent4"},
        new ComputerComponent { ComputerComponentId = 5, Name = "ComputerComponent5"}
        });
            ComputerComponentController controller = new ComputerComponentController(mock.Object);
            controller.pageSize = 3;

            // Act
            ComponentListViewModel result = (ComponentListViewModel)controller.List(2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

    }
}
