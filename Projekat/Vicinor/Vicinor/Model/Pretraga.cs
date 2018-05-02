using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicinor.Model
{
    public class Pretraga
    {
        RegistrovaniKorisnik user;
        LinkedList<Restoran> listRestaurant;
        Time timeOfSearch;
        Restoran chosenRestaurant;

        public RegistrovaniKorisnik User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public LinkedList<Restoran> ListRestaurant
        {
            get
            {
                return listRestaurant;
            }

            set
            {
                listRestaurant = value;
            }
        }

        public Time TimeOfSearch
        {
            get
            {
                return timeOfSearch;
            }

            set
            {
                timeOfSearch = value;
            }
        }

        public Restoran ChosenRestaurant
        {
            get
            {
                return chosenRestaurant;
            }

            set
            {
                chosenRestaurant = value;
            }
        }
    }
}
