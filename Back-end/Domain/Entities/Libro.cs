﻿using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Libro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        [JsonIgnore]
        public ICollection<Alquiler> AlquilerNavigator { get; set; }
    }
}
