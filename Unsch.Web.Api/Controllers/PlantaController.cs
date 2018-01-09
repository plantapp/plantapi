using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Unsch.Web.Api.Helper;
using Unsch.Web.Api.Model;
using Unsch.Web.Api.Provider;
using Unsch.Web.Api.Repository;

namespace Unsch.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/plant")]
    public class PlantaController : Controller
    {
        private readonly IPlantaRepository _planta;
        private readonly IUsuariosRepository _usuario;
        private readonly IHostingEnvironment _env;
        public PlantaController(IPlantaRepository _planta, IUsuariosRepository _usuario, IHostingEnvironment _env)
        {
            this._planta = _planta;
            this._usuario = _usuario;
            this._env = _env;
        }
        [HttpPost("validate")]
        public IActionResult Validate([FromBody] PlantaValidator rep)
        {
            try
            {
                string Guid = System.Guid.NewGuid().ToString();
                List<SearchInfo> files = _planta.fGetFiles();
                rep.ImageName = Guid;
                rep.status = false;
                if (files.Count > 0)
                {
                    SearchInfo oSearchModel = PlantaProvider.fSearch(rep.Image, files);
                    if (oSearchModel != null && oSearchModel.Porcentaje < 15)
                    {
                        var omodel = _planta.findPlanta(oSearchModel.Id);
                        rep.Id = omodel.Id;
                        rep.status = true;
                    }
                }
                return Ok(rep);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, _env);
                throw new PlantaException(ex.Message, ex.InnerException);
            }
        }
        [HttpPost("planta")]
        public IActionResult create([FromBody] PlantaEntity rep)
        {
            try
            {
                string Guid = System.Guid.NewGuid().ToString();
                rep.ImagenName = Guid;
                _planta.create(rep);
                return Ok(rep);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, _env);
                throw new PlantaException(ex.Message, ex.InnerException);
            }
        }
        [HttpGet]
        public IActionResult findAllPlantas()
        {
            try
            {
                List<PlantaInfo> result = _planta.ListarPlantas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, _env);
                throw new PlantaException(ex.Message, ex.InnerException);
            }
        }
        [HttpGet("{id}")]
        public IActionResult findPlanta(string id)
        {
            try
            {
                PlantaEntity result = _planta.findPlanta(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, _env);
                throw new PlantaException(ex.Message, ex.InnerException);
            }
        }
        [HttpGet("search/{plant}")]
        public IActionResult searchAllPlantas(string plant)
        {
            try
            {
                List<PlantaInfo> result = _planta.searchlantas(plant);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, _env);
                throw new PlantaException(ex.Message, ex.InnerException);
            }
        }
        [HttpGet("registros/{id}")]
        public IActionResult getRegistros(string id) {
            try
            {
                List<PlantaInfo> result = _planta.ListarRegistros(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, _env);
                throw new PlantaException(ex.Message, ex.InnerException);
            }
        }


        [HttpPost("signup")]
        public IActionResult Signup([FromBody] UsuarioEntity rep)
        {
            try
            {
                rep = _usuario.singup(rep);
                return Ok(rep);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, _env);
                throw new PlantaException(ex.Message, ex.InnerException);
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioEntity rep)
        {
            try
            {
                rep = _usuario.login(rep.UserName, rep.Password);
                return Ok(rep);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, _env);
                throw new PlantaException(ex.Message, ex.InnerException);
            }
        }
        [HttpGet("User/{id}")]
        public IActionResult findUsuario(string id)
        {
            try
            {
                UsuarioInfo rep = _usuario.findUsuario(id);
                return Ok(rep);
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, _env);
                throw new PlantaException(ex.Message, ex.InnerException);
            }
        }
    }
}