using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OkulYönetimUygulaması
{
    internal class OkulClass
    {
        //Ogrencilerle ilgili tüm işlemleri burada yapacağım. Öğrenci class ile karıştırma ogrenci classta öğrencilerin 
        //özelliklerini oluşturduk. (cinsiyet yaş şube...) Burada öğrenci classın içini doldurcaz.

        static public List<OgrenciClass> OgrenciListesi = new List<OgrenciClass>();



        public void NotEkleme(int no, string yeniders, float not)
        {
            OgrenciClass ogrenci = OgrenciListesi.Where(item => item.No == no).FirstOrDefault();
            if (ogrenci != null)
            {
                DersNotuClass gercekOgrenciNotu = new DersNotuClass(yeniders, not);
                ogrenci.Notlar.Add(gercekOgrenciNotu);
            }

        }


        public void OgrenciEkleMetotu(int no, string ad, string soyad, DateTime dTarihi, CINSIYET cinsiyet, SUBE sb)
        // Metot çağrıldığında ÖğrencilerListesi'ne öğrenciyi ekliyor.
        {
            OgrenciListesi.Add(new OgrenciClass(no, ad, soyad, dTarihi, cinsiyet, sb));
        }

   


        public void TumOgrenciListeleMetotu()
        // OgrenciListesini ListeYazdir ile hazırlayan metot.
        {
            AracGereclerClass.ListeYazdir(OgrenciListesi);
        }


        public void SubeyeOgrenciListelemeMetotu(SUBE sube)
        {
            List<OgrenciClass> yeniListe = new List<OgrenciClass>();
            yeniListe = OgrenciListesi.Where(item => item.Sube == sube).ToList();
            AracGereclerClass.ListeYazdir(yeniListe);

        }

        public void CinsiyeteGoreOgrenciListelemeMetotu(CINSIYET cinsiyet)
        {
            List<OgrenciClass> yeniListe = new List<OgrenciClass>();
            yeniListe = OgrenciListesi.Where(item => item.Cinsiyet == cinsiyet).ToList();
            AracGereclerClass.ListeYazdir(yeniListe);
        }

        public void TariheGoreOgrenciListeleMetotu(DateTime tarih)
        {
            List<OgrenciClass> yeniListe = new List<OgrenciClass>();
            yeniListe = OgrenciListesi.Where(item => item.DogumTarihi > tarih).ToList();
            AracGereclerClass.ListeYazdir(yeniListe);
        }



        public void IllereGoreOgrenciListeleMetotu()
        {

            List<OgrenciClass> yeniListe = new List<OgrenciClass>();
            yeniListe = OgrenciListesi.OrderBy(item => item.Adres.Il).ToList();
            AracGereclerClass.ListeYazdirIl(yeniListe);
        }



        public void OgrenciSilmeMetodu(int ogrNo)
        {

            OgrenciClass ogrenci = OgrenciListesi.Where(s => s.No == ogrNo).FirstOrDefault();
            OgrenciListesi.Remove(ogrenci);

        }


        public void OgrenciGuncelleMetotu(int no, string ad, string soyad, DateTime dg, CINSIYET cins, SUBE sube)

        {
            OgrenciClass ogrenci = OkulClass.OgrenciListesi.Where(item => item.No == no).FirstOrDefault();

            ogrenci.Ad = ad;
            ogrenci.Soyad = soyad;
            ogrenci.DateTime = dg;
            ogrenci.Cinsiyet = cins;
            ogrenci.Sube = sube;


        }


        public void AdresEklemeMetotu(int no, string il, string ilce, string mahalle)
        {
            OgrenciClass ogrenci = OgrenciListesi.FirstOrDefault(r => r.No == no);

            if (ogrenci != null)
            {
                ogrenci.AdresEkleme(il, ilce, mahalle);
            }
        }
    }
}
