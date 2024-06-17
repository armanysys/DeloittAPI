using DeloittAPI.Interface;
using DeloittAPI.Models;
using DeloittAPI.Enum;

namespace DeloittAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly Dictionary<int, Product> _products;

        public ProductService()
        {
            _products = InitializeProducts();
        }

        private Dictionary<int, Product> InitializeProducts()
        {
            return new Dictionary<int, Product>
            {
                { 1, new Product { Id = 1, Quantity = 10, Capacity = 100 } },
                { 2, new Product { Id = 2, Quantity = 20, Capacity = 200 } },
            };
        }

        public async Task<ServiceResponse> GetAllProductsAsync()
        {
            try
            {
                // Return all products
                return await Task.FromResult(ServiceResponse.CreateSuccess(_products.Values.AsEnumerable()));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ServiceResponse.CreateFailure(ex.Message, ServiceResponseStatus.InternalServerError));
            }
        }

        public async Task<ServiceResponse> SetProductCapacityAsync(int productId, int capacity)
        {
            try
            {
                if (!_products.ContainsKey(productId))
                {
                    _products.Add(productId, new Product { Id = productId, Quantity = 0, Capacity = capacity });
                    return await Task.FromResult(ServiceResponse.CreateSuccess("Product added successfully."));
                }
                return await Task.FromResult(ServiceResponse.CreateFailure("Product with given ID already exists.", ServiceResponseStatus.BadRequest));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ServiceResponse.CreateFailure(ex.Message, ServiceResponseStatus.InternalServerError));
            }
            
        }

        public async Task<ServiceResponse> ReceiveProductAsync(int productId, int quantity)
        {
            try
            {
                if (_products.TryGetValue(productId, out var product))
                {
                    if (product.Quantity + quantity <= product.Capacity)
                    {
                        product.Quantity += quantity;
                        return await Task.FromResult(ServiceResponse.CreateSuccess("Product received successfully."));
                    }
                    return await Task.FromResult(ServiceResponse.CreateFailure("Product quantity exceeds capacity.", ServiceResponseStatus.BadRequest));
                }
                return await Task.FromResult(ServiceResponse.CreateFailure("Product not found.", ServiceResponseStatus.NotFound));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ServiceResponse.CreateFailure(ex.Message, ServiceResponseStatus.InternalServerError));
            }
          
        }

        public async Task<ServiceResponse> DispatchProductAsync(int productId, int quantity)
        {

            try
            {
                if (_products.TryGetValue(productId, out var product))
                {
                    if (quantity <= product.Quantity)
                    {
                        product.Quantity -= quantity;
                        return await Task.FromResult(ServiceResponse.CreateSuccess("Product received successfully."));
                    }
                    return await Task.FromResult(ServiceResponse.CreateFailure("Product quantity dispatch more than available.", ServiceResponseStatus.BadRequest));

                }
                return await Task.FromResult(ServiceResponse.CreateFailure("Product not found.", ServiceResponseStatus.NotFound));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ServiceResponse.CreateFailure(ex.Message, ServiceResponseStatus.InternalServerError));
            }
         
        }
    }

}

