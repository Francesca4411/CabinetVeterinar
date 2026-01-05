using System.ComponentModel.DataAnnotations;

namespace CabinetVeterinarWeb.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(80)]
        public string LastName { get; set; } = string.Empty;

        [Phone, StringLength(30)]
        public string? Phone { get; set; }

        [EmailAddress, StringLength(120)]
        public string? Email { get; set; }

        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
