# InventorySystem
Sample Web API for Inventory System

Operations Include

    1) Add a new Inventory
	  2) Edit a new Inventory
	  3) Delete a new Inventory
	  4) List all the Inventory
	  5) List single Inventory

Database script is included in Database folder.
Database design has been included in the Database folder as a .png file.

Currently Authorization disabled.

Authorization can be implemented by UnCommenting [BasicAuthorization] attribute in ShopBridge.Controllers
Add a user in the database, Script in Database query file.

While testing
Use Authorization Header with Value as (base64encodedstring)

	1) Vaid User - cnN1a2hpamE6ZGRzc2Zha24xMTIyMTM0NDM=
	2) Invalid User - cnN1a2hpamE6ZGRzc2Zha24=

So Header would be (For valid one)
Authorization - Basic cnN1a2hpamE6ZGRzc2Zha24xMTIyMTM0NDM=
