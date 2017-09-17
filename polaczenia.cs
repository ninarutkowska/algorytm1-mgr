using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytm11
{
    class polaczenia
    {
        punkty punktpoczatkowy=new punkty();
        punkty punktkoncowy=new punkty();
        int odleglosc;
        double nachylenie;
        double roznicawysokosci;
        public polaczenia()
        {
            odleglosc = 0;
            roznicawysokosci = 0;
        }
        public static void setppocz(polaczenia p, punkty pun)
        {
            p.punktpoczatkowy = pun;
        }
        public static void setpkonc(polaczenia p, punkty pun)
        {
            p.punktkoncowy= pun;
        }
        public static punkty getppocz(polaczenia p)
        {
            return p.punktpoczatkowy;
        }
        public static punkty getpkonc(polaczenia p)
        {
            return p.punktkoncowy;
        }
        public static int getodl(polaczenia p)
        {
            return p.odleglosc;
        }
        public static double getrwys(polaczenia p)
        {
            return p.roznicawysokosci;
        } 
        public static void obliczodlaglosc(polaczenia p)
        {
            double w1 = punkty.getwspz1(p.punktkoncowy);
            double w2 = punkty.getwspz2(p.punktkoncowy);
            double w3 = punkty.getwspr1(p.punktpoczatkowy);
            double w4 = punkty.getwspr2(p.punktpoczatkowy);
            int roznicakm = (int)(Math.Acos((Math.Sin(w1 * Math.PI / 180) * Math.Sin(w3 * Math.PI / 180) + Math.Cos(w1 * Math.PI / 180) * Math.Cos(w3 * Math.PI / 180) * Math.Cos((w2 - w4) * Math.PI / 180))) * 6371);
            p.odleglosc = roznicakm;
        }
        public static void obliczrwys(polaczenia p)
        {
            double roznica = punkty.getwysokosc(p.punktpoczatkowy) - punkty.getwysokosc(p.punktkoncowy);
            p.roznicawysokosci = roznica;
        }
        public static void oblicznachylenie(polaczenia pol)
        {
            if (pol.roznicawysokosci > 0) pol.nachylenie = Math.Atan(pol.roznicawysokosci / pol.odleglosc);
            else pol.nachylenie = 0;
        }
        public static double getnachylenie(polaczenia p)
        {
            return p.nachylenie;
        }
    }
}
