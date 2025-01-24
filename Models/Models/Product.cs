using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Product //товар характеризуется: названием, ценой, количество на складе магазина, срок годности, поставщик
    {
        [Key]
        public int Product_id { get; set; }
        public string Product_name { get; set; }

        public decimal Product_price { get; set; }

        public int Count_at_storage { get; set; }

        public DateTime Expiration_date { get; set; }

        public int Supplier_id { get;set; }

    }
}
