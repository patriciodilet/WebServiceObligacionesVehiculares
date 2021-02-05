using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceObligacionesVehiculares.Models.Request
{
    public class MultaRequest
    {
        public int Id { get; set; }
        public int ValorMulta { get; set; }
        public int IdVehiculo { get; set; }
    }
}
