using System;
using System.Data;
using System.Data.SqlClient; // Alterado para MySql.Data.MySqlClient para conexão MySQL
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SUBINO
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            // Redirecionar para a tela Form2
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void Button3Click(object sender, EventArgs e)
        {
            // Abrir o diálogo para selecionar uma imagem
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Selecione uma Imagem";
            openFileDialog.Filter = "Imagens (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Exibir a imagem no PictureBox
                    pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
                    this.Text = "Imagem carregada: " + System.IO.Path.GetFileName(openFileDialog.FileName);
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
                // Criar a conexão com o banco de dados
                string connectionString = "server=localhost;uid=root;pwd=ETEC;database=subino";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Inserir os dados na tabela de motoristas
                    string query = @"INSERT INTO motorista
                                     (nome, sobrenome, data_nascimento, data_vencimento_cnh, clt, cep, numero, telefone, foto) 
                                     VALUES 
                                     (@nome, @sobrenome, @data_nascimento, @data_vencimento_cnh, @clt, @cep, @numero, @telefone, @foto)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Adicionar parâmetros para os valores do formulário
                        command.Parameters.AddWithValue("@nome", maskedTextBox1.Text);
                        command.Parameters.AddWithValue("@sobrenome", maskedTextBox2.Text);
                        command.Parameters.AddWithValue("@data_nascimento", DateTime.Parse(maskedTextBox7.Text));
                        command.Parameters.AddWithValue("@data_vencimento_cnh", DateTime.Parse(maskedTextBox6.Text));
                        command.Parameters.AddWithValue("@clt", maskedTextBox5.Text);
                        command.Parameters.AddWithValue("@cep", maskedTextBox3.Text);
                        command.Parameters.AddWithValue("@numero", maskedTextBox4.Text);
                        command.Parameters.AddWithValue("@telefone", maskedTextBox8.Text);

                        // Adicionar foto
                        if (pictureBox2.Image != null)
                        {
                            using (var ms = new System.IO.MemoryStream())
                            {
                                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                command.Parameters.AddWithValue("@foto", ms.ToArray());
                            }
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@foto", DBNull.Value);
                        }

                        // Executar o comando de inserção
                        command.ExecuteNonQuery();
                    }

                    // Mostrar mensagem de sucesso
                    MessageBox.Show("Motorista registrado com sucesso! Você será redirecionado automaticamente para nossa home.");

                    // Redirecionar para o Form2
                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar motorista: " + ex.Message);
            }
        }
    }
}
