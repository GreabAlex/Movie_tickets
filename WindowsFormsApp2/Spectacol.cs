using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Spectacol
    {
       
        public string title;
        public string regizor;
        public string actor;
        public string dateOfpremier;
        public string numberOftickets;
        public Spectacol(string title, string regizor, string actor, string dateOfpremier, string numberOftickets)
        {
            this.title = title;
            this.regizor = regizor;
            this.actor = actor;
            this.dateOfpremier = dateOfpremier;
            this.numberOftickets = numberOftickets;
        }
        public string getTitle()
        {
            return this.title;
        }
        public string getRegizor()
        {
            return this.regizor;
        }
        public string getActor()
        {
            return this.actor;
        }
        public string getDateOfpremier()
        {
            return this.dateOfpremier;
        }
        public string getNumberOftickets()
        {
            return this.numberOftickets;
        }
    }
}
