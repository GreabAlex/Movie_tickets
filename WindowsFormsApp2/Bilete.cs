using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Bilete
    {
        public string spectacol;
        public string number;
        public string row;
        public Bilete(string spectacol, string number, string row)
        {
            this.spectacol = spectacol;
            this.number = number;
            this.row = row;
        }
        public string getSpectacol()
        {
            return this.spectacol;
        }
        public string getNumber()
        {
            return this.number;
        }
        public string getRow()
        {
            return this.row;
        }
    }
}
