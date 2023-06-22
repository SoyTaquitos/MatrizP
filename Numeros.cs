using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrizP
{
    class Numeros
    {
        //Atributos
        private int n;
        //Constructor
        public Numeros()
        {
            n = 0;
        }
        public Numeros(int x)
        {
            n = x;
        }   
        public Numeros(Numeros obj)
        {
            n = obj.n;
        }
        //Cargar
        public void Cargar(int x)
        {
            n = x;
        }
        public bool VerifPrimo() //Sin contar el número 1
        {
            if (n <= 1)
            {
                return false;
            }
            int i = n / 2;
            while (i > 1)
            {
                if (n % i == 0)
                {
                    return false;
                }
                i--;
            }
            return true;
        }
    }
}
