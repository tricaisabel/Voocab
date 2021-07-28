using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Voocab
{
    public partial class FormIntroducere : Form
    {
        string connString = "Data Source = Vocabular2.db; Version=3";
        string utilizator;
        public FormIntroducere()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            utilizator = tbUtilizatorNou.Text;
            if (utilizator == "")
                errorProvider1.SetError(tbUtilizatorNou, "Introduceti o valuare nenula");
            else
            {
                if (utilizatorulNuExista(utilizator))
                {
                    MessageBox.Show("Bine ai venit!");
                    introducereUtilizator(utilizator);
                }
                else MessageBox.Show("Bine ai revenit, " + utilizator);
                Form1 frm = new Form1(utilizator);
                frm.Show();
            }
            
            
        }

        private bool utilizatorulNuExista(string utilizator)
        {
            SQLiteConnection conexiune = new SQLiteConnection(connString);
            try
            {
                conexiune.Open();
                SQLiteCommand comanda = new SQLiteCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT COUNT(id) FROM utilizatori WHERE nume='" + utilizator + "'";
                int count = Convert.ToInt32(comanda.ExecuteScalar());
                if (count == 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
            return false;
        }

        private void introducereUtilizator(string utilizator)
        {
            SQLiteConnection conexiune = new SQLiteConnection(connString);
            try
            {
                conexiune.Open();
                SQLiteCommand comanda = new SQLiteCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT COUNT(id) FROM utilizatori";
                int idMax = Convert.ToInt32(comanda.ExecuteScalar());
                idMax += 1;
                comanda.CommandText = "INSERT INTO utilizatori VALUES(" + idMax + ", '" + utilizator + "')";
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
        }

        private void tbUtilizatorNou_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter) button1_Click(sender, e);
        }
    }
}
