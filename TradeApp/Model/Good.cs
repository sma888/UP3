using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeApp.Model
{
    public class Good
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        public string ProductName { get; set; }
        public int Unit_id { get; set; }
        public decimal Price { get; set; }
        public int MaxDiscount { get; set; }
        public int Manufacturer_id { get; set; }
        public int Supplier_id { get; set; }
        public int Category_id { get; set; }
        public int CurrentDiscount { get; set; }
        public int StorageAmount { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
