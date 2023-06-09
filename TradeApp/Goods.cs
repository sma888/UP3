//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TradeApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Goods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Goods()
        {
            this.OrderContent = new HashSet<OrderContent>();
        }
    
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
    
        public virtual Category Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Unit Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderContent> OrderContent { get; set; }
    }
}
