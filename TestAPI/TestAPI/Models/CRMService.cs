using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Xrm.Tooling.Connector;
using System.Configuration;
using System.Net;

namespace TestAPI.Models
{
    public class CRMService
    {
        public static IOrganizationService instance;
        private static object _lockObject = new object();

        private CRMService(){}

        public static IOrganizationService GetService()
        {            
            try
            {
                lock (_lockObject)
                {
                    if (instance == null)
                        instance = CreateOrganizationService();
                    
                    return instance;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo conectar al servicio de CRM. ", ex);
            }
        }

        private static IOrganizationService CreateOrganizationService()
        {
            string connectionString = ConfigurationManager.AppSettings["CRMConnectionString"].ToString();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            CrmServiceClient conection = new Microsoft.Xrm.Tooling.Connector.CrmServiceClient(connectionString);

            if (!conection.IsReady)
                throw new Exception(conection.LastCrmError);

            IOrganizationService service;

            if (conection.OrganizationWebProxyClient == null)
                service = (IOrganizationService)conection.OrganizationServiceProxy;
            else
                service = (IOrganizationService)conection.OrganizationWebProxyClient;               

            return service;
        }
    }
}