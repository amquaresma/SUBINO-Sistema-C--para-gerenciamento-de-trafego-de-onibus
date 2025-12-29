using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace SUBINO
{
    public partial class Form11 : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=ETEC;database=subino";

        public Form11()
        {
            InitializeComponent();
        }

       
        void Button4Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        
        void Button1Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string senha = textBox2.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            if (EmailJaCadastrado(email))
            {
                MessageBox.Show("Este e-mail já está cadastrado.");
                return;
            }

            if (CadastrarUsuario(email, senha))
            {
                MessageBox.Show("Conta criada com sucesso! Faça o LOGIN.");
                Form1 form1 = new Form1();
                this.Hide();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Erro ao criar conta. Tente novamente.");
            }
        }

        
        private bool EmailJaCadastrado(string email)
        {
            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("SELECT COUNT(*) FROM Usuario WHERE email = @Email", conexao);
                    cmd.Parameters.AddWithValue("@Email", email);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar email: {ex.Message}");
                return false;
            }
        }

        
        private bool CadastrarUsuario(string email, string senha)
        {
            try
            {
                string senhaHash = GerarHashSenha(senha);

                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("INSERT INTO Usuario (email, senha) VALUES (@Email, @Senha)", conexao);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senhaHash); 
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return false;
            }
        }

      
        private string GerarHashSenha(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                var senhaBytes = Encoding.UTF8.GetBytes(senha);
                var senhaHash = sha256.ComputeHash(senhaBytes);
                return BitConverter.ToString(senhaHash).Replace("-", "").ToLower();
            }
        }
    }
}
