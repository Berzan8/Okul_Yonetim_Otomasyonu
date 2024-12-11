using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Yonetim_Otomasyonu
{
    public class Kisi
    {
        public string Ad {  get; set; }
        public string Soyad { get; set; }
        public string KimlikNo { get; set;}

        public Kisi(string ad, string soyad,string kimlikno)
        {
            Ad = ad;
            Soyad = soyad;
            KimlikNo = kimlikno;
        }
        public virtual void BilgiYazdir() {
            Console.WriteLine("Ad:",Ad);
            Console.WriteLine("Soyad:", Soyad);
            Console.WriteLine("Kimlik No:",KimlikNo);
        }
    }
}
