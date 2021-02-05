using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceObligacionesVehiculares.Models.Request
{
    public class PermisoCirculacionRequest
    {
        public int Id { get; set; }

        public int ValorPermiso { get; set; }

        public int IdModelo { get; set; }
    }
}
