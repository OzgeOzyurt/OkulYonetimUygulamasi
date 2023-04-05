using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OkulYönetimUygulaması
{
    internal class UygulamaClass
    {
        static public OkulClass Okulumuz = new OkulClass();
        static public List<string> SahteKitaplarListesi = new List<string>();
        static int hataSayaci = 0;


        public void Calistir()
        {
            this.SahteVeriGir();
            this.SahteAdresGir();
            this.SahteKitapGir();
            this.SahteNotGir();

            Menu();
            while (true)
            {
                Console.WriteLine();
                string secim = SecimAl();
                switch (secim)
                {
                    case "1":
                        TumOgrenciListele_1();
                        break;
                    case "2":
                        SubeyeGoreOgrenciListele_2();
                        break;
                    case "3":
                        CinsiyeteGoreOgrenciListele_3();
                        break;
                    case "4":
                        SuTarihtenSonraDoganOgrenciListele_4();
                        break;
                    case "5":
                        IllereGoreOgrenciListele_5();
                        break;
                    case "6":
                        NotlariListele_6();
                        break;
                    case "7":
                        OgrenciOkuduguKitaplarListele_7();
                        break;
                    case "8":
                        OkulEnYuksekBesNotListele_8();
                        break;
                    case "9":
                        OkulEnDusukUcNotListele_9();
                        break;
                    case "10":
                        SubeEnYuksekBesNotListele_10();
                        break;
                    case "11":
                        SubeEnDusukUcNotListele_11();
                        break;
                    case "12":
                        OgrenciNotOrtGor_12();
                        break;
                    case "13":
                        SubeninNotOrtGor_13();
                        break;
                    case "14":
                        OgrenciOkuduguSonKitabiGor_14();
                        break;
                    case "15":
                        OgrenciEkle_15();
                        break;
                    case "16":
                        OgrenciGuncelle_16();
                        break;
                    case "17":
                        OgrenciSil_17();
                        break;
                    case "18":
                        OgrenciAdresGir_18();
                        break;
                    case "19":
                        OgrenciOkuduguKitabiGir_19();
                        break;
                    case "20":
                        OgrenciNotGir_20();
                        break;
                    case "CIKİŞ":
                    case "CIKİS":
                    case "CİKİS":
                    case "ÇIKIŞ":
                    case "ÇIKIS":
                    case "ÇİKİS":
                    case "CIKIS":
                        CikisYap();
                        break;
                    case "LİSTE":
                        Console.WriteLine();
                        Menu();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                        hataSayaci++;
                        break;

                }
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkıs yapmak için \"çıkıs\" yazın.");
            }

        }

        static void Menu()
        //Uygulamada ilk çıkan menuyü gösterecek metot
        {
            Console.WriteLine("------Okul Yönetim Uygulamasi  -----               ");
            Console.WriteLine();
            Console.WriteLine("1 - Bütün öğrencileri listele                      ");
            Console.WriteLine("2 - Şubeye göre öğrencileri listele                ");
            Console.WriteLine("3 - Cinsiyetine göre öğrencileri listele           ");
            Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele    ");
            Console.WriteLine("5 - İllere göre sıralayarak öğrencileri listele    ");
            Console.WriteLine("6 - Öğrencinin tüm notlarını listele               ");
            Console.WriteLine("7 - Öğrencinin okuduğu kitapları listele           ");
            Console.WriteLine("8 - Okuldaki en yüksek notlu 5 öğrenciyi listele   ");
            Console.WriteLine("9 - Okuldaki en düşük notlu 3 öğrenciyi listele    ");
            Console.WriteLine("10 - Şubedeki en yüksek notlu 5 öğrenciyi listele  ");
            Console.WriteLine("11 - Şubedeki en düşük notlu 3 öğrenciyi listele   ");
            Console.WriteLine("12 - Öğrencinin not ortalamasını gör               ");
            Console.WriteLine("13 - Şubenin not ortalamasını gör                  ");
            Console.WriteLine("14 - Öğrencinin okuduğu son kitabı gör             ");
            Console.WriteLine("15 - Öğrenci ekle                                  ");
            Console.WriteLine("16 - Öğrenci güncelle                              ");
            Console.WriteLine("17 - Öğrenci sil                                   ");
            Console.WriteLine("18 - Öğrencinin adresini gir                       ");
            Console.WriteLine("19 - Öğrencinin okuduğu kitabı gir                 ");
            Console.WriteLine("20 - Öğrencinin notunu gir                         ");
            Console.WriteLine();
            Console.WriteLine("Çıkıs yapmak için \"çıkıs\" yazıp \"enter\"a basın.");

        }

        static string SecimAl()

        {
            //Menu metotundan sonra secim yapmak için kullanılacak metot
            if (hataSayaci == 10)
            {
                Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                return "ÇIKIŞ";
            }
            else
            {
                Console.Write("Yapmak istediginiz islemi seçiniz: ");
                string sonuc = Console.ReadLine().ToUpper();
                return sonuc;
            }


        }

        static void TumOgrenciListele_1()
        //OkulClassta OgrenciListesini çeken metotu çağıracak
        {
            Console.WriteLine();
            Console.WriteLine("1-Bütün Öğrencileri Listele --------------------------------------------------");
            Console.WriteLine();
            if (OkulClass.OgrenciListesi.Count == 0)
            {
                Console.WriteLine("Listede öğrenci yok.");
            }
            else
            {
                Console.WriteLine();
                Okulumuz.TumOgrenciListeleMetotu();
            }
        }

        static void SubeyeGoreOgrenciListele_2()
        //OkulClasstan OgrenciListesini SubeyeGoreOgrenciListelemeMetotunu çağıracak
        {
            Console.WriteLine();
            Console.WriteLine("2-Şubeye Göre Ögrencileri Listele --------------------------------------------------");
            if (OkulClass.OgrenciListesi.Count == 0)
            {
                Console.WriteLine("Listede öğrenci yok.");
            }
            else
            {
                SUBE sube = AracGereclerClass.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                Console.WriteLine();
                Okulumuz.SubeyeOgrenciListelemeMetotu(sube);

            }

        }

        static void CinsiyeteGoreOgrenciListele_3()
        {
            Console.WriteLine();
            Console.WriteLine("3-Cinsiyete Göre Öğrencileri Listele -----------------------------------------");
            if (OkulClass.OgrenciListesi.Count == 0)
            {
                Console.WriteLine("Listelenecek öğrenci yok.");
            }
            else
            {
                CINSIYET cinsiyet = AracGereclerClass.CinsiyetAl("Listelemek istediğiniz cinsiyeti girin (K/E): ");
                Console.WriteLine();
                Okulumuz.CinsiyeteGoreOgrenciListelemeMetotu(cinsiyet);

            }


        }

        static void SuTarihtenSonraDoganOgrenciListele_4()
        {
            Console.WriteLine();
            Console.WriteLine("4-Dogum Tarihine Göre Ögrencileri Listele ------------------------------------");
            if (OkulClass.OgrenciListesi.Count == 0)
            {
                Console.WriteLine("Listede öğrenci yok.");
            }
            else
            {
                DateTime tarih = AracGereclerClass.TarihAl("Hangi tarihten sonraki ögrencileri listelemek istersiniz: ");
                Console.WriteLine();
                Okulumuz.TariheGoreOgrenciListeleMetotu(tarih);

            }
        }

        static void IllereGoreOgrenciListele_5()
        {
            Console.WriteLine();
            Console.WriteLine("5-Illere Göre Ögrencileri Listele --------------------------------------------");

            if (OkulClass.OgrenciListesi.Count == 0)
            {
                Console.WriteLine("Listede öğrenci yok.");
            }
            else
            {
                Console.WriteLine();
                Okulumuz.IllereGoreOgrenciListeleMetotu();

            }
        }

        static void NotlariListele_6()
        {
            Console.WriteLine();
            Console.WriteLine("6-Ögrencinin notlarını görüntüle --------------------------------------------");
            if (OkulClass.OgrenciListesi.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
            }
            else
            {
                int no = AracGereclerClass.OgrenciNoVarsaAl("Ögrencinin numarasi: ");
                Console.WriteLine();

                Console.WriteLine("Ögrencinin Adı Soyadı: " + AracGereclerClass.AdSoyadGetir(no));
                Console.WriteLine("Ögrencinin Subesi: " + AracGereclerClass.SubeGetir(no));
                Console.WriteLine();

                AracGereclerClass.ListeYazdirNot(AracGereclerClass.OgrenciNotCagır(no));
            }

        }

        static void OgrenciOkuduguKitaplarListele_7()
        {
            Console.WriteLine();
            Console.WriteLine("7-Ögrencinin okudugu kitapları listele ---------------------------------------");
            int no = AracGereclerClass.OgrenciNoVarsaAl("Ögrencinin numarasi: ");
            Console.WriteLine();
            Console.WriteLine("Ögrencinin Adı Soyadı: " + AracGereclerClass.AdSoyadGetir(no));
            Console.WriteLine("Ögrencinin Subesi: " + AracGereclerClass.SubeGetir(no));
            Console.WriteLine();


            OgrenciClass ogrenci = OkulClass.OgrenciListesi.Where(a => a.No == no).FirstOrDefault();


            if (ogrenci.OgrencininOkuduguKitaplar.Count != 0)
            {
                Console.WriteLine("Okudugu Kitaplar");
                Console.WriteLine("-----------------");


                foreach (string item in ogrenci.OgrencininOkuduguKitaplar)
                {
                    Console.WriteLine(item);
                }


            }
            else
                Console.WriteLine("Öğrencinin okuduğu herhangi bir kitap bulunmamaktadır.");

            Console.WriteLine();
        }



        public void OkulEnYuksekBesNotListele_8()
        {
            Console.WriteLine();
            Console.WriteLine("8-Okuldaki en basarılı 5 ögrenciyi listele -----------------------------------");
            Console.WriteLine();

            AracGereclerClass.ListeYazdir(OkulClass.OgrenciListesi.OrderByDescending(a => a.Ortalama).Take(5).ToList());

        }

        public void OkulEnDusukUcNotListele_9()
        {
            Console.WriteLine();
            Console.WriteLine("9-Okuldaki en basarısız 3 ögrenciyi listele ----------------------------------");
            Console.WriteLine();

            AracGereclerClass.ListeYazdir(OkulClass.OgrenciListesi.OrderBy(a => a.Ortalama).Take(3).ToList());

        }

        public void SubeEnYuksekBesNotListele_10()
        {
            Console.WriteLine();
            Console.WriteLine("10-Subedeki en basarılı 5 ögrenciyi listele -----------------------------------");
            SUBE sube = AracGereclerClass.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
            Console.WriteLine();

            AracGereclerClass.ListeYazdir(OkulClass.OgrenciListesi.Where(a => a.Sube == sube).OrderByDescending(a => a.Ortalama).Take(5).ToList());



        }

        public void SubeEnDusukUcNotListele_11()
        {
            Console.WriteLine();
            Console.WriteLine("11-Subedeki en basarısız 3 ögrenciyi listele ----------------------------------");
            SUBE sube = AracGereclerClass.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
            Console.WriteLine();

            AracGereclerClass.ListeYazdir(OkulClass.OgrenciListesi.Where(a => a.Sube == sube).OrderBy(a => a.Ortalama).Take(3).ToList());



        }

        public void OgrenciNotOrtGor_12()
        {
            Console.WriteLine();
            Console.WriteLine("12-Ögrencinin Not Ortalamasını Gör ----------------------------------");
            int no = AracGereclerClass.OgrenciNoVarsaAl("Ögrencinin numarasi: ");
            Console.WriteLine();

            Console.WriteLine("Ögrencinin Adı Soyadı: " + AracGereclerClass.AdSoyadGetir(no));
            Console.WriteLine("Ögrencinin Subesi: " + AracGereclerClass.SubeGetir(no));
            Console.WriteLine();

            Console.Write("Ögrencinin not ortalaması: " + AracGereclerClass.OrtalamaGetir(no));

        }

        public void SubeninNotOrtGor_13()
        {

            Console.WriteLine();
            Console.WriteLine("13-Şubenin Not Ortalamasını Gör ----------------------------------");
            SUBE sube = AracGereclerClass.SubeAl("Bir şube seçin(A/B/C): ");
            Console.WriteLine();

            Console.Write(sube + " subesinin not ortalaması: " + AracGereclerClass.OrtalamaGetirSube(sube));
            Console.WriteLine();



        }

        public void OgrenciOkuduguSonKitabiGor_14()
        {
            Console.WriteLine();
            Console.WriteLine("14-Ögrencinin okudugu son kitabı listele----------------------------");

            int ogrNo = AracGereclerClass.OgrenciNoVarsaAl("Ögrencinin numarasi: ");
            Console.WriteLine();

            Console.WriteLine("Ögrencinin Adı Soyadı: " + AracGereclerClass.AdSoyadGetir(ogrNo));
            Console.WriteLine("Ögrencinin Subesi: " + AracGereclerClass.SubeGetir(ogrNo));
            Console.WriteLine();

            List<string> yeniListe = AracGereclerClass.KitapListesiOlustur(ogrNo);

            if (yeniListe.Count != 0)
            {
                Console.WriteLine("Ögrencinin Okudugu Son Kitap");
                Console.WriteLine("-----------------------------");
                string sonEleman = yeniListe[(yeniListe.Count) - 1];
                Console.WriteLine(sonEleman);

            }
            else
                Console.WriteLine("Öğrencinin okuduğu herhangi bir kitap bulunmamaktadır.");

            Console.WriteLine();
        }

        static void OgrenciEkle_15()
        {

            //Bu metot öğrenci class içinde tanımladığımız nesne oluşturma şartlarını kullanıcıdan alacak.
            Console.WriteLine();
            Console.WriteLine("15-Öğrenci Ekle -----------------------------------------------------");

            //Araç gereç class içinde tanımlandı ogrenci class nesnesi tanımlandı ogrenci class ta depolandı
            int ogrNoBilgisi = AracGereclerClass.SayiAl("Ögrencinin numarası: ");
            //Araç gereç class içinde tanımlandı ogrenci class nesnesi tanımlandı ogrenci class ta depolandı

            string ogrenciAdBilgisi = AracGereclerClass.YaziAl("Ögrencinin adı: ");
            //Araç gereç class içinde tanımlandı ogrenci class nesnesi tanımlandı ogrenci class ta depolandı

            string ogrenciSoyadBilgisi = AracGereclerClass.YaziAl("Ögrencinin soyadı: ");
            //Araç gereç class içinde tanımlandı ogrenci class nesnesi tanımlandı ogrenci class ta depolandı

            DateTime dogumTarihiBilgisi = AracGereclerClass.TarihAl("Ögrencinin dogum tarihi: ");
            //Araç gereç class içinde tanımlandı ogrenci class nesnesi tanımlandı ogrenci class ta depolandı

            CINSIYET cinsiyetBilgisi = AracGereclerClass.CinsiyetAl("Ögrencinin cinsiyeti (K/E): ");
            //Araç gereç class içinde tanımlandı ogrenci class nesnesi tanımlandı ogrenci class ta depolandı

            SUBE subeBilgisi = AracGereclerClass.SubeAl("Ögrencinin subesi (A/B/C): ");


           
            if ((OkulClass.OgrenciListesi.Where(a => a.No == ogrNoBilgisi).FirstOrDefault()) != null)
            {
                ogrNoBilgisi = ogrNoBilgisi + 1;
                Okulumuz.OgrenciEkleMetotu(ogrNoBilgisi, ogrenciAdBilgisi, ogrenciSoyadBilgisi, dogumTarihiBilgisi, cinsiyetBilgisi, subeBilgisi);
                Console.WriteLine();
                Console.WriteLine(ogrNoBilgisi + " numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.");
                Console.WriteLine("Sistemde " + (ogrNoBilgisi - 1) + " numaralı öğrenci olduğu için verdiğiniz öğrenci no " + ogrNoBilgisi + " olarak değiştirildi.");

            }
            else
            {
                Okulumuz.OgrenciEkleMetotu(ogrNoBilgisi, ogrenciAdBilgisi, ogrenciSoyadBilgisi, dogumTarihiBilgisi, cinsiyetBilgisi, subeBilgisi);
                Console.WriteLine();
                Console.WriteLine(ogrNoBilgisi + " numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.");
            }
        }

        public void OgrenciGuncelle_16()
        {
            Console.WriteLine();
            Console.WriteLine("16-Ögrenci Güncelle -----------------------------------------------------------");

            if (OkulClass.OgrenciListesi.Count == 0)
            {
                Console.WriteLine("Listede güncellenecek ögrenci yok.");
                return;
            }
            else
            {

                int ogrNo = AracGereclerClass.OgrenciNoVarsaAl("Ögrencinin numarasi: ");
                string ogrenciAdBilgisi = AracGereclerClass.YaziAl("Ögrencinin adı: ");
                string ogrenciSoyadBilgisi = AracGereclerClass.YaziAl("Ögrencinin soyadı: ");
                DateTime dogumTarihiBilgisi = AracGereclerClass.TarihAl("Ögrencinin dogum tarihi: ");
                CINSIYET cinsiyetBilgisi = AracGereclerClass.CinsiyetAl(" Ögrencinin cinsiyeti (K/E): ");
                SUBE subeBilgisi = AracGereclerClass.SubeAl("Ögrencinin subesi (A/B/C): ");


                Okulumuz.OgrenciGuncelleMetotu(ogrNo, ogrenciAdBilgisi, ogrenciSoyadBilgisi, dogumTarihiBilgisi, cinsiyetBilgisi, subeBilgisi);


            }
            Console.WriteLine();
            Console.WriteLine("Ogrenci güncellendi.");
        }

        public void OgrenciSil_17()
        {
            Console.WriteLine();
            Console.WriteLine("17-Ögrenci sil ----------------------------------------------------------------");

            if (OkulClass.OgrenciListesi.Count == 0)
            {
                Console.WriteLine("Listede silinecek ögrenci yok.");
            }
            else
            {

                int ogrNo = AracGereclerClass.OgrenciNoVarsaAl("Ögrencinin numarasi: ");
                Console.WriteLine();

                Console.WriteLine("Ögrencinin Adı Soyadı: " + AracGereclerClass.AdSoyadGetir(ogrNo));
                Console.WriteLine("Ögrencinin Subesi: " + AracGereclerClass.SubeGetir(ogrNo));
                Console.WriteLine();




                string str = AracGereclerClass.YaziAl("Ögrenciyi silmek istediginize emin misiniz (E/H): ");
                if (str.ToUpper() == "E")
                {
                    Okulumuz.OgrenciSilmeMetodu(ogrNo);
                    Console.WriteLine("Ögrenci basarılı bir sekilde silindi.");
                }
                else if (str.ToUpper() == "H")
                    return;



            }
        }

        public void OgrenciAdresGir_18()
        {
            Console.WriteLine();
            Console.WriteLine("18-Ögrencinin Adresini Gir ------------------------------------------");
            if (OkulClass.OgrenciListesi.Count == 0)
            {
                Console.WriteLine("Listede silinecek ögrenci yok.");
                return;
            }
            else
            {

                int ogrNo = AracGereclerClass.OgrenciNoVarsaAl("Ögrencinin numarasi: ");
                Console.WriteLine();

                Console.WriteLine("Ögrencinin Adı Soyadı: " + AracGereclerClass.AdSoyadGetir(ogrNo));
                Console.WriteLine("Ögrencinin Subesi: " + AracGereclerClass.SubeGetir(ogrNo));
                Console.WriteLine();



                string il = AracGereclerClass.IlkHarfiBuyut(AracGereclerClass.YaziAl("Il: "));
                string ilce = AracGereclerClass.IlkHarfiBuyut(AracGereclerClass.YaziAl("Ilce: "));
                string mahalle = AracGereclerClass.IlkHarfiBuyut(AracGereclerClass.YaziAl("Mahalle: "));

                Okulumuz.AdresEklemeMetotu(ogrNo, il, ilce, mahalle);


            }
            Console.WriteLine();
            Console.WriteLine("Bilgiler sisteme girilmistir.");
        }

        public void OgrenciOkuduguKitabiGir_19()
        {
            Console.WriteLine();
            Console.WriteLine("19-Ögrencinin okudugu kitabı gir ------------------------------------");
            if (OkulClass.OgrenciListesi.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }
            else
            {

                int ogrNo = AracGereclerClass.OgrenciNoVarsaAl("Ögrencinin numarasi: ");
                Console.WriteLine();

                Console.WriteLine("Ögrencinin Adı Soyadı: " + AracGereclerClass.AdSoyadGetir(ogrNo));
                Console.WriteLine("Ögrencinin Subesi: " + AracGereclerClass.SubeGetir(ogrNo));
                Console.WriteLine();

                string eklenenKitap = AracGereclerClass.IlkHarfiBuyut(AracGereclerClass.YaziAl("Eklenecek Kitabin Adı: "));
                OgrenciClass.KitapEkle(ogrNo, eklenenKitap);

            }

            Console.WriteLine("Bilgiler sisteme girilmistir.");

        }


        public void OgrenciNotGir_20()
        {

            try
            {
                Console.WriteLine();
                Console.WriteLine("20-Not Gir ----------------------------------------------------------");
                int ogrNoBilgisi = AracGereclerClass.OgrenciNoVarsaAl("Ögrencinin numarasi: ");
                Console.WriteLine();

                Console.WriteLine("Ögrencinin Adı Soyadı: " + AracGereclerClass.AdSoyadGetir(ogrNoBilgisi));
                Console.WriteLine("Ögrencinin Subesi: " + AracGereclerClass.SubeGetir(ogrNoBilgisi));

                Console.WriteLine();
                Console.Write("Not eklemek istediğiniz dersi giriniz:  ");
                string yeniDers = AracGereclerClass.IlkHarfiBuyut(Console.ReadLine());


                int notAdedi = AracGereclerClass.SayiAl("Eklemek istediginiz not adedi: ");
                int not;
                for (int i = 1; i <= notAdedi; i++)
                {

                    while (true)
                    {

                        not = AracGereclerClass.SayiAl(i.ToString() + ". Notu girin: ");

                        if (not < 0 || not > 100)
                        {
                            Console.WriteLine("Girdiğiniz değer 0 ve 100 arasında olmalıdır.");


                        }
                        else
                        {
                            break;
                        }

                    }

                    Okulumuz.NotEkleme(ogrNoBilgisi, yeniDers, not);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }



        static void CikisYap()

        {
            Environment.Exit(0);
        }





        public void SahteVeriGir()
        {
            Okulumuz.OgrenciEkleMetotu(1, "Elif", "Selçuk", new DateTime(1998, 9, 15), CINSIYET.Kız, SUBE.A);
            Okulumuz.OgrenciEkleMetotu(2, "Betül", "Yılmaz", new DateTime(1995, 5, 12), CINSIYET.Kız, SUBE.B);
            Okulumuz.OgrenciEkleMetotu(3, "Hakan", "Çelik", new DateTime(1999, 2, 11), CINSIYET.Erkek, SUBE.C);
            Okulumuz.OgrenciEkleMetotu(4, "Kerem", "Akay", new DateTime(2004, 1, 7), CINSIYET.Erkek, SUBE.A);
            Okulumuz.OgrenciEkleMetotu(5, "Hatice", "Çınar", new DateTime(1996, 9, 21), CINSIYET.Kız, SUBE.B);
            Okulumuz.OgrenciEkleMetotu(6, "Selim", "İleri", new DateTime(1997, 11, 14), CINSIYET.Erkek, SUBE.B);
            Okulumuz.OgrenciEkleMetotu(7, "Selin", "Kamış", new DateTime(2001, 12, 25), CINSIYET.Kız, SUBE.C);
            Okulumuz.OgrenciEkleMetotu(8, "Sinan", "Avcı", new DateTime(1998, 7, 28), CINSIYET.Erkek, SUBE.A);
            Okulumuz.OgrenciEkleMetotu(9, "Deniz", "Çoban", new DateTime(2003, 3, 30), CINSIYET.Erkek, SUBE.C);
            Okulumuz.OgrenciEkleMetotu(10, "Selda", "Kavak", new DateTime(1994, 4, 14), CINSIYET.Kız, SUBE.B);
        }
        public void SahteKitapGir()
        {
            OgrenciClass.KitapEkle(1, "Kemal Tahir - Esir Şehrin İnsanları");
            OgrenciClass.KitapEkle(2, "Halit ziya - Aşkı Memnu");
            OgrenciClass.KitapEkle(3, "Sait Faik'in - Abasıyanık eseri :D");
            OgrenciClass.KitapEkle(4, "LOTR - Fellowship of the ring");
            OgrenciClass.KitapEkle(5, "Dostoyevski- Sefiller");
            OgrenciClass.KitapEkle(6, "Gogol Ölü Canlar");
            OgrenciClass.KitapEkle(7, "İclal Aydın- Üç Kız Kardeş");
            OgrenciClass.KitapEkle(8, "Dan Brown Melekler ve Şeytanlar");
            OgrenciClass.KitapEkle(9, "Antoine de Saint-Exupery - Küçük Prens");
            OgrenciClass.KitapEkle(10, "Stephen Hawking - Alacakaranlık");
            OgrenciClass.KitapEkle(1, "Suç ve ceza D.");
            OgrenciClass.KitapEkle(2, "Vadideki zambak Balca");
            OgrenciClass.KitapEkle(4, "LOTR - two tower");
        }
        public void SahteAdresGir()
        {
            Okulumuz.AdresEklemeMetotu(1, "Ankara", "Çankaya", "a");
            Okulumuz.AdresEklemeMetotu(2, "Ankara", "Keçiören", "b");
            Okulumuz.AdresEklemeMetotu(3, "Ankara", "Çankaya", "c");
            Okulumuz.AdresEklemeMetotu(4, "İzmir", "Karşıyaka", "d");
            Okulumuz.AdresEklemeMetotu(5, "İzmir", "Gaziemir", "e");
            Okulumuz.AdresEklemeMetotu(6, "İzmir", "Gaziemir", "f");
            Okulumuz.AdresEklemeMetotu(7, "İzmir", "Bayraklı", "g");
            Okulumuz.AdresEklemeMetotu(8, "İstanbul", "Arnavutköy", "g");
            Okulumuz.AdresEklemeMetotu(9, "İstanbul", "Beykoy", "g");
            Okulumuz.AdresEklemeMetotu(10, "İstanbul", "Ataşehir", "g");
        }
        public void SahteNotGir()
        {
            Okulumuz.NotEkleme(1, "Matematik", 60);
            Okulumuz.NotEkleme(1, "Türkçe", 25);
            Okulumuz.NotEkleme(1, "Fen", 55);
            Okulumuz.NotEkleme(1, "Sosyal", 20);

            Okulumuz.NotEkleme(2, "Matematik", 89);
            Okulumuz.NotEkleme(2, "Türkçe", 54);
            Okulumuz.NotEkleme(2, "Fen", 77);
            Okulumuz.NotEkleme(2, "Sosyal", 98);

            Okulumuz.NotEkleme(3, "Matematik", 45);
            Okulumuz.NotEkleme(3, "Türkçe", 34);
            Okulumuz.NotEkleme(3, "Fen", 100);
            Okulumuz.NotEkleme(3, "Sosyal", 98);

            Okulumuz.NotEkleme(4, "Matematik", 66);
            Okulumuz.NotEkleme(4, "Türkçe", 26);
            Okulumuz.NotEkleme(4, "Fen", 55);
            Okulumuz.NotEkleme(4, "Sosyal", 76);

            Okulumuz.NotEkleme(5, "Matematik", 98);
            Okulumuz.NotEkleme(5, "Türkçe", 89);
            Okulumuz.NotEkleme(5, "Fen", 87);
            Okulumuz.NotEkleme(5, "Sosyal", 100);

            Okulumuz.NotEkleme(6, "Matematik", 60);
            Okulumuz.NotEkleme(6, "Türkçe", 90);
            Okulumuz.NotEkleme(6, "Fen", 12);
            Okulumuz.NotEkleme(6, "Sosyal", 24);

            Okulumuz.NotEkleme(7, "Matematik", 55);
            Okulumuz.NotEkleme(7, "Türkçe", 43);
            Okulumuz.NotEkleme(7, "Fen", 53);
            Okulumuz.NotEkleme(7, "Sosyal", 98);

            Okulumuz.NotEkleme(8, "Matematik", 45);
            Okulumuz.NotEkleme(8, "Türkçe", 01);
            Okulumuz.NotEkleme(8, "Fen", 59);
            Okulumuz.NotEkleme(8, "Sosyal", 23);

            Okulumuz.NotEkleme(9, "Matematik", 60);
            Okulumuz.NotEkleme(9, "Türkçe", 50);
            Okulumuz.NotEkleme(9, "Fen", 23);
            Okulumuz.NotEkleme(9, "Sosyal", 56);

            Okulumuz.NotEkleme(10, "Matematik", 99);
            Okulumuz.NotEkleme(10, "Türkçe", 100);
            Okulumuz.NotEkleme(10, "Fen", 30);
            Okulumuz.NotEkleme(10, "Sosyal", 12);

        }
































    }
}






