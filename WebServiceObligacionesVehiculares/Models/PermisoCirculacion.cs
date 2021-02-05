using System;
using System.Collections.Generic;

#nullable disable

namespace WebServiceObligacionesVehiculares.Models
{
    public partial class PermisoCirculacion
    {
        public int Id { get; set; }
        public int? ValorPermiso { get; set; }
        public int IdModelo { get; set; }

        public virtual Modelo IdModeloNavigation { get; set; }
    }
}
