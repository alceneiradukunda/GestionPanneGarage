//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionPanneGarageMvcWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reparation
    {
        public int Id { get; set; }
        public int ArticlesId { get; set; }
        public int PanneVehiculesId { get; set; }
        public double Quantite { get; set; }
        public System.DateTime DateReparation { get; set; }
        public double MontantTotal { get; set; }
        public string EtatReparation { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual PanneVehicule PanneVehicule { get; set; }
    }
}
