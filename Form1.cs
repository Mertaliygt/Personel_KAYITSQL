using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        } 
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = PersonelVeriTabani; Integrated Security = True");
        private void label5_Click(object sender, EventArgs e)
        {

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
           
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel Where Perid=@k1" , baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtpersonelid.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("KAYIT SİLİNDİ ", "İNFO");
            
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
           // this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }
        void temizle()
        {
            txtpersonelad.Text = " ";
            txtsoyad.Text = " ";
            txtmaas.Text = "";
            txtmeslek.Text = "";
            txtsehir.Text = "";
            btnevli.Checked = false;
            btnbekar.Checked = false;

        }
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerDurum,PerMeslek) values (@p1, @p2 ,@p3 , @p4, @p5 ,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtpersonelad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3" , txtsehir.Text);
            komut.Parameters.AddWithValue("@p4", txtmaas.Text);
            komut.Parameters.AddWithValue("@p5", label8.Text);
            komut.Parameters.AddWithValue("@p6", txtmeslek.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi" , "Durum");

             
        }

        private void btnevli_CheckedChanged(object sender, EventArgs e)
        {
            if (btnevli.Checked == true)
            {
                label8.Text = "True";
            }
            
        }

        private void btnbekar_CheckedChanged(object sender, EventArgs e)
        {    if (btnbekar.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
            txtpersonelad.Focus();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtpersonelid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtpersonelad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text=dataGridView1.Rows[secilen].Cells[2].Value.ToString(); 
            txtsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text=dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
       
        
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                btnevli.Checked = true;

            }
            else
            {
                btnbekar.Checked= true;

            }


        }
    }
}
 