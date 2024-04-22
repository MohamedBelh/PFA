using System.ComponentModel.DataAnnotations;

namespace Store.Model
{
    public class Produit
    {
        [Key]
        public int IdProduit { get; set; }
        public int QteStock { get; set; }
        public double Prix { get; set; }
        public IList<Variante> Variantes { get; set; }
        public IList<PhotoProduit> PPs { get; set; }
        public IList<Favorit> Favorits { get; set; }
        //public IList<Att_Produit> Att_Ps { get; set; }
    }
}
