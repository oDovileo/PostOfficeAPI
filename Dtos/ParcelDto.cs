namespace PostOfficeAPI.Dtos
{
    public class ParcelDto
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public decimal Weight { get; set; }
        public string Phone { get; set; }
        public int? PostId { get; set; }
        public string PostTown { get; set; }
    }
}
