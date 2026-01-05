using System.ComponentModel.DataAnnotations;

namespace CabinetVeterinarWeb.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required, StringLength(500, MinimumLength = 10)]
        public string Text { get; set; } = string.Empty;

        [Required]
        public int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
