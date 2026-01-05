using System.ComponentModel.DataAnnotations;

namespace CabinetVeterinarWeb.Models;

public class Service
{
    public int Id { get; set; }

    [Required, StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [Range(0, 99999)]
    public decimal Price { get; set; }

    [StringLength(300)]
    public string? Description { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}

