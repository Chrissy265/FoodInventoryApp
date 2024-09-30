using System; 
using FoodInventoryApp; 
 
 
 class Program { 

   static void Main (string[] args) 
   {
      var inventory = new FoodInventory();  
      var reportGenerator = new ConsoleReportGenerator(); 
      var InventoryManager = new InventoryManager(inventory, reportGenerator);  




      InventoryManager.AddItem(new FoodItem ("Apple", 10)); 
      InventoryManager.AddItem(new FoodItem ("Grapes", 6)); 
      InventoryManager.AddItem(new FoodItem("Peaches", 20));  
      InventoryManager.AddItem(new FoodItem("Bread",50)); 
      InventoryManager.AddItem(new FoodItem ("Butter", 25)); 
     
   }




 }

