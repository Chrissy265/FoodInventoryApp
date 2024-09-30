using System; 
using System.Collections.Generic;  
using FoodInventoryApp; 

namespace FoodInventoryApp
{

public interface IFoodItem
{
   string GetDetails(); 
}

public class FoodItem: IFoodItem  // Single Responsiblity Principle -- each class and interface has single responsibility
{
    public string Name {get;} 
    public int Quantity {get;} 

    public FoodItem(string name, int quantity) 
    {
    Name =name; 
    Quantity = quantity; 
    } 

public string GetDetails()
 {
    return $"{Name}: {Quantity}";
 } 


} 



public class FoodInventory  

//Open- Closed Princple (OCP) Food Inventory class is open for extension
// adding new types of food items) but closed for modifications

{
     private List<IFoodItem> items = new List<IFoodItem>(); 
    
     public void AddItem(IFoodItem item) 
     {
        items.Add(item); 
     }
  
   public IEnumerable<IFoodItem>GetItems() 
   {
    return items; 
   }




}  
public interface IReportGenerator  
//Interface Gegregation Princple (ISP) -- only have the methods that are necessary for this interface
{
    void GenerateReport(FoodInventory foodInventory); 
}

public class ConsoleReportGenerator: IReportGenerator  
//This class is an example  Liskov Subsitution/ Interface Segregation Principle
//This class can be substituted for IReportGenerator without affecting the program's behavior

{
     public void  GenerateReport(FoodInventory foodInventory)
     {
      Console.WriteLine("Inventory Report: " ); 
       foreach (var item in  foodInventory.GetItems()) 
       {
         Console.WriteLine(item.GetDetails()); 
       }
     }


}


public class InventoryManager   
//Inventory Manager depends on abstraction of IReportGenerator
{

   private readonly FoodInventory inventory; 

   private readonly IReportGenerator reportGenerator;   


   public  InventoryManager ( FoodInventory inventory, IReportGenerator reportGenerator) 
   {
      this.inventory = inventory; 
      this.reportGenerator = reportGenerator; 
   } 

   public void AddItem (IFoodItem item)
   {
      inventory.AddItem(item); 
   }  

   public void GenerateReport() 
   {
      reportGenerator.GenerateReport(inventory);
   }
} 


}

