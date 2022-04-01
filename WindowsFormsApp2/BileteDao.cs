using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    class BileteDao
    {
        private static BileteDao _bileteDAL = null;
        private String _connectionString = @"Data Source=DESKTOP-AANQ76L\SQLEXPRESS;Initial Catalog=ps;Integrated Security=True";
        SqlConnection _conn = null;

        public BileteDao()
        {
            try
            {
                _conn = new SqlConnection(_connectionString);
            }
            catch (SqlException e)
            {
                //de facut ceva error handling, afisat mesaj, etc..
                _conn = null;
            }
        }

        public static BileteDao getInstance()
        {
            if (_bileteDAL == null)
            {
                _bileteDAL = new BileteDao();
            }
            return _bileteDAL;
        }


        public List<Bilete> getallBilete(string s)
        {
            List<Bilete> bileteList = new List<Bilete>();
            Bilete u = null;
            String sql = "SELECT * FROM Bilete WHERE spectacol='" + s +"'";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    u = new Bilete(reader["spectacol"].ToString(), reader["row"].ToString(), reader["number"].ToString());
                    bileteList.Add(u);
                }
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                _conn.Close();
            }
            return bileteList;
        }
        public void marcareBilete(Bilete u)
        {
            String sql = "Insert INTO Bilete (spectacol,number,row) VALUES ('" + u.getSpectacol() + "','" + u.getNumber() + "','" + u.getRow() + "')";
            Console.WriteLine(sql);
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                _conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

      

    }
}
