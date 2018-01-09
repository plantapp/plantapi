using System.Collections.Generic;
using Unsch.Web.Api.Model;

namespace Unsch.Web.Api.Repository
{
    public interface IPlantaRepository
    {
        List<PlantaInfo> ListarPlantas();
        List<PlantaInfo> searchlantas(string search);
        List<SearchInfo> fGetFiles();
        PlantaEntity create(PlantaEntity model);
        PlantaEntity findPlanta(string id);
        List<PlantaInfo> ListarRegistros(string id);
    }
}