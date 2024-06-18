using DeloittAPI.Enum;
namespace DeloittAPI.Models
{
    public class ServiceResponse
    {
        private bool Success { get; set; }
        private IEnumerable<Product>? Data { get; set; }
        private string Message { get; set; } = String.Empty;
        private ServiceResponseStatus Status { get; set; }

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