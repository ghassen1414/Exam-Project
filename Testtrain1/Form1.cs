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
                 string NewUserEntry = $"{username},{password},0,0,0,0";
                File.AppendAllText(path, NewUserEntry + Environment.NewLine);
                MessageBox.Show("User registerd successfully!");
            }
            else
            {
                string NewUserEntry = $"{username},{password},0,0,0,0";
                File.WriteAllText(path, NewUserEntry + Environment.NewLine);
                MessageBox.Show("User registerd successfully!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string path = "users.csv";
            if (File.Exists(path))
            {
                bool isUserFound = false;
                string[] AllUsers = File.ReadAllLines(path);
                foreach (string user in AllUsers)
                {
                    string[] UserInfo = user.Split(",");
                    if (UserInfo.Length >= 2 && UserInfo[0] == username && UserInfo[1] == password)
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
    }

}
