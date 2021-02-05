using System;
using System.Collections.Generic;

#nullable disable

namespace WebServiceObligacionesVehiculares.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Multa = new HashSet<Multum>();
            Pagos = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public string Patente { get; set; }
        public int IdModelo { get; set; }

        public virtual Modelo IdModeloNavigation { get; set; }
        public virtual ICollection<Multum> Multa { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
