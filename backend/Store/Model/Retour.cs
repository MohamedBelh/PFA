using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Model
{
    public class Retour
    {
        
        public int Id { get; set; }
        public DateTime DateRetour { get; set; }
        public string TypeRetour { get; set; }
        public string Commentaire { get; set; }

        public LigneCommande LigneCommande { get; set; }
        public int LigneCommandeId { get; set; }

    }
}
