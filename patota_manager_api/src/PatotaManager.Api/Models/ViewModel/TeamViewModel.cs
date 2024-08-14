using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patota_manager_api.src.PatotaManager.Api.Models.ViewModel
{
    public class TeamViewModel
    {
        public string Name { get; set; }
        public string City { get; set; }

        public string Uf { get; set; }

        public string Address { get; set; }

        public int AddressNumber { get; set; }
        public string SkillLevel { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }


    }
}