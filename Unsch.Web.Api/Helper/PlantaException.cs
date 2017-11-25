using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unsch.Web.Api.Helper
{
    public class PlantaException : Exception
    {
        public PlantaException()
        { }

        public PlantaException(string message)
        : base(message)
        { }

        public PlantaException(string message, Exception innerException)
        : base(message, innerException)
        { }
    }
}
