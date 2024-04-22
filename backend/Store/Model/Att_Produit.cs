using System.ComponentModel.DataAnnotations;

namespace Store.Model
{
    public class Att_Produit
    {
        public int Id { get; set; }
        public String Cle { get; set; }
        public String Valeur { get; set; }
        public Produit Produit { get; set; }
        public int ProduitId { get; set; }
    }
}
