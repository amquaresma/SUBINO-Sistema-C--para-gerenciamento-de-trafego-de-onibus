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
	/// Description of Form4.
	/// </summary>
	public partial class Form4 : Form
	{
		public Form4()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button4Click(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
		}
		void Button1Click(object sender, EventArgs e)
		{
			Form6 form6 = new Form6();
                this.Hide();
                form6.Show();
		}
		void Button2Click(object sender, EventArgs e)
		{
				Form7 form7 = new Form7();
                this.Hide();
                form7.Show();
		}
		void Button3Click(object sender, EventArgs e)
		{
				Form8 form8 = new Form8();
                this.Hide();
                form8.Show();
		}
	}
}
