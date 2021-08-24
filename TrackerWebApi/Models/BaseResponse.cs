using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.Models
{
    public class BaseResponse
    {
        [JsonProperty(Required = Required.Always)]
        public bool HasError { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Message { get; set; }
        public BaseResponse()
        {
            HasError = false;
            Message = "";
        }

        public BaseResponse SetError(string message = null)
        {
            HasError = true;
            Message = message ?? "Server Error";

            return this;
        }
        public BaseResponse SetSuccess(string message = "")
        {
            HasError = false;
            Message = message;

            return this;
        }
    }
}
