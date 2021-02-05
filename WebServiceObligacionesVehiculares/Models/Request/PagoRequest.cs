using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceObligacionesVehiculares.Models.Request
{
    public class PagoRequest
    {
        public int Id { get; set; }
        public int IdMulta { get; set; }
        public int IdVehiculo { get; set; }
        public int ValorPago { get; set; }

    }
}
