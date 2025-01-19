namespace Testtrain1
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            listBox1 = new ListBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(129, 294);
            button1.Name = "button1";
            button1.Size = new Size(184, 38);
            button1.TabIndex = 18;
            button1.Text = "Update Expenses";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(268, 235);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 17;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(268, 195);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(40, 233);
            label3.Name = "label3";
            label3.Size = new Size(186, 21);
            label3.TabIndex = 15;
            label3.Text = "Withdraw from expenses:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(40, 193);
            label2.Name = "label2";
            label2.Size = new Size(126, 21);
            label2.TabIndex = 14;
            label2.Text = "Add to expenses:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(49, 98);
            label1.Name = "label1";
            label1.Size = new Size(233, 21);
            label1.TabIndex = 13;
            label1.Text = "Current Fixed Expenses Amount:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(311, 98);
            label4.Name = "label4";
            label4.Size = new Size(57, 21);
            label4.TabIndex = 19;
            label4.Text = "label4";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(527, 171);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(237, 169);
            listBox1.TabIndex = 20;
            // 
            // button2
            // 
            button2.Location = new Point(527, 346);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 21;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(608, 346);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 22;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(689, 346);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 23;
            button4.Text = "Remove";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(527, 138);
            label5.Name = "label5";
            label5.Size = new Size(225, 15);
            label5.TabIndex = 24;
            label5.Text = "Please remove first item and start adding ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(527, 153);
            label6.Name = "label6";
            label6.Size = new Size(150, 15);
            label6.TabIndex = 25;
            label6.Text = "your expenses accordingly.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(472, 78);
            label7.Name = "label7";
            label7.Size = new Size(358, 25);
            label7.TabIndex = 26;
            label7.Text = "This box help you manage your expenses";
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 498);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form5";
            Text = "Form5";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private ListBox listBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}