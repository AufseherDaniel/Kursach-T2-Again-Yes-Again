using Models.Abstract;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.Context
{
    public class DBProducts : Iproduct
    {
        StoreDBContext context = new StoreDBContext();
        public IEnumerable<Product> Products
        {
            get
            {
                return context.Products
                    .Include("Supplier")
                    .ToList();
            }
        }

        public IEnumerable<Supplier> Suppliers => context.Suppliers.ToList();
        public Product GetProductWithSupplier(int productId)
        {
            return context.Products
                           .Include("Supplier")
                           .FirstOrDefault(p => p.Product_id == productId);
        }
    }
}
