using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voocab
{
    public class Vocabular: Sortare
    {
        List<Cuvant> cuvinte;

        public Vocabular()
        {
            cuvinte = new List<Cuvant>();
        }

        public List<Cuvant> Cuvinte
        {
            get { return cuvinte; }
            set { cuvinte = value; }
        }

        public void sortareAlfabetica(bool asc)
        {
            if(asc)
            {
                cuvinte.Sort((x, y) => string.Compare(x.Denumire, y.Denumire));
            }
        }

        public  void SortareDupaCautari(bool asc)
        {
            for(int i=0;i<Cuvant.NrCuvinte;i++)
            {
                for(int j=i+1;j< Cuvant.NrCuvinte; j++)
                {
                    Cuvant c1 = cuvinte[i];
                    Cuvant c2 = cuvinte[j];
                    if (c1.CompareTo(c2) > 0)
                    { 
                        Cuvant aux = cuvinte[i];
                        cuvinte[i] = cuvinte[j];
                        cuvinte[j] = aux;
                    }
                    
                }
            }
        }

        public void SortareDupaData(bool asc)
        {
            for (int i = 0; i < cuvinte.Count - 1; i++)
            {
                for (int j = i + 1; j <cuvinte.Count; j++)
                {
                    Cuvant c1 = cuvinte[i];
                    Cuvant c2 = cuvinte[j];
                    if (DateTime.Compare(c1.Adaugare, c2.Adaugare) > 0)
                    {
                        Cuvant aux = cuvinte[i];
                        cuvinte[i] = cuvinte[j];
                        cuvinte[j] = aux;
                    }

                }
            }
        }

        public static Vocabular operator +(Vocabular v, Cuvant c)
        {
            v.cuvinte.Add(c);
            return v;
        }

        public override string ToString()
        {
            string result = "";
            foreach(Cuvant c in cuvinte)
            {
                result += "\n"+c.ToString();
            }
            return result;
        }
    }
}
