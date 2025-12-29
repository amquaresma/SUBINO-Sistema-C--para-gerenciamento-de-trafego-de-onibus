/*
 * Created by SharpDevelop.
 * User: mathq
 * Date: 26/11/2024
 * Time: 20:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SUBINO
{
	/// <summary>
	/// Description of Form10.
	/// </summary>
	public partial class Form10 : Form
	{
		public Form10()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Form10Load(object sender, EventArgs e)
		{
			
			label3.Text = Form3.mask8;
			label2.Text = Form3.TextoDoTextBox4;
			label4.Text = Form3.TextoDoTextBox6;
		}
		void Button1Click(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
                this.Hide();
                 form2.Show();
		}
	}
}
