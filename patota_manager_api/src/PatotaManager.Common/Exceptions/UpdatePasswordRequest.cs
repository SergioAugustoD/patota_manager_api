using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patota_manager_api.src.PatotaManager.Common.Exceptions
{
    public class UpdatePasswordRequest
    {
        public required string Email { get; set; }

        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
    }
}