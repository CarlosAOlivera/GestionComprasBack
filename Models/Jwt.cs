using System.Security.Claims;

namespace LionDev.Models
{
    public class Jwt
    {
        public required string Key { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required string Subject { get; set; }

        public static dynamic validarToken(ClaimsIdentity identity, ApplicationDbContext context)
        {
            try
            {            
                if (identity.Claims.Count() == 0)
                {
                    return new
                    {
                        success = false,
                        message = "Token no válido",
                        result = ""
                    };
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;
                //Usuario usuario = Usuario.DB().FirstOrDefault(x => x.idUsuario == id);

                Comprador comprador = context.Compradores
                    .Where(x => x.IdComprador.ToString() == id)
                    .FirstOrDefault();

                return new
                {
                    success = true,
                    message = "exito",
                    //result = usuario
                    result = comprador
                };
            }
            catch (Exception ex) 
            {
                return new
                {
                    success = false,
                    message = "Catch: " + ex.Message,
                    result = ""
                };
            }
        }
    }
}
