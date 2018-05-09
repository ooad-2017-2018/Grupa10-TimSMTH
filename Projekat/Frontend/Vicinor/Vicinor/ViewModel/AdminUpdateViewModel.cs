using System;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicinor.Model;using Newtonsoft.Json;
using Vicinor.Forme;

namespace Vicinor.ViewModel
{
    class AdminUpdateViewModel
    {
        Administrator admin;
        public AdminUpdateViewModel()
        {
            admin = new Administrator();
        }
        /*
        private Boolean updateUsername(Administrator a)
        {
            if (a == null) throw new ArgumentNullException("admin");
            int i = _a.FindIndex(p => p.KorisnikId == a.KorisnikId);
        }

        public HttpResponseMessage putUsernameAdmin(int id, Administrator admin)
        {
            admin.KorisnikId = id;
            if (!updateUsername(admin))
            {

            }
           
        }*/

        public async Task<Boolean> setDataAdmin(String username, String pw, String newUsername, String newPassword)
        {

            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

            //Add a user-agent header to the request. 
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
            Console.WriteLine("asda");
            Uri requestUri = new Uri("http://localhost:6796/Administrators/GetAccount?Username=" + username + "&Password=" + pw);


            //Send the request asynchronously and retrieve the response as a string.
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();

            Administrator korisnik = null;
            string httpResponseBody = "";
            try
            {
                //Send the Get request
                httpResponse = await httpClient.GetAsync(requestUri);

                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                string json = httpResponseBody;
                korisnik = JsonConvert.DeserializeObject<Administrator>(json);
                if (korisnik != null)
                {
                    korisnik.Password = newPassword;
                    korisnik.Username = newUsername;

                    return true;

                }
                else if (json == "")
                {
                    
                    return false;

                }
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;

            }
            return true;

        }
    




        public void putPasswordAdmin(int id, Administrator admin)
        {

        }

        public bool validateUsernameLength(String username)
        {
            if (username.Length < 6) return false;
            return true;
            
        }

        public bool validateUsernameContent(String username)
        {
            if (!username.All(c => Char.IsLetterOrDigit(c) || c == '_')) return false;
            if (username.Any(char.IsUpper)) return false; //ne smije biti ni jedno veliko slovo
            if (!username.Any(char.IsNumber)) return false;     
            return true;

        }

        public bool validatePasswordLength(String password)
        {
            if (password.Length < 6) return false;
            return true;
        }

        public bool validatePasswordContent(String password)
        {
            if (!password.All(c => Char.IsLetterOrDigit(c) || c == '_')) return false;
            if (!password.Any(char.IsUpper)) return false;
            if (!password.Any(char.IsNumber)) return false;
            return true;

        }

        public bool validatePasswordConfirmPassword(String password, String confirm)
        {
            if (String.Compare(password, confirm)==0) return true;
            return false;
        }
    }
}
