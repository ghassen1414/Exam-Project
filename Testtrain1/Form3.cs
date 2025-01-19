using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Testtrain1
{
    public partial class Form3 : Form
    {
        private decimal currentBalance;
        private string username;
        public Form3(string userbalance,string username)
        {
            InitializeComponent();
            this.username = username;
            if (decimal.TryParse(userbalance, out currentBalance))
            {
                label4.Text= currentBalance.ToString("F2");
            }
            else
            {
                currentBalance = 0;
                label4.Text = "0.00";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal addFunds) && addFunds > 0)
            { 
                currentBalance += addFunds;
            }
            if (decimal.TryParse(textBox2.Text, out decimal deductFunds) && deductFunds > 0)
            {
                if (currentBalance >= deductFunds)
                {
                    currentBalance -= deductFunds;
                }
                else
                {
                    MessageBox.Show("Insufficient funds to deduct the specified amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            label4.Text = currentBalance.ToString("F2");
            UpdateCSV(username, currentBalance);
            textBox1.Clear();
            textBox2.Clear();
            this.Close();
            Form2 form2 = new Form2(username);
            form2.Show();

        }
        private void UpdateCSV(string username, decimal newBalance)
        {
            string[] allUsers = File.ReadAllLines("users.csv"); 
            for (int i = 0; i < allUsers.Length; i++)
            {
                string[] userInfo = allUsers[i].Split(",");
                if (userInfo.Length >= 3 && userInfo[0] == username) 
                {
                    userInfo[2] = newBalance.ToString("F2");
                    allUsers[i] = string.Join(",", userInfo); 
                    break;
                }
            }
            File.WriteAllLines("users.csv", allUsers); 
        }
    }
}
