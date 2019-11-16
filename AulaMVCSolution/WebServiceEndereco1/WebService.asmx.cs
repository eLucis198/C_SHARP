using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebServiceEndereco1
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
            return "Hellor World";
        }


        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void BuscarCep(string cep)
        {
            string resultadoJson;
            using (HttpClient client = new HttpClient())
            {
                string url = "https://viacep.com.br/ws/"+cep+"/json/";
                var response = client.GetAsync(url).Result;
                using (HttpContent content = response.Content)
                {
                    Task<string> resultado = content.ReadAsStringAsync();
                    string Jreturn = resultado.Result;
                    resultadoJson = Jreturn;
                }
            }
            HttpContext.Current.Response.Write("["+resultadoJson+"]");
        }
    }
}
