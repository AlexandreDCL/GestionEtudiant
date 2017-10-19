using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace GestionEtudiants.Models
    {
        public class Etudiant
        {
            public string Matricule { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Localite { get; set; }
        }
    }

