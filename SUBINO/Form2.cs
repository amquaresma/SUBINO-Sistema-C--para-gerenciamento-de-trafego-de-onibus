/*
 * Created by SharpDevelop.
 * User: mathq
 * Date: 25/11/2024
 * Time: 09:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SUBINO
{
	/// <summary>
	/// Description of Form2.
	/// </summary>
	public partial class Form2 : Form
	{
		public Form2()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Label2Click(object sender, EventArgs e)
		{
			 label2.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
		}
		void Button1Click(object sender, EventArgs e)
		{
				Form3 form3 = new Form3();
                this.Hide();
                form3.Show();
		}
		void Button3Click(object sender, EventArgs e)
		{
			Form4 form4 = new Form4();
                this.Hide();
                form4.Show();
		}
		void Button4Click(object sender, EventArgs e)
		{
			Form9 form9 = new Form9();
                this.Hide();
                form9.Show();
		}
		void Button2Click(object sender, EventArgs e)
		{
			Form10 form10 = new Form10();
                this.Hide();
                form10.Show();
		}
		void PictureBox2Click(object sender, EventArgs e)
		{
			Form10 form10 = new Form10();
                this.Hide();
                form10.Show();
		}
	}
}
