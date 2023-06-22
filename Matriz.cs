using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrizP
{
    class Matriz
    {
        //Atributos
        const int MAXF = 50;
        const int MAXC = 50;
        private int[,] m;
        private int f,c;
        //Constructor
        public Matriz()
        {
            m = new int[MAXF,MAXC];
            f = 0;
            c = 0;
        }
      //Cargar Descargar
      public void Cargar(int nf,int nc ,int a,int b)
        {
            Random r = new Random();
            f = nf;
            c = nc;
            for (int f1 = 1; f1 <= f; f1++)            
                for (int c1 = 1; c1 <= c; c1++)                
                    m[f1, c1] = r.Next(a, b);                            
        }
        public string Descargar()
        {
            string s = "";
            for (int f1 = 1; f1 <= f; f1++)
            {
                for (int c1 = 1; c1 <= c; c1++)
                {
                    s = s + m[f1, c1] + "\x0009";
                }
                s = s + "\x000d" + "\x000a";
            }
            return s;
        }
        public double AcumularConPrimo()
        {
            Numeros n = new Numeros();
            double acum = 0;
            for (int f1 = f; f1 >= 1; f1--)
            {
                for (int c1 = c; c1 >= 1; c1--)
                {
                    n.Cargar(m[f1, c1]);
                    if (n.VerifPrimo())
                    {
                        acum = acum + Math.Sqrt(c1);
                    }               
                }
            }
            return acum;
        }
    }
}
