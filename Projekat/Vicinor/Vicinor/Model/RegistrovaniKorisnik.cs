using System;
using System.Collections.Generic;

namespace Vicinor.Model
{
    public class RegistrovaniKorisnik: KorisnikUSistemu
    {
        String firstName, lastName, email;
        int id;
        Boolean banovan;
        Date dateOfBirth;
        Bitmap image;
        LinkedList<Restoran> listOfRestaurants;

        public System.String FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public System.String LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public System.String Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public System.Int32 Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public Boolean Banovan
        {
            get
            {
                return banovan;
            }

            set
            {
                banovan = value;
            }
        }

        public Date DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }

            set
            {
                dateOfBirth = value;
            }
        }

        public Bitmap Image
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

        public LinkedList<Restoran> ListOfRestaurants
        {
            get
            {
                return listOfRestaurants;
            }

            set
            {
                listOfRestaurants = value;
            }
        }
    }
}
