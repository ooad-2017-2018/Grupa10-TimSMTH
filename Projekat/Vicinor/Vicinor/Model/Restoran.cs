using System;
//using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicinor.Model
{
    public class Restoran
    {
        string name, description, phoneNumber;
        //Bitmap image;
        Lokacija location;
        List<Recenzija> listRezension;



        public System.String Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public System.String Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public System.String PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

       /* public Bitmap Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }
        */
        public Lokacija Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        void addRecension(RegistrovaniKorisnik korisnik, Recenzija r)
        {

        }

        void call(string telefon)
        {

        }
    }
}
