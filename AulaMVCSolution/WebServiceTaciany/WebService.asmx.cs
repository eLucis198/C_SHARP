using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebServiceTaciany
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        [WebMethod]
        public string BuscaCep(string cep)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = "https://viacep.com.br/ws/"+cep+"/json/";
                var response = client.GetAsync(url).Result;
                using (HttpContent content = response.Content)
                {
                    try
                    {
                        Task<string> resultado = content.ReadAsStringAsync();
                        string Jreturn = resultado.Result;
                        cep = Jreturn;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return cep;
        }
    }
}
