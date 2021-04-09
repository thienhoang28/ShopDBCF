namespace Shop.Models
{
	using global::Shop.Models.Enums;
	using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public partial class Order
    {

        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public long Id { get; set; }
        public long? CustomerId { get; set; }
        [MaxLength(200)]
        public string FullName { get; set; }
        [MaxLength(12)]
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public System.DateTime OrderTime { get; set; }
        public long? CouponId { get; set; }
        public OrderStatus Status { get; set; }
    
        public virtual Coupon Coupon { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
