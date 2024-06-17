using System;
using DeloittAPI.Models;

namespace DeloittAPI.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Response> SetProductCapacityAsync(int productId, int capacity);
        Task<Response> ReceiveProductAsync(int productId, int quantity);
        Task<Response> DispatchProductAsync(int productId, int quantity);
    }
}

