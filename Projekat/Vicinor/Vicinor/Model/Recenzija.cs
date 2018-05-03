using System;
using System.Collections.Generic;
using System.Text;


namespace Vicinor.Model
{
    public class Recenzija
    {
        String comment;
        int starRating, userId;
        DateTime timeOfRez;

        public String Comment
        {
            get
            {
                return comment;
            }

            set
            {
                comment = value;
            }
        }

        public System.Int32 StarRating
        {
            get
            {
                return starRating;
            }

            set
            {
                starRating = value;
            }
        }

        public DateTime TimeOfRez
        {
            get
            {
                return timeOfRez;
            }

            set
            {
                timeOfRez = value;
            }
        }

        public System.Int32 UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
            }
        }
    }
}
