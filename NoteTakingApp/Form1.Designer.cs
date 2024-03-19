namespace NoteTakingApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            newnote = new RichTextBox();
            n = new Label();
            label3 = new Label();
            label4 = new Label();
            open = new Button();
            save = new Button();
            label5 = new Label();
            label6 = new Label();
            delete = new Button();
            label7 = new Label();
            DeleteBox = new ComboBox();
            oep = new ComboBox();
            date = new Label();
            label1 = new Label();
            calendar = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // newnote
            // 
            newnote.Location = new Point(12, 166);
            newnote.Name = "newnote";
            newnote.Size = new Size(605, 311);
            newnote.TabIndex = 0;
            newnote.Text = "";
            // 
            // n
            // 
            n.AutoSize = true;
            n.Font = new Font("MV Boli", 24F, FontStyle.Regular, GraphicsUnit.Point);
            n.Location = new Point(226, 9);
            n.Name = "n";
            n.Size = new Size(151, 41);
            n.TabIndex = 2;
            n.Text = "NoteApp";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MV Boli", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(329, 84);
            label3.Name = "label3";
            label3.Size = new Size(158, 21);
            label3.TabIndex = 3;
            label3.Text = "Open existing note:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("MV Boli", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(517, 58);
            label4.Name = "label4";
            label4.Size = new Size(0, 21);
            label4.TabIndex = 4;
            // 
            // open
            // 
            open.Location = new Point(490, 111);
            open.Name = "open";
            open.Size = new Size(120, 23);
            open.TabIndex = 5;
            open.Text = "Open";
            open.UseVisualStyleBackColor = true;
            open.Click += open_Click;
            // 
            // save
            // 
            save.Location = new Point(542, 454);
            save.Name = "save";
            save.Size = new Size(75, 23);
            save.TabIndex = 6;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 82);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("MV Boli", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(27, 82);
            label6.Name = "label6";
            label6.Size = new Size(104, 21);
            label6.TabIndex = 10;
            label6.Text = "Delete note:";
            // 
            // delete
            // 
            delete.Location = new Point(132, 111);
            delete.Name = "delete";
            delete.Size = new Size(120, 23);
            delete.TabIndex = 11;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("MV Boli", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(147, 58);
            label7.Name = "label7";
            label7.Size = new Size(0, 21);
            label7.TabIndex = 13;
            // 
            // DeleteBox
            // 
            DeleteBox.FormattingEnabled = true;
            DeleteBox.Location = new Point(132, 86);
            DeleteBox.Name = "DeleteBox";
            DeleteBox.Size = new Size(121, 23);
            DeleteBox.TabIndex = 16;
            // 
            // oep
            // 
            oep.FormattingEnabled = true;
            oep.Location = new Point(489, 84);
            oep.Name = "oep";
            oep.Size = new Size(121, 23);
            oep.TabIndex = 17;
            // 
            // date
            // 
            date.AutoSize = true;
            date.Location = new Point(562, 166);
            date.Name = "date";
            date.Size = new Size(0, 15);
            date.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MV Boli", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(27, 142);
            label1.Name = "label1";
            label1.Size = new Size(51, 21);
            label1.TabIndex = 19;
            label1.Text = "Date:";
            // 
            // calendar
            // 
            calendar.AutoSize = true;
            calendar.Font = new Font("MV Boli", 12F, FontStyle.Regular, GraphicsUnit.Point);
            calendar.Location = new Point(80, 142);
            calendar.Name = "calendar";
            calendar.Size = new Size(0, 21);
            calendar.TabIndex = 20;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "default", "red dragon", "Earth", "passion fruit", "sakura" });
            comboBox1.Location = new Point(489, 25);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 21;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MV Boli", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(422, 25);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 22;
            label2.Text = "Palette";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 489);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(calendar);
            Controls.Add(label1);
            Controls.Add(date);
            Controls.Add(oep);
            Controls.Add(DeleteBox);
            Controls.Add(label7);
            Controls.Add(delete);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(save);
            Controls.Add(open);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(n);
            Controls.Add(newnote);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox newnote;
        private Label n;
        private Label label3;
        private Label label4;
        private Button open;
        private Button save;
        private Label label5;
        private Label label6;
        private Button delete;
        private Label label7;
        private ComboBox DeleteBox;
        private ComboBox oep;
        private Label date;
        private Label label1;
        private Label calendar;
        private ComboBox comboBox1;
        private Label label2;
    }
}