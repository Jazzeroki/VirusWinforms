namespace Viruses
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Infect = new System.Windows.Forms.Button();
            this.panelAntiviral = new System.Windows.Forms.Panel();
            this.AntiViral3 = new System.Windows.Forms.Button();
            this.AntiViral2 = new System.Windows.Forms.Button();
            this.AntiViral1 = new System.Windows.Forms.Button();
            this.panelViruses = new System.Windows.Forms.Panel();
            this.tryAgain = new System.Windows.Forms.Button();
            this.ComputerCrashed = new System.Windows.Forms.Label();
            this.Virus12 = new System.Windows.Forms.Button();
            this.Virus11 = new System.Windows.Forms.Button();
            this.Virus10 = new System.Windows.Forms.Button();
            this.Virus9 = new System.Windows.Forms.Button();
            this.Virus8 = new System.Windows.Forms.Button();
            this.Virus7 = new System.Windows.Forms.Button();
            this.Virus6 = new System.Windows.Forms.Button();
            this.Virus5 = new System.Windows.Forms.Button();
            this.Virus4 = new System.Windows.Forms.Button();
            this.Virus3 = new System.Windows.Forms.Button();
            this.Virus2 = new System.Windows.Forms.Button();
            this.Virus1 = new System.Windows.Forms.Button();
            this.panelFood = new System.Windows.Forms.Panel();
            this.Food4 = new System.Windows.Forms.Button();
            this.Food3 = new System.Windows.Forms.Button();
            this.Food2 = new System.Windows.Forms.Button();
            this.Food1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelAntiviral.SuspendLayout();
            this.panelViruses.SuspendLayout();
            this.panelFood.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alert!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(532, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Your Computer has been infected.  Take care of the virus and your computer shall " +
    "continue to run for... for now.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Feed it to keep it happy, Touch it and make it mad.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Antivirals might save your computer.";
            // 
            // Infect
            // 
            this.Infect.Location = new System.Drawing.Point(388, 327);
            this.Infect.Name = "Infect";
            this.Infect.Size = new System.Drawing.Size(75, 23);
            this.Infect.TabIndex = 4;
            this.Infect.Text = "Infect";
            this.Infect.UseVisualStyleBackColor = true;
            this.Infect.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelAntiviral
            // 
            this.panelAntiviral.Controls.Add(this.AntiViral3);
            this.panelAntiviral.Controls.Add(this.AntiViral2);
            this.panelAntiviral.Controls.Add(this.AntiViral1);
            this.panelAntiviral.Location = new System.Drawing.Point(821, 12);
            this.panelAntiviral.Name = "panelAntiviral";
            this.panelAntiviral.Size = new System.Drawing.Size(85, 341);
            this.panelAntiviral.TabIndex = 5;
            // 
            // AntiViral3
            // 
            this.AntiViral3.Location = new System.Drawing.Point(3, 67);
            this.AntiViral3.Name = "AntiViral3";
            this.AntiViral3.Size = new System.Drawing.Size(75, 23);
            this.AntiViral3.TabIndex = 3;
            this.AntiViral3.Text = "Patch";
            this.AntiViral3.UseVisualStyleBackColor = true;
            this.AntiViral3.Click += new System.EventHandler(this.AntiViral3_Click);
            // 
            // AntiViral2
            // 
            this.AntiViral2.Location = new System.Drawing.Point(3, 38);
            this.AntiViral2.Name = "AntiViral2";
            this.AntiViral2.Size = new System.Drawing.Size(75, 23);
            this.AntiViral2.TabIndex = 2;
            this.AntiViral2.Text = "AntiMalware";
            this.AntiViral2.UseVisualStyleBackColor = true;
            this.AntiViral2.Click += new System.EventHandler(this.AntiViral2_Click);
            // 
            // AntiViral1
            // 
            this.AntiViral1.Location = new System.Drawing.Point(3, 11);
            this.AntiViral1.Name = "AntiViral1";
            this.AntiViral1.Size = new System.Drawing.Size(75, 23);
            this.AntiViral1.TabIndex = 1;
            this.AntiViral1.Text = "AntiVirus";
            this.AntiViral1.UseVisualStyleBackColor = true;
            this.AntiViral1.Click += new System.EventHandler(this.AntiViral1_Click);
            // 
            // panelViruses
            // 
            this.panelViruses.Controls.Add(this.tryAgain);
            this.panelViruses.Controls.Add(this.ComputerCrashed);
            this.panelViruses.Controls.Add(this.Virus12);
            this.panelViruses.Controls.Add(this.Virus11);
            this.panelViruses.Controls.Add(this.Virus10);
            this.panelViruses.Controls.Add(this.Virus9);
            this.panelViruses.Controls.Add(this.Virus8);
            this.panelViruses.Controls.Add(this.Virus7);
            this.panelViruses.Controls.Add(this.Virus6);
            this.panelViruses.Controls.Add(this.Virus5);
            this.panelViruses.Controls.Add(this.Virus4);
            this.panelViruses.Controls.Add(this.Virus3);
            this.panelViruses.Controls.Add(this.Virus2);
            this.panelViruses.Controls.Add(this.Virus1);
            this.panelViruses.Location = new System.Drawing.Point(99, 12);
            this.panelViruses.Name = "panelViruses";
            this.panelViruses.Size = new System.Drawing.Size(716, 341);
            this.panelViruses.TabIndex = 6;
            // 
            // tryAgain
            // 
            this.tryAgain.Location = new System.Drawing.Point(307, 264);
            this.tryAgain.Name = "tryAgain";
            this.tryAgain.Size = new System.Drawing.Size(75, 23);
            this.tryAgain.TabIndex = 13;
            this.tryAgain.Text = "Try Again";
            this.tryAgain.UseVisualStyleBackColor = true;
            this.tryAgain.Click += new System.EventHandler(this.tryAgain_Click);
            // 
            // ComputerCrashed
            // 
            this.ComputerCrashed.AutoSize = true;
            this.ComputerCrashed.Location = new System.Drawing.Point(224, 85);
            this.ComputerCrashed.Name = "ComputerCrashed";
            this.ComputerCrashed.Size = new System.Drawing.Size(200, 13);
            this.ComputerCrashed.TabIndex = 12;
            this.ComputerCrashed.Text = "Your Computer has CRASHED!!!!!!!!!!!!!!!!";
            // 
            // Virus12
            // 
            this.Virus12.Location = new System.Drawing.Point(217, 130);
            this.Virus12.Name = "Virus12";
            this.Virus12.Size = new System.Drawing.Size(75, 23);
            this.Virus12.TabIndex = 11;
            this.Virus12.Text = "button12";
            this.Virus12.UseVisualStyleBackColor = true;
            this.Virus12.Click += new System.EventHandler(this.Virus12_Click);
            // 
            // Virus11
            // 
            this.Virus11.Location = new System.Drawing.Point(115, 130);
            this.Virus11.Name = "Virus11";
            this.Virus11.Size = new System.Drawing.Size(75, 23);
            this.Virus11.TabIndex = 10;
            this.Virus11.Text = "button11";
            this.Virus11.UseVisualStyleBackColor = true;
            this.Virus11.Click += new System.EventHandler(this.Virus11_Click);
            // 
            // Virus10
            // 
            this.Virus10.Location = new System.Drawing.Point(12, 130);
            this.Virus10.Name = "Virus10";
            this.Virus10.Size = new System.Drawing.Size(75, 23);
            this.Virus10.TabIndex = 9;
            this.Virus10.Text = "button10";
            this.Virus10.UseVisualStyleBackColor = true;
            this.Virus10.Click += new System.EventHandler(this.Virus10_Click);
            // 
            // Virus9
            // 
            this.Virus9.Location = new System.Drawing.Point(217, 88);
            this.Virus9.Name = "Virus9";
            this.Virus9.Size = new System.Drawing.Size(75, 23);
            this.Virus9.TabIndex = 8;
            this.Virus9.Text = "button9";
            this.Virus9.UseVisualStyleBackColor = true;
            this.Virus9.Click += new System.EventHandler(this.Virus9_Click);
            // 
            // Virus8
            // 
            this.Virus8.Location = new System.Drawing.Point(115, 93);
            this.Virus8.Name = "Virus8";
            this.Virus8.Size = new System.Drawing.Size(75, 23);
            this.Virus8.TabIndex = 7;
            this.Virus8.Text = "button8";
            this.Virus8.UseVisualStyleBackColor = true;
            this.Virus8.Click += new System.EventHandler(this.Virus8_Click);
            // 
            // Virus7
            // 
            this.Virus7.Location = new System.Drawing.Point(12, 93);
            this.Virus7.Name = "Virus7";
            this.Virus7.Size = new System.Drawing.Size(75, 23);
            this.Virus7.TabIndex = 6;
            this.Virus7.Text = "button7";
            this.Virus7.UseVisualStyleBackColor = true;
            this.Virus7.Click += new System.EventHandler(this.Virus7_Click);
            // 
            // Virus6
            // 
            this.Virus6.Location = new System.Drawing.Point(217, 53);
            this.Virus6.Name = "Virus6";
            this.Virus6.Size = new System.Drawing.Size(75, 23);
            this.Virus6.TabIndex = 5;
            this.Virus6.Text = "button6";
            this.Virus6.UseVisualStyleBackColor = true;
            this.Virus6.Click += new System.EventHandler(this.Virus6_Click);
            // 
            // Virus5
            // 
            this.Virus5.Location = new System.Drawing.Point(115, 53);
            this.Virus5.Name = "Virus5";
            this.Virus5.Size = new System.Drawing.Size(75, 23);
            this.Virus5.TabIndex = 4;
            this.Virus5.Text = "button5";
            this.Virus5.UseVisualStyleBackColor = true;
            this.Virus5.Click += new System.EventHandler(this.Virus5_Click);
            // 
            // Virus4
            // 
            this.Virus4.Location = new System.Drawing.Point(12, 53);
            this.Virus4.Name = "Virus4";
            this.Virus4.Size = new System.Drawing.Size(75, 23);
            this.Virus4.TabIndex = 3;
            this.Virus4.Text = "button4";
            this.Virus4.UseVisualStyleBackColor = true;
            this.Virus4.Click += new System.EventHandler(this.Virus4_Click);
            // 
            // Virus3
            // 
            this.Virus3.Location = new System.Drawing.Point(217, 11);
            this.Virus3.Name = "Virus3";
            this.Virus3.Size = new System.Drawing.Size(75, 23);
            this.Virus3.TabIndex = 2;
            this.Virus3.Text = "button3";
            this.Virus3.UseVisualStyleBackColor = true;
            this.Virus3.Click += new System.EventHandler(this.Virus3_Click);
            // 
            // Virus2
            // 
            this.Virus2.Location = new System.Drawing.Point(115, 11);
            this.Virus2.Name = "Virus2";
            this.Virus2.Size = new System.Drawing.Size(75, 23);
            this.Virus2.TabIndex = 1;
            this.Virus2.Text = "button2";
            this.Virus2.UseVisualStyleBackColor = true;
            this.Virus2.Click += new System.EventHandler(this.Virus2_Click);
            // 
            // Virus1
            // 
            this.Virus1.Location = new System.Drawing.Point(12, 11);
            this.Virus1.Name = "Virus1";
            this.Virus1.Size = new System.Drawing.Size(75, 23);
            this.Virus1.TabIndex = 0;
            this.Virus1.Text = "button1";
            this.Virus1.UseVisualStyleBackColor = true;
            this.Virus1.Click += new System.EventHandler(this.Virus1_Click);
            // 
            // panelFood
            // 
            this.panelFood.Controls.Add(this.Food4);
            this.panelFood.Controls.Add(this.Food3);
            this.panelFood.Controls.Add(this.Food2);
            this.panelFood.Controls.Add(this.Food1);
            this.panelFood.Location = new System.Drawing.Point(12, 9);
            this.panelFood.Name = "panelFood";
            this.panelFood.Size = new System.Drawing.Size(81, 341);
            this.panelFood.TabIndex = 7;
            // 
            // Food4
            // 
            this.Food4.Location = new System.Drawing.Point(3, 96);
            this.Food4.Name = "Food4";
            this.Food4.Size = new System.Drawing.Size(75, 23);
            this.Food4.TabIndex = 3;
            this.Food4.Text = "Credit Card";
            this.Food4.UseVisualStyleBackColor = true;
            this.Food4.Click += new System.EventHandler(this.Food4_Click);
            // 
            // Food3
            // 
            this.Food3.Location = new System.Drawing.Point(3, 70);
            this.Food3.Name = "Food3";
            this.Food3.Size = new System.Drawing.Size(75, 23);
            this.Food3.TabIndex = 2;
            this.Food3.Text = "Files";
            this.Food3.UseVisualStyleBackColor = true;
            this.Food3.Click += new System.EventHandler(this.Food3_Click);
            // 
            // Food2
            // 
            this.Food2.Location = new System.Drawing.Point(3, 41);
            this.Food2.Name = "Food2";
            this.Food2.Size = new System.Drawing.Size(75, 23);
            this.Food2.TabIndex = 1;
            this.Food2.Text = "RAM";
            this.Food2.UseVisualStyleBackColor = true;
            this.Food2.Click += new System.EventHandler(this.Food2_Click);
            // 
            // Food1
            // 
            this.Food1.Location = new System.Drawing.Point(3, 12);
            this.Food1.Name = "Food1";
            this.Food1.Size = new System.Drawing.Size(75, 23);
            this.Food1.TabIndex = 0;
            this.Food1.Text = "CPU";
            this.Food1.UseVisualStyleBackColor = true;
            this.Food1.Click += new System.EventHandler(this.Food1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 365);
            this.Controls.Add(this.panelFood);
            this.Controls.Add(this.panelViruses);
            this.Controls.Add(this.panelAntiviral);
            this.Controls.Add(this.Infect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Viruses";
            this.panelAntiviral.ResumeLayout(false);
            this.panelViruses.ResumeLayout(false);
            this.panelViruses.PerformLayout();
            this.panelFood.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Infect;
        private System.Windows.Forms.Panel panelAntiviral;
        private System.Windows.Forms.Button AntiViral3;
        private System.Windows.Forms.Button AntiViral2;
        private System.Windows.Forms.Button AntiViral1;
        private System.Windows.Forms.Panel panelViruses;
        private System.Windows.Forms.Panel panelFood;
        private System.Windows.Forms.Button Food4;
        private System.Windows.Forms.Button Food3;
        private System.Windows.Forms.Button Food2;
        private System.Windows.Forms.Button Food1;
        private System.Windows.Forms.Button Virus12;
        private System.Windows.Forms.Button Virus11;
        private System.Windows.Forms.Button Virus10;
        private System.Windows.Forms.Button Virus9;
        private System.Windows.Forms.Button Virus8;
        private System.Windows.Forms.Button Virus7;
        private System.Windows.Forms.Button Virus6;
        private System.Windows.Forms.Button Virus5;
        private System.Windows.Forms.Button Virus4;
        private System.Windows.Forms.Button Virus3;
        private System.Windows.Forms.Button Virus2;
        private System.Windows.Forms.Button Virus1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button tryAgain;
        private System.Windows.Forms.Label ComputerCrashed;
    }
}

