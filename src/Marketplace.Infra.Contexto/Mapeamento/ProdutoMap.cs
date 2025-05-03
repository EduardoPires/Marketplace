using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Marketplace.Dominio.Entidades;

namespace Marketplace.Infra.Contexto.Mapeamento
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(t => t.Codigo);
            builder.Property(t => t.Nome).IsRequired();
            builder.Property(t => t.Descricao).IsRequired();
            builder.Property(t => t.Preco).HasPrecision(5,2).IsRequired();
            builder.Property(t => t.Imagem).IsRequired();
            builder.Property(t => t.Estoque).IsRequired();
            builder.ToTable("Produto");

        }
    }
}
