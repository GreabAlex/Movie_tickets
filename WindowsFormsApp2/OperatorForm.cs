using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class OperatorForm : Form
    {
        string role;
        public OperatorForm(string role)
        {
            this.role = role;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BileteService afisare_bilete = new BileteService();
            string spectacol = textBox1.Text.ToString();
            dataGridView1.Rows.Clear();
            foreach (Bilete s in afisare_bilete.bilete(spectacol))
                dataGridView1.Rows.Add(s.getSpectacol(),s.getNumber(),s.getRow());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bilete u = new Bilete(textBox1.Text.ToString(), textBox3.Text.ToString(), textBox2.Text.ToString());
            BileteService bilet1 = new BileteService();
            int i=bilet1.marcareBilet(u);
            if(i!=1)
                MessageBox.Show("Acest bilet a mai fost marcat sau s-a depasit numarul de bilete!");
        }
    }
}
