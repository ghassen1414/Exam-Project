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
    public partial class Form5 : Form
    {
        private decimal currentExpenses;
        private string username;
        private List<Expense> expensesList = new List<Expense>();

        public Form5(string userexpenses, string username)
        {
            InitializeComponent();
            this.username = username;

            if (decimal.TryParse(userexpenses, out currentExpenses))
            {
                label4.Text = currentExpenses.ToString("F2");
            }
            else
            {
                currentExpenses = 0;
                label4.Text = "0.00";
            }
            expensesList = new List<Expense>
            {
                new Expense("First item expamle", 10.50m, DateTime.Now.AddDays(-2)),
            };
            PopulateListBox();


        }
        private void PopulateListBox()
        {
            listBox1.Items.Clear(); // Clear any existing items
            foreach (var expense in expensesList)
            {
                listBox1.Items.Add(expense); // Add each expense to the list
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal addExpenses) && addExpenses > 0)
            {
                currentExpenses += addExpenses;
            }
            if (decimal.TryParse(textBox2.Text, out decimal deductExpenses) && deductExpenses > 0)
            {
                if (currentExpenses >= deductExpenses)
                {
                    currentExpenses -= deductExpenses;
                }
                else
                {
                    MessageBox.Show("Detucted Amount is bigger than total of Expenses value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            label4.Text = currentExpenses.ToString("F2");
            UpdateCSV(username, currentExpenses);
            textBox1.Clear();
            textBox2.Clear();
            this.Close();
            Form2 form2 = new Form2(username);
            form2.Show();


        }
        private void UpdateCSV(string username, decimal newExpenses)
        {
            string[] allUsers = File.ReadAllLines("users.csv");
            for (int i = 0; i < allUsers.Length; i++)
            {
                string[] userInfo = allUsers[i].Split(",");
                if (userInfo.Length >= 3 && userInfo[0] == username)
                {
                    userInfo[4] = newExpenses.ToString("F2");
                    allUsers[i] = string.Join(",", userInfo);
                    break;
                }
            }
            File.WriteAllLines("users.csv", allUsers);
        }

        public class Expense
        {
            public string Name;  // Name or category of the expense
            public decimal Amount; // Amount of the expense
            public DateTime Date;  // Date of the expense

            public Expense(string name, decimal amount, DateTime date)
            {
                this.Name = name;
                this.Amount = amount;
                this.Date = date;
            }

            public override string ToString()
            {
                return $"{Name}: ${Amount:F2} on {Date:yyyy-MM-dd}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string expenseName = Prompt.ShowDialog("Enter Expense Name:", "Add Expense");
            string expenseAmountText = Prompt.ShowDialog("Enter Expense Amount:", "Add Expense");
            string expenseDateText = Prompt.ShowDialog("Enter Expense Date (yyyy-MM-dd):", "Add Expense");

            if (decimal.TryParse(expenseAmountText, out decimal expenseAmount) &&
                DateTime.TryParse(expenseDateText, out DateTime expenseDate))
            {
                var newExpense = new Expense(expenseName, expenseAmount, expenseDate);
                expensesList.Add(newExpense);
                PopulateListBox();
            }
            else
            {
                MessageBox.Show("Invalid input. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                var selectedExpense = expensesList[listBox1.SelectedIndex];

                string newExpenseName = Prompt.ShowDialog("Edit Expense Name:", "Edit Expense", selectedExpense.Name);
                string newExpenseAmountText = Prompt.ShowDialog("Edit Expense Amount:", "Edit Expense", selectedExpense.Amount.ToString());
                string newExpenseDateText = Prompt.ShowDialog("Edit Expense Date (yyyy-MM-dd):", "Edit Expense", selectedExpense.Date.ToString("yyyy-MM-dd"));

                if (decimal.TryParse(newExpenseAmountText, out decimal newExpenseAmount) &&
                    DateTime.TryParse(newExpenseDateText, out DateTime newExpenseDate))
                {
                    selectedExpense.Name = newExpenseName;
                    selectedExpense.Amount = newExpenseAmount;
                    selectedExpense.Date = newExpenseDate;
                    PopulateListBox();
                }
                else
                {
                    MessageBox.Show("Invalid input. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an expense to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                expensesList.RemoveAt(listBox1.SelectedIndex);
                PopulateListBox();
            }
            else
            {
                MessageBox.Show("Please select an expense to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption, string defaultValue = "")
            {
                Form prompt = new Form
                {
                    Width = 500,
                    Height = 200,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label { Left = 50, Top = 20, Text = text, Width = 400 };
                TextBox inputBox = new TextBox { Left = 50, Top = 50, Width = 400, Text = defaultValue };
                Button confirmation = new Button { Text = "Ok", Left = 350, Width = 100, Top = 100, DialogResult = DialogResult.OK };
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
            }
        }
    }
}
