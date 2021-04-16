using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp1.Models.ViewModels
{
    public class ProductView
    {
        public ProductView()
        {

        }
        //Copy tu product -> ProductView
        public ProductView(Product product)
        {
            if (product == null)
            {
                return;
            }

            Id = product.Id;
            Name = product.Name;
            CategoryId = product.CategoryId;
            ModelCar = product.ModelCar;
            Description = product.Description;
            FeatureImage = product.FeatureImage;
            Imglink1 = product.Imglink1;
            Imglink2 = product.Imglink2;
            Imglink3 = product.Imglink3;
            Imglink4 = product.Imglink4;
            Imglink5 = product.Imglink5;
            Status = product.Status;
            PublishDate = product.PublishDate;
            Price = product.Prices.Where(p => p.Type == Enums.PriceType.ProductPrice && p.ApplyDate <= DateTime.Now)
                .OrderByDescending(p => p.ApplyDate)
                .FirstOrDefault()?.Value ?? 0;

        }
        //Copy tu ProductView -> product
        public void CopyToProduct(ref Product product)
        {
            product.Name = Name;
            if (product.Prices.Count > 0)
            {
                product.Prices.First().Value = Price;   // TODO: use product price
            }
            else
            {
                product.Prices.Add(new Price { ApplyDate = DateTime.Today, ProductId = product.Id, Type = Enums.PriceType.ProductPrice, Value = Price });
            }
            product.PublishDate = PublishDate;
            product.Status = Status;
            product.CategoryId = CategoryId;
            product.Description = Description;
            product.ModelCar = ModelCar;
            //product.FeatureImage = FeatureImage;
            //product.Imglink1 = Imglink1;
            //product.Imglink2 = Imglink2;
            //product.Imglink3 = Imglink3;
            //product.Imglink4 = Imglink4;
            //product.Imglink5 = Imglink5;
            product.Id = Id;
        }
        public long Id { get; set; }

        public string Name { get; set; }

        public long CategoryId { get; set; }

        public string ModelCar { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string FeatureImage { get; set; }

        public string Imglink1 { get; set; }

        public string Imglink2 { get; set; }

        public string Imglink3 { get; set; }

        public string Imglink4 { get; set; }

        public string Imglink5 { get; set; }

        public PublishStatus Status { get; set; }

        public DateTime PublishDate { get; set; }

        public decimal Price { get; set; }

        public HttpPostedFileBase UploadFile { get; set; }

        public HttpPostedFileBase UploadFile1 { get; set; }

        public HttpPostedFileBase UploadFile2 { get; set; }

        public HttpPostedFileBase UploadFile3 { get; set; }

        public HttpPostedFileBase UploadFile4 { get; set; }

        public HttpPostedFileBase UploadFile5 { get; set; }
    }
}