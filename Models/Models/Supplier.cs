using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.Models
{
    public class Supplier
    {
        [Key]
        public int Supplier_id { get; set; }

        public string Supplier_name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
