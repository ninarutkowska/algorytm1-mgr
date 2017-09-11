using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytm11
{
    class tablicasasiedztwa
    {
        int iloscwierszy; //w dół które się łączą, w bok z którymi
        int ilosckolumn;
        int[,] elementy=new int[15000,15000];
        public tablicasasiedztwa()
        {
           // int[,] elementy = new int[15000, 15000];
            for (int i = 0; i < 15000; i++)
            {
                for (int j = 0; j < 15000; j++)
                {
                    this.elementy[i, j] = new int();
                    this.elementy[i,j] = 0;
                }
            }
            ilosckolumn = 0;
            iloscwierszy = 0;
        }
        public static void dodajelement(tablicasasiedztwa t, int w, int k)
        {
            t.elementy[w, k] = 1;
        }
        public static int odczytajztablicy(tablicasasiedztwa t, int w, int k)
        {
            return t.elementy[w,k];
        }
    }
}
