namespace PostOfficeAPI.Dtos
{
    public class CreateParcelDto
    {      
        public string NameSurname { get; set; }
        public decimal Weight { get; set; }
        public string Phone { get; set; }
        public int? PostId { get; set; }         
    }
}
