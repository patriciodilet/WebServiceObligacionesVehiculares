using System;
using System.Collections.Generic;

#nullable disable

namespace WebServiceObligacionesVehiculares.Models
{
    public partial class Multum
    {
        public int Id { get; set; }
        public int? ValorMulta { get; set; }
        public int? IdVehiculo { get; set; }

        public virtual Vehiculo IdVehiculoNavigation { get; set; }
    }
}
