using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicinor.Model;
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

        public void setUsername()
        {
            
        }

        public void setPassword()
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
