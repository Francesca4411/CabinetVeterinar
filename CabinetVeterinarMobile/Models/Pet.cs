using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel.DataAnnotations;

namespace CabinetVeterinarMobile.Models
{
    public class Pet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(80), NotNull]
        public string Name { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.MaxLength(40), NotNull]
        public string Species { get; set; } = "Dog";

        [System.ComponentModel.DataAnnotations.MaxLength(40)]
        public string? Breed { get; set; }

        public int? AgeYears { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(120)]
        public string? OwnerName { get; set; }
    }
}
