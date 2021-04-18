using ShopBridge.Data;
using ShopBridge.Intefaces;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopBridge.Services
{
    /// <summary>
    /// Service class to access database and extract data.
    /// </summary>
    public class InventoryItemService : IInventoryItem
    {
        /// <summary>
        /// Getting a single inventory item
        /// </summary>
        /// <param name="id">Id of the Inventory Item</param>
        /// <returns>Inventory Item Object</returns>
        public InventoryItem GetInventoryItem(string ID)
        {
            using (InventoryItemDBEntities entities = new InventoryItemDBEntities())
            {
                return entities.InventoryItems.Where(m => m.ID == new Guid(ID)).FirstOrDefault();
            }
        }

        /// <summary>
        /// Getting all the list of Inventory Items
        /// </summary>
        /// <returns>List of Inventory Items</returns>
        public IEnumerable<InventoryItem> GetInventoryItems()
        {
            using (InventoryItemDBEntities entities = new InventoryItemDBEntities())
            {
                return entities.InventoryItems.ToList();
            }
        }

        /// <summary>
        /// Storing a new Inventory Items
        /// </summary>
        /// <param name="inventoryItem">Inventory Item object</param>
        /// <returns></returns>

        public void SaveInventoryItem(InventoryItem inventoryItem)
        {
            using (InventoryItemDBEntities entities = new InventoryItemDBEntities())
            {
                inventoryItem.ID = Guid.NewGuid();
                entities.InventoryItems.Add(inventoryItem);
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Editing a Inventory Item
        /// </summary>
        /// <param name="inventoryItem">Inventory Item object</param>
        /// <returns></returns>

        public void UpdateInventoryItem(InventoryItem inventoryItem)
        {
            using (InventoryItemDBEntities entities = new InventoryItemDBEntities())
            {
                entities.Entry(inventoryItem).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Deleting a Inventory Item
        /// </summary>
        /// <param name="Id">Id of the inventory item that needs to be deleted</param>
        /// <returns>bool</returns>

        public bool DeleteInventoryItem(string ID)
        {
            using (InventoryItemDBEntities entities = new InventoryItemDBEntities())
            {
                InventoryItem inventoryItem = entities.InventoryItems.FirstOrDefault(p => p.ID == new Guid(ID));
                if(inventoryItem != null)
                {
                    entities.InventoryItems.Remove(inventoryItem);
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}