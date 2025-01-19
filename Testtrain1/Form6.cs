using System;
using System.Net.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Testtrain1
{
    public partial class Form6 : Form
    {
        private decimal currentInvestment;
        private string username;
        private decimal currentBalance;
        public Form6(string userinvestment, string username, string userbalance)
        {
            InitializeComponent();
            this.username = username;
            if (decimal.TryParse(userinvestment, out currentInvestment))
            {
                label8.Text = currentInvestment.ToString("F2");
            }
            else
            {
                currentInvestment = 0;
                label8.Text = "0.00";
            }
            if (decimal.TryParse(userbalance, out currentBalance))
            {
                // Assuming userbalance is passed correctly as a decimal number
            }
            else
            {
                currentBalance = 0;
            }
            FetchCryptoPrices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal addInvestment) && addInvestment > 0)
            {
                if (currentBalance >= addInvestment)
                {
                    currentInvestment += addInvestment;
                    currentBalance -= addInvestment;
                }
                else
                {
                    MessageBox.Show("Insufficient balance to add to Investments.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (decimal.TryParse(textBox2.Text, out decimal deductSavings) && deductSavings > 0)
            {
                if (currentInvestment >= deductSavings)
                {
                    currentInvestment -= deductSavings;
                    currentBalance += deductSavings;
                }
                else
                {
                    MessageBox.Show("Insufficient funds to deduct the specified amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            label8.Text = currentInvestment.ToString("F2");
            UpdateCSV(username, currentInvestment, currentBalance);
            textBox1.Clear();
            textBox2.Clear();
            this.Close();
            Form2 form2 = new Form2(username);
            form2.Show();
        }
        private void UpdateCSV(string username, decimal newInvestment, decimal newBalance)
        {
            string[] allUsers = File.ReadAllLines("users.csv");
            for (int i = 0; i < allUsers.Length; i++)
            {
                string[] userInfo = allUsers[i].Split(",");
                if (userInfo.Length >= 3 && userInfo[0] == username)
                {
                    userInfo[2] = newBalance.ToString("F2");
                    userInfo[5] = newInvestment.ToString("F2");
                    allUsers[i] = string.Join(",", userInfo);
                    break;
                }
            }
            File.WriteAllLines("users.csv", allUsers);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private async Task<string> GetCryptoPrice(string cryptoName)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://api.coingecko.com/api/v3/simple/price?ids={cryptoName}&vs_currencies=usd";
                string response = await client.GetStringAsync(url); // Fetc data from the API
                JObject json = JObject.Parse(response); // JSON response
                return json[cryptoName]["usd"].ToString(); // get USD price
            }
        }
        private async void FetchCryptoPrices()
        {
            try
            {
                string btcPrice = await GetCryptoPrice("bitcoin");   
                string ethPrice = await GetCryptoPrice("ethereum"); 
                string solPrice = await GetCryptoPrice("solana");   
                string adaPrice = await GetCryptoPrice("cardano");  

                label9.Text = $"${btcPrice}";  
                label11.Text = $"${ethPrice}"; 
                label10.Text = $"${solPrice}"; 
                label12.Text = $"${adaPrice}"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching cryptocurrency prices: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
