using System.Text;
using System.Security.Cryptography;

namespace Testtrain1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string path = "users.csv";
            string hashedPassword = HashPassword(password);
            if (File.Exists(path))
            {
                string[] AllUsers = File.ReadAllLines(path);
                foreach (string user in AllUsers)
                {
                    string[] UserInfo = user.Split(",");
                    if (UserInfo[0] == username)
                    {
                        MessageBox.Show("Username already exists");
                        return;
                    }
                }
                string NewUserEntry = $"{username},{hashedPassword},0,0,0,0";
                File.AppendAllText(path, NewUserEntry + Environment.NewLine);
                MessageBox.Show("User registerd successfully!");
            }
            else
            {
                string NewUserEntry = $"{username},{hashedPassword},0,0,0,0";
                File.WriteAllText(path, NewUserEntry + Environment.NewLine);
                MessageBox.Show("User registerd successfully!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string path = "users.csv";
            string hashedPassword = HashPassword(password);
            if (File.Exists(path))
            {
                bool isUserFound = false;
                string[] AllUsers = File.ReadAllLines(path);
                foreach (string user in AllUsers)
                {
                    string[] UserInfo = user.Split(",");
                    if (UserInfo.Length >= 2 && UserInfo[0] == username && UserInfo[1] == hashedPassword)
                    {
                        isUserFound = true;
                        Form2 form2 = new Form2(username);
                        form2.Show();
                        this.Hide();
                        //Application.Exit();
                        break;
                    }
                }
                if (!isUserFound)
                {
                    MessageBox.Show("Username and password do not match.");
                }
            }
            else
            {
                MessageBox.Show("User data file not found.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)); //to byte

                
                StringBuilder builder = new StringBuilder(); //to hexadecimal array
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

}
