namespace UserManagement.Application.DTOs
{
    public class UserRequestDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
    }
}
