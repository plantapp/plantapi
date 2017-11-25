using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unsch.Web.Api.Model
{
    public class UsuarioInfo
    {
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
