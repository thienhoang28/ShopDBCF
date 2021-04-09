namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public partial class Account
    {
        public Account()
        {
            //this.Customers = new HashSet<Customer>();
            //this.Users = new HashSet<User>();
        }
    
        public long Id { get; set; }
        [Required]
        public string LoginName { get; set; }
        [MinLength(5)]
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression("^\\w+@\\w+\\.\\w+$")]
        public string Email { get; set; }
        public short Locked { get; set; }
        public string ActivationCode { get; set; }
    
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
