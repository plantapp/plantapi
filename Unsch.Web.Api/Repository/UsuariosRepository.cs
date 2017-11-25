using Microsoft.Extensions.Logging;
using System.Linq;
using Unsch.Web.Api.Helper;
using Unsch.Web.Api.Model;

namespace Unsch.Web.Api.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly DatabaseContext _context;
        private readonly ILogger _logger;
        public UsuariosRepository(DatabaseContext _context, ILoggerFactory loggerFactory)
        {
            this._context = _context;
            _logger = loggerFactory.CreateLogger(nameof(UsuariosRepository));
        }

        public UsuarioEntity login(string user, string pass)
        {
            var query = from u in _context.Usuario
                        where u.UserName == user && u.Password == pass
                        select u;
            UsuarioEntity result = query.FirstOrDefault();
            if (result != null)
            {
                result.Image = result.Image == string.Empty ? "" : ImageHelper.getImage(result.Image);
            }
            return result == null ? new UsuarioEntity() : result;
        }

        public UsuarioEntity singup(UsuarioEntity model)
        {
            model.Id = System.Guid.NewGuid().ToString();
            model = _context.Usuario.Add(model).Entity;
            _context.SaveChanges();
            return model;
        }
        public UsuarioInfo findUsuario(string id)
        {
            UsuarioInfo result = (from u in _context.Usuario
                                  where u.Id == id
                                  select new UsuarioInfo()
                                  {
                                      Id = id,
                                      Nombres = u.Nombres,
                                      UserName = u.UserName,
                                      Password = u.Password,
                                      Email = u.Email,
                                      Image = u.Image
                                  }).FirstOrDefault();
            if (result != null)
            {
                result.Image = result.Image == string.Empty ? "" : ImageHelper.getImage(result.Image);
            }
            return result == null ? new UsuarioInfo() : result;

        }    

    }
}
