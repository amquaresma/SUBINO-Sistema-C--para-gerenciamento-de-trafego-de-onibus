/*
 * Created by SharpDevelop.
 * User: mathq
 * Date: 25/11/2024
 * Time: 20:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SUBINO
{
	/// <summary>
	/// Description of Form3.
	/// </summary>
	public partial class Form3 : Form
	{
		public static string TextoDoTextBox = "";
		public static string TextoDoTextBox1 = "";
		public static string TextoDoTextBox2 = "";
		public static string TextoDoTextBox3 = "";
		public static string TextoDoTextBox4 = "";
		public static string TextoDoTextBox5 = "";
		public static string TextoDoTextBox6 = "";
		public static string TextoDoTextBox7 = "";
		public static string mask8 = "";
		
		public Form3()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
		}
		void Button2Click(object sender, EventArgs e)
		{
			TextoDoTextBox = maskedTextBox1.Text;
			TextoDoTextBox1 = maskedTextBox10.Text;
			TextoDoTextBox2 = maskedTextBox2.Text;
			TextoDoTextBox3 = maskedTextBox9.Text;
			TextoDoTextBox4 = maskedTextBox15.Text;
			TextoDoTextBox5 = maskedTextBox13.Text;
			TextoDoTextBox6 = label22.Text;
			mask8 = maskedTextBox8.Text;
			 	Form5 form5 = new Form5();
                this.Hide();
                form5.Show();
		}
		void Button3Click(object sender, EventArgs e)
		{
			try
    {
        // Obtém o valor do TextBox e converte para número
        double km = double.Parse(maskedTextBox5.Text);
        // Calcula o valor total
        double valorTotal = km * 12 + 300;
        // Exibe o resultado na Label
        label22.Text = "Valor Total: R$" + valorTotal;
    }
    catch (FormatException)
    {
        // Exibe mensagem de erro em caso de entrada inválida
        label22.Text = "Por favor, insira um número válido.";
    }
		}
	}
}
