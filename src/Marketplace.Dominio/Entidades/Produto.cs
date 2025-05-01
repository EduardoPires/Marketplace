using System.ComponentModel.DataAnnotations;

namespace Marketplace.Dominio.Entidades
{
    public class Produto
    {
        [Key]
        public Guid Codigo { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        [Display(Name = "Categoria")]
        public Guid CategoriaCodigo { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
