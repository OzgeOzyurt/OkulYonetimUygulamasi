using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYönetimUygulaması
{

    internal class OgrenciClass
    //nesnenin tanımlandığı şablon


    {// Değişkenleri tanımladık. Diğer classlardan görünmesi için başlarına public yazdık. 

        //public List<DersNotuClass> Notlar = new List<DersNotuClass>();
        //Ogrenci bilgilerini ders notları ile eşleştirmek için ders notu listesi oluşturdum. Ders notunun ayrı sınıfı var unutma!
        //public List<DersNotuClass> DersNotuListesi = new List<DersNotuClass>();

        public SUBE Sube;
        public CINSIYET Cinsiyet;
        public DateTime DogumTarihi;
        public AdresClass Adres;
        public int No;
        public string Ad;
        public string Soyad;
        public List<DersNotuClass> Notlar = new List<DersNotuClass>();
        public List<string> OgrencininOkuduguKitaplar = new List<string>();



        public float Ortalama
        {
            get
            {
                float ortalama = this.Notlar.Sum(a => a.Not);

                if (ortalama == 0)
                {
                    return 0;
                }
                return ortalama / this.Notlar.Count;

            }
        }

        public int KitapSayisi
        {
            get
            {

                return OgrencininOkuduguKitaplar.Count;
            }
        }

        
        static public void KitapEkle(int no, string kitapAdi)
        {
            OgrenciClass ogrenci = OkulClass.OgrenciListesi.Where(item => item.No == no).FirstOrDefault();

            ogrenci.OgrencininOkuduguKitaplar.Add(kitapAdi);

        }



        public OgrenciClass(int no, string ad, string soyad, DateTime dTarihi, CINSIYET cins, SUBE sb)
        {//Clasdan nesne yaratırken girilmesini istediğimiz bilgileri yazdık. Bu bilgiler olmadan ogrenciclass nesnesi yaratılamaz.

            this.Ad = ad;
            this.Soyad = soyad;
            this.No = no;
            this.DogumTarihi = dTarihi;
            this.Cinsiyet = cins;
            this.Sube = sb;

        }

        public DateTime DateTime { get; internal set; }

        public void AdresEkleme(string il, string ilce, string mahalle)
        {
            if (Adres == null)
            {
                Adres = new AdresClass(); // Eğer adres yoksa yeni bir adres nesnesi oluşturuyor ve özelliklere göre dolduruyor.
            }
            Adres.Il = il;
            Adres.Ilce = ilce;
            Adres.Mahalle = mahalle;
        }

    }
    //Bazi veri girişlerini sınırlamak için class'a ait verilerin bazılarında enum tanımladık. 
    public enum SUBE
    {
        Empty,
        A,
        B,
        C,
        D
    }
    public enum CINSIYET
    {
        Empty,
        Kız,
        Erkek
    }
}

//1-Adres class düzenlendi. İl enum yapısından cıkarıldı. Zorunlu değildi zaten. 