namespace RestAPI.Models.DTOs.DesignDTO
{
    public class DesignDTO : CreateDesignDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
