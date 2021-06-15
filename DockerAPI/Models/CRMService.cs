using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using Microsoft.PowerPlatform.Dataverse.Client;

namespace DockerAPI.Models
{
    public class CRMService : ICRMService
    {
        public ServiceClient _instance { get; set; }

        private readonly object _lockObject = new object();

        public CRMService()
        { 
            GetService(); 
        }

        public ServiceClient GetService()
        {            
            try
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                        _instance = CreateOrganizationService();
                    
                    return _instance;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo conectar al servicio de CRM. ", ex);
            }
        }

        private ServiceClient CreateOrganizationService()
        {
            string connectionString = "AuthType=OAuth;Username=federico.damis@agilethought.com;Password=*****;Url=https://org6659b267.crm.dynamics.com;AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;LoginPrompt=Auto";
            var service = new ServiceClient(connectionString);           
            
            if (!service.IsReady)
                throw new Exception(service.LastError);

            return service;
        }
    }
}