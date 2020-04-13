using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Threading.Tasks;
using System.Net.Http;

namespace WebApplication7
{
    public class Client
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string NationalId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual List<Account> Accounts { get; set; }
    }
    /// <summary>
    /// Descripción breve de caja2comunication
    /// </summary>
    [WebService(Namespace = "http://caja2comunication.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    //[System.Web.Script.Services.ScriptService]
    public class caja2comunication : System.Web.Services.WebService
    {
        static readonly HttpClient client = new HttpClient();
       
        
        static public Client cliente= new Client();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public Account GetAccount(int id)
        {
            
            Account account = new Account();
            GetAccountAsync(id,account).Wait();       
            

            return account;
        }
        [WebMethod]
        public Client GetClient(int id)
        {
            
            GetClientAsync(id) .Wait();
            return cliente;
        }

        internal static async Task GetAccountAsync(int id, Account account)
        {



            HttpResponseMessage response = await client.GetAsync("https://core-2.azurewebsitesnet/api/Accounts/" + id);

            if (response.IsSuccessStatusCode)
            {
                account = await response.Content.ReadAsAsync<Account>();
            }


        }
        internal static async Task GetClientAsync(int id)
        {

            
            
            HttpResponseMessage response = await client.GetAsync("https://core-2.azurewebsitesnet/api/Clients/" + id);

            if (response.IsSuccessStatusCode)
            {
                cliente = await response.Content.ReadAsAsync<Client>();
            }

            // cliente;
        }
    }
}
