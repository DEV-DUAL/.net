using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta1.Models;
using WSVenta1.Models.Response;
using WSVenta1.Models.Request;
using Microsoft.AspNetCore.Authorization;

namespace WSVenta1.Controllers
 
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {

                using (ventarealContext db = new ventarealContext())
                {
                    var lst = db.Cliente.OrderByDescending(d=>d.Id).ToList(); 
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
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (ventarealContext db = new ventarealContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = oModel.nombre;
                    db.Cliente.Add(oCliente);
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

        /*editar*/
        [HttpPut]
        public IActionResult edit(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (ventarealContext db = new ventarealContext())
                {
                    Cliente oCliente = db.Cliente.Find(oModel.id);
                    oCliente.Nombre = oModel.nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        /*eliminar*/
        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (ventarealContext db = new ventarealContext())
                {
                    Cliente oCliente = db.Cliente.Find(id);
                    db.Remove(oCliente);
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
