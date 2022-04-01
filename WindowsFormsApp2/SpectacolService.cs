using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class SpectacolService
    {
        private String _connectionString = @"Data Source=DESKTOP-AANQ76L\SQLEXPRESS;Initial Catalog=ps;Integrated Security=True";
        SqlConnection _conn = null;
        SpectacolDao spectacolDao;
        public SpectacolService()
        {
            this.spectacolDao = new SpectacolDao();
        }
        public List<Spectacol> spectacol()
        {
            List<Spectacol> spectacol = new List<Spectacol>();
            spectacol = this.spectacolDao.getallSpectacol();
            return spectacol;
        }
        
        public void deletespectcol(Spectacol s)
        {
            this.spectacolDao.removeSpectacol(s);
        }
        public void insertSpectacol(Spectacol s)
        {
            this.spectacolDao.insertSpectacol(s);
        }
        public void editSpectacol(Spectacol s)
        {
            this.spectacolDao.editSpectacol(s);
        }
        public Spectacol getSpectacol(string s)
        {
            return this.spectacolDao.getSpectacol(s);
        }

       

    }
}
