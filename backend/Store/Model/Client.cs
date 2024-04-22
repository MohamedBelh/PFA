using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;

namespace Store.Model
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adresse { get; set; }
        public int PointsFidelite { get; set; }
        public IList<Favorit> Favorits { get; set; }
        public IList<Review> Reviews { get; set; }
        public Panier Panier { get; set; }
    }


}

