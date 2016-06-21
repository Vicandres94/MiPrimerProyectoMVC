using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("TipoDocumentos")]
    public class TipoDocumento
    {
        [Key]
        [Display(Name = "Tipo Documento")]
        public int TipoDocId { get; set; }
        [Display(Name = "Tipo Documento")]
        public string Documento { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
