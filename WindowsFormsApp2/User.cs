using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class User
    {
        public string username;
        public string password;
        public string name;
        public string role;
        public User(string username, string password, string name, string role)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.role = role;

        }
        public string getRole()
        {
            return this.role;
        }
        public string getName()
        {
            return this.name;
        }
        public string getPassword()
        {
            return this.password;
        }
        public string getUsename()
        {
            return this.username;
        }

    }
}
