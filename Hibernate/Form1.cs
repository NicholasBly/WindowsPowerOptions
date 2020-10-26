using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices; 

namespace Hibernate
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        [DllImport("user32")]
        public static extern void LockWorkStation();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(null) == true || textBox1.Text.Equals("") == true)
            {
                textBox1.Text = "Enter Amount of Seconds";
                textBox1.ForeColor = Color.Gray;
            }
            if (textBox2.Text.Equals(null) == true || textBox2.Text.Equals("") == true)
            {
                textBox2.Text = "Enter Amount of Seconds";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "") return;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (char.IsNumber(textBox1.Text[i]))
                {
                    Process.Start("shutdown", "/s /t " + textBox1.Text);
                }
                else
                {
                    MessageBox.Show("The textbox includes '" + textBox1.Text[i] + "' which is an illegal character. Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.SetSuspendState(PowerState.Hibernate, true, true);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Amount of Seconds")
            {
                textBox1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetSuspendState(false, true, true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "") return;
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                if (char.IsNumber(textBox2.Text[i]))
                {
                    Process.Start("shutdown", "/r /t " + textBox2.Text);
                }
                else
                {
                    MessageBox.Show("The textbox includes '" + textBox2.Text[i] + "' which is an illegal character. Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Amount of Seconds")
            {
                textBox2.Text = "";
            }
        }
    }
}
