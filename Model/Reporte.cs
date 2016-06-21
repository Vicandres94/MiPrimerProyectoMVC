using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reporte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Reporte")]
        public int ReporteId { get; set; }

        
        public DateTime Fecha_Reporte { get; set; }

       
        public DateTime Fecha_Realizado { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

       
        public string Estado { get; set; }

        [ForeignKey("Usuario")]
        public int UserId { get; set; }

        [ForeignKey("Equipo")]
        public int EquipoId { get; set; }

        
        public int User_RealizadoId { get; set; }

       
        [Display(Name = "Reportado por: ")]
        public int UserId_Reporte { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Equipo Equipo { get; set; }
    }
}
