using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voocab
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
 /*           Vocabular v = new Vocabular();
            Cuvant c1 = new Cuvant("Acuvant1", new DateTime(2019, 11, 5));
            Cuvant c2 = new Cuvant("Bcuvant2", new DateTime(2018, 11, 5));
            Explicatie e1 = new Explicatie(new DateTime(2019, 11, 6), "Isabel", "Aceasta este descrierea 1");
            Explicatie e2 = new Explicatie(new DateTime(2019, 11, 6), "Isabel", "Aceasta este descrierea 2");
            Explicatie e3 = new Explicatie(new DateTime(2018, 11, 6), "Claudia", "Aceasta este descrierea 3");
            Explicatie e4 = new Explicatie(new DateTime(2018, 11, 6), "Claudia", "Aceasta este descrierea 4");

            c1+=e1;
            c1+=e2;
            c2+= e3;
            c2 += e4;

            e1++;
            e1++;
            e4++;

            c1.Cautari = 1;
            c2.Cautari = 2;

            v += c2;
            v += c1;

            v.SortareDupaData();

            Console.WriteLine(v.ToString());*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1("isabel"));
        }
    }
}
