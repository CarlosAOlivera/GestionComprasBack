using System.Threading.Tasks;
using LionDev.Models;

public interface IUsuarioService
{
    Task<Usuario> GetUsuarioByEmailAsync(string email);
    bool VerifyPassword(Usuario usuario, string password);
    string HashPassword(string password);
}