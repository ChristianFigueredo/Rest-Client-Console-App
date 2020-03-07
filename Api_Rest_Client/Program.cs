using System;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace Api_Rest_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
                MetodoGetAsync().Wait();
                MetodoPostAsync().Wait();
                MetodoPutAsync().Wait();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ocurrio error, por favor verifique: \n" + ex.Message );
            }
        }

        static async Task MetodoPostAsync()
        {
            using (HttpClient LibreriaHttp = new HttpClient()) 
            {
                ClienteRequest C = new ClienteRequest();
                C.NumeroDocumento = "5322032644";
                C.Nombre = "YOLANDA";
                C.Apellido = "FLOREZ";
                C.Telefono = "3213984022";
                C.Email = "YOLANDA.FLOREZ@GMAIL.COM";
                C.Direccion = "CUCUTA";
                C.IdTipoDocumento = 2;
                 
                LibreriaHttp.BaseAddress = new Uri("https://localhost:44359/");
                LibreriaHttp.DefaultRequestHeaders.Accept.Clear();
                LibreriaHttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response = await LibreriaHttp.PostAsJsonAsync("api/Cliente", C);

                if (response.IsSuccessStatusCode)
                {
                    RespuestaTransaccion Respuesta_Insercion = await response.Content.ReadAsAsync<RespuestaTransaccion>();
                    string obj = Newtonsoft.Json.JsonConvert.SerializeObject(Respuesta_Insercion, Formatting.Indented);
                    Console.WriteLine(obj);
                }
                else 
                {
                    Console.WriteLine("Response: " + response.StatusCode);
                }
            }
        }

        static async Task MetodoPutAsync()
        {
            using (HttpClient LibreriaHttp = new HttpClient())
            {
                ClienteRequest C = new ClienteRequest();
                C.NumeroDocumento = "5322032644";
                C.Nombre = "YOLANDITA";
                C.Apellido = "FLOREZ";
                C.Telefono = "3213985044";
                C.Email = "YOLANDA.FLOREZ@GMAIL.COM";
                C.Direccion = "CUCUTA";
                C.IdTipoDocumento = 2;

                LibreriaHttp.BaseAddress = new Uri("https://localhost:44359/");
                LibreriaHttp.DefaultRequestHeaders.Accept.Clear();
                LibreriaHttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await LibreriaHttp.PutAsJsonAsync("api/Cliente", C);

                if (response.IsSuccessStatusCode)
                {
                    RespuestaTransaccion Respuesta_Insercion = await response.Content.ReadAsAsync<RespuestaTransaccion>();
                    string obj = Newtonsoft.Json.JsonConvert.SerializeObject(Respuesta_Insercion, Formatting.Indented);
                    Console.WriteLine(obj);
                }
                else
                {
                    Console.WriteLine("Response: " + response.StatusCode);
                }
            }
        }

        static async Task MetodoGetAsync() 
        { 
            using ( HttpClient LibreriaHttp = new HttpClient())
            {
                LibreriaHttp.BaseAddress = new Uri("https://localhost:44359/");
                LibreriaHttp.DefaultRequestHeaders.Accept.Clear();
                LibreriaHttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await LibreriaHttp.GetAsync("api/Cliente");

                if (response.IsSuccessStatusCode) 
                {
                    var Respuesta_Clientes = await response.Content.ReadAsAsync<List<ClienteRequest>>();
                    foreach (ClienteRequest c in Respuesta_Clientes)
                    {
                        string respuesta = Newtonsoft.Json.JsonConvert.SerializeObject(c, Formatting.Indented);
                        Console.WriteLine(respuesta);
                    }
                }
                else
                {
                    Console.WriteLine("Response: " + response.StatusCode);
                }
            }
        }
    }
}
