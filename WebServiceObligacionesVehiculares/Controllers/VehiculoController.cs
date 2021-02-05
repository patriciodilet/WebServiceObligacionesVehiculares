using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceObligacionesVehiculares.Models;
using WebServiceObligacionesVehiculares.Models.Request;
using WebServiceObligacionesVehiculares.Models.Response;

namespace WebServiceObligacionesVehiculares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Vehiculo>> oRespuesta = new Respuesta<List<Vehiculo>>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    var lst = db.Vehiculos.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Respuesta<Vehiculo> oRespuesta = new Respuesta<Vehiculo>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    var lst = db.Vehiculos.Find(Id);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(VehiculoRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    Vehiculo oVehiculo = new Vehiculo();
                    oVehiculo.Patente = model.Patente;
                    oVehiculo.IdModelo = model.IdModelo;
                    db.Vehiculos.Add(oVehiculo);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(VehiculoRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    Vehiculo oVehiculo = db.Vehiculos.Find(model.Id);

                    oVehiculo.Patente = model.Patente;
                    oVehiculo.IdModelo = model.IdModelo;
                    db.Entry(oVehiculo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    Vehiculo oVehiculo = db.Vehiculos.Find(Id);
                    db.Remove(oVehiculo);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

    }
}
