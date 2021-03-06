using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class UserService
    {
        UserDao userDao;
       public UserService()
        {
            this.userDao = new UserDao();
        }
        public List<User> users()
        {
            List<User> users = new List<User>();
            users = this.userDao.getallUser();
            return users;
        }
        static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public User users1(string a, string b)
        {
            User users1 = null;
            string c = getMd5Hash(b);
            users1 = this.userDao.getUser(a,c);
            return users1;
        }
        public void insertUser(User u)
        {
            this.userDao.insertUser(u);
        }

    }
}
