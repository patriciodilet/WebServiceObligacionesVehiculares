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
    public class MultaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Multum>> oRespuesta = new Respuesta<List<Multum>>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    var lst = db.Multa.ToList();
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
            Respuesta<Multum> oRespuesta = new Respuesta<Multum>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    var lst = db.Multa.Find(Id);
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
        public IActionResult Add(MultaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    Multum oMulta = new Multum();
                    oMulta.ValorMulta = model.ValorMulta;
                    oMulta.IdVehiculo = model.IdVehiculo;
                    db.Multa.Add(oMulta);
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
        public IActionResult Edit(MultaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    Multum oMulta = db.Multa.Find(model.Id);
                    oMulta.ValorMulta = model.ValorMulta;
                    oMulta.IdVehiculo = model.IdVehiculo;
                    db.Entry(oMulta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Multum oMulta = db.Multa.Find(Id);
                    db.Remove(oMulta);
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
