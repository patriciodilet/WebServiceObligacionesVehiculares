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
    public class PagoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Pago>> oRespuesta = new Respuesta<List<Pago>>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    var lst = db.Pagos.ToList();
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
            Respuesta<Pago> oRespuesta = new Respuesta<Pago>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    var lst = db.Pagos.Find(Id);
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
        public IActionResult Add(PagoRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    Pago oPago = new Pago();
                    oPago.IdMulta = model.IdMulta;
                    oPago.IdVehiculo = model.IdVehiculo;
                    oPago.ValorPago = model.ValorPago;
                    db.Pagos.Add(oPago);
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
        public IActionResult Edit(PagoRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    Pago oPago = db.Pagos.Find(model.Id);
                    oPago.IdMulta = model.IdMulta;
                    oPago.IdVehiculo = model.IdVehiculo;
                    oPago.ValorPago = model.ValorPago;
                    db.Entry(oPago).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Pago oPago = db.Pagos.Find(Id);
                    db.Remove(oPago);
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
