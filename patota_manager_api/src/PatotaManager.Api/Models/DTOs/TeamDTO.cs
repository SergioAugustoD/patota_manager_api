namespace patota_manager_api.src.PatotaManager.Api.Models.DTOs
{
    public class TeamDTO
    {

        public Guid TeamId { get; set; }

        public required string Name { get; set; }

        public required string Location { get; set; }

        public required string SkillLevel { get; set; }

        public required string Description { get; set; }

        public required Guid CreatedBy { get; set; }

        public required User User { get; set; }
    }
}
