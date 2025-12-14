using Backend_SSR_Servicios_Informaticos_JR.Dtos;
using Backend_SSR_Servicios_Informaticos_JR.Response;

namespace Backend_SSR_Servicios_Informaticos_JR.Services
{
    public interface IEnviarCorreoService
    {
        Task<ResponseData> EnviarCorreoAsync(EnvioCorreoDto dataCorreo);
    }
}
