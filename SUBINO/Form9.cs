using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace SUBINO
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        void Button1Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        void Button3Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Selecione uma Imagem";
            openFileDialog.Filter = "Imagens (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Exibe a imagem no PictureBox
                    pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
                    // Opcional: Mostra o caminho do arquivo no título do formulário
                    this.Text = "Imagem carregada: " + Path.GetFileName(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message);
                }
            }
        }

        void Button2Click(object sender, EventArgs e)
        {
            try
            {
                // Estabelecendo a conexão com o banco de dados
                string connectionString = "Server=localhost;Database=subino;Uid=root;Pwd=ETEC;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Preparando o comando SQL para inserir os dados do cliente
                    string query = "INSERT INTO cliente (nome, sobrenome, cep, complemento, data_nascimento, cpf, email, telefone, foto) " +
                                   "VALUES (@nome, @sobrenome, @cep, @complemento, @data_nascimento, @cpf, @email, @telefone, @foto)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Adicionando os parâmetros
                        cmd.Parameters.AddWithValue("@nome", maskedTextBox1.Text);
                        cmd.Parameters.AddWithValue("@sobrenome", maskedTextBox2.Text);
                        cmd.Parameters.AddWithValue("@cep", maskedTextBox3.Text);
                        cmd.Parameters.AddWithValue("@complemento", maskedTextBox4.Text);
                        cmd.Parameters.AddWithValue("@data_nascimento", DateTime.Parse(maskedTextBox7.Text));
                        cmd.Parameters.AddWithValue("@cpf", maskedTextBox6.Text);
                        cmd.Parameters.AddWithValue("@email", maskedTextBox5.Text);
                        cmd.Parameters.AddWithValue("@telefone", maskedTextBox8.Text);

                        // Converting a imagem para um formato BLOB (se houver imagem)
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
                            cmd.Parameters.AddWithValue("@foto", DBNull.Value);
                        }

                        // Executando o comando SQL para inserir os dados
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente registrado com sucesso! Você será redirecionado automaticamente para nossa home.");
                Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar cliente: " + ex.Message);
            }
        }
    }
}
