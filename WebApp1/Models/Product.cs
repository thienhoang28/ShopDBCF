using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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

        [Display(Name = "Model")]
        public string ModelCar { get; set; }
        
        [MaxLength(500, ErrorMessage = "Content is too length.")]
        [AllowHtml]
        public string Description { get; set; }

        [MaxLength(250)]
        [Display(Name = "Featured image")]
        public string FeatureImage { get; set; }

        [MaxLength(250)]
        [Display(Name = "Image1")]
        public string Imglink1 { get; set; }

        [MaxLength(250)]
        [Display(Name = "Image2")]
        public string Imglink2 { get; set; }

        [MaxLength(250)]
        [Display(Name = "Image3")]
        public string Imglink3 { get; set; }

        [MaxLength(250)]
        [Display(Name = "Image4")]
        public string Imglink4 { get; set; }

        [MaxLength(250)]
        [Display(Name = "Image5")]
        public string Imglink5 { get; set; }

        public PublishStatus Status { get; set; }

        [Display(Name = "Publish on date")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime PublishDate { get; set; }

        public virtual Category Category { get; set; }

        [ScriptIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Price> Prices { get; set; }

    }
}