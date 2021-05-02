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
        [Route("api/personas/{telefono}")]
        [HttpGet]
        public PersonaDTO Get(string telefono) 
        {
            try
            {
                var personaDTO = new PersonaDTO();

                personaDTO.Log("Inicio GET");

                QueryExpression query = new QueryExpression("contact");
                query.ColumnSet = new ColumnSet("firstname", "lastname", "telephone1");
                query.Criteria.AddCondition("telephone1", ConditionOperator.Equal, telefono);
                EntityCollection resultPersonas = personaDTO.service.RetrieveMultiple(query);

                if (resultPersonas.Entities.Count == 0)
                    Conflict();
                //throw new Exception("No existe persona con ese telefono en CRM.");

                Entity resultPersona = resultPersonas.Entities[0];

                Persona persona = new Persona();
                persona.nombre = resultPersona.GetAttributeValue<string>("firstname");
                persona.apellido = resultPersona.GetAttributeValue<string>("lastname");
                persona.nroTelefono = resultPersona.GetAttributeValue<string>("telephone1");

                var datos = new Datos();
                datos.Obj = persona;
                //personaDTO.Datos.Add((Datos)persona);
                personaDTO.Datos.Add(datos);

                return personaDTO; 
            }
            catch (Exception ex)
            {
                //cargar objeto Error
                throw;
            }           
        }        
    }
}
