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
    public partial class ControlExplicatie : UserControl
    {
        private string utilizator;
        private string data;
        private int likes;
        private string descriere;
        private int cod;
        string connString="Data Source = Vocabular2.db; Version=3";

        public int Cod
        {
            set { cod = value; }
            get { return cod; }
        }

        public string Utilizator
        {
            set { utilizator = value; tbNume.Text = value; }
            get { return utilizator; }
        }
        public string Data
        {
            set { data = value; tbData.Text = value; }
            get { return data;  }
        }
        public int Likes
        {
            set { likes = value; tbLikes.Text = value.ToString(); }
            get { return likes;  }
        }

        public string Descriere
        {
            set { descriere = value; tbExplicatie.Text = value; }
            get { return descriere; }
        }

        public ControlExplicatie()
        {
            InitializeComponent();
        }

        private void btLike_Click(object sender, EventArgs e)
        {
            likes++;
            tbLikes.Text= likes.ToString();
            btLike.Enabled = false;
            btLike.BackColor = Color.LightGray;
            updateLike();
        }

        private void updateLike()
        {
            SQLiteConnection conexiune = new SQLiteConnection(connString);
            try
            {
                conexiune.Open();
                SQLiteCommand comanda = new SQLiteCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "UPDATE explicatii SET likes=likes+1 WHERE cod="+cod;
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
    }
}
