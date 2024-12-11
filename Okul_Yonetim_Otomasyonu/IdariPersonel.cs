using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul_Yonetim_Otomasyonu
{
    public class IdariPersonel:Kisi
    {
        public string Pozisyon {  get; set; }
        public string Departman {  get; set; }
        public IdariPersonel(string ad,string soyad,string kimlikno,string pozisyon,string departman)
            : base(ad, soyad, kimlikno)
        {
            Pozisyon = pozisyon;
            Departman = departman;
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine("Pozisyon:",Pozisyon);
            Console.WriteLine("Departman:",Departman);
        }
    }
}
