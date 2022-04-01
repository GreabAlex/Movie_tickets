using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WindowsFormsApp2;

public class UserDao
{
    private static UserDao _usersDAL = null; 
    private String _connectionString = @"Data Source=DESKTOP-AANQ76L\SQLEXPRESS;Initial Catalog=ps;Integrated Security=True";
    SqlConnection _conn = null;

    public UserDao()
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

    public static UserDao getInstance()
    {
        if (_usersDAL == null)
        {
            _usersDAL = new UserDao();
        }
        return _usersDAL;
    }


    public List<User> getallUser()
    {
        List<User> userList = new List<User>();
        User u = null;
        String sql = "SELECT * FROM users ";
        try
        {
            _conn.Open();
            SqlCommand cmd = new SqlCommand(sql, _conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                u = new User(reader["username"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["role"].ToString());
                userList.Add(u);
            }
           _conn.Close();
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
        return userList;
    }
    public User getUser(string username,string password)
    {
        User u = null;
        String sql = "SELECT * FROM users  WHERE username = '" + username + "' AND password = '" + password + "'"; 
        try
        { 
            _conn.Open();
            SqlCommand cmd = new SqlCommand(sql, _conn);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            u = new User(reader["username"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["role"].ToString());
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
    public void insertUser(User u)
    {
        String sql = "Insert INTO users ( username,password,name,role) VALUES ('" + u.getUsename() + "','" + u.getPassword() +"','" + u.getName() +"','"  + u.getRole() +"')";
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

