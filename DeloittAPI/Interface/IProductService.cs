using DeloittAPI.Models;

namespace DeloittAPI.Interface
{
    public interface IProductService
    {
        Task<ServiceResponse> GetAllProductsAsync();
        Task<ServiceResponse> SetProductCapacityAsync(int productId, int capacity);
        Task<ServiceResponse> ReceiveProductAsync(int productId, int quantity);
        Task<ServiceResponse> DispatchProductAsync(int productId, int quantity);
    }
}

