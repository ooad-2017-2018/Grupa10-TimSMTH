using System;
using System.ComponentModel.DataAnnotations;

namespace Vicinor.Model
{
    public abstract class Korisnik
    {
        private int korisnikId;

        public int KorisnikId
        {
            get { return korisnikId; }
            set { korisnikId = value; }
        }

        private String username, password;
        
        [Required]
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

        [Required]
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
