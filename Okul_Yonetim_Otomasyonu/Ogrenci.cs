using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul_Yonetim_Otomasyonu
{
    public class Ogrenci:Kisi
    {
        public int OgrenciNo {  get; set; }
        public string SinifSeviyesi {  get; set; }

        public Ogrenci(string ad,string soyad,string kimlikno,int ogrencino,string sınıfseviyesi)
            : base(ad, soyad, kimlikno)
        {
            OgrenciNo = ogrencino;
            SinifSeviyesi = sınıfseviyesi;
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine("Ogrenci No:",OgrenciNo);
            Console.WriteLine("Sınıf Seviyesi:",SinifSeviyesi);
        }
        public override string ToString()
        {
            return $"Ad: {Ad}, Soyad: {Soyad}, Öğrenci No: {OgrenciNo}";
        }


    }
}
