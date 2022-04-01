using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFactory.Models
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public ServiceResult()
        {
            IsSuccess = true;
        }

        public ServiceResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
