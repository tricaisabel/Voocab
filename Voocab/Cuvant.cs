using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voocab
{
    public class Cuvant: ICloneable, IComparable
    {
        int cod;
        string denumire;
        DateTime adaugare;
        int cautari;
        List<Explicatie> explicatii;
        static int nrCuvinte = 0;
        string utilizator;

        public Cuvant(string d,DateTime a,string u)
        {
            nrCuvinte++;
            cod = nrCuvinte;
            denumire = d;
            adaugare = a;
            cautari = 0;
            explicatii = new List<Explicatie>();
            utilizator = u;
        }
        public String Utilizator
        {
            set { utilizator = value; }
            get { return utilizator; }
        }

        public static int NrCuvinte
        {
            get { return nrCuvinte; }
        }
        public DateTime Adaugare
        {
            get { return adaugare; }
            set { adaugare = value; }
        }

        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        public int Cautari
        {
            get { return cautari; }
            set { cautari = value; }
        }

        public string Denumire
        {
            get { return denumire; }
            set { denumire = value; }
        }

        public List<Explicatie> Explicatii
        {
            get { return explicatii; }
            set { explicatii = value; }
        }

        public static Cuvant operator +(Cuvant c,Explicatie e)
        {
            c.explicatii.Add(e);
            return c;
        }

        public Explicatie this[int index]
        {
            get
            {
                if (explicatii != null && index >= 0 && index < explicatii.Count)
                    return explicatii[index];
                else
                    return null;
            }
        }

        public static void sortareLikes(List<Explicatie> e)
        {
            for (int i = 0; i < e.Count - 1; i++)
                for (int j = i + 1; j < e.Count; j++)
                    if (e[i].CompareTo(e[j])==-1)
                    {
                        Explicatie aux = e[i];
                        e[i] = e[j];
                        e[j] = aux;
                    }
        }

        public object Clone()
        {
            Cuvant clona = (Cuvant)this.MemberwiseClone();
            List<Explicatie> listaNoua = new List<Explicatie>();
            foreach (Explicatie a in explicatii)
                listaNoua.Add((Explicatie)a.Clone());
            clona.explicatii = listaNoua;
            return clona;
        }

        public int CompareTo(object obj)
        {
            Cuvant c = (Cuvant)obj;
            if (cautari > c.cautari) return 1;
            else
                if (cautari==c.cautari) return 0;
            else
                return -1;
        }

        public override string ToString()
        {
            string result= cod + "\t" + denumire + "\t" + adaugare + "\t" + cautari;
            foreach(Explicatie e in explicatii)
            {
                result += "\n" + e.Descriere + "\t" + e.Likes + "\t" + e.Utilizator + "\t" + e.Adaugare;
            }
            return result;
        }
    }
}
