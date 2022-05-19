﻿using System.Collections.Generic;
using System.Linq;
using FlixOne.Web.Models;

namespace FlixOne.Web.Common
{
    public static class Extension
    {
        public static Product ToProductModel(this ProductViewModel productvm)
        {
            return new Product
            {
                CategoryId = productvm.CategoryId,
                Description = productvm.ProductDescription,
                Id = productvm.ProductId,
                Name = productvm.ProductName,
                Price = productvm.ProductPrice
            };
        }

        public static ProductViewModel ToProductvm(this Product productModel)
        {
            return new ProductViewModel
            {
                CategoryId = productModel.CategoryId,
                CategoryDescription = productModel.Category.Description,
                CategoryName = productModel.Category.Name,
                ProductDescription = productModel.Description,
                ProductId = productModel.Id,
                ProductImage = productModel.Image,
                ProductName = productModel.Name,
                ProductPrice = productModel.Price
            };
        }
        public static IEnumerable<Product> ToProductModel(this IEnumerable<ProductViewModel> productvm) => productvm.Select(ToProductModel).ToList();

        public static IEnumerable<ProductViewModel> ToProductvm(this IEnumerable<Product> productModel) => productModel.Select(ToProductvm).ToList();
    }
}
