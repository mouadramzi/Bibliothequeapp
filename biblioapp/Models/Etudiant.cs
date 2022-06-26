using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace biblioapp.Models
{
    public class Etudiant
    {
        [Key] 
        public int matricule { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string nom { get; set; }
        [Required]
        [Display(Name = "Prenom :")]
        public string prenom { get; set; }
        [Required]
        [Display(Name = "Date de naissance :")]
        public string datenaissnace { get; set; }
        [Required]
        [Display(Name = "Filiere :")]
        public string filiere { get; set; }
        [Required]
        [Display(Name = "Groupe :")]
        public string groupe { get; set; }
        public virtual Emprunt Emprunts { get; set; }


    }
}