using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OkulYönetimUygulaması
{
    internal static class AracGereclerClass
    {


        static public string YaziAl(string yazi)
        {
            int sayi;


            //TryParse metodu bool değişkeni sonucu üretir.
            //Eğer girilen string veri int veriye dönüştürülebiliyor ise hata döndürülüp yazı girilmesi istenir.
            //Uygun giriş sağlanıldığında girilen giriş döndürülür.

            do
            {
                try
                {
                    Console.Write(yazi);
                    string giris = Console.ReadLine().ToUpper();

                    if (int.TryParse(giris, out sayi))
                    {
                        throw new Exception("Hatalı işlem tekrar girin.");
                    }
                    else if (string.IsNullOrEmpty(giris))
                    {
                        Console.WriteLine("Veri girişi yapılmadı tekrar deneyin.");
                    }
                    else
                    {
                        return IlkHarfiBuyut(giris);
                    }

                }
                catch (Exception f)
                {

                    Console.WriteLine(f.Message);
                }

            } while (true);

        }

        public static int SayiAl(string text)
        {
            int sayi;
            do
            {
                Console.Write(text);
                string giris = Console.ReadLine();
                if (int.TryParse(giris, out sayi) == true)
                {
                    return sayi;
                }

                Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");


            } while (true);

        }




        public static string IlkHarfiBuyut(string veri)
        {
            return veri[0].ToString().ToUpper() + veri.Substring(1).ToLower();
        }

        public static void ListeYazdir(List<OgrenciClass> liste)
        {
            string str = "";
            if (liste.Count != 0)
            {
                Console.WriteLine("Sube".PadRight(10, ' ') + "No".PadRight(10, ' ') + "Adı " + "Soyadı".PadRight(21, ' ') + "Not Ort.".PadRight(15, ' ') + "Okuduğu Kitap Say.");
                Console.WriteLine(str.PadRight(79, '-'));
                foreach (OgrenciClass item in liste)
                {
                    Console.WriteLine(item.Sube.ToString().PadRight(10, ' ') + item.No.ToString().PadRight(10, ' ') + (item.Ad + " " + item.Soyad).PadRight(25, ' ') + (item.Ortalama.ToString().PadRight(15, ' ')) + (item.KitapSayisi));
                }
            }
            else
            {
                Console.WriteLine("Listelenecek öğrenci yok.");
            }
        }


        public static void ListeYazdirIl(List<OgrenciClass> liste)
        {
            string str = "";
            if (liste.Count != 0)
            {
                Console.WriteLine("Sube".PadRight(10, ' ') + "No".PadRight(10, ' ') + "Adı " + "Soyadı".PadRight(17, ' ') + "Sehir".PadRight(15, ' ') + "Semt");
                Console.WriteLine(str.PadRight(79, '-'));
                foreach (OgrenciClass item in liste)
                {
                    Console.WriteLine(item.Sube.ToString().PadRight(10, ' ') + item.No.ToString().PadRight(10, ' ') + (item.Ad + " " + item.Soyad).PadRight(21, ' ') + (item.Adres.Il.ToString().PadRight(15, ' ')) + (item.Adres.Ilce.ToString().PadRight(15, ' ')));
                }
            }
            else
            {
                Console.WriteLine("Listelenecek öğrenci yok.");
            }
        }

        public static void ListeYazdirNot(List<DersNotuClass> liste)
        {

            string str = "";
            if (liste.Count != 0)
            {
                Console.WriteLine("Dersin Adi".PadRight(15, ' ') + "Notu");
                Console.WriteLine(str.PadRight(20, '-'));
                foreach (DersNotuClass item in liste)
                {
                    Console.WriteLine(item.Ders.ToString().PadRight(15, ' ') + item.Not.ToString());
                }
            }
            else
            {
                Console.WriteLine("Listelenecek öğrenci yok.");
            }
        }
        static public List<DersNotuClass> OgrenciNotCagır(int no)
        {
            OgrenciClass ogrenci1 = OkulClass.OgrenciListesi.Where(a => a.No == no).FirstOrDefault();
            if (ogrenci1 != null)
            {
                return ogrenci1.Notlar.ToList();
            }
            return null;
        }

        public static List<string> KitapListesiOlustur(int no)
        {
            OgrenciClass ogrenci = OkulClass.OgrenciListesi.Where(a => a.No == no).FirstOrDefault();
            if (ogrenci != null || ogrenci.OgrencininOkuduguKitaplar != null)
            {
                return ogrenci.OgrencininOkuduguKitaplar;

            }
            return null;
        }





        public static string AdSoyadGetir(int ogrNoBilgisi)
        {

            OgrenciClass ogrenci = OkulClass.OgrenciListesi.Where(a => a.No == ogrNoBilgisi).FirstOrDefault();

            string str = "";
            if (ogrenci != null)
            {
                str = ogrenci.Ad + " " + ogrenci.Soyad;
            }
            return str;
        }

        public static float OrtalamaGetir(int ogrNoBilgisi)
        {

            OgrenciClass ogrenci = OkulClass.OgrenciListesi.Where(a => a.No == ogrNoBilgisi).FirstOrDefault();

            float flt = 1;
            if (ogrenci != null)
            {
                flt = ogrenci.Ortalama;
            }
            return flt;
        }


        public static float OrtalamaGetirSube(SUBE sube)
        {

            float subeOrt = OkulClass.OgrenciListesi.Where(a => a.Sube == sube).Average(a => a.Ortalama);
            return subeOrt;
        }


        public static SUBE SubeGetir(int ogrNoBilgisi)
        {

            OgrenciClass ogrenci = OkulClass.OgrenciListesi.Where(a => a.No == ogrNoBilgisi).FirstOrDefault();
            SUBE sb = SUBE.Empty;
            if (ogrenci != null)
            {
                sb = ogrenci.Sube;
                return sb;

            }
            else
            {
                throw new Exception("Hatali giris yapildi. Tekrar deneyin");
            }

        }

        public static int OgrenciNoVarsaAl(string text)
        {
            while (true)
            {
                int no = SayiAl(text); //text = "Ögrencinin numarasi:" 



                if ((OkulClass.OgrenciListesi.Where(a => a.No == no).FirstOrDefault()) != null)
                {

                    return no;

                }
                else if ((OkulClass.OgrenciListesi.Where(a => a.No == no).FirstOrDefault()) == null)
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");

                }
                else
                {
                    Console.WriteLine("Hatali giriş yapıldı. Tekrar deneyin");
                }
            }

        }




        static public DateTime TarihAl(string yazi)
        {
            DateTime tarih;

            do
            {
                try
                {
                    Console.Write(yazi);
                    string giris = Console.ReadLine();

                    if (DateTime.TryParse(giris, out tarih))
                    {
                        return tarih;
                    }
                    else
                    {
                        throw new Exception("Hatali giris yapildi. Tekrar deneyin");

                    }

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            } while (true);

        }

        static public CINSIYET CinsiyetAl(string yazi)
        //Doğru şekilde cinsiyet girişi yapılıp yapılmadığının cevabını verecek bilgi alacak   
        {

            do
            {
                try
                {

                    Console.Write(yazi);
                    string secim = Console.ReadLine().ToUpper();
                    string harfler = "EK";
                    if (harfler.IndexOf(secim) > -1 || secim.Length >= 0)
                    {
                        switch (secim)
                        {

                            case "E":
                                return CINSIYET.Erkek;

                            case "K":
                                return CINSIYET.Kız;

                            case "":
                                return CINSIYET.Empty;
                            default:
                                Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                                break;
                        }

                    }
                    else
                    {

                        throw new Exception("Hatali giris yapildi. Tekrar deneyin");

                    }
                }

                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            } while (true);


        }


        static public SUBE SubeAl(string yazi) //Doğru şekilde Şube girişi yapılıp yapılmadığının cevabını verecek bilgi alacak   
        {
            do
            {

                try
                {
                    Console.Write(yazi);
                    string secim = Console.ReadLine().ToUpper();
                    string harfler = "ABC";
                    if (harfler.IndexOf(secim) > -1 || secim.Length >= 0)
                    {
                        switch (secim)
                        {
                            case "A":
                                return SUBE.A;

                            case "B":
                                return SUBE.B;

                            case "C":
                                return SUBE.C;
                            case "":
                                return SUBE.Empty;
                            default:
                                Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                                break;

                        }


                    }
                    else
                    {

                        throw new Exception("Hatali giris yapildi. Tekrar deneyin");

                    }
                }

                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            } while (true);


        }



    }
}



