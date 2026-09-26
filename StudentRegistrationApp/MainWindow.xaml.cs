using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentRegistrationApp
{
    public partial class MainWindow : Window
    {
        // Penyimpanan semua data mahasiswa
        private List<Student> daftarMahasiswa = new List<Student>();

        // Menyimpan data yang sedang diedit (null = mode tambah)
        private Student mahasiswaDiedit = null;

        public MainWindow()
        {
            InitializeComponent();
            TampilkanData();
        }

        // ============ TAMPILKAN DATA + SEARCH + COUNTER ============
        private void TampilkanData()
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            List<Student> hasil = daftarMahasiswa
                .Where(m => m.Nim.ToLower().Contains(keyword)
                         || m.Nama.ToLower().Contains(keyword)
                         || m.Prodi.ToLower().Contains(keyword))
                .ToList();

            lstMahasiswa.ItemsSource = hasil;

            string teks = $"Jumlah Mahasiswa: {daftarMahasiswa.Count}";
            if (keyword != "")
            {
                teks += $" (ditemukan: {hasil.Count})";
            }
            txtJumlah.Text = teks;
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsLoaded) return;
            TampilkanData();
        }

        // ============ RESET FORM ============
        private void ResetForm()
        {
            txtNim.Clear();
            txtNama.Clear();
            txtAlamat.Clear();
            txtTelepon.Clear();
            cmbProdi.SelectedIndex = -1;
            rbLaki.IsChecked = false;
            rbPerempuan.IsChecked = false;
            dpTanggalLahir.SelectedDate = null;

            mahasiswaDiedit = null;
            btnSimpan.Content = "Simpan";
            txtNim.Focus();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }

        // ============ SIMPAN / UPDATE ============
        private void BtnSimpan_Click(object sender, RoutedEventArgs e)
        {
            // ----- VALIDASI -----
            if (string.IsNullOrWhiteSpace(txtNim.Text))
            {
                MessageBox.Show("NIM harus diisi!");
                txtNim.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("Nama harus diisi!");
                txtNama.Focus();
                return;
            }

            if (cmbProdi.SelectedItem == null)
            {
                MessageBox.Show("Pilih program studi!");
                return;
            }

            if (rbLaki.IsChecked != true && rbPerempuan.IsChecked != true)
            {
                MessageBox.Show("Pilih jenis kelamin!");
                return;
            }

            if (dpTanggalLahir.SelectedDate == null)
            {
                MessageBox.Show("Pilih tanggal lahir!");
                return;
            }

            if (dpTanggalLahir.SelectedDate.Value > DateTime.Today)
            {
                MessageBox.Show("Tanggal lahir tidak boleh melebihi hari ini!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAlamat.Text))
            {
                MessageBox.Show("Alamat harus diisi!");
                txtAlamat.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelepon.Text))
            {
                MessageBox.Show("Nomor telepon harus diisi!");
                txtTelepon.Focus();
                return;
            }

            if (!txtTelepon.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Nomor telepon hanya boleh berisi angka!");
                txtTelepon.Focus();
                return;
            }

            // Cek NIM ganda (data yang sedang diedit tidak dihitung)
            string nim = txtNim.Text.Trim();
            bool nimSudahAda = daftarMahasiswa.Any(
                m => m.Nim == nim && m != mahasiswaDiedit);

            if (nimSudahAda)
            {
                MessageBox.Show("NIM sudah terdaftar!");
                txtNim.Focus();
                return;
            }

            // ----- AMBIL DATA DARI FORM -----
            string prodi = ((ComboBoxItem)cmbProdi.SelectedItem).Content.ToString();
            string jenisKelamin = rbLaki.IsChecked == true ? "Laki-laki" : "Perempuan";

            if (mahasiswaDiedit == null)
            {
                // ----- MODE TAMBAH -----
                Student baru = new Student
                {
                    Nim = nim,
                    Nama = txtNama.Text.Trim(),
                    Prodi = prodi,
                    JenisKelamin = jenisKelamin,
                    TanggalLahir = dpTanggalLahir.SelectedDate.Value,
                    Alamat = txtAlamat.Text.Trim(),
                    NoTelepon = txtTelepon.Text.Trim()
                };
                daftarMahasiswa.Add(baru);

                MessageBox.Show(
                    "Data mahasiswa berhasil disimpan!",
                    "Informasi",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                // ----- MODE EDIT (UPDATE) -----
                mahasiswaDiedit.Nim = nim;
                mahasiswaDiedit.Nama = txtNama.Text.Trim();
                mahasiswaDiedit.Prodi = prodi;
                mahasiswaDiedit.JenisKelamin = jenisKelamin;
                mahasiswaDiedit.TanggalLahir = dpTanggalLahir.SelectedDate.Value;
                mahasiswaDiedit.Alamat = txtAlamat.Text.Trim();
                mahasiswaDiedit.NoTelepon = txtTelepon.Text.Trim();

                MessageBox.Show(
                    "Data mahasiswa berhasil diperbarui!",
                    "Informasi",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            TampilkanData();
            ResetForm();
        }

        // ============ EDIT ============
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Student terpilih = lstMahasiswa.SelectedItem as Student;

            if (terpilih == null)
            {
                MessageBox.Show("Pilih data yang ingin diedit!");
                return;
            }

            // Isi form dengan data yang dipilih
            txtNim.Text = terpilih.Nim;
            txtNama.Text = terpilih.Nama;
            txtAlamat.Text = terpilih.Alamat;
            txtTelepon.Text = terpilih.NoTelepon;
            dpTanggalLahir.SelectedDate = terpilih.TanggalLahir;

            foreach (ComboBoxItem item in cmbProdi.Items)
            {
                if (item.Content.ToString() == terpilih.Prodi)
                {
                    cmbProdi.SelectedItem = item;
                    break;
                }
            }

            rbLaki.IsChecked = terpilih.JenisKelamin == "Laki-laki";
            rbPerempuan.IsChecked = terpilih.JenisKelamin == "Perempuan";

            // Masuk mode edit
            mahasiswaDiedit = terpilih;
            btnSimpan.Content = "Update";
            txtNama.Focus();
        }
     
        private void BtnHapus_Click(object sender, RoutedEventArgs e)
        {
            Student terpilih = lstMahasiswa.SelectedItem as Student;

            if (terpilih == null)
            {
                MessageBox.Show("Pilih data yang ingin dihapus!");
                return;
            }

            MessageBoxResult konfirmasi = MessageBox.Show(
                $"Yakin ingin menghapus data {terpilih.Nama}?",
                "Konfirmasi Hapus",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (konfirmasi == MessageBoxResult.Yes)
            {
                // Kalau data yang dihapus sedang diedit, kosongkan form
                if (mahasiswaDiedit == terpilih)
                {
                    ResetForm();
                }

                daftarMahasiswa.Remove(terpilih);
                TampilkanData();
            }
        }
    }
}