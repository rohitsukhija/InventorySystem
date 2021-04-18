using ShopBridge.Models;
using System.Collections.Generic;

namespace ShopBridge.Intefaces
{
    /// <summary>
    /// Interface for common inventory system operations
    /// </summary>
    public interface IInventoryItem
    {
        InventoryItem GetInventoryItem(string ID);
        IEnumerable<InventoryItem> GetInventoryItems();
        void SaveInventoryItem(InventoryItem inventoryItem);
        void UpdateInventoryItem(InventoryItem inventoryItem);
        bool DeleteInventoryItem(string ID);
    }
}