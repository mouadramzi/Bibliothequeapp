using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace biblioapp.Models
{
    public class Emprunt
    {
        [Required]
        [Key ]
        [Display(Name = "ID Emprunt")]
        public int id { get; set; }
        [Display(Name = "Etudiant matricule ")]
        public int Matricule { get; set; }
        [Display(Name = "Livre code barre")]
        public int codelivre { get; set; }
        public virtual ICollection<Etudiant> Etudiants { get; set; }
        public virtual ICollection<Livre> Livres { get; set; }

    }
}