using System.ComponentModel.DataAnnotations;

namespace SistemaComercio.Model
{
    public class ProdutosModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="ERRO. O produto precisa conter um nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage =" ERRO. O valor do produto deve ser informado!")]
        public int Valor { get; set; }
        public int Quantidade { get; set; }

    }
}
