using ShopBridge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Auth
{
    /// <summary>
    /// Class to implement Login method accepting username and password and validating from database.
    /// </summary>

    public class InventoryAuth
    {
        public static bool Login(string username, string password)
        {
            try
            {
                using (InventoryItemDBEntities entities = new InventoryItemDBEntities())
                    return entities.Users.Any(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                                &&
                                user.PasswordHash.Equals(password));
            }
            catch
            {
                return false;
            }
        }
    }
}