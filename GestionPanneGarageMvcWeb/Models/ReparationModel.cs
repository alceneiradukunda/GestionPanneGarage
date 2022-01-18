using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionPanneGarageMvcWeb.Models
{
    public class ReparationModel
    {
           public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Telephone { get; set; }
            public string Plaque { get; set; }
            public string Marque { get; set; }
            public string Modele { get; set; }
            public double Quantite { get; set; }
            public double MontantTotal { get; set; }
            public DateTime DateReparation { get; set; }
            public string EtatReparation { get; set; }
            public int PanneId { get; set; }
       
            public int PannevehiculeId { get; set; }
            public string EtatVehicule { get; set; }
 
        }

    
}