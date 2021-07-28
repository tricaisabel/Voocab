using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;


namespace Voocab
{
    public partial class Form3 : Form
    {
        Bitmap bm;
        Graphics g;
        const int marg = 10;
        Font font1 = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
        Font font2 = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular);
        int procCuvDefinite=40;
        int procCuvNedefinite = 60;
        int axa = 380;
        List<int> cautari = new List<int>();
        List<int> likes = new List<int>();
        public Form3(List<int> l,List<int> c,int d,int n)
        {
            likes = l;
            cautari = c;
            procCuvDefinite = d;
            procCuvNedefinite = n;
            InitializeComponent();
        }

        private void desenarePie(object sender, PaintEventArgs e)
        {
            int procPieDefinite = procCuvDefinite * 360 / (procCuvDefinite + procCuvNedefinite);
            int procPieNedefinite = 360 - procPieDefinite;

            Graphics gr = e.Graphics;
            Rectangle rec = new Rectangle(26, 186, 350, 350);
            gr.DrawPie(new Pen(Color.ForestGreen, 3), rec, 0, procPieDefinite);
            gr.FillPie(new SolidBrush(Color.ForestGreen), rec, 0, procPieDefinite);
            gr.DrawPie(new Pen(Color.CornflowerBlue, 3), rec, procPieDefinite, procPieNedefinite);
            gr.FillPie(new SolidBrush(Color.CornflowerBlue), rec, procPieDefinite, procPieNedefinite);
            //Legenda
            gr.DrawString("Cuvinte cu explicatii (" + procCuvDefinite + "%)", font1, new SolidBrush(Color.Black), new Point(55, 66));
            Pen pen = new Pen(Color.ForestGreen, 3);
            Rectangle rec2 = new Rectangle(24, 66, 15, 15);
            gr.DrawRectangle(pen, rec2);
            gr.FillRectangle(new SolidBrush(Color.ForestGreen), rec2);

            gr.DrawString("Cuvinte fara explicatii (" + procCuvNedefinite + "%)", font1, new SolidBrush(Color.Black), new Point(55, 96));
            Pen pen2 = new Pen(Color.CornflowerBlue, 3);
            Rectangle rec3 = new Rectangle(24, 96, 15, 15);
            gr.DrawRectangle(pen2, rec3);
            gr.FillRectangle(new SolidBrush(Color.CornflowerBlue), rec3);
        }

        private void pdPrintPie(object sender, PrintPageEventArgs e)
        {
            int procPieDefinite = procCuvDefinite * 360 / (procCuvDefinite + procCuvNedefinite);
            int procPieNedefinite = 360 - procPieDefinite;

            Graphics gr = e.Graphics;
            Rectangle rec = new Rectangle(26, 186, 350, 350);
            gr.DrawPie(new Pen(Color.ForestGreen, 3), rec, 0, procPieDefinite);
            gr.FillPie(new SolidBrush(Color.ForestGreen), rec, 0, procPieDefinite);
            gr.DrawPie(new Pen(Color.CornflowerBlue, 3), rec, procPieDefinite, procPieNedefinite);
            gr.FillPie(new SolidBrush(Color.CornflowerBlue), rec, procPieDefinite, procPieNedefinite);
            //Legenda
            gr.DrawString("Cuvinte cu explicatii (" + procCuvDefinite + "%)", font1, new SolidBrush(Color.Black), new Point(55, 66));
            Pen pen = new Pen(Color.ForestGreen, 3);
            Rectangle rec2 = new Rectangle(24, 66, 15, 15);
            gr.DrawRectangle(pen, rec2);
            gr.FillRectangle(new SolidBrush(Color.ForestGreen), rec2);

            gr.DrawString("Cuvinte fara explicatii(" + procCuvNedefinite + "%)", font1, new SolidBrush(Color.Black), new Point(55, 96));
            Pen pen2 = new Pen(Color.CornflowerBlue, 3);
            Rectangle rec3 = new Rectangle(24, 96, 15, 15);
            gr.DrawRectangle(pen2, rec3);
            gr.FillRectangle(new SolidBrush(Color.CornflowerBlue), rec3);
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            desenarePie(sender, e);
        }

