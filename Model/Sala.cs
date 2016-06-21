using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sala
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Sala")]
        public int SalaId { get; set; }

        [Display(Name = "Nombre Sala")]
        public string Nombre { get; set; }

        [ForeignKey("Bloque")]
        public int BloqueId { get; set; }

        public virtual Bloque Bloque { get; set; }

        public virtual ICollection<Equipo> Equipos { get; set; }
    }
}
