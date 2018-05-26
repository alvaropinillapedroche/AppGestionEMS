using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Evaluaciones
    {
        public enum ConvocatoriaType
        {
            Ordinaria,
            Extraordinaria
        }
        public int Id { get; set; }

        [Display(Name = "Curso")]
        public int cursoId { get; set; }
        public virtual Cursos curso { get; set; }

        [Display(Name = "Alumno")]
        public string alumnoId { get; set; }
        public virtual ApplicationUser alumno { get; set; }

        public ConvocatoriaType convocatoria { get; set; }
        public float notaP1 { get; set; }
        public float notaP2 { get; set; }
        public float notaP3 { get; set; }
        public float notaP4 { get; set; }
        public float notaPractica { get; set; }
    }
}