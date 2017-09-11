using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytm11
{
    class punkty
    {
        int liczbakropel;
        int lporzadkowa;
        int lsasiadow;
        double wspz1;
        double wspz2;
        double wspr1;
        double wspr2;
        double wysokosc;
        int dltrasy=0;
        daty data = new daty();
        public punkty()
        {
            wysokosc = 0;
            lporzadkowa = 0;
            liczbakropel = 0;
        }
        public static void dodajkrople(punkty p)
        {
            p.liczbakropel = p.liczbakropel + 1;
        }
        public static int getlkropel(punkty p)
        {
            return p.liczbakropel;
        }
        public static void setlporzadkowa(punkty p, int k)
        {
            p.lporzadkowa = k;
        }
        public static void setlsasiadow(punkty p, int k)
        {
            p.lsasiadow = k;
        }
        public static void setwspz1(punkty p, double k)
        {
            p.wspz1 = k;
        }
        public static void setwspz2(punkty p, double k)
        {
            p.wspz2 = k;
        }
        public static void setwspr1(punkty p, double k)
        {
            p.wspr1 = k;
        }
        public static void setwspr2(punkty p, double k)
        {
            p.wspr2 = k;
        }
        public static void setwysokosc(punkty p, double k)
        {
            p.wysokosc = k;
        }
        public static void setdata(punkty p, daty k)
        {
            p.data = k;
        }
        public static int getlporzadkowa(punkty p)
        {
            return p.lporzadkowa;
        }
        public static int getlsasiadow(punkty p)
        {
            return p.lsasiadow;
        }
        public static double getwspz1(punkty p)
        {
            return p.wspz1;
        }
        public static double getwspz2(punkty p)
        {
            return p.wspz2;
        }
        public static double getwspr1(punkty p)
        {
            return p.wspr1;
        }
        public static double getwspr2(punkty p)
        {
            return p.wspr2;
        }
        public static double getwysokosc(punkty p)
        {
            return p.wysokosc;
        }
        public static daty getdata(punkty p)
        {
            return p.data;
        }
        public static punkty wczytppocz()
        {
            punkty ppocz = new punkty();
            string s = "A";
            System.Console.WriteLine("Dzień:");  //punkt poczatkowy-wczytywanie!
            s = System.Console.ReadLine();
            daty.setdzien(punkty.getdata(ppocz), ciagnaliczbe.ciagnaint(s));
            System.Console.WriteLine("Miesiąc:");
            s = System.Console.ReadLine();
            daty.setmiesiac(punkty.getdata(ppocz), ciagnaliczbe.ciagnaint(s));
            System.Console.WriteLine("Rok:");
            s = System.Console.ReadLine();
            daty.setrok(punkty.getdata(ppocz), ciagnaliczbe.ciagnaint(s));
            System.Console.WriteLine("Współrzędna 1:");
            s = System.Console.ReadLine();
            punkty.setwspz1(ppocz, ciagnaliczbe.ciagnadouble(s));
            System.Console.WriteLine("Współrzędna 2:");
            s = System.Console.ReadLine();
            punkty.setwspz2(ppocz, ciagnaliczbe.ciagnadouble(s));
            punkty.setwspr1(ppocz, punkty.getwspz1(ppocz));
            punkty.setwspr2(ppocz, punkty.getwspz2(ppocz));
            punkty.setlporzadkowa(ppocz, 0);
            punkty.setwysokosc(ppocz, 3000); //początkowa wysokość

            return ppocz;
        }
        public static int getdltrasy(punkty o)
        {
            return o.dltrasy;
        }
        public static void setdltrasy(punkty o)
        {
            int roznicakm = (int)(Math.Acos((Math.Sin(o.wspr1 * Math.PI / 180) * Math.Sin(o.wspz1 * Math.PI / 180) + Math.Cos(o.wspr1 * Math.PI / 180) * Math.Cos(o.wspz1 * Math.PI / 180) * Math.Cos((o.wspr2 - o.wspz2) * Math.PI / 180))) * 6371);
            o.dltrasy = roznicakm;
        }
        public static void obliczwysokosc(punkty p, double czynnikfrachtow, int warstwa)
        {
            int i = 0;
            int j = 0;
            double h = 0;
            if (warstwa == 1) h =3000-( punkty.getlsasiadow(p) + czynnikfrachtow/50);
            if (warstwa == 2) h =1000-( czynnikfrachtow/50);
            p.wysokosc = h;
        }
        public static bool czyistpolaczenie(punkty poczatek, int maxodleglosc, int maxczas, int minczas, oferty o)
        {
            int i = 0;
            int dzien1;
            int dzien2;
            int miesiac1;
            int miesiac2;
            int rok1;
            int rok2;
            dzien1 = daty.getdzien(punkty.getdata(poczatek));
            miesiac1 = daty.getmiesiac(punkty.getdata(poczatek));
            rok1 = daty.getrok(punkty.getdata(poczatek));
            double wsppocz1 = 0;
            double wsppocz2 = 0;
            double wspo1;
            double wspo2;
            int roznicakm = 0;
            int roznicadni; //zakladamy ze oferty tylko aktualne!!!
            int k = 2;
            dzien2 = daty.getdzien(oferty.getdatazal(o));
            miesiac2 = daty.getmiesiac(oferty.getdatazal(o));
            rok2 = daty.getrok(oferty.getdatazal(o));
            wspo1 = oferty.getwspzal1(o);
            wspo2 = oferty.getwspzal2(o);
       
            wsppocz1 = poczatek.wspr1;
            wsppocz2 = poczatek.wspr2;
            if (poczatek.dltrasy > 900 && poczatek.dltrasy <= 1800) k = 2;
            if (poczatek.dltrasy <= 900) k = 1;
            if (poczatek.dltrasy > 1800) k = 3;
            if (miesiac1 == 1 || miesiac1 == 3 || miesiac1 == 5 || miesiac1 == 7 || miesiac1 == 8 || miesiac1 == 10)
                {
                    if (dzien1 == 31)
                    {
                        dzien1 = k;
                        miesiac1++;
                    }
                    if (dzien1 == 30 && k > 1)
                    {
                        dzien1 = k - 1;
                        miesiac1++;
                    }
                    if (dzien1 == 29 && k > 2)
                    {
                        dzien1 = k - 2;
                        miesiac1++;
                    }
                    else dzien1 = dzien1 + k;
                }
                if (miesiac1 == 4 || miesiac1 == 6 || miesiac1 == 9 || miesiac1 == 11)
                {
                    if (dzien1 == 30)
                    {
                        dzien1 = k;
                        miesiac1++;
                    }
                    if (dzien1 == 29 && k > 1)
                    {
                        dzien1 = k - 1;
                        miesiac1++;
                    }
                    if (dzien1 == 28 && k > 2)
                    {
                        dzien1 = k - 2;
                        miesiac1++;
                    }
                    else dzien1 = dzien1 + k;
                }
                if (miesiac1 == 2)
                {
                    if ((dzien1 == 28 && rok1 % 4 == 0) || dzien1 == 29)
                    {
                        dzien1 = k;
                        miesiac1++;
                    }
                    if (dzien1 == 28 && rok1 % 4 != 0 && k > 1)
                    {
                        dzien1 = k - 1;
                        miesiac1++;
                    }
                    if (dzien1 == 27 && rok1 % 4 != 0 && k > 2)
                    {
                        dzien1 = k - 2;
                        miesiac1++;
                    }
                    else dzien1 = dzien1 + k;
                }
                if (miesiac1 == 12)
                {
                    if (dzien1 == 31)
                    {
                        dzien1 = k;
                        miesiac1 = 1;
                        rok1++;
                    }
                    if (dzien1 == 30 && k > 1)
                    {
                        dzien1 = k - 1;
                        miesiac1 = 1;
                        rok1++;
                    }
                    if (dzien1 == 29 && k > 2)
                    {
                        dzien1 = k - 2;
                        miesiac1 = 1;
                        rok1++;
                    }
                    else dzien1 = dzien1 + 2;
                }

            roznicadni = daty.roznicaczasu(poczatek.data,oferty.getdatazal(o));
            if (roznicadni <2)
            {
                oferty.setaktywna(o);
            }
            if (dzien1 == dzien2 && wspo1 == wsppocz1 && wspo2 == wsppocz2) return false;
            if (roznicadni <= maxczas && roznicadni >= minczas)
            {
                roznicakm = (int)(Math.Acos((Math.Sin(wspo1 * Math.PI / 180) * Math.Sin(wsppocz1 * Math.PI / 180) + Math.Cos(wspo1 * Math.PI / 180) * Math.Cos(wsppocz1 * Math.PI / 180) * Math.Cos((wspo2 - wsppocz2) * Math.PI / 180))) * 6371);

                if (roznicakm <= maxodleglosc)
                {
                    return true;
                }
                else return false;
            }

            else return false;

        }
        public static punkty ofertanapunkt(oferty o, int i)
        {
            punkty p=new punkty();
            p.data = oferty.getdatazal(o);
            p.dltrasy = oferty.getdltrasy(o);
            p.lporzadkowa = i;
            p.wspr1 = oferty.getwsproz1(o);
            p.wspr2 = oferty.getwsproz2(o);
            p.wspz1 = oferty.getwspzal1(o);
            p.wspz2 = oferty.getwspzal2(o);
            return p;
        }
        public static void porownajpunkty(punkty[] p, int liczba)
        {
            punkty[] pw=new punkty[5];
            int j=0;
            int k = 0;
            int[] nr=new int[5];
            for(j=0;j<5;j++)
            {
                pw[j]=new punkty();
                nr[j] = -1;
            }
            int l1=0;
            int l2=0;
            int i = 1;
            for(j=0;j<5;j++)
            {
                if (nr[0]!=1 && nr[1]!=1 && nr[2]!=1 && nr[3]!=1)
                {
                    pw[j] = p[1];
                    l1 = p[1].liczbakropel;
                    k = 2;
                    nr[j] = 1;
                }
                else if (nr[0] != 2 && nr[1] != 2 && nr[2] != 2 && nr[3] != 2)
                {
                    pw[j] = p[2];
                    l1 = p[2].liczbakropel;
                    k = 3;
                    nr[j] = 1;
                }
                else if (nr[0] != 3 && nr[1] != 3 && nr[2] != 3 && nr[3] != 3)
                {
                    pw[j] = p[3];
                    l1 = p[3].liczbakropel;
                    k = 4;
                    nr[j] = 1;
                }
                else if (nr[0] != 4 && nr[1] != 4 && nr[2] != 4 && nr[3] != 4)
                {
                    pw[j] = p[4];
                    l1 = p[4].liczbakropel;
                    k = 5;
                    nr[j] = 1;
                }
                for (i=k ; i <= liczba && i!=nr[0] && i!=nr[1] && i!=nr[2] && i!=nr[3]; i++) 
                {
                    l2 = p[i].liczbakropel;
                    if (l2 > l1)
                    {
                        pw[j] = p[i];
                        nr[j] = i;
                    }
                }
            }
            for(j=0;j<5;j++)
            {
                System.Console.WriteLine(j+1 +" miejsce z prawdopodobienstwem "+ pw[j].liczbakropel + "/1000:");
                System.Console.WriteLine("współrzędne załadunku: "+pw[j].wspz1+","+pw[j].wspz2);
                System.Console.WriteLine("współrzędne rozładunku: " + pw[j].wspr1 + "," + pw[j].wspr2);
                System.Console.WriteLine("data załadunku: " + daty.getdzien(pw[j].data) + "/" + daty.getmiesiac(pw[j].data) + "/" + daty.getrok(pw[j].data));
            }
        }
        
    }
}
