using System.ComponentModel.DataAnnotations;

namespace CabinetVeterinarWeb.Models;

public class Pet
{
    public int Id { get; set; }

    [Required, StringLength(80)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(40)]
    public string Species { get; set; } = "Dog";

    [StringLength(40)]
    public string? Breed { get; set; }

    [Range(0, 80)]
    public int? AgeYears { get; set; }

    [Required]
    public int OwnerId { get; set; }
    public Owner? Owner { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
