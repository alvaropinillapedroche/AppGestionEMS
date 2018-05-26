using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Matriculas
    {
        public int Id { get; set; }

        [Display(Name = "Alumno")]
        public string alumnoId { get; set; }
        public virtual ApplicationUser alumno { get; set; }

        [Display(Name = "Curso")]
        public int cursoId { get; set; }
        public virtual Cursos curso { get; set; }

        [Display(Name = "Grupo")]
        public int grupoId { get; set; }
        public virtual GrupoClases grupo { get; set; }

        public DateTime fecha { get; set; }
    }
}