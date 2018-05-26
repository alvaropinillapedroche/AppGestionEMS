using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Cursos
    {
        public int Id { get; set; }
        public String promocion { get; set; }
        public float notaCorte { get; set; }
        public int cupo { get; set; }
    }
}