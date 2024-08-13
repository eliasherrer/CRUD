namespace CRUD.DTOs
{
    public class BrandUpdateDto
    {
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public string? BrandCountry { get; set; }
        public int PreId { get; set; }
    }
}
