using Backend_SSR_Servicios_Informaticos_JR.Response;
using Backend_SSR_Servicios_Informaticos_JR.Dtos;
using Resend;

namespace Backend_SSR_Servicios_Informaticos_JR.Services
{
    public class EnviarCorreoService : IEnviarCorreoService
    {
        public ILogger<EnviarCorreoService> _logger;
        public readonly IResend _resend;
        public EnviarCorreoService(ILogger<EnviarCorreoService> logger, IResend resend)
        {
            _logger = logger;
            _resend = resend;
        }
        public async Task<ResponseData> EnviarCorreoAsync(EnvioCorreoDto dataCorreo)
        {
            ResponseData response = new ResponseData();
            if (dataCorreo == null)
            { 
                response.Exito = false;
                response.Mensaje = "Los datos del correo son nulos.";
                return response;
            }

            try {
                var message = new EmailMessage();

                // 1. FROM: DEBE ser tu dirección de correo verificada en Resend.
                // Puedes usar un nombre de tu empresa si lo deseas.
                message.From = $"Notificación Acme <onboarding@resend.dev>";

                // 2. TO: A dónde quieres que llegue el mensaje (tu propio correo).
                message.To.Add("jemerson0095@gmail.com");

                message.Subject = $"{dataCorreo.Asunto} - Nombre: {dataCorreo.Nombre} - Correo: {dataCorreo.Email}";
                message.HtmlBody = dataCorreo.Mensaje;

                ResendResponse resultado = await _resend.EmailSendAsync(message);

                if (resultado.Success) { 
                    response.Exito = true;
                    response.Mensaje = "Correo enviado exitosamente.";
                    return response;
                }
                else
                {
                    response.Exito = false;
                    response.Mensaje = "Error al enviar el correo.";
                    return response;
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error servicio externo al enviar el correo: {ex.Message}");
                response.Exito = false;
                response.Mensaje = "Error externo al enviar el correo.";
                return response;
            }
        }
    }
}
