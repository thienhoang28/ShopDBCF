namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Coupon
    {
        public Coupon()
        {
            //this.Orders = new HashSet<Order>();
        }
    
        public long Id { get; set; }
        public string CouponCode { get; set; }
        public System.DateTime ApplyDate { get; set; }
        public System.DateTime ExpireDate { get; set; }
        public float DiscountPercent { get; set; }
        public long CategoryId { get; set; }
    

        public virtual ICollection<Order> Orders { get; set; }
    }
}
