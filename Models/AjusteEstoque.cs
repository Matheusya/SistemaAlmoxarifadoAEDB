using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAlmoxarifado.Models
{
    
    /// Ajuste de Estoque
 
    [Table("AjustesEstoque")]
    public class AjusteEstoque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MaterialId { get; set; }

        [Required]
        public int QuantidadeAnterior { get; set; }

        [Required]
        public int NovaQuantidade { get; set; }

        [Required]
        [StringLength(500)]
        public string Justificativa { get; set; } = string.Empty;

        [Required]
        public DateTime DataAjuste { get; set; } = DateTime.Now;

        // Navegação
        [ForeignKey("MaterialId")]
        public virtual Material? Material { get; set; }
    }
}
