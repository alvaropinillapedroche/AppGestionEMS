using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public enum Turno { mañana, tarde }
    public class GrupoClases
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public Turno turno { get; set; }
        public string aula { get; set; }
        public int capacidad { get; set; }
    }
}