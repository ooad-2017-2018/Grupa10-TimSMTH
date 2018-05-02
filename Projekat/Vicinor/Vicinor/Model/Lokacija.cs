using System;
using System.Collections.Generic;
using System.Text;

namespace Vicinor.Model
{
    public class Lokacija
    {
        private int x, y;

        public int X
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

        public int Y
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
