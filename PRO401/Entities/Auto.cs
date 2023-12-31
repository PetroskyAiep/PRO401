﻿using System.ComponentModel.DataAnnotations;

namespace PRO401.Entities
{
    public class Auto
    {
        public int Id { get; set; }

        [MaxLength(6)]
        public string Patente {  get; set; }

        public int MarcaId  { get; set; }

        public int ModeloId { get; set; }

        [MaxLength(50)]
        public string? Color { get; set; }
        public int CarroceriaId { get; set; }
    }
}
