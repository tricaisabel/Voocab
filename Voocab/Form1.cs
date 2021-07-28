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
using System.IO;
using System.Xml;

namespace Voocab
{
    public partial class Form1 : Form
    {

        private const string PLACE_HOLDER_TEXT = "Vreau sa caut cuvantul...";
        Vocabular v = new Vocabular();
        string connString;
        string utilizator;
        public Form1(string u)
        {
            InitializeComponent();
            connString = "Data Source = Vocabular2.db; Version=3";
            textBox1.ForeColor = Color.Gray;
            if (string.IsNullOrWhiteSpace(textBox1.Text)) textBox1.Text = PLACE_HOLDER_TEXT;
            utilizator = u;
        }

        private void actualizareListView(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            for (int i = 0; i < v.Cuvinte.Count; i++)
            {
                ListViewItem item = new ListViewItem(v.Cuvinte[i].Cod.ToString());
                item.SubItems.Add(v.Cuvinte[i].Denumire);
                item.SubItems.Add(v.Cuvinte[i].Adaugare.ToString());
                item.SubItems.Add(v.Cuvinte[i].Utilizator);
                listView1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(v,"",utilizator);
            frm.Show();
            frm.FormClosed += actualizareListView;
            frm.FormClosed += AfisareBD;
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedItem.ToString() == "Alfabetica")
                v.sortareAlfabetica(true);
            else if (comboBox2.SelectedItem.ToString() == "Dupa nr. de cautari")
                v.SortareDupaCautari(true);
            else if (comboBox2.SelectedItem.ToString() == "Dupa data adaugarii")
                v.SortareDupaData(true);
            actualizareListView(sender,e);
        }
        
