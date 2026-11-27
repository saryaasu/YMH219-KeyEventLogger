using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace YMH219_KeyEventLogger
{
    public partial class Form1 : Form
    {
        private readonly List<KeyEventRecord> _kayitlar = new List<KeyEventRecord>();
        private bool _kayitAktif = false;

        private Button btnBaslat;
        private Button btnDurdur;
        private Button btnTemizle;
        private Button btnKaydet;
        private Label lblDurum;
        private ListBox lstKayitlar;

        public Form1()
        {
            ArayuzuOlustur();
            DurumGuncelle(false);
        }

        private void ArayuzuOlustur()
        {
            Text = "YMH 219 - Key Event Logger";
            Width = 620;
            Height = 420;
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;

            btnBaslat = new Button { Text = "Başlat", Left = 20, Top = 20, Width = 100, Height = 34 };
            btnDurdur = new Button { Text = "Durdur", Left = 130, Top = 20, Width = 100, Height = 34 };
            btnTemizle = new Button { Text = "Temizle", Left = 240, Top = 20, Width = 100, Height = 34 };
            btnKaydet = new Button { Text = "TXT Kaydet", Left = 350, Top = 20, Width = 110, Height = 34 };

            lblDurum = new Label
            {
                Text = "Durum: Pasif",
                Left = 20,
                Top = 66,
                Width = 440,
                Height = 24,
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold)
            };

            lstKayitlar = new ListBox
            {
                Left = 20,
                Top = 98,
                Width = 560,
                Height = 260,
                IntegralHeight = false
            };

            btnBaslat.Click += BtnBaslat_Click;
            btnDurdur.Click += BtnDurdur_Click;
            btnTemizle.Click += BtnTemizle_Click;
            btnKaydet.Click += BtnKaydet_Click;

            KeyDown += Form1_KeyDown;

            Controls.AddRange(new Control[] { btnBaslat, btnDurdur, btnTemizle, btnKaydet, lblDurum, lstKayitlar });
        }

        private void DurumGuncelle(bool aktif)
        {
            _kayitAktif = aktif;
            btnBaslat.Enabled = !aktif;
            btnDurdur.Enabled = aktif;
            lblDurum.Text = aktif
                ? "Durum: AKTİF (Tuşlar kaydediliyor...)"
                : "Durum: PASİF (Kayıt durduruldu)";
        }

        private void BtnBaslat_Click(object sender, EventArgs e)
        {
            DurumGuncelle(true);
        }

        private void BtnDurdur_Click(object sender, EventArgs e)
        {
            DurumGuncelle(false);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            _kayitlar.Clear();
            lstKayitlar.Items.Clear();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (_kayitlar.Count == 0)
            {
                MessageBox.Show("Kaydedilecek tuş kaydı bulunmuyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Kayıtları TXT Olarak Kaydet";
                sfd.Filter = "Metin Dosyası (*.txt)|*.txt";
                sfd.FileName = $"KeyEvents_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                        {
                            foreach (KeyEventRecord kayit in _kayitlar)
                            {
                                sw.WriteLine(kayit.ToString());
                            }
                        }

                        MessageBox.Show("Kayıtlar başarıyla dosyaya kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Dosya kaydedilirken hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_kayitAktif) return;

            var kayit = new KeyEventRecord(DateTime.Now, "KeyDown", e.KeyCode.ToString());
            KayitEkle(kayit);
        }

        private void KayitEkle(KeyEventRecord kayit)
        {
            _kayitlar.Add(kayit);
            lstKayitlar.Items.Add(kayit.ToString());
            lstKayitlar.TopIndex = Math.Max(0, lstKayitlar.Items.Count - 1);
        }
    }

    public class KeyEventRecord
    {
        public DateTime Zaman { get; }
        public string OlayTuru { get; }
        public string TusAdi { get; }

        public KeyEventRecord(DateTime zaman, string olayTuru, string tusAdi)
        {
            Zaman = zaman;
            OlayTuru = olayTuru;
            TusAdi = tusAdi;
        }

        public override string ToString()
        {
            return $"[{Zaman:yyyy-MM-dd HH:mm:ss.fff}] [{OlayTuru}] Tuş: {TusAdi}";
        }
    }
}