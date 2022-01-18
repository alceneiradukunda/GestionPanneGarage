using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionPanneGarageMvcWeb.Models
{
    public class PanneVehiculeModel
    {

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Plaque { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string Email { get; set; }
        public int CLIENTSID { get; set; }
        public DateTime DateEnregistrement{ get; set; }
        public string StatusClient { get; set; }
    }
}