using System;
using System.Collections.Generic;

#nullable disable

namespace WebServiceObligacionesVehiculares.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            PermisoCirculacions = new HashSet<PermisoCirculacion>();
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string Modelo1 { get; set; }

        public virtual ICollection<PermisoCirculacion> PermisoCirculacions { get; set; }
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
