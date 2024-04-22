using System.ComponentModel.DataAnnotations;

namespace Store.Model
{
    public class PhotoProduit
    {
       
        //IdProduit deja existe est ce qu'on doit faire IdPhoto au lieu de IdProduit??
        public int PhotoProduitId { get; set; }
        public String UrlImage { get; set; }
        public Produit Produit { get; set; }
        public int ProduitId { get; set; }


    }
}
