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

    }
}