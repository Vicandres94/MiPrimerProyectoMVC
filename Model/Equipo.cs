using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Equipos")]
    public class Equipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Equipo")]
        public int EquipoId { get; set; }

        [Required]
        [Display(Name = "Nombre Equipo")]
        public string NombreEquipo { get; set; }

        [Required]
        [Display(Name = "Especificación")]
        public string Especificacion { get; set; }

        public string Estado { get; set; }

        [ForeignKey("Sala")]
        public int SalaId { get; set; }

        public virtual Sala Sala { get; set; }
        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
