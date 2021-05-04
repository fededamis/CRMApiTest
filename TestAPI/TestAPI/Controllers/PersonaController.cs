using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    public class PersonaController : ApiController
    {       
        [Route("api/personas/{nombre}")]
        [HttpGet]
        public ResponseDTO<Persona> Get(string nombre) 
        {
            //Example 
            //http://localhost:63527/api/personas/Roberto
            var responseDTO = new ResponseDTO<Persona>();
            try
            {                                   
                responseDTO.Log("Inicio GET"); 

                QueryExpression query = new QueryExpression("contact");
                query.ColumnSet = new ColumnSet("firstname", "lastname");
                query.Criteria.AddCondition("firstname", ConditionOperator.Equal, nombre);
                EntityCollection resultPersonas = responseDTO.service.RetrieveMultiple(query);

                if (resultPersonas.Entities.Count == 0)
                    throw new Exception("No existe persona con ese nombre en CRM.");

                Entity resultPersona = resultPersonas.Entities.First();

                Persona persona = new Persona();
                persona.nombre = resultPersona.GetAttributeValue<string>("firstname");
                persona.apellido = resultPersona.GetAttributeValue<string>("lastname");

                responseDTO.Datos.Add(persona);
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
