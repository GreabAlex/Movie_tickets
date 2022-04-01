using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            SpectacolService afisare_spectacol = new SpectacolService();
            dataGridView1.Rows.Clear();
            foreach (Spectacol s in afisare_spectacol.spectacol())
                dataGridView1.Rows.Add(s.getTitle(), s.getRegizor(), s.getActor(), s.getDateOfpremier(), s.getNumberOftickets());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Spectacol u = new Spectacol(textBox4.Text.ToString(), textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox8.Text.ToString());
            SpectacolService spec1 = new SpectacolService();
            spec1.insertSpectacol(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User u = new User(textBox2.Text.ToString(), textBox3.Text.ToString(), textBox2.Text.ToString(),"operator");
            UserService user1 = new UserService();
            user1.insertUser(u);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Spectacol s = new Spectacol(textBox4.Text.ToString(), textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox8.Text.ToString());
            SpectacolService spec = new SpectacolService();
            spec.deletespectcol(s);
       }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Spectacol s = new Spectacol(textBox4.Text.ToString(), textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox8.Text.ToString());
            SpectacolService spec = new SpectacolService();
            spec.editSpectacol(s);
        }
    }
}
