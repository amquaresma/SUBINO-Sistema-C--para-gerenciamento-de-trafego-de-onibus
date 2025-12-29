using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SUBINO
{
    public partial class Form6 : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=ETEC;database=subino"; // Conexão com o banco de dados

        public Form6()
        {
            InitializeComponent();
        }

        // Botão para voltar para o Form2
        void Button1Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        // Botão para carregar a imagem
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

        // Botão para cadastrar a recepcionista no banco
        void Button2Click(object sender, EventArgs e)
        {
            string nome = maskedTextBox1.Text;
            string sobrenome = maskedTextBox2.Text;
            string cep = maskedTextBox3.Text;
            string complemento = maskedTextBox4.Text;
            string cpf = maskedTextBox6.Text;
            string email = maskedTextBox5.Text;
            string telefone = maskedTextBox8.Text;
            byte[] foto = null;
            DateTime dataNascimento;

            // Verifica se a data de nascimento é válida
            if (!DateTime.TryParseExact(maskedTextBox7.Text, "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dataNascimento))
            {
                MessageBox.Show("Data de nascimento inválida. Por favor, insira a data no formato dd/MM/yyyy.");
                return;
            }

            // Verifica se a imagem foi carregada
            if (pictureBox2.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                    foto = ms.ToArray();
                }
            }
            else
            {
                MessageBox.Show("Por favor, carregue uma imagem.");
                return;
            }

            // Verifica se todos os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(sobrenome) || string.IsNullOrWhiteSpace(cpf) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(telefone))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            // Tenta cadastrar a recepcionista
            if (CadastrarRecepcionista(nome, sobrenome, cep, complemento, dataNascimento, cpf, email, telefone, foto))
            {
                MessageBox.Show("Recepcionista registrado com sucesso! Você será redirecionado automaticamente para nossa home.");
                Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Erro ao registrar recepcionista. Tente novamente.");
            }
        }

        // Método para cadastrar a recepcionista no banco de dados
        private bool CadastrarRecepcionista(string nome, string sobrenome, string cep, string complemento, DateTime dataNascimento, string cpf, string email, string telefone, byte[] foto)
        {
            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("INSERT INTO recepcionista (nome, sobrenome, cep, complemento, data_nascimento, cpf, email, telefone, foto) VALUES (@Nome, @Sobrenome, @Cep, @Complemento, @DataNascimento, @Cpf, @Email, @Telefone, @Foto)", conexao);

                    // Adiciona os parâmetros
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", sobrenome);
                    cmd.Parameters.AddWithValue("@Cep", cep);
                    cmd.Parameters.AddWithValue("@Complemento", complemento);
                    cmd.Parameters.AddWithValue("@DataNascimento", dataNascimento.ToString("yyyy-MM-dd")); // Converter data para formato MySQL
                    cmd.Parameters.AddWithValue("@Cpf", cpf);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Telefone", telefone);
                    cmd.Parameters.AddWithValue("@Foto", foto);

                    // Executa a inserção
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar recepcionista: {ex.Message}");
                return false;
            }
        }
    }
}
