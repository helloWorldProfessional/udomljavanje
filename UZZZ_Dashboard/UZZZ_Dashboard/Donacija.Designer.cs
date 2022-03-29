namespace UZZZ_Dashboard
{
    partial class Donacija
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Donacija));
            this.dataGridViewDonation = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMoney = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.iconBtnPrintSelected = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconBtnPrint = new FontAwesome.Sharp.IconButton();
            this.iconBtnDeleteSelected = new FontAwesome.Sharp.IconButton();
            this.iconBtnView = new FontAwesome.Sharp.IconButton();
            this.iconBtnAdd = new FontAwesome.Sharp.IconButton();
            this.iconBtnSearch = new FontAwesome.Sharp.IconButton();
            this.printDialog2 = new System.Windows.Forms.PrintDialog();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog2 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDonation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDonation
            // 
            this.dataGridViewDonation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewDonation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDonation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDonation.Location = new System.Drawing.Point(605, 30);
            this.dataGridViewDonation.MinimumSize = new System.Drawing.Size(691, 449);
            this.dataGridViewDonation.MultiSelect = false;
            this.dataGridViewDonation.Name = "dataGridViewDonation";
            this.dataGridViewDonation.ReadOnly = true;
            this.dataGridViewDonation.RowTemplate.Height = 24;
            this.dataGridViewDonation.Size = new System.Drawing.Size(871, 531);
            this.dataGridViewDonation.TabIndex = 23;
            this.dataGridViewDonation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDonation_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.label1.Location = new System.Drawing.Point(118, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ime:";
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.ForeColor = System.Drawing.Color.White;
            this.textBoxName.Location = new System.Drawing.Point(81, 159);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(308, 28);
            this.textBoxName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.label2.Location = new System.Drawing.Point(118, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Prezime:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.panel3.Location = new System.Drawing.Point(75, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(314, 1);
            this.panel3.TabIndex = 11;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.textBoxLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLastName.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLastName.ForeColor = System.Drawing.Color.White;
            this.textBoxLastName.Location = new System.Drawing.Point(81, 245);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(308, 28);
            this.textBoxLastName.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.panel1.Location = new System.Drawing.Point(77, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 1);
            this.panel1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.label3.Location = new System.Drawing.Point(118, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Donacija:";
            // 
            // textBoxMoney
            // 
            this.textBoxMoney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.textBoxMoney.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMoney.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMoney.ForeColor = System.Drawing.Color.White;
            this.textBoxMoney.Location = new System.Drawing.Point(81, 335);
            this.textBoxMoney.Name = "textBoxMoney";
            this.textBoxMoney.Size = new System.Drawing.Size(308, 28);
            this.textBoxMoney.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.panel2.Location = new System.Drawing.Point(78, 366);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(314, 1);
            this.panel2.TabIndex = 17;
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // iconBtnPrintSelected
            // 
            this.iconBtnPrintSelected.AutoSize = true;
            this.iconBtnPrintSelected.FlatAppearance.BorderSize = 0;
            this.iconBtnPrintSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnPrintSelected.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.iconBtnPrintSelected.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.iconBtnPrintSelected.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnPrintSelected.IconSize = 45;
            this.iconBtnPrintSelected.Location = new System.Drawing.Point(530, 172);
            this.iconBtnPrintSelected.Name = "iconBtnPrintSelected";
            this.iconBtnPrintSelected.Size = new System.Drawing.Size(60, 60);
            this.iconBtnPrintSelected.TabIndex = 31;
            this.iconBtnPrintSelected.UseVisualStyleBackColor = true;
            this.iconBtnPrintSelected.Click += new System.EventHandler(this.iconBtnPrintSelected_Click);
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.iconPictureBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Donate;
            this.iconPictureBox3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.Location = new System.Drawing.Point(75, 301);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox3.TabIndex = 30;
            this.iconPictureBox3.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.IdBadge;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.Location = new System.Drawing.Point(75, 211);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox2.TabIndex = 29;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.IdBadge;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.Location = new System.Drawing.Point(75, 123);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 28;
            this.iconPictureBox1.TabStop = false;
            // 
            // iconBtnPrint
            // 
            this.iconBtnPrint.AutoSize = true;
            this.iconBtnPrint.FlatAppearance.BorderSize = 0;
            this.iconBtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnPrint.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.iconBtnPrint.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.iconBtnPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnPrint.IconSize = 45;
            this.iconBtnPrint.Location = new System.Drawing.Point(343, 373);
            this.iconBtnPrint.Name = "iconBtnPrint";
            this.iconBtnPrint.Size = new System.Drawing.Size(60, 60);
            this.iconBtnPrint.TabIndex = 27;
            this.iconBtnPrint.UseVisualStyleBackColor = true;
            this.iconBtnPrint.Click += new System.EventHandler(this.iconBtnPrint_Click);
            // 
            // iconBtnDeleteSelected
            // 
            this.iconBtnDeleteSelected.AutoSize = true;
            this.iconBtnDeleteSelected.FlatAppearance.BorderSize = 0;
            this.iconBtnDeleteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnDeleteSelected.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.iconBtnDeleteSelected.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.iconBtnDeleteSelected.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnDeleteSelected.IconSize = 45;
            this.iconBtnDeleteSelected.Location = new System.Drawing.Point(530, 106);
            this.iconBtnDeleteSelected.Name = "iconBtnDeleteSelected";
            this.iconBtnDeleteSelected.Size = new System.Drawing.Size(60, 60);
            this.iconBtnDeleteSelected.TabIndex = 25;
            this.iconBtnDeleteSelected.UseVisualStyleBackColor = true;
            this.iconBtnDeleteSelected.Click += new System.EventHandler(this.iconBtnDeleteSelected_Click);
            // 
            // iconBtnView
            // 
            this.iconBtnView.AutoSize = true;
            this.iconBtnView.FlatAppearance.BorderSize = 0;
            this.iconBtnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnView.IconChar = FontAwesome.Sharp.IconChar.List;
            this.iconBtnView.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.iconBtnView.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnView.IconSize = 45;
            this.iconBtnView.Location = new System.Drawing.Point(530, 40);
            this.iconBtnView.Name = "iconBtnView";
            this.iconBtnView.Size = new System.Drawing.Size(60, 60);
            this.iconBtnView.TabIndex = 24;
            this.iconBtnView.UseVisualStyleBackColor = true;
            this.iconBtnView.Click += new System.EventHandler(this.iconBtnView_Click);
            // 
            // iconBtnAdd
            // 
            this.iconBtnAdd.AutoSize = true;
            this.iconBtnAdd.FlatAppearance.BorderSize = 0;
            this.iconBtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnAdd.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.iconBtnAdd.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.iconBtnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnAdd.IconSize = 45;
            this.iconBtnAdd.Location = new System.Drawing.Point(277, 373);
            this.iconBtnAdd.Name = "iconBtnAdd";
            this.iconBtnAdd.Size = new System.Drawing.Size(60, 60);
            this.iconBtnAdd.TabIndex = 19;
            this.iconBtnAdd.UseVisualStyleBackColor = true;
            this.iconBtnAdd.Click += new System.EventHandler(this.iconBtnAdd_Click);
            // 
            // iconBtnSearch
            // 
            this.iconBtnSearch.AutoSize = true;
            this.iconBtnSearch.FlatAppearance.BorderSize = 0;
            this.iconBtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconBtnSearch.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.iconBtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnSearch.IconSize = 45;
            this.iconBtnSearch.Location = new System.Drawing.Point(422, 211);
            this.iconBtnSearch.Name = "iconBtnSearch";
            this.iconBtnSearch.Size = new System.Drawing.Size(60, 60);
            this.iconBtnSearch.TabIndex = 18;
            this.iconBtnSearch.UseVisualStyleBackColor = true;
            this.iconBtnSearch.Click += new System.EventHandler(this.iconBtnSearch_Click);
            // 
            // printDialog2
            // 
            this.printDialog2.Document = this.printDocument2;
            this.printDialog2.UseEXDialog = true;
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // printPreviewDialog2
            // 
            this.printPreviewDialog2.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog2.Document = this.printDocument2;
            this.printPreviewDialog2.Enabled = true;
            this.printPreviewDialog2.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog2.Icon")));
            this.printPreviewDialog2.Name = "printPreviewDialog1";
            this.printPreviewDialog2.Visible = false;
            // 
            // Donacija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(1504, 606);
            this.Controls.Add(this.iconBtnPrintSelected);
            this.Controls.Add(this.iconPictureBox3);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.iconBtnPrint);
            this.Controls.Add(this.iconBtnDeleteSelected);
            this.Controls.Add(this.iconBtnView);
            this.Controls.Add(this.dataGridViewDonation);
            this.Controls.Add(this.iconBtnAdd);
            this.Controls.Add(this.iconBtnSearch);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBoxMoney);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Donacija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Donacija";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDonation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDonation;
        private FontAwesome.Sharp.IconButton iconBtnView;
        private FontAwesome.Sharp.IconButton iconBtnDeleteSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMoney;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton iconBtnSearch;
        private FontAwesome.Sharp.IconButton iconBtnAdd;
        private FontAwesome.Sharp.IconButton iconBtnPrint;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private FontAwesome.Sharp.IconButton iconBtnPrintSelected;
        private System.Windows.Forms.PrintDialog printDialog2;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog2;
    }
}