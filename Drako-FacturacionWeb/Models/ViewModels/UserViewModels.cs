using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Drako_FacturacionWeb.Models.ViewModels
{
    public class UserViewModels
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        [StringLength(30, ErrorMessage = "Longitud maxima es 30")]
        public string usuario { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        [StringLength(30, ErrorMessage = "Longitud maxima es 30")]
        public string nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        [StringLength(30,ErrorMessage = "Longitud maxima es 30")]
        public string apellidos { get; set; }

        [Required]
        [Display(Name = "Correo electronico")]
        [StringLength(150, ErrorMessage = "Longitud maxima es 150")]
        [EmailAddress]
        public string correo { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [StringLength(200, ErrorMessage = "Longitud maxima es 200")]
        public string clave { get; set; }

        [Display(Name = "Confimar contraseña")]
        [DataType(DataType.Password)]
        [Compare("clave",ErrorMessage = "Las contraseñas no son iguales")]
        public string confirmarClave { get; set; }

        [Required]
        [Display(Name = "Estatus")]
        public int idState { get; set; }

        public DateTime fechaRegistro { get; set; }

        //PROPIEDADES ADICIONALES
        public string tipoEstatus { get; set; }
        public string mensajeError { get; set; }
    }





    public class EditUserViewModels
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        [StringLength(30, ErrorMessage = "Longitud maxima es 30")]
        public string usuario { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        [StringLength(30, ErrorMessage = "Longitud maxima es 30")]
        public string nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        [StringLength(30, ErrorMessage = "Longitud maxima es 30")]
        public string apellidos { get; set; }

        [Required]
        [Display(Name = "Correo electronico")]
        [StringLength(150, ErrorMessage = "Longitud maxima es 150")]
        [EmailAddress]
        public string correo { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [StringLength(200, ErrorMessage = "Longitud maxima es 200")]
        public string clave { get; set; }

        [Display(Name = "Confimar contraseña")]
        [DataType(DataType.Password)]
        [Compare("clave", ErrorMessage = "Las contraseñas no son iguales")]
        public string confirmarClave { get; set; }

        [Required]
        [Display(Name = "Estatus")]
        public int idState { get; set; }

        public DateTime fechaRegistro { get; set; }

        //PROPIEDADES ADICIONALES
        public string tipoEstatus { get; set; }
        public string mensajeError { get; set; }
    }
}