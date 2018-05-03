using System;
using System.Collections.Generic;
using System.Text;

namespace Vicinor.Model
{
    public abstract class KorisnikUSistemu: Korisnik
    {
        String username, password;

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
