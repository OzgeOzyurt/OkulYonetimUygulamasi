using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYönetimUygulaması
{
    internal class DersNotuClass
    {



        //Ders notu class içinde Dersler adında enum tanımladık. Float veri tipinde not tanımladık. Dipnot: VAZGEÇTİK. :D
        public string Ders;
        public float Not;
        


        //Ders notu class da nesne tanımlanırken kesinlikle olmasını istediğim bilgileri buraya yazdım.Unutma bu bilgiler olmadan nesne tanımlanamaz. Kısayol CTOR...
        public DersNotuClass(string dersAdiBilgisi,float dersNotuBilgisi)
        {
            this.Not = dersNotuBilgisi;
            this.Ders = dersAdiBilgisi;  
           
        }
    }
    
    
  }


