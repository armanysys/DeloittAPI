using System;
namespace DeloittAPI.Models
{
    public class Response 
    {
        public bool Success { get; set; } = false;
        public string? Message { get; set; } = "Error";
    }
}

