/*
 * Created by SharpDevelop.
 * User: mathq
 * Date: 25/11/2024
 * Time: 20:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SUBINO
{
	/// <summary>
	/// Description of Form5.
	/// </summary>
	public partial class Form5 : Form
	{
		public Form5()
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
			Form3 form3 = new Form3();
                this.Hide();
                form3.Show();
		}
		void Button2Click(object sender, EventArgs e)
		{
			 MessageBox.Show("Viagem agendada com Sucesso!");
			 Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
		}
		void Form5Load(object sender, EventArgs e)
		{
			label2.Text = Form3.TextoDoTextBox;
			label3.Text = Form3.TextoDoTextBox1;
			label4.Text = Form3.TextoDoTextBox4;
			label5.Text = Form3.TextoDoTextBox3;
			label6.Text = Form3.TextoDoTextBox2;
			label7.Text = Form3.TextoDoTextBox5;
			label8.Text = Form3.TextoDoTextBox6;
			
		}
	}
}
