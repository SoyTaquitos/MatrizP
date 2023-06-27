﻿using System;
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
        //Metodos de ayuda
        public void Intercambiar(int f1, int c1, int f2, int c2)
        {
            int aux;
            aux = m[f1, c1];
            m[f1, c1] = m[f2, c2];
            m[f2, c2] = aux;
        }
        public int GetCantPrimos(int fila)
        {
            int cant = 0;
            Numeros pri = new Numeros();
            for (int i = 1; i <= this.c; i++)
            {
                pri.Cargar(m[fila, i]);
                if(pri.VerifPrimo())
                {
                    cant++;
                }
            }
            return cant;
        }
        public void IntercambiarFilas(int f1,int f2)
        {
            for (int i = 1; i <= c; i++)
            {
                this.Intercambiar(f1, i, f2, i);
            }
        }

        //Practico
        public double AcumularConPrimo() //Ejercicio 1
        {
            Numeros n = new Numeros();
            double acum = 0;
            bool b = true;
            for (int f1 = f; f1 >= 1; f1--)
            {
                for (int c1 = c; c1 >= 1; c1--)
                {
                    n.Cargar(m[f1, c1]);
                    if (n.VerifPrimo())
                    {
                        if(b)
                        {
                            acum = acum - Math.Sqrt(m[f1,c1]);
                        }
                        else
                        {
                            acum = acum + Math.Sqrt(m[f1,c1]);
                        }
                        b = !b;                       
                    }               
                }
            }
            return acum;
        }
        public int FrecuenciaDeUnElemento(int ele) //Ejercicio 2
        {
            int frec = 0;
            for (int c1 = 1; c1 <= c; c1++)
            {
                for (int f1 = 1; f1 <= f; f1++)
                {
                    if (m[f1,c1] == ele)
                    {
                        frec++;
                    }
                }
            }
            return frec;
        }
        public int ContarEleQueNoSeRepiten() //Ejercicio 3
        {
            int cont = 0;
            int ele;
            for (int c1 = 1; c1 <= c; c1++)
            {
                for (int f1 = 1; f1 <= f; f1++)
                {
                    ele = this.FrecuenciaDeUnElemento(m[f1, c1]);                   
                    if (ele == 1)
                    {
                        cont++;
                    }
                }
            }            
            return cont;
        }       
        public void CargarSerieFibonacci(int nf, int nc) //Ejercicio 4
        {
            Numeros ele = new Numeros();
            f = nf;
            c = nc;
            int ind = 0;
            int i;
            int c1 = 1;
            for (int f1 = 1; f1 <= f; f1++)
            {
                if (c1 < c)
                {
                    i = c1;
                    for (int cd = i; cd <= c; cd++)
                    {
                        m[f1, cd] = ele.Fibonacci(ind);
                        ind++;
                        c1++;
                    }
                }
                else
                {
                    i = c;
                    for (int cd = i; cd >= 1; cd--)
                    {
                        m[f1, cd] = ele.Fibonacci(ind);
                        ind++;
                        c1 = 1;
                    }
                }
            }
        }
        public bool VerificarSiLasFilasEstanOrdenadas() //Ejercicio 5
        {
            bool b = false;
            int ele;
            for (int f1 = 1; f1 <= f; f1++)
            {
                for (int c1 = 1; c1 <= c -1; c1++)
                {
                    ele = m[f1, c1+1];
                    if(m[f1,c1] <= ele)
                    {
                        b = true;
                    }
                    else
                    {
                        b = false;                                         
                    }
                }
            }
            return b;
        }
        public void MayorFrecuenciaUltimaColumna() //Ejercicio 6
        {

        }
        public bool VerificarSiEstaOrdenadaConRigor(int r) //Ejercicio 7
        {
            bool b = false;
            int rigor = r;
            for (int f1 = 1; f1 <= f; f1++)
            {
                for (int c1 = 1; c1 <= c - 1; c1++)
                {
                    if(m[f1,c1]+ r == m[f1,c1+1])
                    {
                        b = true;
                    }
                    else
                    {
                        b = false;
                    }
                }
            }
            return b;
        }     
        public bool VerificarSiUnaMatrizEstaEnOtra() //Ejercicio 8
        {
            bool verif = false;

            return verif;
        }   
        public void SegmentarFilasEnParesImpares() //Ejercicio 9 mal
        {
            Numeros ele = new Numeros();
            Numeros ele2 = new Numeros();            
            int i;
            for (int fp = 1; fp <= f; fp++)
            {
                for (int cp = 1; cp <= c; cp++)
                {
                    for (int fd = fp; fd <= f; fd++)
                    {
                        if (fd == fp)
                        {
                            i = cp;
                        }
                        else
                        {
                            i = 1;
                        }
                        for (int cd = i; cd <= c; cd++)
                        {
                            ele.Cargar(m[fd, cd]);
                            ele2.Cargar(m[fp, cp]);
                            if (ele.VerificarPar() && !ele2.VerificarPar() ||
                                ele.VerificarPar() && ele2.VerificarPar() && m[fd,cd] < m [fp,cp] ||
                                !ele.VerificarPar() && !ele2.VerificarPar() && m[fd,cd] < m[fp,cp])
                            {
                                this.Intercambiar(fd, cd, fp, cp);
                            }
                        }
                    }
                }
            }
        }
        public void OrdFilasPorCantPrimos() //Ejercicio 10
        {
            int a, b;
            for (int f1 = 1; f1 <= f - 1; f1++)
            {
                for (int f2 = f1 + 1; f2 <= f; f2++)
                {
                    a = this.GetCantPrimos(f1);
                    b = this.GetCantPrimos(f2);
                    if(a > b)
                    {
                        this.IntercambiarFilas(f1, f2);
                    }
                }
            }
        }



    }
}
