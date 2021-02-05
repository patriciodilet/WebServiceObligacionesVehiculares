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
    public class PermisoCirculacionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<PermisoCirculacion>> oRespuesta = new Respuesta<List<PermisoCirculacion>>();

            try
            {

                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    var lst = db.PermisoCirculacions.ToList();
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
            Respuesta<PermisoCirculacion> oRespuesta = new Respuesta<PermisoCirculacion>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    var lst = db.PermisoCirculacions.Find(Id);
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
        public IActionResult Add(PermisoCirculacionRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    PermisoCirculacion oPermisoCirculacion = new PermisoCirculacion();
                    oPermisoCirculacion.IdModelo = model.IdModelo;
                    oPermisoCirculacion.ValorPermiso = model.ValorPermiso;
                    db.PermisoCirculacions.Add(oPermisoCirculacion);
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
        public IActionResult Edit(PermisoCirculacionRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    PermisoCirculacion oPermisoCirculacion = db.PermisoCirculacions.Find(model.Id);

                    oPermisoCirculacion.IdModelo = model.IdModelo;
                    oPermisoCirculacion.ValorPermiso = model.ValorPermiso;
                    db.Entry(oPermisoCirculacion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    PermisoCirculacion oPermisoCirculacion = db.PermisoCirculacions.Find(Id);
                    db.Remove(oPermisoCirculacion);
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
