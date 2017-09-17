using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytm11
{
    class krople
    {
        int lporzadkowa;
        double osad;
        public krople()
        {
            lporzadkowa = 0;
        }
        public static int getlporzadkowa(krople k)
        {
            return k.lporzadkowa;
        }
        public static double getosad(krople k)
        {
            return k.osad;
        }
        public static void erozja(krople k, polaczenia pol)
        {
            double wynik = 0; 
            double nachylenie = polaczenia.getnachylenie(pol);
            wynik = Math.Exp(2.93 * nachylenie); 
            if (wynik >80)
            {
                k.osad = 0.1 * wynik; 
            }
            else k.osad = 0.1 * wynik;
        }
        public static void ruch(krople k, int liczba, punkty ppocz, polaczenia[] pol, int lpolaczen) //jeden ruch kropli
        {
            int i=0;
            int l = 0;
            punkty p1 = new punkty();
            punkty p2=new punkty();
            double czynnik = 0;
            polaczenia najlepsze = new polaczenia();
            l = punkty.getlporzadkowa(ppocz);
            punkty p0 = new punkty(); //punkt z pierwszego ruchu który się okaże "najlepszy"
            while (polaczenia.getppocz(pol[i]) != ppocz) i++;
            najlepsze=pol[i];
            i++;
            while (polaczenia.getppocz(pol[i]) == ppocz)
            {
                polaczenia.obliczrwys(pol[i]);  //z uwagi na erozje to sie zmienia!!!
                polaczenia.oblicznachylenie(pol[i]);
                czynnik = polaczenia.getnachylenie(pol[i]);
                
                if (czynnik > polaczenia.getnachylenie(najlepsze))
                {
                    najlepsze = pol[i];
                }
                i++;
            }
           
            i = 0;
            p1=polaczenia.getppocz(najlepsze);
            p2=polaczenia.getpkonc(najlepsze);
            punkty.dodajkrople(p2);
            krople.erozja(k, najlepsze);
            punkty.setwysokosc(p1, punkty.getwysokosc(p1)-k.osad);
            punkty.setwysokosc(p2, punkty.getwysokosc(p2)+k.osad);
   //         System.Console.WriteLine(punkty.getwysokosc(p1)+" "+punkty.getlporzadkowa(p2)+" "+punkty.getwysokosc(p2));
     //       System.Console.ReadKey();
            //druga krawedz
            if (liczba < 3000)
            {
                while (polaczenia.getppocz(pol[i]) != p2 && punkty.getlsasiadow(p2)>0) i++;
                najlepsze = pol[i];
                i++;
                if (punkty.getlsasiadow(p2) > 1)
                {
                    while (polaczenia.getppocz(pol[i]) == p2)
                    {
                        polaczenia.obliczrwys(pol[i]);  //z uwagi na erozje to sie zmienia!!!
                        polaczenia.oblicznachylenie(pol[i]);

                        czynnik = polaczenia.getnachylenie(pol[i]);
                        if (czynnik > polaczenia.getnachylenie(najlepsze))
                        {
                            najlepsze = pol[i];
                        }
                        i++;
                    }
                }
                i = 0;
                p1 = polaczenia.getppocz(najlepsze);
                p2 = polaczenia.getpkonc(najlepsze);
                krople.erozja(k, najlepsze);
                punkty.setwysokosc(p1, punkty.getwysokosc(p1)- k.osad);
                punkty.setwysokosc(p2, punkty.getwysokosc(p2)+ k.osad); //przez 2 bo część poleci "dalej" czego nie uwzględniamy 
            }
        }
    }
}
