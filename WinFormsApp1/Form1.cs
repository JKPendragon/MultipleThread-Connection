using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UserClient
{
    partial class getData
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button1 = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            richTextBox2 = new RichTextBox();
            richTextBox1 = new RichTextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label5 = new Label();
            button3 = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            button4 = new Button();
            label11 = new Label();
            button5 = new Button();
            richTextBox3 = new RichTextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(richTextBox2);
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(336, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(630, 610);
            panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 221);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(624, 386);
            dataGridView1.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(429, 25);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 9;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(341, 25);
            button1.Name = "button1";
            button1.Size = new Size(82, 34);
            button1.TabIndex = 8;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 99);
            label4.Name = "label4";
            label4.Size = new Size(42, 25);
            label4.TabIndex = 7;
            label4.Text = "GET";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 65);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 6;
            label3.Text = "POST";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 28);
            label2.Name = "label2";
            label2.Size = new Size(41, 25);
            label2.TabIndex = 5;
            label2.Text = "LOT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, -3);
            label1.Name = "label1";
            label1.Size = new Size(117, 25);
            label1.TabIndex = 4;
            label1.Text = "MES Connect";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(429, 62);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(183, 153);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(93, 99);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(330, 116);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(93, 62);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(330, 31);
            textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(93, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(242, 31);
            textBox1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 12);
            label5.Name = "label5";
            label5.Size = new Size(129, 25);
            label5.TabIndex = 1;
            label5.Text = "Plc Connection";
            // 
            // button3
            // 
            button3.Location = new Point(12, 40);
            button3.Name = "button3";
            button3.Size = new Size(318, 34);
            button3.TabIndex = 11;
            button3.Text = "Setup Connect";
            button3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 80);
            label6.Name = "label6";
            label6.Size = new Size(87, 25);
            label6.TabIndex = 12;
            label6.Text = "Mes Data";
            // 
            // label7
            // 
            label7.BackColor = SystemColors.ActiveBorder;
            label7.Location = new Point(13, 105);
            label7.Name = "label7";
            label7.Size = new Size(317, 5);
            label7.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 140);
            label8.Name = "label8";
            label8.Size = new Size(110, 25);
            label8.TabIndex = 14;
            label8.Text = "Temperature";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 189);
            label9.Name = "label9";
            label9.Size = new Size(78, 25);
            label9.TabIndex = 15;
            label9.Text = "Pressure";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 239);
            label10.Name = "label10";
            label10.Size = new Size(144, 25);
            label10.TabIndex = 16;
            label10.Text = "Pressure Time (s)";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(170, 138);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(154, 31);
            numericUpDown1.TabIndex = 17;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(170, 187);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(154, 31);
            numericUpDown2.TabIndex = 18;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(170, 239);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(154, 31);
            numericUpDown3.TabIndex = 19;
            // 
            // button4
            // 
            button4.Location = new Point(13, 288);
            button4.Name = "button4";
            button4.Size = new Size(311, 34);
            button4.TabIndex = 20;
            button4.Text = "Mannual Setup";
            button4.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 338);
            label11.Name = "label11";
            label11.Size = new Size(78, 25);
            label11.TabIndex = 21;
            label11.Text = "Logging";
            // 
            // button5
            // 
            button5.Location = new Point(218, 598);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 22;
            button5.Text = "Read data";
            button5.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(19, 366);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(305, 226);
            richTextBox3.TabIndex = 23;
            richTextBox3.Text = "";
            // 
            // getData
            // 

            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
        private Label label4;
        private Label label3;
        private Label label2;
        private DataGridView dataGridView1;
        private Button button2;
        private Label label5;
        private Button button3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private Button button4;
        private Label label11;
        private Button button5;
        private RichTextBox richTextBox3;
    }
}

