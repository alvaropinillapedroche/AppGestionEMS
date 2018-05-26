using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class AsignacionDocentes
    {
        public int Id { get; set; }

        [Display(Name = "Profesor")]
        public string profesorId { get; set; }
        public virtual ApplicationUser profesor { get; set; }

        [Display(Name = "Curso")]
        public int cursoId { get; set; }
        public virtual Cursos curso { get; set; }

        [Display(Name = "Grupo")]
        public int grupoId { get; set; }
        public virtual GrupoClases grupo { get; set; }

        public int numCreditosAsignados { get; set; }
    }
}