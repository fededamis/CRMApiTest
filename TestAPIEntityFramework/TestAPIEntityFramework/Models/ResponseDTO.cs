using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TestAPIEntityFramework.Models
{
    [DataContract]
    public class ResponseDTO<T>
    {
        [DataMember]
        public List<T> Datos { get; set; }
        [DataMember]
        public List<Bitacora> Bitacora { get; set; }
        [DataMember]
        public List<Error> Errores {get; set;}

        public ResponseDTO()
        {
            Datos = new List<T>();
            Bitacora = new List<Bitacora>();            
            Errores = new List<Error>();            
        }

        public void Log (string stringToLog)
        {
            Bitacora.Add(new Bitacora(stringToLog));
        }
    }

    public class Bitacora
    {
        public string Log { get; set; }
        public string FechaLog { get; set; }

        public Bitacora(string log)
        {
            FechaLog = DateTime.Now.ToLocalTime().ToString();
            Log = log;
        }
    }   

    public class Error
    {
        public string DetalleError { get; set; }
    }
}