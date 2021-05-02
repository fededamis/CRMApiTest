using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI.Models
{
    public class PersonaDTO : BaseDTO
    {
        public PersonaDTO()
        {
            base.Datos.Add(new Persona());
        }

        private class Persona : Datos
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string nroTelefono { get; set; }
        }
    }    
}