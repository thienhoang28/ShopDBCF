namespace WebApp1.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Script.Serialization;
    using WebApp1.Models;

    public class Category
    {
        public Category()
        {
            //this.Products = new HashSet<Product>();
        }
        [Required(ErrorMessage ="Vui long nhap Category!")]
        public string Category_Name { get; set; }
        public long Id { get; set; }   
        public long? ParentId { get; set; }

        [ScriptIgnore]
        public virtual ICollection<Product> Products { get; set; }    //TODO: remove
        [ScriptIgnore]
        [ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }
    }
}
