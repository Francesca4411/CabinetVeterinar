using System.ComponentModel.DataAnnotations;

namespace CabinetVeterinarWeb.Models;

public class Vet
{
    public int Id { get; set; }

    [Required, StringLength(120)]
    public string FullName { get; set; } = string.Empty;

    [StringLength(80)]
    public string? Specialty { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
