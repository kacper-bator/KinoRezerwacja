using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KinoRezerwacja
{
    public partial class RezerwacjaKlient : Form
    {
        

        public RezerwacjaKlient()
        {
            InitializeComponent();
        }

        private List<System.Windows.Forms.Button> buttony = new List<Button>();
        Color niezaznacz;
        int temp1, temp2, temp3;
        private void RezerwacjaKlient_Load(object sender, EventArgs e)
        {
            label2.Text = (string)FormatkaKlienta.potrzebne.ToString();

            string connSql = @"Data source=(LocalDB)\MSSQLLocalDB;database=KinoRezerwacja;Integrated Security=SSPI;";
            int los = FormatkaKlienta.potrzebne;

            string x = "SELECT ile_rzed FROM Sala WHERE id = " + los +";" ;
            string y = "SELECT ile_m_w_rz FROM Sala WHERE id = " + los + ";";


            SqlConnection polaczenie = new SqlConnection(connSql);
            try
            {

                polaczenie.Open();

                string sql = x;
                string sql2 = y;

                SqlCommand cmd = new SqlCommand(sql, polaczenie);
                
                temp1 = (int)cmd.ExecuteScalar();

                SqlCommand cmd2 = new SqlCommand(sql2, polaczenie);

                temp2 = (int)cmd2.ExecuteScalar();

                temp3 = temp1 * temp2;





            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Niepowodzenie");
            }
            polaczenie.Close();




            for (int i = 0; i < temp3; i++)
            {
                buttony.Add(new System.Windows.Forms.Button());
                this.flowLayoutPanel1.Controls.Add(this.buttony[i]);
                this.flowLayoutPanel1.Width = temp2 * 46;


                this.buttony[i].Name = "button" + i;
                this.buttony[i].Size = new System.Drawing.Size(40, 40);
                this.buttony[i].TabIndex = 3 + i;
                this.buttony[i].Text = (1 + i % temp2).ToString();
                this.buttony[i].UseVisualStyleBackColor = true;
                this.buttony[i].Click += new System.EventHandler(this.button1_1_Click);
                this.buttony[i].Location = new System.Drawing.Point(3 + 46 * (i % temp2), 3 + 46 * (i / temp2));
            }
        }

        private void button1_1_Click(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(Button))
                return;

            if (niezaznacz == Color.Black)
                niezaznacz = buttony[0].BackColor;

            Button b = ((Button)sender);
            if (b.BackColor == Color.Red)
                b.BackColor = niezaznacz;
            else
                b.BackColor = Color.Red;
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
