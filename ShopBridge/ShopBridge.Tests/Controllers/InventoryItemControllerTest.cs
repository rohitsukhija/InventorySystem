using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using ShopBridge.Intefaces;
using ShopBridge.Models;
using ShopBridge.Controllers;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Web.Http;
using System.Web.Http.Results;

namespace ShopBridge.Tests.Controllers
{
    /// <summary>
    /// Inventory Item Controller Test Class - Containing few unit test cases.
    /// </summary>
    [TestFixture]
    class InventoryItemControllerTest
    {
        private Mock<IInventoryItem> itemService;
        [SetUp]
        public void SetUp()
        {
            itemService = new Mock<IInventoryItem>();
        }

        /// <summary>
        /// Check the method returning list of Inventory Items.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Test]
        public void GetInventoryItems_Returns_AllInventoryItems()
        {
            // Arrange
            IEnumerable<InventoryItem> fakeItems = GetFakeInventoryItems();
            itemService.Setup(x => x.GetInventoryItems()).Returns(fakeItems.AsQueryable());
            InventoryItemController controller = new InventoryItemController(itemService.Object)
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            // Act
            var invItems = controller.GetInventoryItems();

            // Assert
            Assert.IsNotNull(invItems, "Result is null");
            Assert.IsInstanceOf(typeof(IEnumerable<InventoryItem>), invItems, "Wrong Model");
            Assert.AreEqual(2, invItems.Count(), "Got wrong number of Inventory Items");
        }

        /// <summary>
        /// Check the method returning particular Inventory Items.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Test]
        public void Get_CorrectInventoryItemID_Returns_InventoryItem()
        {
            // Arrange   
            IEnumerable<InventoryItem> fakeItems = GetFakeInventoryItems();
            itemService.Setup(x => x.GetInventoryItem("2cfcb180-1c14-4dc3-9cfd-6b553f9dccab")).Returns(fakeItems.Where(x => x.ID == new Guid("2cfcb180-1c14-4dc3-9cfd-6b553f9dccab")).FirstOrDefault());

            InventoryItemController controller = new InventoryItemController(itemService.Object)
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            // Act
            var actionResult = controller.GetInventoryItem("2cfcb180-1c14-4dc3-9cfd-6b553f9dccab");
            var contentResult = actionResult as OkNegotiatedContentResult<InventoryItem>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(new Guid("2cfcb180-1c14-4dc3-9cfd-6b553f9dccab"), contentResult.Content.ID, "Got wrong number of Inventory Items");
        }

        /// <summary>
        /// Check the method giving proper resonse once the inventory item not found.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Test]
        public void Get_InValidInventoryItemID_Returns_NotFound()
        {
            // Arrange   
            IEnumerable<InventoryItem> fakeItems = GetFakeInventoryItems();
            itemService.Setup(x => x.GetInventoryItem("2cfcb180-1c14-4dc3-9cfd-6b553f9dccab")).Returns(fakeItems.Where(x => x.ID == new Guid("2cfcb180-1c14-4dc3-9cfd-6b553f9dccab")).FirstOrDefault());

            InventoryItemController controller = new InventoryItemController(itemService.Object)
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            // Act
            var actionResult = controller.GetInventoryItem("2cfcb180-1c14-4dc3-9cfd-6b553f9dccac");
            var contentResult = actionResult as OkNegotiatedContentResult<InventoryItem>;

            // Assert
            Assert.IsNull(contentResult);
            Assert.IsInstanceOf<NotFoundResult>(actionResult);
        }

        /// <summary>
        /// A Method returning some fake Inventory Items for validations.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private static IEnumerable<InventoryItem> GetFakeInventoryItems()
        {
            IEnumerable<InventoryItem> fakeItems = new List<InventoryItem>
            {
                    new InventoryItem {ID=new Guid("2cfcb180-1c14-4dc3-9cfd-6b553f9dccab"),Name="Bluetooth Speaker",Description="With Lamp",Price="Rs 1099",ImagePath="ghf/hjk.jpeg" , ItemAddedOn = new DateTime(2021, 04, 18, 12, 46, 11) , itemUpdatedOn = new DateTime(2021, 04, 18, 12, 46, 11) },
                    new InventoryItem {ID=new Guid("86D4E5C6-1683-4CA2-9A22-E3AFF87A7A23"),Name="IPods",Description="Apple IPods",Price="$24455.12",ImagePath="ghf/hjk.jpeg" , ItemAddedOn = new DateTime(2021, 04, 18, 12, 46, 11) , itemUpdatedOn = new DateTime(2021, 04, 18, 12, 46, 11) },
            }.AsEnumerable();
            return fakeItems;
        }
    }
}
