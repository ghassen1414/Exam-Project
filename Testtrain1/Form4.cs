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
    public partial class Form4 : Form
    {
        private decimal currentSavings;
        private string username;
        private decimal currentBalance;
        public Form4(string usersavings,string username,string userbalance)
        {
            InitializeComponent();
            this.username = username;
            
            if (decimal.TryParse(usersavings, out currentSavings))
            {
                label4.Text = currentSavings.ToString("F2");
            }
            else
            {
                currentSavings = 0;
                label4.Text = "0.00";
            }
            if (decimal.TryParse(userbalance, out currentBalance))
            {
                // Assuming userbalance is passed correctly as a decimal number
            }
            else
            {
                currentBalance = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal addSavings) && addSavings > 0)
            {
                if (currentBalance >= addSavings)
                {
                    currentSavings += addSavings;
                    currentBalance -= addSavings;
                }
                else
                {
                    MessageBox.Show("Insufficient balance to add to savings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            if (decimal.TryParse(textBox2.Text, out decimal deductSavings) && deductSavings > 0)
            {
                if (currentSavings >= deductSavings)
                {
                    currentSavings -= deductSavings;
                    currentBalance += deductSavings;
                }
                else
                {
                    MessageBox.Show("Insufficient funds to deduct the specified amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            label4.Text = currentSavings.ToString("F2");
            UpdateCSV(username, currentSavings,currentBalance);
            textBox1.Clear();
            textBox2.Clear();
            this.Close();
            Form2 form2 = new Form2(username);
            form2.Show();

        }
        private void UpdateCSV(string username,decimal newSavings, decimal newBalance)
        {
            string[] allUsers = File.ReadAllLines("users.csv");
            for (int i = 0; i < allUsers.Length; i++)
            {
                string[] userInfo = allUsers[i].Split(",");
                if (userInfo.Length >= 3 && userInfo[0] == username)
                {
                    userInfo[2] = newBalance.ToString("F2");
                    userInfo[3] = newSavings.ToString("F2");
                    allUsers[i] = string.Join(",", userInfo);
                    break;
                }
            }
            File.WriteAllLines("users.csv", allUsers);
        }
    }
}
