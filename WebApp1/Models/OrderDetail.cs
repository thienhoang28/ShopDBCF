namespace WebApp1.Models
{
    using System;
    using System.Collections.Generic;
    using WebApp1.Models;

    public partial class OrderDetail
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public long ProductId { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
