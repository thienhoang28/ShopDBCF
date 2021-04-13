using Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp1.Models
{
    public class Product
    {
        public Product()
        {
            this.Prices = new HashSet<Price>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(250)]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product ID")]
        public long CategoryId { get; set; }

        
        [MaxLength(500, ErrorMessage = "Content is too length.")]
        [AllowHtml]
        public string Description { get; set; }

        [MaxLength(250)]
        [Display(Name = "Featured image")]
        public string FeatureImage { get; set; }

        public PublishStatus Status { get; set; }

        [Display(Name = "Publish on date")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime PublishDate { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Price> Prices { get; set; }

    }
}