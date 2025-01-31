﻿using System;
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

        [Display(Name = "Наименование товара")]
        public string Product_name { get; set; }

        [Display(Name = "Цена")]
        public decimal Product_price { get; set; }

        [Display(Name = "Количество на складе")]
        public int Count_at_storage { get; set; }

        [Display(Name = "Срок годности")]
        public DateTime Expiration_date { get; set; }

        [Display(Name = "Код поставщика")]
        public int Supplier_id { get;set; }

        public Supplier Supplier { get; set; }

    }
}
