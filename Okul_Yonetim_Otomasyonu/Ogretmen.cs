using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul_Yonetim_Otomasyonu
{
    public class Ogretmen:Kisi
    {
        public string Brans {  get; set; }
        public double Maas {  get; set; }

        public Ogretmen(string ad,string soyad,string kimlikno,string brans, double maas)
            : base(ad, soyad, kimlikno)
        {
            Brans = brans;
            Maas = maas;
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine("Branş", Brans);
            Console.WriteLine("maaş:",Maas);
        }
        public override string ToString()
        {
            return $"Ad: {Ad}, Soyad: {Soyad}, Branş: {Brans}, Maaş: {Maas:C}";
        }
    }
}
