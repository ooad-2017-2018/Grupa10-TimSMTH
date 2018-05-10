using System;
using System.Net.Http;
using System.Linq;
using System.Collections.Generic;
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

        public async Task<Boolean> Initial(String u, String p)
        {
            Boolean j = await getData(u,p);
            return j;

        }


        public Administrator dajAdmina()
        {
            return admin;
        }

        private async Task<Boolean> getData(String u, String p)
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


            Uri requestUri = new Uri("http://localhost:6796/Administrators/GetAccount?Username="+u+"&Password="+p);

            //Send the GET request asynchronously and retrieve the response as a string.
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();

            string httpResponseBody = "";
            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);

                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                string json = httpResponseBody;
                admin = JsonConvert.DeserializeObject<Administrator>(json);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            if (admin != null) return true;
            return false;
        }

        public async Task<Boolean> changeUsername(int id, String name)
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

            Uri requestUri = new Uri("http://localhost:6796/Administrators/changeUsername/" + id + "?Username="+name);


            //Send the PUT request asynchronously and retrieve the response as a string.
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();

            string httpResponseBody = "";
            try
            {

                httpResponse = await httpClient.PutAsync(requestUri, null);

                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                string json = httpResponseBody;
             }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
            return true;

        }

        public async Task<Boolean> changePassword(int id, String password)
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

            Uri requestUri = new Uri("http://localhost:6796/Administrators/changePassword/" + id + "?Password=" + password);


            //Send the PUT request asynchronously and retrieve the response as a string.
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();

            string httpResponseBody = "";
            try
            {

                httpResponse = await httpClient.PutAsync(requestUri, null);

                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                string json = httpResponseBody;
          
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
            return true;

        }


        //Validacija

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
