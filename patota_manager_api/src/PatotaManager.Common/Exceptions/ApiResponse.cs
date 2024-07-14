using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patota_manager_api.src.PatotaManager.Common.Exceptions
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse(bool success, string message, object data = null, List<string> errors = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors ?? new List<string>();
        }
    }

}