        private void QueryCarti(string comanda)
        {
            SQLiteConnection conn = new SQLiteConnection(connString);
            try
            {
                conn.Open();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(comanda, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "cuvinte");
                dataGridView1.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void AfisareBD(object sender, EventArgs e)
        {
            QueryCarti("SELECT * FROM cuvinte");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            QueryCarti("SELECT * FROM cuvinte WHERE denumire like '" + textBox1.Text + "%'");
            SQLiteConnection conexiune = new SQLiteConnection(connString);
            if(textBox1.Text != PLACE_HOLDER_TEXT && textBox1.Text.Length != 0)
            try
            {
                conexiune.Open();
                SQLiteCommand comanda = new SQLiteCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "UPDATE cuvinte SET cautari=cautari+1 WHERE denumire like '" + textBox1.Text + "%'";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string comanda = "SELECT * FROM cuvinte ";
            if (textBox1.Text!=PLACE_HOLDER_TEXT && textBox1.Text.Length!=0) comanda += "WHERE denumire like '" + textBox1.Text + "%' ";
            comanda += "ORDER BY ";
            if (comboBox1.Text == "Alfabetica")
                comanda += "denumire";
            else if (comboBox1.Text == "Dupa nr. de cautari")
                comanda += "cautari";
            else if (comboBox1.Text == "Dupa data adaugarii")
                comanda += "adaugare";
            if (checkBox1.Checked) comanda += " ASC";
            else comanda += " DESC";
            QueryCarti(comanda);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Sortare dupa") 
                comboBox1_SelectedIndexChanged(sender,e);
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            string denumireCuvantSelectat;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                if (dataGridView1.Rows[i].Selected)
                {
                    denumireCuvantSelectat = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    Form2 frm = new Form2(v, denumireCuvantSelectat,utilizator);
                    frm.Show();
                    flowLayoutPanel1.Controls.Clear();
                    frm.FormClosed += dataGridView1_MouseClick;
                }
        }

        public void populareExplicatii(int cod,string utilizator,int likes, string data,string descriere)
        {
            
                ControlExplicatie c = new ControlExplicatie();
                c.Utilizator = utilizator;
                c.Likes = likes;
                c.Data = data;
                c.Descriere = descriere;
                c.Cod = cod; 
                flowLayoutPanel1.Controls.Add(c);
            
        }

        private void dataGridView1_MouseClick(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            int codCuvantSelectat;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                if (dataGridView1.Rows[i].Selected)
                {
                    codCuvantSelectat = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    SQLiteConnection conexiune = new SQLiteConnection(connString);
                    try
                    {
                        conexiune.Open();
                        SQLiteCommand comanda = new SQLiteCommand();
                        comanda.Connection = conexiune;
                        comanda.CommandText = "SELECT cod, utilizator, adaugare, descriere, likes FROM explicatii WHERE codCuvant=" + codCuvantSelectat+" ORDER BY likes DESC";
                        SQLiteDataReader reader = comanda.ExecuteReader();
                        string utilizator = "", data = "", descriere = "";
                        int nrExplicatii = 0, likes = 0,cod=0;
                        while (reader.Read())
                        {
                            nrExplicatii++;
                            utilizator = reader["utilizator"].ToString();
                            data = reader["adaugare"].ToString();
                            descriere = reader["descriere"].ToString();
                            likes = Convert.ToInt32(reader["likes"]);
                            cod= Convert.ToInt32(reader["cod"]);
                            populareExplicatii(cod,utilizator, likes, data, descriere);

                        }
                        if (nrExplicatii == 0)
                        {
                            MessageBox.Show("Nu exista inca explicatii. O poti adauga chiar tu!");
                            flowLayoutPanel1.Controls.Clear();
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conexiune.Close();
                    }

                    break;
                }
        }

        private string generareInfoTextCarti()
        {
            string text = "";
            SQLiteConnection conn = new SQLiteConnection(connString);
            try
            {
                conn.Open();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM cuvinte", conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "cuvinte");

                DataTable tabela = ds.Tables["cuvinte"];
                foreach (DataColumn coloana in tabela.Columns)
                    text += coloana.ColumnName + " ";
                text += Environment.NewLine;
                foreach (DataRow linie in tabela.Rows)
                {
                    foreach (object camp in linie.ItemArray)
                        text += camp + " ";
                    text += Environment.NewLine;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return text;
        }

        private void inFisierTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(generareInfoTextCarti());
                sw.Close();
                fs.Close();
                MessageBox.Show("Salvare cu succes!");
            }
        }

        private void analiticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLiteConnection conexiune = new SQLiteConnection(connString);
            try
            {
                conexiune.Open();
                SQLiteCommand comanda = new SQLiteCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "select cautari,sum(likes) from cuvinte,explicatii where cuvinte.cod=explicatii.codCuvant group by cuvinte.cod";
                SQLiteDataReader reader = comanda.ExecuteReader();
                List<int> cautari = new List<int>();
                List<int> likes = new List<int>();
                int cartiDefinite = 0;
                while (reader.Read())
                {
                    cautari.Add(Convert.ToInt32(reader[0]));
                    likes.Add(Convert.ToInt32(reader[1]));
                    cartiDefinite++;
                }
                reader.Close();
                comanda.CommandText = "SELECT MAX(cod) FROM cuvinte";
                int cartiTotale= Convert.ToInt32(comanda.ExecuteScalar());
                int cartiNedefinite=cartiTotale-cartiDefinite;
                int procDefinite=(int)(((double)cartiDefinite/cartiTotale)*100);
                int procentNedefinite= 100-procDefinite;
                Form3 frm = new Form3(likes, cautari,procDefinite,procentNedefinite);
                frm.Show();
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

        private void inFisierXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.xml)|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string text = generareInfoTextCarti();
                text.Replace("\n", " ");
                string[] elemente = text.Split(' ');
                MemoryStream memStream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(memStream, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;

                writer.WriteStartDocument();

                writer.WriteStartElement("Cuvinte");

                for (int j = 0; j < elemente.Length; j=j+1)
                {
                    writer.WriteStartElement("Element"+j);
                    writer.WriteAttributeString("lin",(j/4).ToString());
                    writer.WriteAttributeString("col", (j % 4).ToString());
                    writer.WriteValue(elemente[j]);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Close();

                string str = Encoding.UTF8.GetString(memStream.ToArray());
                memStream.Close();

                StreamWriter sw = new StreamWriter(dlg.FileName);
                sw.WriteLine(str);
                sw.Close();
                MessageBox.Show("Salvare cu succes!"); ;
            }
                
        }

    }
}
