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
    public partial class Form2 : Form
    {
        Cuvant c;
        Explicatie ex;
        Vocabular v;
        string connString;
        string denumire;
        string utilizator;
        public Form2(Vocabular vocabular,string den,string u)
        {
            v = vocabular;
            utilizator = u;
            denumire=den;
            InitializeComponent();
            connString = "Data Source = Vocabular2.db; Version=3";
            if (den != "")
            {
                tbDenumire.Text=denumire;
                tbDenumire.ReadOnly = true;
                tbDenumire.BackColor = Color.White;
            }
        }

        private int indexMaxim(string tabela)
        {
            int maxim=0;
            SQLiteConnection conexiune = new SQLiteConnection(connString);
            try
            {
                conexiune.Open();
                SQLiteCommand comanda = new SQLiteCommand();
                comanda.Connection = conexiune;

                comanda.CommandText = "SELECT MAX(cod) FROM "+tabela;
                maxim = Convert.ToInt32(comanda.ExecuteScalar());


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
            return maxim+1;
        }
        private void inserareCuvant(Cuvant c)
        {
            SQLiteConnection conexiune = new SQLiteConnection(connString);
            try
            {
                conexiune.Open();
                SQLiteCommand comanda = new SQLiteCommand();
                comanda.Connection = conexiune;                
                comanda.CommandText = "INSERT INTO cuvinte VALUES (" + indexMaxim("cuvinte") + ", '" + c.Denumire + "', '" + c.Adaugare.ToString() + "', " + c.Cautari.ToString() + ", '" + c.Utilizator + "')";
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

        private void inserareExplicatie(Explicatie e,string denumire)
        {
            SQLiteConnection conexiune = new SQLiteConnection(connString);
            try
            {
                conexiune.Open();
                SQLiteCommand comanda = new SQLiteCommand();
                comanda.Connection = conexiune;
                string s = "select cod from cuvinte where denumire like '" + denumire+"'";
                comanda.CommandText =s ;
                int codCuvant = Convert.ToInt32(comanda.ExecuteScalar());

                comanda.CommandText = "INSERT INTO explicatii VALUES (" + indexMaxim("explicatii") +", '"+e.Adaugare.ToString()+"', "+e.Likes+", '"+e.Utilizator+"', '"+e.Descriere+"', "+codCuvant+")";
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
        private void btAdaugare_Click(object sender, EventArgs e)
        {
            if (denumire=="")
            {
                string denumire = tbDenumire.Text;
                string descriere = tbExplicatie.Text;
                if (denumire == "")
                    errorProvider1.SetError(tbDenumire, "Cuvantul nu poate fi nul");
                else if (descriere == "")
                    errorProvider1.SetError(tbExplicatie, "Explicatia nu poate fi nula");
                else
                {
                    ex = new Explicatie(DateTime.Now, utilizator, descriere);
                    c = new Cuvant(denumire, DateTime.Now, utilizator);
                    c += ex;
                    v += c;
                    tbDenumire.Clear();
                    tbExplicatie.Clear();
                    inserareCuvant(c);
                    inserareExplicatie(ex, denumire);
                    MessageBox.Show("Adaugarea este reusita!");
                }
            }
            else
            {               
                string descriere = tbExplicatie.Text;
                if (descriere == "")
                    errorProvider1.SetError(tbExplicatie, "Explicatia nu poate fi nula");
                else
                {
                    ex = new Explicatie(DateTime.Now, utilizator, descriere);
                    inserareExplicatie(ex, denumire);
                    this.Close();
                    MessageBox.Show("Adaugarea este reusita!");
                }
            }            
        }

    }
}
