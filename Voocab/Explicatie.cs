using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voocab
{
    public class Explicatie: ICloneable, IComparable
    {
        int cod;
        DateTime adaugare;
        int likes;
        string utilizator;
        string descriere;
        static int nrExplicatii=0;

        //Setteri si getteri
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

        public int Likes
        {
            get { return likes; }
            set { likes = value; }
        }

        public string Utilizator
        {
            get { return utilizator; }
            set { utilizator = value; }
        }

        public string Descriere
        {
            get { return descriere; }
            set { descriere = value; }
        }

        //Constructor
        public Explicatie(DateTime a, string u,string d)
        {
            nrExplicatii++;
            cod = nrExplicatii;
            adaugare = a;
            likes = 0;
            utilizator = u;
            descriere = d;
        }

        //Interfete
        public int CompareTo(object obj)
        {
            Explicatie e = (Explicatie)obj;
            if (likes > e.likes) return 1;
            else
                if (likes == e.likes) return 0;
            else
                return -1;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public static Explicatie operator ++(Explicatie e)
        {
            e.likes++;
            return e;
        }

        public static Explicatie operator --(Explicatie e)
        {
            e.likes--;
            return e;
        }

    }
}
