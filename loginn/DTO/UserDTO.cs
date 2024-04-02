using System.ComponentModel.DataAnnotations;

namespace loginn.Data
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string username { get; set; }
        public string Password { get; set; }
    }
}
