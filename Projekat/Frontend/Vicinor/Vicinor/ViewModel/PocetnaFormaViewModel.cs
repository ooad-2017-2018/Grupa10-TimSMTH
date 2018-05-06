using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicinor.Model;

namespace Vicinor.ViewModel
{
    public class PocetnaFormaViewModel 
    {
        String usernameG = null, passwordG = null;
        Boolean adminDaNe;
        public async Task<Boolean> loginAdmin(String username, String pw)
        {
            adminDaNe = await getDataAdmin(username, pw);

            // if (usernameG == null || passwordG == null || !adminDaNe) return false;
            if (username == usernameG && passwordG == pw && adminDaNe) return true;
            return false;
        }

        public async Task<Boolean> loginUser(String username, String pw)
        {
            adminDaNe = await getDataUser(username, pw);
           // if (usernameG == null || passwordG == null || adminDaNe) return false;
           

            if (username == usernameG && passwordG == pw && !adminDaNe) return true;
            return false;
        }


        public async Task<Boolean> getDataUser(String usernme, String pw)
        {
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            Uri requestUri = new Uri("http://localhost:6796/RegistrovaniKorisniks/GetAccount?Username=" + usernme + "&Password=" + pw);

            //Uri requestUri = new Uri("http://localhost:6796/RegistrovaniKorisniks/GetAccount?Username=Masha&Password=sifraHaris");

            //Send the GET request asynchronously and retrieve the response as a string.
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();

            RegistrovaniKorisnik korisnik = null;
            string httpResponseBody = "";
            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);

                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                string json = httpResponseBody;
                korisnik = JsonConvert.DeserializeObject<RegistrovaniKorisnik>(json);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            if(korisnik != null){
                usernameG = korisnik.Username;
                passwordG = korisnik.Password;
            }
            return false;
        }

        public async Task<Boolean> getDataAdmin(String usernme, String pw)
        {
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            Uri requestUri = new Uri("http://localhost:6796/Administrators/GetAccount?Username=" + usernme + "&Password=" + pw);


            //Send the GET request asynchronously and retrieve the response as a string.
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();

            Administrator korisnik = null;
            string httpResponseBody = "";
            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);

                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                string json = httpResponseBody;
                korisnik = JsonConvert.DeserializeObject<Administrator>(json);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            if (korisnik != null)
            {
                usernameG = korisnik.Username;
                passwordG = korisnik.Password;
                return true;
            }
            return false;
        }
    }

}
