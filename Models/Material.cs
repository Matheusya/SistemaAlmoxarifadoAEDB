using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAlmoxarifado.Models
{
   
    /// Material
    
    [Table("Materiais")]
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string UnidadeMedida { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Classificacao { get; set; } = string.Empty;

        [Required]
        public int EstoqueMinimo { get; set; }

        [Required]
        public int EstoqueAtual { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        // Navegação
        public virtual ICollection<EntradaMaterial> Entradas { get; set; } = new List<EntradaMaterial>();
        public virtual ICollection<SaidaMaterial> Saidas { get; set; } = new List<SaidaMaterial>();
        public virtual ICollection<AjusteEstoque> Ajustes { get; set; } = new List<AjusteEstoque>();
    }
}
