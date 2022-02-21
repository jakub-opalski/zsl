using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalFacilityAPI.Models
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public ResponseModel() { }
    }

    public class ResponseModel<T> : ResponseModel
    {
        public T Result { get; set; }
    }
}
