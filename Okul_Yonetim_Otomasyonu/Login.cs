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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            notifyIcon1.BalloonTipTitle = "New Message";
            notifyIcon1.BalloonTipText = "Nesne Yönelimli Programlama Ödev 2";
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.ShowBalloonTip(1000);
            notifyIcon1.Visible = false;
        }

        public void textboxReset()
        {
            textBoxKulaniciAdi.Text = textBoxSifre.Text = "";
            textBoxKulaniciAdi.Focus();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string kulanici_adi = "Berzan";
            string sifre = "123";
            if(textBoxKulaniciAdi.Text == kulanici_adi && textBoxSifre.Text == sifre)
            {
                Admin admin = new Admin();
                admin.Show();
            }
            else
            {
                MessageBox.Show("kulanici adi ve ya sifre hatalidir");
                textboxReset();
            }
        }

       
    }
}
