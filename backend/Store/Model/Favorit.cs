using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Model
{
    public class Favorit
    {
        [Key]
        public int IdFavoris { get; set; }
        public Client Client { get; set; }
       
        public int ClientId { get; set; }

        public Produit Produit { get; set; }
       
        public int ProduitId { get; set; }
    }
}
