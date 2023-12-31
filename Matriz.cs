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
        }public bool BusquedaDeUnElemento(int ele)
        {
            bool b = false;
            int f1, c1;
            for (f1 = 1; f1 <= f; f1++)
            {
                c1 = 1;
                while ((c1 <= c) && (b == false))
                {
                    if (ele == m[f1, c1])
                    {
                        b = true;
                    }
                    c1++;
                }
            }
            return b;
        }        
        public void OrdenarUnaFilaMenMay(int nf)
        {
            // i = Inicio; d = Desplazamiento
            for (int i = 1; i <= c-1; i++)
            {
                for (int d = c; d >= i + 1; d--)
                {
                    if(m[nf,d] < m[nf,d- 1])
                    {
                        this.Intercambiar(nf,d, nf,d-1);
                    }
                }
            }
        }
        public void OrdenarUnaColumna(int nc)
        {
            for (int t = 1; t <= f - 1; t++)
            {
                for (int d = f; d >= t + 1; d--)
                {
                    if (m[d, nc] < m[d - 1, nc])
                        this.Intercambiar(d, nc, d - 1, nc);
                }
            }
        }
        public void SegmentarFilaParNoPar(int nf)
        {
            // i = Inicio; d = Desplazamiento
            Numeros ele1 = new Numeros();
            Numeros ele2 = new Numeros();
            int fila = nf;
            for (int i = 1; i <= c - 1; i++)
            {
                for (int d = c; d >= i + 1; d--)
                {
                    ele1.Cargar(m[fila, d]);
                    ele2.Cargar(m[fila, d - 1]);
                    if (ele1.VerificarPar() && !ele2.VerificarPar() ||
                        ele1.VerificarPar() &&  ele2.VerificarPar() && m[fila,d] < m[fila,d-1] ||
                        !ele1.VerificarPar() && !ele2.VerificarPar() && m[fila, d] < m[fila, d - 1])
                    {
                        this.Intercambiar(fila, d, fila, d - 1);
                    }
                }
            }
        }
        

        //Practico
        // PARTE 1
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
            int f1, c1, aux, may, aux2;
            may = 0;
            for (f1 = 1; f1 <= f; f1++)
            {
                aux2 = m[f1, 1];
                aux = this.FrecuenciaDeUnElemento(m[f1, 1]);
                for (c1 = 2; c1 <= c; c1++)
                {
                    aux = this.FrecuenciaDeUnElemento(m[f1, c1]);
                    if (aux > may)
                    {
                        may = aux;
                        aux2 = m[f1, c1];

                    }
                    m[f1, c + 1] = aux2;
                }
            }
            c++;
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
        public bool VerificarSiUnaMatrizEstaEnOtra(Matriz m2) //Ejercicio 8
        {
            bool verif = false;           
            int f1, c1;
            c1 = 1;
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    verif = m2.BusquedaDeUnElemento(m[f1, c1]);
                    if (verif == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }   
        public void SegmentarFilasEnParesImpares() //Ejercicio 9 
        {
            for (int f1 = 1; f1 <= f; f1++)
            {
                this.SegmentarFilaParNoPar(f1);
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
        //PARTE 2
        public void OrdenarPorFrecuenciaSecuencia() //Ejercicio 1
        {
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
                            if (m[fd, cd] < m[fp, cp])
                            {
                                this.Intercambiar(fd, cd, fp, cp);
                            }
                        }
                    }
                }
            }
        }
        public void OrdenarMatrizSenozoidal() //Ejercicio 2 //Verlo denuevo
        {
            int i;
            bool b = true;
            for (int cp = 1; cp <= c; cp++)
            {
                if (b)
                    for (int fp = f; fp >= 1; fp--)
                        for (int cd = cp; cd <= c; cd++)
                        {
                            if (cd == cp)
                                i = fp;
                            else
                                i = f;
                            for (int fd = i; fd >= 1; fd--)
                                if (m[fd, cd] < m[fp, cp])
                                    this.Intercambiar(fd, cd, fp, cp);
                        }
                else
                    for (int fp = 1; fp <= f; fp++)
                        for (int cd = cp; cd <= c; cd++)
                        {
                            if (cd == cp)
                                i = fp;
                            else
                                i = 1;
                            for (int fd = i; fd <= f; fd++)
                                if (m[fd, cd] < m[fp, cp])
                                    this.Intercambiar(fd, cd, fp, cp);
                        }
                b = !b;
            }
        }
        public void IntercalarFiboNoFibo() //Ejercicio 3 //Mirarlo
        {
            int fd, fp, cp, cd, i;
            bool b = true;
            Numeros nu1, nu2;
            nu1 = new Numeros();
            nu2 = new Numeros();
            for (fp = f; fp >= 1; fp--)
                for (cp = 1; cp <= c; cp++)
                {
                    if (b)
                        for (fd = fp; fd >= 1; fd--)
                        {
                            if (fd == fp)
                                i = cp;
                            else
                                i = 1;
                            for (cd = i; cd <= c; cd++)
                            {
                                nu1.Cargar(m[fp, cp]); nu2.Cargar(m[fd, cd]);
                                if (!nu1.VerificarFibo() && nu2.VerificarFibo() ||
                                     nu1.VerificarFibo() && nu2.VerificarFibo() && m[fd, cd] < m[fp, cp] ||
                                    !nu1.VerificarFibo() && !nu2.VerificarFibo() && m[fd, cd] < m[fp, cp])

                                    this.Intercambiar(fd, cd, fp, cp);
                            }
                        }
                    else

                        for (fd = fp; fd >= 1; fd--)
                        {
                            if (fd == fp)
                                i = cp;
                            else
                                i = 1;
                            for (cd = i; cd <= c; cd++)
                            {
                                nu1.Cargar(m[fp, cp]); nu2.Cargar(m[fd, cd]);
                                if (nu1.VerificarFibo() && !nu2.VerificarFibo() ||
                                   !nu1.VerificarFibo() && !nu2.VerificarFibo() && m[fd, cd] < m[fp, cp] ||
                                    nu1.VerificarFibo() && nu2.VerificarFibo() && m[fd, cd] < m[fp, cp])

                                    this.Intercambiar(fd, cd, fp, cp);
                            }
                        }
                    b = !b;
                }
        }
        public void OrdenarTriangularSuperior() //Ejercicio 4
        {
            int fp, cp, fd, cd, i;
            for (fp = 1; fp <= f - 1; fp++)
                for (cp = (fp + 1); cp <= c; cp++)
                    for (fd = fp; fd <= f - 1; fd++)
                    {
                        if (fd == fp)
                            i = cp;
                        else
                            i = fd + 1;

                        for (cd = i; cd <= c; cd++)
                            if (m[fd, cd] < m[fp, cp])
                                this.Intercambiar(fd, cd, fp, cp);
                    }
        }
        public void SegmentarParImparTriangularInferiorDerecha() //Ejercicio 5
        {
            Numeros nu1, nu2;
            nu1 = new Numeros();
            nu2 = new Numeros();
            for (int cp = 2; cp <= c; cp++)
                for (int fp = f; fp >= (f + 2) - cp; fp--)
                    for (int cd = cp; cd <= c; cd++)
                        for (int fd = fp; fd >= (f + 2) - cd; fd--)
                        {
                            nu1.Cargar(m[fp, cp]); nu2.Cargar(m[fd, cd]);
                            if (!nu1.VerificarPar() && nu2.VerificarPar() ||
                                !nu1.VerificarPar() && !nu2.VerificarPar() && m[fd, cd] < m[fp, cp] ||
                                 nu1.VerificarPar() && nu2.VerificarPar() && m[fd, cd] < m[fp, cp])

                                this.Intercambiar(fd, cd, fp, cp);
                        }
        }
        public void OrdenamientoDiagonal() //Ejercicio 6
        {   
            for (int fp = 1; fp <= f; fp++)
                for (int cp = (c + 1) - fp; cp >= (c + 1) - fp; cp--)
                    for (int fd = fp; fd <= f; fd++)
                        for (int cd = (c + 1) - fd; cd >= (c + 1) - fd; cd--)
                            if (m[fd, cd] < m[fp, cp])
                                this.Intercambiar(fd, cd, fp, cp);
        }
        public void EncontrarElementoMayorAñadir() //Ejercicio 7
        {
            int i, may;
            i = 0;
            for (int f1 = f; f1 >= 1; f1--)
            {
                i++;
                may = m[f1, i];
                m[f1, c + 1] = may;
                for (int c1 = i + 1; c1 <= c; c1++)
                    if (m[f1, c1] > may)
                    {
                        may = m[f1, c1];
                        m[f1, c + 1] = may;
                    }
            }
            c++;
        }
    }
}
