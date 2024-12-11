using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Yonetim_Otomasyonu
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        public bool BosMu(string text)
        {
           if (string.IsNullOrEmpty(text)) {
                MessageBox.Show("Eksik ya da hatlı girilen değerler var");
                return true;
            }
           return false;
        }

        //öğrenciekle textboxlarını resetlemek için textboxreset fonksiyonunu kulandık
        public void textboxreset()
        {
            // TextBox'ları temizle
            textBoxOgrenciAdi.Clear();
            textBoxOgrenciSoyadi.Clear();
            textBox3OgrenciKimlkNo.Clear();
            textBoxOgrenciNo.Clear();
            textBoxSinifSeviyesi.Clear();

            // İlk TextBox'a odaklan
            textBoxOgrenciAdi.Focus();
        }
        // birden fazla öğrenci kaydı yapabilmek için Ogrenci classından türetilmiş bir list oluşturduk
        public List<Ogrenci> Ogrenciekle = new List<Ogrenci>();
        private void buttonOgrenciEkle_Click(object sender, EventArgs e)
        {

            string ad = textBoxOgrenciAdi.Text;
            if(BosMu(ad)) return;
            string soyad = textBoxOgrenciSoyadi.Text;
            if (BosMu(soyad)) return;
            string kimlikno = textBox3OgrenciKimlkNo.Text;
            if (BosMu(kimlikno)) return;
            if (!int.TryParse(textBoxOgrenciNo.Text, out int ogrencino))
            {
                MessageBox.Show("Lütfen geçerli bir öğrenci numarası girin.");
                return;
            }
            string sinifseviyesi = textBoxSinifSeviyesi.Text;
            if (BosMu(sinifseviyesi)) return;
            //yeni bir öğrenci nesnesi oluşturduk
            Ogrenci YeniOgrenci = new Ogrenci(ad, soyad, kimlikno, ogrencino, sinifseviyesi);
            Ogrenciekle.Add(YeniOgrenci);
            dataGridViewOgrenciListesi.DataSource = null;
            dataGridViewOgrenciListesi.DataSource = Ogrenciekle;
            MessageBox.Show($"Öğrenci başarıyla eklendi:\n{YeniOgrenci.Ad} {YeniOgrenci.Soyad}");
            textboxreset();
        }

        //öğretmenekle textboxlarını resetlemek için boxreset fonksiyonunu kulandık
        public void boxreset()
        {
            textBoxOgretmenAdi.Clear();
            textBoxOgretmenSoyadi.Clear();
            textBoxOgretmnKimlkNo.Clear();
            textBoxBrans.Clear();
            textBoxMaas.Clear();
            textBoxOgretmenAdi.Focus();
        }
        // birden fazla öğretmen kaydı yapabilmek için Ogretmen classından türetilmiş bir list oluşturduk
        List<Ogretmen> ogretmenekle = new List<Ogretmen>();
        private void buttonOgretmenEkle_Click(object sender, EventArgs e)
        {
            string ad = textBoxOgretmenAdi.Text;
            if (BosMu(ad)) return;
            string soyad = textBoxOgretmenSoyadi.Text;
            if (BosMu(soyad)) return;
            string kimlikno = textBoxOgretmnKimlkNo.Text;
            if (BosMu(kimlikno)) return;
            string brans = textBoxBrans.Text;
            if (!double.TryParse(textBoxMaas.Text, out double ogretmenmaas))
            {
                MessageBox.Show("Lütfen geçerli bir maas girin.");
                return;
            }
            //yeni bir Ogretmen nesnesi oluşturduk
            Ogretmen yeniogretmen = new Ogretmen(ad, soyad, kimlikno, brans, ogretmenmaas);
            ogretmenekle.Add(yeniogretmen);
            dataGridViewOgretmenListesi.DataSource = null;
            dataGridViewOgretmenListesi.DataSource = ogretmenekle;
            MessageBox.Show($"Öğretmen başarıyla eklendi:\n{yeniogretmen.Ad} {yeniogretmen.Soyad}");
            boxreset();

        }
        //sınıf kaydet textboxlarını resetlemek için sinifBoxReset fonksiyonunu kulandık
        public void sinifBoxReset()
        {
            textBoxSinifAdi.Clear();
            textBoxKapasite.Clear();
            textBoxSnfOgrncKyd.Clear();
            textBoxSinifAdi.Focus();
        }
        // birden fazla sınıf kaydı yapabilmek için Sinif Classından türetilmiş bir list oluşturduk
        public List<Sinif> sinifekle = new List<Sinif>();
        private void buttonSinifKaydet_Click(object sender, EventArgs e)
        {
            string sinif_adi = textBoxSinifAdi.Text;
            if (BosMu(sinif_adi)) return;

            if (!int.TryParse(textBoxKapasite.Text, out int kapasite))
            {
                MessageBox.Show("Lütfen geçerli bir sınıf kapasitesi girin.");
                return;
            }

            if (!int.TryParse(textBoxSnfOgrncKyd.Text, out int ogrencino))
            {
                MessageBox.Show("Girilen ogrenci numarasi geçersizdir.");
                return;
            }
            //yeni bir Sinif nesnesi oluşturduk
            Sinif yenisinif = new Sinif(sinif_adi, kapasite);

            foreach (var ogrenci in Ogrenciekle)
            {
                if (ogrenci.OgrenciNo == ogrencino)
                {
                    if (yenisinif.OgrenciListesi.Any(o => o.OgrenciNo == ogrencino))
                    {
                        MessageBox.Show("Bu öğrenci zaten bu sınıfa kayıtlı.");
                        sinifBoxReset();
                        return;
                    }
                    yenisinif.OgrenciEkle(ogrenci);
                    MessageBox.Show($"{ogrenci.Ad} {ogrenci.Soyad} in kaydi olusturulmustur");
                    break;
                }
            }
            sinifekle.Add(yenisinif);
            // Sınıfı ve öğrencileri görüntülemek için SinifGorunum listesi oluşturuyoruz
            List<SinifGorunum> sinifGorunumListesi = new List<SinifGorunum>();

            // Her sınıf için öğrencileri ayrı satırlarda göstereceğiz
            foreach (var sinif in sinifekle)
            {
                foreach (var ogrenci in sinif.OgrenciListesi)
                {
                    sinifGorunumListesi.Add(new SinifGorunum
                    {
                        SinifAdi = sinif.SinifAdi,
                        Kapasite = sinif.Kapasite,
                        OgrenciAdi = ogrenci.Ad,
                        OgrenciSoyadi = ogrenci.Soyad,
                        OgrenciNo = ogrenci.OgrenciNo
                    });
                }
            }

            // DataGridView'i güncelliyoruz
            dataGridViewSinifListesi.DataSource = null;
            dataGridViewSinifListesi.DataSource = sinifGorunumListesi;

            MessageBox.Show($"Sınıf ve öğrenciler başarıyla kaydedildi: {yenisinif.SinifAdi}");
            sinifBoxReset();
        }
        public class SinifGorunum
        {
            public string SinifAdi { get; set; }
            public int Kapasite { get; set; }
            public string OgrenciAdi { get; set; }
            public string OgrenciSoyadi { get; set; }
            public int OgrenciNo { get; set; }
        }

        //DersKaydet textboxlarını resetlemek için dersboxreset fonksiyonunu kulandık
        public void dersboxreset()
        {
            textBoxDersAdi.Clear();
            textBoxDersKodu.Clear();
            textBoxDersOgrtmnKyd.Clear();
            textBoxDrsOgrncKyd.Clear();
            textBoxDersAdi.Focus();
        }

        public List<Ders> dersekle = new List<Ders>();
        private void buttonDersKaydet_Click(object sender, EventArgs e)
        {
            string Dersadi = textBoxDersAdi.Text;
            if (BosMu(Dersadi)) return;
            string Derskodu = textBoxDersKodu.Text;
            if (BosMu(Derskodu)) return;
            Ders yeniDers = new Ders(Dersadi, Derskodu);

            string ogretmenkimlikno=textBoxDersOgrtmnKyd.Text;
            if (BosMu(ogretmenkimlikno)) return;
            foreach (var ogretmen in ogretmenekle)
            {
                if (ogretmen.KimlikNo == ogretmenkimlikno)
                {
                    yeniDers.OgretmenEkle(ogretmen);
                    break;
                }
            }

            if (!int.TryParse(textBoxDrsOgrncKyd.Text, out int ogrencino))
            {
                MessageBox.Show("Girilen ogrenci numarasi geçersizdir.");
                return;
            }
            foreach(var ogrenci in Ogrenciekle)
            {
                if (ogrenci.OgrenciNo == ogrencino)
                {
                    yeniDers.OgrenciEkle(ogrenci);
                    break;
                }
            }
            dersekle.Add(yeniDers);
            // Dersleri, Öğretmenleri ve öğrencileri görüntülemek için DersGorunum listesi oluşturuyoruz
            List<DersGorunum> dersgörünüm=new List<DersGorunum>();
            foreach (var ders in dersekle)
            {
                foreach (var ogrenci in ders.Ogrencilistesi)
                {
                    dersgörünüm.Add(new DersGorunum
                    {
                        DersAdi = ders.DersAdi,
                        Derskodu = ders.DersKodu,
                        OgretmenAdi = ders.Ogretmen?.Ad,
                        OgretmenSoyadi = ders.Ogretmen?.Soyad, 
                        OgrenciAdi = ogrenci.Ad,  
                        OgrenciSoyadi = ogrenci.Soyad,
                        OgrenciNo = ogrenci.OgrenciNo

                    });
                }
            }
            dataGridViewDersLİstele.DataSource = null;
            dataGridViewDersLİstele.DataSource = dersgörünüm;
            MessageBox.Show("Kayıt işlemi tamamlandı");
            dersboxreset();
        }

        public class DersGorunum
        {
            public string DersAdi { get; set; }
            public string Derskodu { get; set; }
            public string OgretmenAdi {  get; set; }
            public string OgretmenSoyadi {  get; set; } 
            public string OgrenciAdi { get; set; }
            public string OgrenciSoyadi { get; set; }
            public int OgrenciNo { get; set; }

        }

        //personelkaydet textboxlarını resetlemek için personelboxreset fonksiyonunu kulandık
        public void personelboxreset()
        {
            textBoxPersonelAdi.Clear();
            textBoxPersonelSoyadi.Clear();
            textBoxPersonelKimlikNo.Clear();
            textBoxPozisyon.Clear();
            textBoxDepartman.Clear();
            textBoxPersonelAdi.Focus();
        }
        //Birden fazla personel eklemek için IdariPersonel classından türetilimiş bir list oluşturduk
        List<IdariPersonel> personelekle=new List<IdariPersonel>();
        private void buttonPersonelKaydet_Click(object sender, EventArgs e)
        {
            string ad=textBoxPersonelAdi.Text;
            if (BosMu(ad)) return;
            string soyad=textBoxPersonelSoyadi.Text;
            if (BosMu(ad)) return;
            string kimlikno=textBoxPersonelKimlikNo.Text;
            if (BosMu(ad)) return;
            string pozisyon=textBoxPozisyon.Text;
            if (BosMu(ad)) return;
            string departman=textBoxDepartman.Text;
            if (BosMu(ad)) return;

            //yeni bir IdariPersonel nesnesi oluşturduk
            IdariPersonel yenipersonel=new IdariPersonel(ad,soyad, kimlikno, pozisyon,departman);
            personelekle.Add(yenipersonel);
            dataGridViewDepartmanListele.DataSource=null;
            dataGridViewDepartmanListele.DataSource = personelekle;
            MessageBox.Show($"{ad} {soyad} idari personel olarak eklendi");
            personelboxreset();
        }
       
    }
}
