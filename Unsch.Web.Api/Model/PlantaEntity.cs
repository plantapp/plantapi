using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unsch.Web.Api.Model
{
    [Table("T_PLANTA")]
    public class PlantaEntity
    {
        [Key, Column("ID")]
        public string Id { get; set; }
        [Column("USURARIO_ID"), MaxLength(100)]
        public string UsuarioId { get; set; }
        [Required, Column("IMAGEN_BASE64")]
        public string Imagen { get; set; }
        [Required, Column("NOMBRE_ARCHIVO"), MaxLength(100)]
        public string ImagenName { get; set; }
        [Required, Column("NOMBRE_PLANTA"), MaxLength(200)]
        public string Nombre { get; set; }
        [Column("REINO"), MaxLength(200)]
        public string Reino { get; set; }
        [Column("DIVISION"), MaxLength(200)]
        public string Division { get; set; }
        [Column("CLASE"), MaxLength(200)]
        public string Clase { get; set; }
        [Column("SUB_CLASE"), MaxLength(200)]
        public string SubClase { get; set; }
        [Column("ORDEN"), MaxLength(200)]
        public string Orden { get; set; }
        [Column("FAMILIA"), MaxLength(200)]
        public string Familia { get; set; }
        [Column("SUB_FAMILIA"), MaxLength(200)]
        public string SubFamilia { get; set; }
        [Column("TRIBU"), MaxLength(200)]
        public string Tribu { get; set; }
        [Column("GENERO"), MaxLength(200)]
        public string Genero { get; set; }
        [Column("ESPECIE"), MaxLength(200)]
        public string Especie { get; set; }
        [Column("DESCRIPCION"), MaxLength(800)]
        public string Descripcion { get; set; }
        [Column("UBICACION"), MaxLength(200)]
        public string Ubicacion { get; set; }
        [Column("FECHA"), MaxLength(100)]
        public string Fecha { get; set; }
    }
}
