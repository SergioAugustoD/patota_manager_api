using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patota_manager_api.src.PatotaManager.Api.Models.ViewModel
{
    public class TeamViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string SkillLevel { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }


    }
}