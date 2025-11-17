using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAlmoxarifado.Models
{
    
    ///Entrada de Material
    
    [Table("EntradasMateriais")]
    public class EntradaMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MaterialId { get; set; }

        [Required]
        [StringLength(200)]
        public string Fornecedor { get; set; } = string.Empty;

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CustoUnitario { get; set; }

        [StringLength(100)]
        public string? NumeroLote { get; set; }

        [StringLength(100)]
        public string? DataValidade { get; set; }

        [Required]
        public DateTime DataEntrada { get; set; } = DateTime.Now;

        // Navegação
        [ForeignKey("MaterialId")]
        public virtual Material? Material { get; set; }
    }
}
