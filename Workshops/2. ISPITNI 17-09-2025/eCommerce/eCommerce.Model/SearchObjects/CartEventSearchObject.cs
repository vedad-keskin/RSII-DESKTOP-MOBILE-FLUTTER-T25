using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Model.SearchObjects
{
    public class CartEventSearchObject : BaseSearchObject
    {
        public string? FullName { get; set; }
        public string? ProductName { get; set; }
    }
} 