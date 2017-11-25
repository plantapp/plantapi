using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unsch.Web.Api.Helper;
using Unsch.Web.Api.Model;
using Unsch.Web.Api.Repository;

namespace Unsch.Web.Api.Provider
{
    public class PlantaProvider
    {
        public static SearchInfo fSearch(string imagen, List<SearchInfo> files)
        {
            SearchInfo result = null;
            foreach (SearchInfo search in files)
            {              
                search.Porcentaje = ComparatorHelper.Compare(imagen, search.Imagen);
            }
            if (files.Count > 0)
            {
                float minimo = files.Min(t => t.Porcentaje);
                result = files.Where(t => t.Porcentaje == minimo).FirstOrDefault();
            }
            return result;

        }        
    }
}