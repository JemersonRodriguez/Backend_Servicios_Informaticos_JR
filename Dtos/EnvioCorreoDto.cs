using System.ComponentModel.DataAnnotations;

namespace Backend_SSR_Servicios_Informaticos_JR.Dtos
{
    public class EnvioCorreoDto
    {
        [Required(ErrorMessage = "El campo de nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo de correo es obligatorio")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo de asunto es obligatorio")]
        public string Asunto { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo de mensaje es obligatorio")]
        public string Mensaje { get; set; } = string.Empty;
    }
}
