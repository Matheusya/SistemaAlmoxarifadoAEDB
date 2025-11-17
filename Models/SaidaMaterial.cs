using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAlmoxarifado.Models
{
    
    ///Saída de Material
    
    [Table("SaidasMateriais")]
    public class SaidaMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MaterialId { get; set; }

        [Required]
        [StringLength(200)]
        public string SetorSolicitante { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Responsavel { get; set; } = string.Empty;

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public DateTime DataSaida { get; set; } = DateTime.Now;

        // Navegação
        [ForeignKey("MaterialId")]
        public virtual Material? Material { get; set; }
    }
}
