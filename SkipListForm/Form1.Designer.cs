namespace SkipListForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.typeTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.intBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.stringBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.TextBox();
            this.colourBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.arrayRadio = new System.Windows.Forms.RadioButton();
            this.linkedRadio = new System.Windows.Forms.RadioButton();
            this.immutableRadio = new System.Windows.Forms.RadioButton();
            this.actionIntButton = new System.Windows.Forms.Button();
            this.actionStrButton = new System.Windows.Forms.Button();
            this.actionFlwrButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.Panel();
            this.typeTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeTab
            // 
            this.typeTab.Controls.Add(this.tabPage1);
            this.typeTab.Controls.Add(this.tabPage2);
            this.typeTab.Controls.Add(this.tabPage3);
            this.typeTab.Location = new System.Drawing.Point(12, 11);
            this.typeTab.Name = "typeTab";
            this.typeTab.SelectedIndex = 0;
            this.typeTab.Size = new System.Drawing.Size(211, 187);
            this.typeTab.TabIndex = 0;
            this.typeTab.SelectedIndexChanged += new System.EventHandler(this.typeTab_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FloralWhite;
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.intBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(203, 158);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "int";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Enter number";
            // 
            // intBox
            // 
            this.intBox.Location = new System.Drawing.Point(9, 124);
            this.intBox.Name = "intBox";
            this.intBox.Size = new System.Drawing.Size(144, 22);
            this.intBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FloralWhite;
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.stringBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(203, 158);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "string";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Enter string";
            // 
            // stringBox
            // 
            this.stringBox.Location = new System.Drawing.Point(9, 124);
            this.stringBox.Name = "stringBox";
            this.stringBox.Size = new System.Drawing.Size(144, 22);
            this.stringBox.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FloralWhite;
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.typeBox);
            this.tabPage3.Controls.Add(this.colourBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(203, 158);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "flower";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Enter colour";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Enter type";
            // 
            // typeBox
            // 
            this.typeBox.Location = new System.Drawing.Point(9, 51);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(144, 22);
            this.typeBox.TabIndex = 11;
            // 
            // colourBox
            // 
            this.colourBox.Location = new System.Drawing.Point(9, 124);
            this.colourBox.Name = "colourBox";
            this.colourBox.Size = new System.Drawing.Size(144, 22);
            this.colourBox.TabIndex = 11;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FloralWhite;
            this.addButton.Location = new System.Drawing.Point(253, 36);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(117, 38);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.FloralWhite;
            this.removeButton.Location = new System.Drawing.Point(253, 97);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(117, 38);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FloralWhite;
            this.searchButton.Location = new System.Drawing.Point(253, 160);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(117, 38);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // arrayRadio
            // 
            this.arrayRadio.AutoSize = true;
            this.arrayRadio.Checked = true;
            this.arrayRadio.Location = new System.Drawing.Point(16, 218);
            this.arrayRadio.Name = "arrayRadio";
            this.arrayRadio.Size = new System.Drawing.Size(91, 21);
            this.arrayRadio.TabIndex = 4;
            this.arrayRadio.TabStop = true;
            this.arrayRadio.Text = "Use array";
            this.arrayRadio.UseVisualStyleBackColor = true;
            this.arrayRadio.CheckedChanged += new System.EventHandler(this.arrayRadio_CheckedChanged);
            // 
            // linkedRadio
            // 
            this.linkedRadio.AutoSize = true;
            this.linkedRadio.Location = new System.Drawing.Point(16, 259);
            this.linkedRadio.Name = "linkedRadio";
            this.linkedRadio.Size = new System.Drawing.Size(75, 21);
            this.linkedRadio.TabIndex = 5;
            this.linkedRadio.Text = "Use list";
            this.linkedRadio.UseVisualStyleBackColor = true;
            this.linkedRadio.CheckedChanged += new System.EventHandler(this.linkedRadio_CheckedChanged);
            // 
            // immutableRadio
            // 
            this.immutableRadio.AutoSize = true;
            this.immutableRadio.Location = new System.Drawing.Point(16, 298);
            this.immutableRadio.Name = "immutableRadio";
            this.immutableRadio.Size = new System.Drawing.Size(173, 21);
            this.immutableRadio.TabIndex = 6;
            this.immutableRadio.Text = "Convert into immutable";
            this.immutableRadio.UseVisualStyleBackColor = true;
            this.immutableRadio.CheckedChanged += new System.EventHandler(this.immutableRadio_CheckedChanged);
            // 
            // actionIntButton
            // 
            this.actionIntButton.BackColor = System.Drawing.Color.FloralWhite;
            this.actionIntButton.Location = new System.Drawing.Point(12, 355);
            this.actionIntButton.Name = "actionIntButton";
            this.actionIntButton.Size = new System.Drawing.Size(348, 39);
            this.actionIntButton.TabIndex = 7;
            this.actionIntButton.Text = "Check if all numbers are negative";
            this.actionIntButton.UseVisualStyleBackColor = false;
            this.actionIntButton.Click += new System.EventHandler(this.actionIntButton_Click);
            // 
            // actionStrButton
            // 
            this.actionStrButton.BackColor = System.Drawing.Color.FloralWhite;
            this.actionStrButton.Location = new System.Drawing.Point(12, 413);
            this.actionStrButton.Name = "actionStrButton";
            this.actionStrButton.Size = new System.Drawing.Size(348, 39);
            this.actionStrButton.TabIndex = 8;
            this.actionStrButton.Text = "Count all 3-symbol strings";
            this.actionStrButton.UseVisualStyleBackColor = false;
            this.actionStrButton.Click += new System.EventHandler(this.actionStrButton_Click);
            // 
            // actionFlwrButton
            // 
            this.actionFlwrButton.BackColor = System.Drawing.Color.FloralWhite;
            this.actionFlwrButton.Location = new System.Drawing.Point(12, 472);
            this.actionFlwrButton.Name = "actionFlwrButton";
            this.actionFlwrButton.Size = new System.Drawing.Size(348, 39);
            this.actionFlwrButton.TabIndex = 9;
            this.actionFlwrButton.Text = "Remove all white flowers";
            this.actionFlwrButton.UseVisualStyleBackColor = false;
            this.actionFlwrButton.Click += new System.EventHandler(this.actionFlwrButton_Click);
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.Color.White;
            this.listView.Location = new System.Drawing.Point(420, 36);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(846, 474);
            this.listView.TabIndex = 10;
            //this.listView.Paint += new System.Windows.Forms.PaintEventHandler(this.listView_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(1278, 617);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.actionFlwrButton);
            this.Controls.Add(this.actionStrButton);
            this.Controls.Add(this.actionIntButton);
            this.Controls.Add(this.immutableRadio);
            this.Controls.Add(this.linkedRadio);
            this.Controls.Add(this.arrayRadio);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.typeTab);
            this.Name = "Form1";
            this.Text = "Examples";
            this.typeTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl typeTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.RadioButton arrayRadio;
        private System.Windows.Forms.RadioButton linkedRadio;
        private System.Windows.Forms.RadioButton immutableRadio;
        private System.Windows.Forms.Button actionIntButton;
        private System.Windows.Forms.Button actionStrButton;
        private System.Windows.Forms.Button actionFlwrButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox intBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox stringBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox typeBox;
        private System.Windows.Forms.TextBox colourBox;
        private System.Windows.Forms.Panel listView;
    }
}

