using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vicinor.Model
{
    public class Lokacija
    {

        private int lokacijaId;
        [ScaffoldColumn(false)]
        public int LokacijaId
        {
            get { return lokacijaId; }
            set { lokacijaId = value; }
        }

        private double x, y;
        [Required]
        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
    }
}
