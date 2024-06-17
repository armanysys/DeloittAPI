using System;
using DeloittAPI.Interface;
using DeloittAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeloittAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly Dictionary<int, Product> _products;

        public ProductService()
        {
            // Initialize Product Dictionary
            _products = new Dictionary<int, Product>
        {
            { 1, new Product { Id = 1, Quantity = 10, Capacity = 100 } },
            { 2, new Product { Id = 2, Quantity = 20, Capacity = 200 } },
        };
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            // Return all products
            return Task.FromResult(_products.Values.AsEnumerable());
        }

        public Task<Response> SetProductCapacityAsync(int productId, int capacity)
        {
            if (!_products.ContainsKey(productId))
            {
                _products.Add(productId, new Product { Id = productId, Quantity = 0, Capacity = capacity });
                return Task.FromResult(new Response { Success = true, Message = "Product added successfully." });
            }
            return Task.FromResult(new Response { Success = false, Message = "Product with given ID already exists." });
        }

        public Task<Response> ReceiveProductAsync(int productId, int quantity)
        {
            if (_products.TryGetValue(productId, out var product))
            {
                if (product.Quantity + quantity <= product.Capacity)
                {
                    product.Quantity += quantity;
                    return Task.FromResult(new Response { Success = true, Message = "Product received successfully." });
                }
                return Task.FromResult(new Response { Success = false, Message = "Product quantity exceeds capacity." });
            }
            return Task.FromResult(new Response { Success = false, Message = "Product not found." });
        }

        public Task<Response> DispatchProductAsync(int productId, int quantity)
        {
            if (_products.TryGetValue(productId, out var product))
            {
                if ( quantity <= product.Quantity) {
                    product.Quantity -= quantity;
                    return Task.FromResult(new Response { Success = true, Message = "Product received successfully." });
                }
                return Task.FromResult(new Response { Success = false, Message = "Product quantity dispatch more than available." });
                
            }
            return Task.FromResult(new Response { Success = false, Message = "Product not found." });
        }
    }

}

