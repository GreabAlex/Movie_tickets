using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    class SpectacolDao
    {
        private static BileteDao _SpectacolDAL = null;
        private String _connectionString = @"Data Source=DESKTOP-AANQ76L\SQLEXPRESS;Initial Catalog=ps;Integrated Security=True";
        SqlConnection _conn = null;

        public SpectacolDao()
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
            if (_SpectacolDAL == null)
            {
                _SpectacolDAL = new BileteDao();
            }
            return _SpectacolDAL;
        }


        public List<Spectacol> getallSpectacol()
        {
            List<Spectacol> spectacolList = new List<Spectacol>();
            Spectacol u = null;
            String sql = "SELECT * FROM Spectacol ";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    u = new Spectacol(reader["title"].ToString(), reader["regizor"].ToString(), reader["actor"].ToString(), reader["dateOfpremiere"].ToString(), reader["numberOftickets"].ToString());
                    spectacolList.Add(u);
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
            return spectacolList;
        }

        public void removeSpectacol(Spectacol s)
        {
            List<Spectacol> spectacolList = new List<Spectacol>();
            String sql = "DELETE FROM Spectacol WHERE title='" + s.getTitle() + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("title", s.getTitle());
                _conn.Open();
                cmd.ExecuteNonQuery();

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
        public void insertSpectacol(Spectacol u)
        {
            List<Spectacol> spectacolList = new List<Spectacol>();
            //Spectacol u = null;
            String sql = "Insert INTO Spectacol (title,regizor,actor,dateOfpremiere,numberOftickets) VALUES ('" + u.getTitle() + "','" + u.getRegizor() + "','" + u.getActor() + "','" + u.getDateOfpremier() + "','" + u.getNumberOftickets() + "')";
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

        public void editSpectacol(Spectacol u)
        {
            List<Spectacol> spectacolList = new List<Spectacol>();

            String sql = "UPDATE Spectacol SET title='" + u.getTitle() + "', regizor='" + u.getRegizor() + "', actor='" + u.getActor() + "', dateOfpremiere='" + u.getDateOfpremier() + "', numberOftickets='" + u.getNumberOftickets() + "' WHERE title='" + u.getTitle() + "'" ;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("title", u.getTitle());
                cmd.Parameters.AddWithValue("regizor", u.getRegizor());
                cmd.Parameters.AddWithValue("actor", u.getActor());
                cmd.Parameters.AddWithValue("dateOfpremiere", u.getDateOfpremier());
                cmd.Parameters.AddWithValue("numberOfbilets", u.getNumberOftickets());
                _conn.Open();
                cmd.ExecuteNonQuery();

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

        public Spectacol getSpectacol(string s)
        {
            Spectacol u = null;
            String sql = "SELECT * FROM Spectacol WHERE title='" + s +"'" ;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                u = new Spectacol(reader["title"].ToString(), reader["regizor"].ToString(), reader["actor"].ToString(), reader["dateOfpremiere"].ToString(), reader["numberOftickets"].ToString());

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
            return u;
        }

    }
}
