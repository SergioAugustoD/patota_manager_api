using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patota_manager_api.src.PatotaManager.Api.Models.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}