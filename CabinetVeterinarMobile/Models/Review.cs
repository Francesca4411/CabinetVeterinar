using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CabinetVeterinarMobile.Models
{
    public class Review
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Rating { get; set; } = 5;

        [MaxLength(500)]
        public string Text { get; set; } = string.Empty;
        public int AppointmentId { get; set; }

    }
}
