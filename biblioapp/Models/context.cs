using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using biblioapp.Models;
namespace biblioapp.Models
{
    public class context : DbContext
    {
        public DbSet<Etudiant> etudiants { get; set; }
         public DbSet<Register> Registers { get; set; }
        public DbSet<Login> Logins { get; set; }

        public DbSet<Livre> livres { get; set; }
        public DbSet<Emprunt> emprunts { get; set; } 
    }
}