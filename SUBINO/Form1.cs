using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace SUBINO
{
    public partial class Form1 : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=ETEC;database=subino";

        public Form1()
        {
            InitializeComponent();
        }

        void Button1Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string senha = textBox2.Text;

            if (ValidarLogin(email, senha))
            {
                MessageBox.Show("Login realizado com sucesso!");
                Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
            }
            else
            {
                MessageBox.Show("E-mail ou senha incorretos.");
            }
        }

        
        void Button2Click(object sender, EventArgs e)
        {
            Form11 cadastro = new Form11();
            this.Hide();
            cadastro.Show();
        }

        
        private bool ValidarLogin(string email, string senha)
        {
            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("SELECT senha FROM Usuario WHERE email = @Email", conexao);
                    cmd.Parameters.AddWithValue("@Email", email);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string storedHash = result.ToString();
                        if (VerificarSenha(senha, storedHash))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao validar login: {ex.Message}");
            }
            return false;
        }

        
        private bool VerificarSenha(string senha, string storedHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var senhaBytes = Encoding.UTF8.GetBytes(senha);
                var senhaHash = sha256.ComputeHash(senhaBytes);
                var senhaHashString = BitConverter.ToString(senhaHash).Replace("-", "").ToLower();

                return senhaHashString == storedHash;
            }
        }
    }
}
