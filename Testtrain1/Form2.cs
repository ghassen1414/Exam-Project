using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testtrain1
{
    public partial class Form2 : Form
    {
        private string username;
        public Form2(string user)
        {
            InitializeComponent();
            username = user;
            LoadUserData();
        }
        private void LoadUserData()
        {
            string path = "users.csv";
            if (File.Exists(path))
            {
                string[] AllUsers = File.ReadAllLines(path);
                foreach (string User in AllUsers)
                {
                    string[] UserInfo = User.Split(',');
                    if (UserInfo.Length >= 6 && UserInfo[0] == username)
                    {
                        label7.Text = UserInfo[2];
                        label8.Text = UserInfo[3];
                        label9.Text = UserInfo[4];
                        label10.Text = UserInfo[5];
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("User data file not found");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(label7.Text, username);
            form3.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(label8.Text, username, label7.Text);
            form4.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(label9.Text, username);
            form5.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(label10.Text, username, label7.Text);
            form6.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
