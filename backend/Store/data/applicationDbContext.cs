using Microsoft.EntityFrameworkCore;
using Store.Model;

namespace Store.data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }


        public DbSet<Variante> Variante { get; set; }
        public DbSet<LignePanier> LignePanier { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Reclamation> Reclamations { get; set; }
        public DbSet<Produit> produits { get; set; }
        public DbSet<PhotoVariante> photoVariantes { get; set; }
        public DbSet<PhotoProduit> photoProduits { get; set; }
        public DbSet<Panier> paniers { get; set; }
        public DbSet<LigneCommande> ligneCommandes { get; set; }
        public DbSet<Favorit> Favorits { get; set; }
        public DbSet<Commande> commandes { get; set; }
        public DbSet<Client> clients { get; set; }

        public DbSet<Att_Variante> att_variantes { get; set; }
        public DbSet<Att_Produit> att_produits { get; set; }

    }
    }








