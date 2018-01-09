using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unsch.Web.Api.Helper;
using Unsch.Web.Api.Model;

namespace Unsch.Web.Api.Repository
{
    public class PlantaRepository : IPlantaRepository
    {
        private readonly DatabaseContext _context;
        private readonly ILogger _logger;
        public PlantaRepository(DatabaseContext _context, ILoggerFactory loggerFactory)
        {
            this._context = _context;
            _logger = loggerFactory.CreateLogger(nameof(PlantaRepository));
        }

        public List<PlantaInfo> ListarPlantas()
        {

            List<PlantaInfo> result = (from p in _context.Planta
                                       join u in _context.Usuario on p.UsuarioId equals u.Id into leftU
                                       from u in leftU.DefaultIfEmpty()
                                       select new PlantaInfo()
                                       {
                                           Id = p.Id,
                                           UserNombres = u.Nombres,
                                           UserImage = u.Image,
                                           Imagen = p.Imagen,
                                           ImagenName = p.ImagenName,
                                           Nombre = p.Nombre,
                                           Reino = p.Reino,
                                           Division = p.Division,
                                           Clase = p.Clase,
                                           SubClase = p.SubClase,
                                           Orden = p.Orden,
                                           Familia = p.Familia,
                                           SubFamilia = p.SubClase,
                                           Tribu = p.Tribu,
                                           Genero = p.Genero,
                                           Especie = p.Especie,
                                           Descripcion = p.Descripcion,
                                           Ubicacion = p.Ubicacion,
                                           Fecha = p.Fecha
                                       }).ToList();
            result.ForEach(item =>
            {
                item.UserImage = (item.UserImage == string.Empty ? "" : ImageHelper.getImage(item.UserImage));
                item.Imagen = ImageHelper.getImage(item.Imagen);
            });
            return result;

        }
        public List<PlantaInfo> searchlantas(string search)
        {
            List<PlantaInfo> result = (from p in _context.Planta
                                       join u in _context.Usuario on p.UsuarioId equals u.Id into leftU
                                       from u in leftU.DefaultIfEmpty()
                                       where p.Nombre.Contains(search) || p.Reino.Contains(search) || p.Division.Contains(search) || p.Clase.Contains(search) ||
                                       p.SubClase.Contains(search) || p.Orden.Contains(search) || p.Familia.Contains(search) || p.SubFamilia.Contains(search) ||
                                       p.Tribu.Contains(search) || p.Genero.Contains(search) || p.Especie.Contains(search) || p.Ubicacion.Contains(search)
                                       select new PlantaInfo()
                                       {
                                           Id = p.Id,
                                           UserNombres = u.Nombres,
                                           UserImage = u.Image,
                                           Imagen = p.Imagen,
                                           ImagenName = p.ImagenName,
                                           Nombre = p.Nombre,
                                           Reino = p.Reino,
                                           Division = p.Division,
                                           Clase = p.Clase,
                                           SubClase = p.SubClase,
                                           Orden = p.Orden,
                                           Familia = p.Familia,
                                           SubFamilia = p.SubClase,
                                           Tribu = p.Tribu,
                                           Genero = p.Genero,
                                           Especie = p.Especie,
                                           Descripcion = p.Descripcion,
                                           Ubicacion = p.Ubicacion,
                                           Fecha = p.Fecha
                                       }).ToList();
            result.ForEach(item =>
            {
                item.UserImage = (item.UserImage == string.Empty ? "" : ImageHelper.getImage(item.UserImage));
                item.Imagen = ImageHelper.getImage(item.Imagen);
            });
            return result;
        }
        public List<SearchInfo> fGetFiles()
        {
            List<SearchInfo> model = _context.Planta.Select(item => new SearchInfo { Id = item.Id, Imagen = item.Imagen }).ToList();
            return model;
        }
        public PlantaEntity create(PlantaEntity model)
        {
            model.Fecha = DateTime.Now.ToString();
            model.Id = System.Guid.NewGuid().ToString();
            var item = _context.Planta.Add(model);
            _context.SaveChanges();
            return item.Entity;
        }
        public PlantaEntity findPlanta(string id)
        {
            PlantaEntity omodel = _context.Planta.Find(id);
            if (omodel != null)
            {
                omodel.Imagen = ImageHelper.getImage(omodel.Imagen);
            }
            return omodel == null ? new PlantaEntity() : omodel;
        }

        public List<PlantaInfo> ListarRegistros(string id)
        {
            List<PlantaInfo> result = (from p in _context.Planta
                                       join u in _context.Usuario on p.UsuarioId equals u.Id
                                       where u.Id == id
                                       select new PlantaInfo()
                                       {
                                           Id = p.Id,
                                           UserNombres = u.Nombres,
                                           UserImage = u.Image,
                                           Imagen = p.Imagen,
                                           ImagenName = p.ImagenName,
                                           Nombre = p.Nombre,
                                           Reino = p.Reino,
                                           Division = p.Division,
                                           Clase = p.Clase,
                                           SubClase = p.SubClase,
                                           Orden = p.Orden,
                                           Familia = p.Familia,
                                           SubFamilia = p.SubClase,
                                           Tribu = p.Tribu,
                                           Genero = p.Genero,
                                           Especie = p.Especie,
                                           Descripcion = p.Descripcion,
                                           Ubicacion = p.Ubicacion,
                                           Fecha = p.Fecha
                                       }).ToList();
            result.ForEach(item =>
            {
                item.UserImage = (item.UserImage == string.Empty ? "" : ImageHelper.getImage(item.UserImage));
                item.Imagen = ImageHelper.getImage(item.Imagen);
            });
            return result;
        }
    }
}
