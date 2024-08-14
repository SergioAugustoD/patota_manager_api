namespace patota_manager_api.src.PatotaManager.Api.Models.DTOs
{
    public class TeamDTO
    {

        public Guid TeamId { get; set; }

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
