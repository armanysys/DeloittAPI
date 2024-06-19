using DeloittAPI.Enum;
namespace DeloittAPI.Models
{
    public class ServiceResponse
    {
        public bool Success { get; set; }
        public IEnumerable<Product>? Data { get; set; }
        public string Message { get; set; } = String.Empty;
        public ServiceResponseStatus Status { get; set; }

        public static ServiceResponse CreateSuccess(String message)
        {
            return new ServiceResponse { Success = true, Message = message, Status = ServiceResponseStatus.Success };
        }

        public static ServiceResponse CreateSuccess(IEnumerable<Product> data)
        {
            return new ServiceResponse { Success = true, Data = data, Status = ServiceResponseStatus.Success };
        }

        public static ServiceResponse CreateFailure(string message, ServiceResponseStatus status)
        {
            return new ServiceResponse { Success = false, Message = message, Status = status };
        }
    }
}
