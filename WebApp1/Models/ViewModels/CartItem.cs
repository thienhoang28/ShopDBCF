using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp1.Models.ViewModels
{
	public class CartItem
	{
		[Key]
		public long ProductId { get; set; }
		public string ProductName { get; set; }
		public string ImageUrl { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }

		public CartItem(Product product, int quantity)
		{
			ProductId = product.Id;
			ProductName = product.Name;
			ImageUrl = product.FeatureImage;
			Quantity = quantity;
			Price = product.Prices.First().Value;
		}
	}
}