using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace algorytm11
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0; //zmienne do ew liczenia
            int j = 0;
            int k = 0;
            int l = 0;
            double d = 0;
            string s = "A";
            string s1 = "A";
            bool b;
            int lpunktow = 0;
            int lofert = 0;
            int lkropel = 0;
            int lfrachtow = 0;
            int lpolaczen=0;
            double[] czynnikfrachtow = new double[20000];
            oferty[] ofer=new oferty[40000];
            frachty[] fra=new frachty[9000];
            punkty[] pun=new punkty[200000];
            krople[] krop=new krople[3000];
            polaczenia[] pol = new polaczenia[300000];
            punkty ppocz = new punkty();
            punkty pkonc = new punkty();
            tablicasasiedztwa t=new tablicasasiedztwa();
            int lpunktow1w=0;  //na pierwszej warstwie
            int lpunktow2w=0;  //na drugiej

            for(i=0;i<3000;i++)
            {
                krop[i]=new krople();
            }
            ppocz=punkty.wczytppocz();
            pun[0] = ppocz;
            s = "C:/Users/Nina/Documents/Visual Studio 2013/Projects/algorytm11/Arkusz1.txt"; //jak odnośnik krótszy?!
            if (File.Exists(s))
            {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader(s);
                s1 = sr.ReadLine();
                while (s1 != null)
                {
                    s1 = sr.ReadLine();
                    if (s1 != null)
                    {
                        fra[j] = new frachty();
                        frachty.setwlasnosci(fra[j], s1);
                    }
                    j++;
                }
                sb.AppendLine(s1);
                sr.Close();
            }
            lfrachtow = j;
            s = "C:/Users/Nina/Documents/Visual Studio 2013/Projects/algorytm11/oferty.txt";
            j = 0;
            if (File.Exists(s))
            {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader(s);
                s1 = sr.ReadLine();
                while (s1 != null && s1 != "")
                {
                    s1 = sr.ReadLine();
                    ofer[j] = new oferty();
                    if (s1 != null && s1 != "")
                    {
                        oferty.setwlasnosci(ofer[j], s1, ppocz,j-1,ofer);
                        oferty.setlporzadkowa(ofer[j], j);
                    }
                    for (i = 0; i < j; i++) //powtarzające się oferty!!!!!!!!!!
                    {
                        if (daty.getdzien(oferty.getdatazal(ofer[i])) == daty.getdzien(oferty.getdatazal(ofer[j])) && daty.getmiesiac(oferty.getdatazal(ofer[i])) == daty.getmiesiac(oferty.getdatazal(ofer[j])) && daty.getrok(oferty.getdatazal(ofer[i])) == daty.getrok(oferty.getdatazal(ofer[j])) && oferty.getwspzal1(ofer[i]) == oferty.getwspzal1(ofer[j]) && oferty.getwspzal2(ofer[i]) == oferty.getwspzal2(ofer[j]) && oferty.getwsproz1(ofer[i]) == oferty.getwsproz1(ofer[j]) && oferty.getwsproz2(ofer[i]) == oferty.getwsproz2(ofer[j]))
                        {
                            oferty.setaktywna(ofer[j], false);
                            i = j;
                        }

                    }
                        if (oferty.getczyaktywna(ofer[j]) == true) j++;
                }
                sb.AppendLine(s1);
                sr.Close();
            }
            lofert = j;
            lpunktow = 0; //poczatkowy jest zerowy!
            for (i = 1; i <= lofert; i++)
            {
                b = punkty.czyistpolaczenie(ppocz, 90, 2, 0, ofer[i-1]);
                if (b == true)
                {
                    lpunktow++;
                    pun[lpunktow]=punkty.ofertanapunkt(ofer[i - 1],lpunktow);
                    tablicasasiedztwa.dodajelement(t, 0, lpunktow);
                }
            }
            k = lpunktow;
            lpunktow1w=lpunktow;
            System.Console.WriteLine(k);
            for (i = 1; i <= k; i++)
            {
                for (j = 1; j <= lofert; j++)
                {
                    if (oferty.getczyaktywna(ofer[j - 1]) == true)
                    {
                        b = punkty.czyistpolaczenie(pun[i], 90, 3, 0, ofer[j - 1]);
                        if (b == true)
                        {
                            if (oferty.getczyistnieje(ofer[j - 1]) == false)
                            {
                                lpunktow++;
                                pun[lpunktow] = punkty.ofertanapunkt(ofer[j - 1], lpunktow);
                                tablicasasiedztwa.dodajelement(t, i, j - 1);
                                oferty.setczyistnieje(ofer[j - 1], lpunktow);
                            }
                            else
                            {
                                tablicasasiedztwa.dodajelement(t, i, oferty.getnrpunktu(ofer[j - 1]));
                            }
                        }
                    }

                }
            }
            lpunktow2w=lpunktow-lpunktow1w;
            for (i = 1; i < lpunktow; i++)
            {
                czynnikfrachtow[i] = frachty.porownujfrachty(fra, pun[i], lfrachtow);
                if (i <= lpunktow1w) punkty.obliczwysokosc(pun[i], czynnikfrachtow[i], 1, ppocz);
                else punkty.obliczwysokosc(pun[i], czynnikfrachtow[i], 2, ppocz);
            }
            for (i = 0; i < lpunktow; i++) //polaczenia
            {
                l = 0;
                for(j=0;j<lpunktow;j++)
                {
                    k=tablicasasiedztwa.odczytajztablicy(t, i, j);
                    if (k == 1)
                    {
                        pol[lpolaczen] = new polaczenia();
                        polaczenia.setppocz(pol[lpolaczen], pun[i]);
                        polaczenia.setpkonc(pol[lpolaczen], pun[j]);
                        polaczenia.obliczodlaglosc(pol[lpolaczen]);
                        polaczenia.obliczrwys(pol[lpolaczen]);
                        lpolaczen++;
                        l++;
                    }
                }
                punkty.setlsasiadow(pun[i], l);
                //System.Console.WriteLine(l);
                //System.Console.ReadKey();
            }
            System.Console.WriteLine(lpolaczen);
            for (i = punkty.getlsasiadow(ppocz)+1; i < lpunktow;i++) //polaczenie koncowe
            {
                pol[lpolaczen] = new polaczenia();
                polaczenia.setppocz(pol[lpolaczen], pun[i]);
                polaczenia.setpkonc(pol[lpolaczen], pkonc);
                polaczenia.obliczrwys(pol[lpolaczen]);
                lpolaczen++;
            }
            
            
            for (i = 0; i < 3000;i++) krople.ruch(krop[i], i + 1, ppocz, pol, lpolaczen);
            punkty.porownajpunkty(pun, lpunktow1w);

            System.Console.ReadKey();
        }
    }
}
