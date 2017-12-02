using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Data;

namespace HTC_CRM_DataAccess.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        [Computed]
        public string ProductInfo
        {
            get
            {
                string info = "Product name: " + ProductName + "; Product description: " + ProductDescription;
                return info;
            }
            set { }
        }

        //helper methods
        public static IEnumerable<Product> GetAll(IDbConnection db)
        {
            return db.GetAll<Product>();
        }

        public static Product GetById(IDbConnection db, int id)
        {
            return db.Get<Product>(id);
        }

        public static Product GetByName(IDbConnection db, string name)
        {
            //string sql = "select * from dbo.Products where ProductName = @ProductName";
            //return db.QueryFirstOrDefault<Product>(sql, new { ProductName = name });

            return db.GetAll<Product>().Where(i => i.ProductName == name).FirstOrDefault();
        }

        
    }
}
