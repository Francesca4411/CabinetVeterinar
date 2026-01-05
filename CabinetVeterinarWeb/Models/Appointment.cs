using System.ComponentModel.DataAnnotations;

namespace CabinetVeterinarWeb.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartAt { get; set; }

        [StringLength(300)]
        public string? Notes { get; set; }

        [Required]
        public int PetId { get; set; }
        public Pet? Pet { get; set; }

        [Required]
        public int VetId { get; set; }
        public Vet? Vet { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public Service? Service { get; set; }

        public Review? Review { get; set; }
    }
}
