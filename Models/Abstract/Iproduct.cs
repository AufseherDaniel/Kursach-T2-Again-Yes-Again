﻿using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Abstract
{
    public interface Iproduct
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Supplier> Suppliers { get; }
    }
}
