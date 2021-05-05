using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAPIEntityFramework.Models;

namespace TestAPIEntityFramework.Controllers
{
    public class CanalVenta1Controller : ApiController
    {       
        [Route("api/canalventa1/{id}")]
        [HttpGet]
        public ResponseDTO<CanalVentaNivel1> Get(string id) 
        {
            //Example 
            //http://localhost:63527/api/canalventa1/10
            var responseDTO = new ResponseDTO<CanalVentaNivel1>();
            try
            {
                using (var ctx = new BaseTestContext())
                {
                    var query = from st in ctx.CanalVentaNivel1
                                where st.CV1_Id == id
                                select st;

                    var canal = query.FirstOrDefault();
                    responseDTO.Datos.Add(canal);
                }
                return responseDTO;
            }
            catch (Exception ex)
            {
                var error = new Error();
                error.DetalleError = ex.Message;
                responseDTO.Errores.Add(error);
                return responseDTO;                
            }           
        }        
    }
}
