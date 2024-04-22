using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointsFidelite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "produits",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QteStock = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produits", x => x.IdProduit);
                });

            migrationBuilder.CreateTable(
                name: "commandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCommande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Etat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_commandes_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paniers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paniers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_paniers_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "att_produits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_att_produits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_att_produits_produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "produits",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorits",
                columns: table => new
                {
                    IdFavoris = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorits", x => x.IdFavoris);
                    table.ForeignKey(
                        name: "FK_Favorits_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorits_produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "produits",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "photoProduits",
                columns: table => new
                {
                    PhotoProduitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photoProduits", x => x.PhotoProduitId);
                    table.ForeignKey(
                        name: "FK_photoProduits_produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "produits",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variante",
                columns: table => new
                {
                    IdVariante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QteStock = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variante", x => x.IdVariante);
                    table.ForeignKey(
                        name: "FK_Variante_produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "produits",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paiement",
                columns: table => new
                {
                    IdPaiement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePaimenet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Montant = table.Column<double>(type: "float", nullable: false),
                    modePaiement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiement", x => x.IdPaiement);
                    table.ForeignKey(
                        name: "FK_Paiement_commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reclamations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reclamations_commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "att_variantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VarianteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_att_variantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_att_variantes_Variante_VarianteId",
                        column: x => x.VarianteId,
                        principalTable: "Variante",
                        principalColumn: "IdVariante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ligneCommandes",
                columns: table => new
                {
                    IdLigneCommande = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    ProduitUnitaire = table.Column<double>(type: "float", nullable: false),
                    VarianteId = table.Column<int>(type: "int", nullable: false),
                    CommandeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ligneCommandes", x => x.IdLigneCommande);
                    table.ForeignKey(
                        name: "FK_ligneCommandes_commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ligneCommandes_Variante_VarianteId",
                        column: x => x.VarianteId,
                        principalTable: "Variante",
                        principalColumn: "IdVariante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LignePanier",
                columns: table => new
                {
                    IdLignePanier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    PanierId = table.Column<int>(type: "int", nullable: false),
                    VarianteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignePanier", x => x.IdLignePanier);
                    table.ForeignKey(
                        name: "FK_LignePanier_paniers_PanierId",
                        column: x => x.PanierId,
                        principalTable: "paniers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LignePanier_Variante_VarianteId",
                        column: x => x.VarianteId,
                        principalTable: "Variante",
                        principalColumn: "IdVariante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "photoVariantes",
                columns: table => new
                {
                    IdPhoto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VarianteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photoVariantes", x => x.IdPhoto);
                    table.ForeignKey(
                        name: "FK_photoVariantes_Variante_VarianteId",
                        column: x => x.VarianteId,
                        principalTable: "Variante",
                        principalColumn: "IdVariante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    VarianteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviews_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviews_Variante_VarianteId",
                        column: x => x.VarianteId,
                        principalTable: "Variante",
                        principalColumn: "IdVariante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRetour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeRetour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LigneCommandeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retour_ligneCommandes_LigneCommandeId",
                        column: x => x.LigneCommandeId,
                        principalTable: "ligneCommandes",
                        principalColumn: "IdLigneCommande",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_att_produits_ProduitId",
                table: "att_produits",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_att_variantes_VarianteId",
                table: "att_variantes",
                column: "VarianteId");

            migrationBuilder.CreateIndex(
                name: "IX_commandes_ClientId",
                table: "commandes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorits_ClientId",
                table: "Favorits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorits_ProduitId",
                table: "Favorits",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_ligneCommandes_CommandeId",
                table: "ligneCommandes",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_ligneCommandes_VarianteId",
                table: "ligneCommandes",
                column: "VarianteId");

            migrationBuilder.CreateIndex(
                name: "IX_LignePanier_PanierId",
                table: "LignePanier",
                column: "PanierId");

            migrationBuilder.CreateIndex(
                name: "IX_LignePanier_VarianteId",
                table: "LignePanier",
                column: "VarianteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paiement_CommandeId",
                table: "Paiement",
                column: "CommandeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_paniers_ClientId",
                table: "paniers",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_photoProduits_ProduitId",
                table: "photoProduits",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_photoVariantes_VarianteId",
                table: "photoVariantes",
                column: "VarianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamations_CommandeId",
                table: "Reclamations",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_Retour_LigneCommandeId",
                table: "Retour",
                column: "LigneCommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_ClientId",
                table: "reviews",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_VarianteId",
                table: "reviews",
                column: "VarianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Variante_ProduitId",
                table: "Variante",
                column: "ProduitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "att_produits");

            migrationBuilder.DropTable(
                name: "att_variantes");

            migrationBuilder.DropTable(
                name: "Favorits");

            migrationBuilder.DropTable(
                name: "LignePanier");

            migrationBuilder.DropTable(
                name: "Paiement");

            migrationBuilder.DropTable(
                name: "photoProduits");

            migrationBuilder.DropTable(
                name: "photoVariantes");

            migrationBuilder.DropTable(
                name: "Reclamations");

            migrationBuilder.DropTable(
                name: "Retour");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "paniers");

            migrationBuilder.DropTable(
                name: "ligneCommandes");

            migrationBuilder.DropTable(
                name: "commandes");

            migrationBuilder.DropTable(
                name: "Variante");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "produits");
        }
    }
}
