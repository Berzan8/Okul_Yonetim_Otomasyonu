using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Yonetim_Otomasyonu
{
    public class Sinif
    {
        public string SinifAdi {  get; set; }
        public int Kapasite {  get; set; }  
        public List<Ogrenci> OgrenciListesi { get; set; }
        public Sinif(string sinifAdi,int kapasite)
        {
            SinifAdi = sinifAdi;
            Kapasite = kapasite;
            OgrenciListesi = new List<Ogrenci>();

        }

        public void OgrenciEkle(Ogrenci ogrenci)
        {
            // Kapasiteyi kontrol et
            if (OgrenciListesi.Count >= Kapasite)
            {
                MessageBox.Show("Sinif kapasitesi dolduğundan dolayı kayıt yapılamaz.");
                return; // Kapasite dolmuşsa, öğrenci eklenmesin
            }

            // Kapasiteyi geçmediyse öğrenci ekle
            OgrenciListesi.Add(ogrenci);
        }


        public void SinifBilgileriniYazdir()
        {
            Console.WriteLine("Sınıf Adı:",SinifAdi);
            Console.WriteLine("Kapasite", Kapasite);
            Console.WriteLine("Öğrenciler:");
            foreach(var ogrenci in OgrenciListesi)
            {
                ogrenci.BilgiYazdir();
                Console.WriteLine();

            }
        }
    }
}
