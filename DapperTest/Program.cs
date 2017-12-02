using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTC_CRM_DataAccess.Models;
using HTC_CRM_DataAccess.Connections;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;

namespace DapperTest
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    IDbConnection db = DBConnection.GetConnection();
        //    //Product p = new Product()
        //    //{
        //    //    ProductName = "Google Pixel",
        //    //    ProductDescription = "Silver, 32GB"
        //    //};

        //    //var identity = db.Insert<Product>(p);

        //    //Product p = db.Get<Product>(3);
        //    //db.Delete(p);
        //    //p.ProductDescription = "Black, 16GB";

        //    //db.Update<Product>(entityToUpdate: p);
        //    //db.Update<Product>(new Product { Id = 2, ProductName = "Galaxy S7", ProductDescription = "Blue, 32GB" });
        //    Product p = Product.GetByName(db, "Galaxy S7");
        //    Console.WriteLine(p.ProductName);
        //    Console.Read();


        //}
    }
}
