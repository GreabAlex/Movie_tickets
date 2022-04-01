using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class BileteService
    { 
        BileteDao bileteDao;
        List<Bilete> bilet = new List<Bilete>();
        public BileteService()
        {
            this.bileteDao = new BileteDao();
        }
        
        public List<Bilete> bilete(string s)
        {
            this.bilet = this.bileteDao.getallBilete(s);
            return bilet;
        }
        public void marcareBilete(Bilete u)
        {
            this.bileteDao.marcareBilete(u);
        }
        public int marcareBilet(Bilete s)
        {

            List<Bilete> bilete = this.bileteDao.getallBilete(s.getSpectacol());
            int ok = 1;
            foreach (Bilete i in bilete)
            {
                if (i.getNumber() == s.getRow() && i.getRow() == s.getNumber())
                    ok = 0;
                ///am inversat text box-urile , de asta am schimbat comparatiile
               // Console.WriteLine(i.getNumber());
               // Console.WriteLine(i.getRow());
            }
           
            if (ok == 1)
            {
                SpectacolService spec = new SpectacolService();
                Spectacol sp = spec.getSpectacol(s.getSpectacol());
                int nrbilete = Int32.Parse(sp.getNumberOftickets());
                //Console.WriteLine(nrbilete);
                if (nrbilete > bilete.Count)
                {
                    this.bileteDao.marcareBilete(s);
                    return 1;
                }
                else return 0;
            }
            else return 0;
            
        }
    }
}
