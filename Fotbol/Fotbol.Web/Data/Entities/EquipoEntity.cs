using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fotbol.Web.Data.Entities
{
    public class EquipoEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} Nombre no puede tener mas de {1} carateres.")]
        [Required(ErrorMessage = "El Campo {0} Es Obligatorio.")]
        public  string Nombre { get; set; }
        [Display(Name = "Logo")]
        public  string LogoPath { get; set; }
    }
}
