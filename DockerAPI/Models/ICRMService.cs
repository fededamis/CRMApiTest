using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerAPI.Models
{
    public interface ICRMService
    {        
        ServiceClient _instance { get; set; }
    }
}
