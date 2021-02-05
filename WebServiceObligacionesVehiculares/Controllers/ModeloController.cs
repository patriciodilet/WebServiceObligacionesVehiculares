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
    public class ModeloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Modelo>> oRespuesta = new Respuesta<List<Modelo>>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    var lst = db.Modelos.ToList();
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
            Respuesta<Modelo> oRespuesta = new Respuesta<Modelo>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    var lst = db.Modelos.Find(Id);
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
        public IActionResult Add(ModeloRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    Modelo oModelo = new Modelo();
                    oModelo.Modelo1 = model.Modelo;
                    db.Modelos.Add(oModelo);
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
        public IActionResult Edit(ModeloRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DBObligacionesVehicularesContext db = new DBObligacionesVehicularesContext())
                {
                    Modelo oModelo = db.Modelos.Find(model.Id);
                    oModelo.Modelo1 = model.Modelo;
                    db.Modelos.Add(oModelo);
                    db.Entry(oModelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Modelo oModelo = db.Modelos.Find(Id);
                    db.Remove(oModelo);
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
