namespace WebApp1.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public partial class User
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        [Required]
        public string Roles { get; set; }
        public long AccountId { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
