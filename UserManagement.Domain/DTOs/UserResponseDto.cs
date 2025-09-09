namespace UserManagement.Domain.DTOs
{
    public class UserResponseDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
