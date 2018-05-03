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
        List<Restoran> listRestaurant;
        DateTime timeOfSearch;
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

        public List<Restoran> ListRestaurant
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

        public DateTime TimeOfSearch
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
