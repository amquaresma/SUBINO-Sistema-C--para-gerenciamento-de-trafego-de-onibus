using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SUBINO
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Button4Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void Button3Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Selecione uma Imagem";
            openFileDialog.Filter = "Imagens (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
                    this.Text = "Imagem carregada: " + Path.GetFileName(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message);
                }
            }
        }

        private void Button2Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=subino;Uid=root;Pwd=ETEC;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO veiculo (antt, placa, modelo, numero_chassi, marca, cor, foto) " +
                                   "VALUES (@antt, @placa, @modelo, @numero_chassi, @marca, @cor, @foto)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@antt", maskedTextBox1.Text);
                        cmd.Parameters.AddWithValue("@placa", maskedTextBox2.Text);
                        cmd.Parameters.AddWithValue("@modelo", maskedTextBox3.Text);
                        cmd.Parameters.AddWithValue("@numero_chassi", maskedTextBox5.Text);
                        cmd.Parameters.AddWithValue("@marca", maskedTextBox4.Text);
                        cmd.Parameters.AddWithValue("@cor", maskedTextBox6.Text);

                        // Convertendo a imagem para um array de bytes
                        if (pictureBox2.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                                cmd.Parameters.AddWithValue("@foto", ms.ToArray());
                            }
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@foto", DBNull.Value);  // Se não houver foto, insere NULL
                        }

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Veículo registrado com sucesso! Você será redirecionado automaticamente para nossa home.");
                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar veículo: " + ex.Message);
            }
        }
    }
}
