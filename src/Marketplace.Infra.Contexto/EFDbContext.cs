using Marketplace.Dominio.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infra.Contexto
{
    public class EFDbContext(DbContextOptions<EFDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var categorias = new List<Categoria>();
            for (int i = 1; i <= 10; i++)
            {
                categorias.Add(new Categoria
                {
                    Codigo = Guid.Parse($"00000000-0000-0000-0000-{i.ToString("D12")}"),
                    Nome = $"Categoria {i}",
                    Descricao = $"Descrição da categoria {i}"
                });
            }

            modelBuilder.Entity<Categoria>().HasData(categorias);

            var produtos = new List<Produto>();
            int prodCount = 1;
            foreach (var categoria in categorias)
            {
                for (int j = 1; j <= 10; j++)
                {
                    produtos.Add(new Produto
                    {
                        Codigo = Guid.Parse($"11111111-1111-1111-1111-{prodCount.ToString("D12")}"),
                        Nome = $"Produto {prodCount}",
                        Descricao = $"Descrição do produto {prodCount}",
                        Preco = 10.0m + prodCount,
                        Estoque = 5 + (prodCount % 10),
                        CategoriaCodigo = categoria.Codigo,
                        Imagem = ImagemPadrao
                    });
                    prodCount++;
                }
            }


            modelBuilder.Entity<Produto>().HasData(produtos);
        }
        public static byte[] ImagemPadrao => Convert.FromBase64String(
     "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFElEQVR42mP8z/D/PwMDAwMTAwMAAAcDAFUzB2FYAAAAAElFTkSuQmCC"
 );


    }
}