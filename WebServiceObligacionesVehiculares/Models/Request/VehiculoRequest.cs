using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceObligacionesVehiculares.Models.Request
{
    public class VehiculoRequest
    {
        public int Id { get; set; }

        public string Patente { get; set; }

        public int IdModelo { get; set; }
    }
}
