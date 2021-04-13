namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
    using WebApp1.Models;

    public class Category
    {
        public Category()
        {
            //this.Products = new HashSet<Product>();
        }
        [Required(ErrorMessage ="Vui long nhap Category!")]
        public string DisplayText { get; set; }
        public long Id { get; set; }   
        public long? ParentId { get; set; }

        public virtual ICollection<Product> Products { get; set; }    //TODO: remove
        [ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }
    }
}
