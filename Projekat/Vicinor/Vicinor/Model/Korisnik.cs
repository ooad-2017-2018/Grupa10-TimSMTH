using System;

namespace Vicinor.Model
{
    public abstract class Korisnik
    {
        private String username, password;
        
        public String Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public String Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }
    }
}
