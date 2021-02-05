using System;
using System.Collections.Generic;

#nullable disable

namespace WebServiceObligacionesVehiculares.Models
{
    public partial class Pago
    {
        public int Id { get; set; }
        public int? IdMulta { get; set; }
        public int? IdVehiculo { get; set; }
        public int? ValorPago { get; set; }

        public virtual Vehiculo IdVehiculoNavigation { get; set; }
    }
}
