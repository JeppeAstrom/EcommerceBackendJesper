namespace Manero_Backend.Models.Dtos.User
{
    public class UserProfileDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
    }
}
