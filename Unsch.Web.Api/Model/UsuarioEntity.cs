using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unsch.Web.Api.Model
{
    [Table("T_USUARIO")]
    public class UsuarioEntity
    {
        [Key, Column("ID")]
        public string Id { get; set; }
        [Required, Column("NOMBRES"), MaxLength(200)]
        public string Nombres { get; set; }
        [Required, Column("USER_NAME"), MaxLength(100)]
        public string UserName { get; set; }
        [Required, Column("PASSWORD"), MaxLength(100)]
        public string Password { get; set; }
        [Required, Column("EMAIL"), MaxLength(100)]
        public string Email { get; set; }
        [Required, Column("IMAGE")]
        public string Image { get; set; }
    }
}
