using ShopBridge.Filters;
using ShopBridge.Intefaces;
using ShopBridge.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ShopBridge.Controllers
{
    //[BasicAuthorization]  --attribute can be added then in order to use this need to add a valid user and pass a Authorization Header with Basic Authentication a token
    public class InventoryItemController : ApiController
    {
        private readonly IInventoryItem _itemService;

        public InventoryItemController(IInventoryItem itemService)
        {
            this._itemService = itemService;
        }

        /// <summary>
        /// Getting a single inventory item
        /// </summary>
        /// <param name="id">Id of the Inventory Item</param>
        /// <returns>Inventory Item Object</returns>
        
        //GET - api/inventoryitem
        public IHttpActionResult GetInventoryItem(string id)
        {
            InventoryItem item = _itemService.GetInventoryItem(id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Getting all the list of Inventory Items
        /// </summary>
        /// <returns>List of Inventory Items</returns>

        //GET - api/inventoryitem
        public IEnumerable<InventoryItem> GetInventoryItems() 
        {
            return _itemService.GetInventoryItems();
        }

        /// <summary>
        /// Storing a new Inventory Items
        /// </summary>
        /// <param name="inventoryItem">Inventory Item object</param>
        /// <returns>HttpResponseMessage</returns>

        //POST - api/inventoryitem
        [ValidateModel]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage AddInventoryItem([Bind(Exclude = "Id")]InventoryItem inventoryItem)
        {
            _itemService.SaveInventoryItem(inventoryItem);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        /// <summary>
        /// Editing a Inventory Item
        /// </summary>
        /// <param name="inventoryItem">Inventory Item object</param>
        /// <returns>HttpResponseMessage</returns>

        //PUT - api/posts
        [ValidateModel]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage UpdateInventoryItem(InventoryItem inventoryItem)
        {
            _itemService.UpdateInventoryItem(inventoryItem);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Deleting a Inventory Item
        /// </summary>
        /// <param name="Id">Id of the inventory item that needs to be deleted</param>
        /// <returns>HttpResponseMessage</returns>
        
        //Delete - api/posts
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage DeleteInventoryItem(string Id)
        {
            bool isDeleted = _itemService.DeleteInventoryItem(Id);
            if (isDeleted)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}
