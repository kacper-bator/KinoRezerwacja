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
using System.Runtime.CompilerServices;
using System.CodeDom.Compiler;

namespace KinoRezerwacja
{
    public partial class FormatkaKlienta : Form
    {


        public static int potrzebne;

        public FormatkaKlienta()
        {
            InitializeComponent();

            
        }

        private void FormatkaKlienta_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";


            label3.Text = dateTimePicker1.Value.Date.ToString("yyyy/MM/dd");
            label3.Text = label3.Text.Replace(".", "-");
            BazaLoad();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        void BazaLoad()
        {
            listBox1.Items.Clear();

            string connSql = @"Data source=(LocalDB)\MSSQLLocalDB;database=KinoRezerwacja;Integrated Security=SSPI;";



            string y = "SELECT Film.id,nazwa FROM Film INNER JOIN Seans ON Film.id = Seans.id_film WHERE data_sensu = CONVERT(date, GETDATE()); ";


            SqlConnection polaczenie = new SqlConnection(connSql);
            try
            {

                polaczenie.Open();

                string sql = y;

                SqlCommand cmd = new SqlCommand(sql, polaczenie);
                SqlDataReader thisReader = cmd.ExecuteReader();

                while (thisReader.Read())
                {
                    Film film = new Film ((int)thisReader[0],(string)thisReader[1]);
                    listBox1.Items.Add(film.Nazwa);
                }
                thisReader.Close();



            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString(), "Niepowodzenie");
            }
            polaczenie.Close();
        }

        void BazaLoad2()
        {
            listBox1.Items.Clear();

            string connSql = @"Data source=(LocalDB)\MSSQLLocalDB;database=KinoRezerwacja;Integrated Security=SSPI;";

            string lulz = label3.Text;

            string y = "SELECT Film.id,nazwa FROM Film INNER JOIN Seans ON Film.id = Seans.id_film WHERE data_sensu = '" + lulz + "'; ";


            SqlConnection polaczenie = new SqlConnection(connSql);
            try
            {

                polaczenie.Open();

                string sql = y;

                SqlCommand cmd = new SqlCommand(sql, polaczenie);
                SqlDataReader thisReader = cmd.ExecuteReader();

                while (thisReader.Read())
                {
                    Film film = new Film((int)thisReader[0], (string)thisReader[1]);
                    listBox1.Items.Add(film.Nazwa);
                }
                thisReader.Close();



            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString(), "Niepowodzenie");
            }
            polaczenie.Close();
        }

        void BazaSeans()
        {
            listBox2.Items.Clear();

            string connSql = @"Data source=(LocalDB)\MSSQLLocalDB;database=KinoRezerwacja;Integrated Security=SSPI;";
            int temp;

            SqlConnection polaczenie2 = new SqlConnection(connSql);
            polaczenie2.Open();
            string zm1 = listBox1.SelectedItem.ToString();
            string sql2 = "SELECT id FROM Film WHERE nazwa LIKE '" + zm1 + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, polaczenie2);

            temp = (int)cmd2.ExecuteScalar();
            
            polaczenie2.Close();


            int zmn1 = temp ; 


            string x = "SELECT Seans.id, Seans.id_film, Seans.data_sensu, Seans.godz_rozp, Seans.id_sala FROM Seans INNER JOIN Film ON Film.id = Seans.id_film WHERE Film.id = " + zmn1;


            SqlConnection polaczenie = new SqlConnection(connSql);
            try
            {

                polaczenie.Open();

                string sql = x;

                SqlCommand cmd = new SqlCommand(sql, polaczenie);
                SqlDataReader thisReader = cmd.ExecuteReader();


 

                DateTime y = dateTimePicker1.Value;

                while (thisReader.Read())
                {
                    if((DateTime)thisReader[2] == y) 
                    {
                            Seans seans = new Seans((int)thisReader[0],(int)thisReader[1],(DateTime)thisReader[2], (DateTime)thisReader[3], (int)thisReader[4]);
                            listBox2.Items.Add(seans.Id_sala);
                       
                    }

                }
                thisReader.Close();



            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString(), "Niepowodzenie");
            }
            polaczenie.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            BazaSeans();

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            label3.Text = dateTimePicker1.Value.Date.ToString("yyyy/MM/dd");
            label3.Text = label3.Text.Replace(".", "-");

            BazaLoad2();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            potrzebne = (int)listBox2.SelectedItem;

            var myform = new RezerwacjaKlient();
            myform.Show();
        }
    }
}
