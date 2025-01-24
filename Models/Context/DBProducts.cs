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
        public IEnumerable<Product> Products { get { return context.Products; } }  
    }
}
