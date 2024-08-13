﻿namespace patota_manager_api.src.PatotaManager.Api.Models.DTOs
{
    public class TeamDTO
    {

        public Guid TeamId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string SkillLevel { get; set; }

        public string Description { get; set; }

        public Guid CreatedBy { get; set; }
    }
}