        private void desenarePlot(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawString("Axa Ox - numarul de cautari ale unui cuvant", font1, new SolidBrush(Color.Black), new Point(19, 66));
            gr.DrawString("Axa Oy - numarul total de like-uri ale unui cuvant", font1, new SolidBrush(Color.Black), new Point(19, 96));
            gr.DrawString("Un cuvant al vocabularului", font1, new SolidBrush(Color.Black), new Point(51, 126));
            Pen pen2 = new Pen(Color.CornflowerBlue, 3);
            Rectangle rec3 = new Rectangle(24, 126, 15, 15);
            gr.DrawRectangle(pen2, rec3);
            gr.FillRectangle(new SolidBrush(Color.CornflowerBlue), rec3);
            //Desenare axe
            int x1 = 37, y1 = 186;
            Point initial = new Point(x1, y1);
            Rectangle rec = new Rectangle(x1, y1, axa, axa);
            Pen pen = new Pen(Color.Black, 3);
            Point x = new Point(x1, y1 + axa);
            Point y = new Point(x1 + axa, y1 + axa);
            gr.DrawLine(pen, x, y);
            gr.DrawLine(pen, initial, x);
            //Desenare denumire axe
            gr.DrawString("Cautari", font2, new SolidBrush(Color.Black), new Point(x1 + 90 * axa / 100, y1 + axa));
            gr.DrawString("Like-uri", font2, new SolidBrush(Color.Black), new Point(x1 - 5, y1 - 15));
            //Desenare puncte-cuvinte
            int maxCautari = cautari.Max();
            int maxLikes = likes.Max();
            int pX, pY;
            for (int i = 0; i < cautari.Count; i++)
            {
                pX = (int)(((double)cautari[i] / maxCautari) * axa) + initial.X + 4;
                pY = (int)(((double)likes[i] / maxLikes) * axa) + initial.Y - 4;
                gr.DrawRectangle(pen2, new Rectangle(pX, pY, 4, 4));
                gr.FillRectangle(new SolidBrush(Color.CornflowerBlue), new Rectangle(pX, pY, 4, 4));
            }
        }

        private void pdPrintPlot(object sender, PrintPageEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawString("Axa Ox - numarul de cautari ale unui cuvant", font1, new SolidBrush(Color.Black), new Point(19, 66));
            gr.DrawString("Axa Oy - numarul total de like-uri ale unui cuvant", font1, new SolidBrush(Color.Black), new Point(19, 96));
            gr.DrawString("Un cuvant al vocabularului", font1, new SolidBrush(Color.Black), new Point(51, 126));
            Pen pen2 = new Pen(Color.CornflowerBlue, 3);
            Rectangle rec3 = new Rectangle(24, 126, 15, 15);
            gr.DrawRectangle(pen2, rec3);
            gr.FillRectangle(new SolidBrush(Color.CornflowerBlue), rec3);
            //Desenare axe
            int x1 = 37, y1 = 186;
            Point initial = new Point(x1, y1);
            Rectangle rec = new Rectangle(x1, y1, axa, axa);
            Pen pen = new Pen(Color.Black, 3);
            Point x = new Point(x1, y1 + axa);
            Point y = new Point(x1 + axa, y1 + axa);
            gr.DrawLine(pen, x, y);
            gr.DrawLine(pen, initial, x);
            //Desenare denumire axe
            gr.DrawString("Cautari", font2, new SolidBrush(Color.Black), new Point(x1 + 90 * axa / 100, y1 + axa));
            gr.DrawString("Like-uri", font2, new SolidBrush(Color.Black), new Point(x1 - 5, y1 - 15));
            //Desenare puncte-cuvinte
            int maxCautari = cautari.Max();
            int maxLikes = likes.Max();
            int pX, pY;
            for (int i = 0; i < cautari.Count; i++)
            {
                pX = (int)(((double)cautari[i] / maxCautari) * axa) + initial.X + 4;
                pY = (int)(((double)likes[i] / maxLikes) * axa) + initial.Y - 4;
                gr.DrawRectangle(pen2, new Rectangle(pX, pY, 4, 4));
                gr.FillRectangle(new SolidBrush(Color.CornflowerBlue), new Rectangle(pX, pY, 4, 4));
            }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            desenarePlot(sender, e);
        }

        private void groupBox2_MouseHover(object sender, EventArgs e)
        {
            groupBox2.DoDragDrop("gbPie", DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            panel1.BackColor = Color.LightBlue;
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Gainsboro;
        }

        private void pdPrint(object sender, PaintEventArgs e)
        {
            desenarePie(sender, e);
        }
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            panel1.BackColor = Color.LightBlue;
            string text = e.Data.GetData(typeof(string)).ToString();
            PrintDocument pd = new PrintDocument();
            if(text=="gbPlot") pd.PrintPage += new PrintPageEventHandler(pdPrintPlot);
            else pd.PrintPage += new PrintPageEventHandler(pdPrintPie);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
            panel1.BackColor = Color.Gainsboro;
        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            groupBox1.DoDragDrop("gbPlot", DragDropEffects.Copy | DragDropEffects.Move);
        }

    }
}
