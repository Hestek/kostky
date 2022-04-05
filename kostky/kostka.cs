using System;
using System.Collections.Generic;
using System.Text;

namespace kostky
{
    class kostka
    {
        private int hodnota;

        public int Hodnota { get => hodnota; }

        public void Hod()
        {
            Random random = new Random();
            hodnota = random.Next(1, 7);
        }

        public kostka()
        {
            Hod();
        }
            

    }
}
