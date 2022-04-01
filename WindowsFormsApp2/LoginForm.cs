using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace WindowsFormsApp2
{


    public partial class LoginForm : Form
    {
       
        public LoginForm()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            UserService nume = new UserService();
            string a = textBox1.Text;
            string b = textBox2.Text;
            //string b = textBox2.Text;
            User u = nume.users1(a, b);
            if (u!=null)
            {
                if (u.getRole() == "Admin")
                {
                    AdminForm f = new AdminForm();
                    f.Show();
                }
                else if (u.getRole() == "operator")
                {
                    OperatorForm f = new OperatorForm("operator");
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Utilizator Incorect");
                }
            }

        }
    }
}
