using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace biblioapp.Models
{
    public class Livre
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Titre")]
        public string titre { get; set; }
        [Required]
        [Display(Name = "Date de sortie :")]
        public DateTime date { get; set; }
        [Required]
        [Display(Name = " Auteur :")]
        public string auteur { get; set; }
        [Required]
        [Display(Name = "Categorie :")]
        public string categorie { get; set; }
        public virtual Emprunt Emprunts { get; set; }

    }
}