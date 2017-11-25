using Unsch.Web.Api.Model;

namespace Unsch.Web.Api.Repository
{
    public interface IUsuariosRepository
    {
        UsuarioEntity login(string user, string pass);
        UsuarioEntity singup(UsuarioEntity model);
        UsuarioInfo findUsuario(string id);

    }
}