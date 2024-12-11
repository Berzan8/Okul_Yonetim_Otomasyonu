using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Yonetim_Otomasyonu
{
    public class Ders
    {
        public string DersAdi {  get; set; }
        public string DersKodu { get; set; }
        public Ogretmen Ogretmen { get; set; }
        public List<Ogrenci> Ogrencilistesi { get; set; }

        public Ders(string dersAdi,string derskodu) 
        { 
            DersAdi = dersAdi;
            DersKodu= derskodu;
            Ogrencilistesi = new List<Ogrenci>();

        }
        public void OgrenciEkle(Ogrenci ogrenci)
        {
            Ogrencilistesi.Add(ogrenci);

        }
        public void OgretmenEkle(Ogretmen ogretmen)
        {
            Ogretmen = ogretmen;
        }

        public void DersBilgileriniYazdir()
        {
            Console.WriteLine("Ders Adı:", DersAdi);
            Console.WriteLine("Ders Kodu:",DersKodu);
            Console.WriteLine(" Dersi Veren Ögretmen:");
            Ogretmen.BilgiYazdir();
            Console.WriteLine("Ögrenciler:");
            foreach(var ogrenci  in Ogrencilistesi)
            {
                ogrenci.BilgiYazdir();
                Console.WriteLine();
            }

        }
        
    }
}
