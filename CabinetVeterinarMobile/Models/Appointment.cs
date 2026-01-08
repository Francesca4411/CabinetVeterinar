using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CabinetVeterinarMobile.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime StartAt { get; set; } = DateTime.Now.AddDays(1);

        [MaxLength(300)]
        public string? Notes { get; set; }

        // legatura appointment->pet
        public int PetId { get; set; }

        [MaxLength(120)]
        public string? VetName { get; set; }

        [MaxLength(120)]
        public string? ServiceName { get; set; }
    }
}
