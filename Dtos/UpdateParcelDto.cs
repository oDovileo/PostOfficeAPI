namespace PostOfficeAPI.Dtos
{
    public class UpdateParcelDto
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public decimal Weight { get; set; }
        public string Phone { get; set; }
        public int? PostId { get; set; }
        public string PostTown { get; set; }
        //public object PostTown { get; set; }
    }
}
