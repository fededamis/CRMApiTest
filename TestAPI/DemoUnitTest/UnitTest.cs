using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
namespace DemoUnitTest
{
    [TestFixture]
    public class UnitTests
    {        
        [Test]
        public void TestGetApi()
        {
            string searchString = "Roberto";
            WebRequest request = WebRequest.Create("http://localhost:63527/api/personas/" + searchString);
            WebResponse response = request.GetResponse();
            string responseJSONString = null;

            using (Stream dataStream = response.GetResponseStream())
            {                
                StreamReader reader = new StreamReader(dataStream);
                responseJSONString = reader.ReadToEnd();             
            }

            dynamic responseJSON = JsonConvert.DeserializeObject<dynamic>(responseJSONString);
            string foundName = responseJSON["Datos"][0]["nombre"];           
            response.Close();
            Assert.AreEqual(searchString, foundName);
        }        
    }
}