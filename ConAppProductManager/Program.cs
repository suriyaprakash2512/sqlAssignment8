using System;
using System.Data;
namespace ProductManager 
{ 
class ProductManager
{
    private DataTable productsTable;

    public ProductManager()
    {
        
        productsTable = new DataTable("Products");

       
        productsTable.Columns.Add("ProductId", typeof(int));
        productsTable.Columns.Add("ProductName", typeof(string));
        productsTable.Columns.Add("ProductPrice", typeof(int));
        productsTable.Columns.Add("MnfDate", typeof(DateTime));
        productsTable.Columns.Add("ExpDate", typeof(DateTime));

        
        productsTable.PrimaryKey = new DataColumn[] { productsTable.Columns["ProductId"] };
    }

    
    public void InsertProduct(int ProductId, string ProductName, int ProductPrice, DateTime MnfDate, DateTime ExpDate)
    {
        DataRow newRow = productsTable.NewRow();
        newRow["ProductId"] = ProductId;
        newRow["ProductName"] = ProductName;
        newRow["ProductPrice"] = ProductPrice;
        newRow["MnfDate"] = MnfDate;
        newRow["ExpDate"] = ExpDate;

        productsTable.Rows.Add(newRow);
    }

    
    public void UpdateProduct(int ProductId, string ProductName, int ProductPrice, DateTime MnfDate, DateTime ExpDate)
    {
        DataRow existingRow = productsTable.Rows.Find(ProductId);

        if (existingRow != null)
        {
            existingRow["ProductName"] = ProductName;
            existingRow["ProductPrice"] = ProductPrice;
            existingRow["MnfDate"] = MnfDate;
            existingRow["ExpDate"] = ExpDate;
        }
    }

  
    public void DeleteProduct(int ProductId)
    {
        DataRow rowToDelete = productsTable.Rows.Find(ProductId);

        if (rowToDelete != null)
        {
            rowToDelete.Delete();
        }
    }

    
    public DataRow SearchProduct(int ProductId)
    {
        return productsTable.Rows.Find(ProductId);
    }

    
    public void DisplayAllProducts()
    {
        foreach (DataRow row in productsTable.Rows)
        {
            Console.WriteLine($"Pid: {row["ProductId"]}, PName: {row["ProductName"]}, PPrice: {row["ProductPrice"]}, MnfDate: {row["MnfDate"]}, ExpDate: {row["ExpDate"]}");
        }
    }
}

    class Program
    {
        static void Main()
        {
            ProductManager productManager = new ProductManager();

            productManager.InsertProduct(1, "redmi", 15000, DateTime.Parse("2023-01-01"), DateTime.Parse("2023-12-31"));
            productManager.InsertProduct(2, "moto", 35000, DateTime.Parse("2023-02-15"), DateTime.Parse("2023-11-30"));

            Console.WriteLine("All Products:");
            productManager.DisplayAllProducts();


            productManager.UpdateProduct(1, "samsung", 12000, DateTime.Parse("2023-03-01"), DateTime.Parse("2023-12-31"));


            Console.WriteLine("\nAll Products After Update:");
            productManager.DisplayAllProducts();


            int searchProductId = 2;
            DataRow searchedProduct = productManager.SearchProduct(searchProductId);

            if (searchedProduct != null)
            {
                Console.WriteLine($"\nProduct found with Pid {searchProductId}: {searchedProduct["ProductName"]}");
            }
            else
            {
                Console.WriteLine($"\nProduct with Pid {searchProductId} not found.");
            }


            int deletePid = 1;
            productManager.DeleteProduct(deletePid);


            Console.WriteLine("\nAll Products After Delete:");
            productManager.DisplayAllProducts();

            Console.ReadKey();
        }
    }
}