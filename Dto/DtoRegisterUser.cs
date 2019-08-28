using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.API.Dto
{

    public class DtoRegisterUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(8, MinimumLength =3, ErrorMessage = "Contraseña entre 3 y 8 caracteres")]
        public string Password { get; set; }
        

    }
}
