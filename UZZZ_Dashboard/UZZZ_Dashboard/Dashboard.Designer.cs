using System.Windows.Forms;

namespace UZZZ_Dashboard
{
    partial class Dashboard
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
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.iconBtnMinimize = new FontAwesome.Sharp.IconButton();
            this.iconBtnShrink = new FontAwesome.Sharp.IconButton();
            this.iconBtnCloseDash = new FontAwesome.Sharp.IconButton();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconBtnSignOut = new FontAwesome.Sharp.IconButton();
            this.labelUsernameLogIn = new System.Windows.Forms.Label();
            this.iconBtnEdit = new FontAwesome.Sharp.IconButton();
            this.labelStatus = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.labelIDLogIn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.iconBtnDonation = new FontAwesome.Sharp.IconButton();
            this.iconBtnMed = new FontAwesome.Sharp.IconButton();
            this.iconBtnVaccine = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.iconBtnStaff = new FontAwesome.Sharp.IconButton();
            this.iconBtnAdoption = new FontAwesome.Sharp.IconButton();
            this.iconBtnAnimals = new FontAwesome.Sharp.IconButton();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel4;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1468, 38);
            this.panel4.TabIndex = 3;
            this.panel4.DoubleClick += new System.EventHandler(this.panel4_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.panel3.Controls.Add(this.iconBtnMinimize);
            this.panel3.Controls.Add(this.iconBtnShrink);
            this.panel3.Controls.Add(this.iconBtnCloseDash);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1306, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(160, 36);
            this.panel3.TabIndex = 11;
            // 
            // iconBtnMinimize
            // 
            this.iconBtnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(77)))), ((int)(((byte)(148)))));
            this.iconBtnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconBtnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconBtnMinimize.FlatAppearance.BorderSize = 0;
            this.iconBtnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnMinimize.ForeColor = System.Drawing.Color.White;
            this.iconBtnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconBtnMinimize.IconColor = System.Drawing.Color.White;
            this.iconBtnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnMinimize.IconSize = 23;
            this.iconBtnMinimize.Location = new System.Drawing.Point(49, 0);
            this.iconBtnMinimize.Name = "iconBtnMinimize";
            this.iconBtnMinimize.Size = new System.Drawing.Size(37, 36);
            this.iconBtnMinimize.TabIndex = 5;
            this.iconBtnMinimize.UseVisualStyleBackColor = false;
            this.iconBtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click_1);
            this.iconBtnMinimize.MouseHover += new System.EventHandler(this.BtnMinimize_MouseHover);
            // 
            // iconBtnShrink
            // 
            this.iconBtnShrink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(77)))), ((int)(((byte)(148)))));
            this.iconBtnShrink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconBtnShrink.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconBtnShrink.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.iconBtnShrink.FlatAppearance.BorderSize = 0;
            this.iconBtnShrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnShrink.ForeColor = System.Drawing.Color.White;
            this.iconBtnShrink.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.iconBtnShrink.IconColor = System.Drawing.Color.White;
            this.iconBtnShrink.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnShrink.IconSize = 23;
            this.iconBtnShrink.Location = new System.Drawing.Point(86, 0);
            this.iconBtnShrink.Name = "iconBtnShrink";
            this.iconBtnShrink.Size = new System.Drawing.Size(37, 36);
            this.iconBtnShrink.TabIndex = 4;
            this.iconBtnShrink.UseVisualStyleBackColor = false;
            this.iconBtnShrink.Click += new System.EventHandler(this.BtnShrink_Click_1);
            this.iconBtnShrink.MouseHover += new System.EventHandler(this.BtnShrink_MouseHover);
            // 
            // iconBtnCloseDash
            // 
            this.iconBtnCloseDash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(77)))), ((int)(((byte)(148)))));
            this.iconBtnCloseDash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconBtnCloseDash.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconBtnCloseDash.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.iconBtnCloseDash.FlatAppearance.BorderSize = 0;
            this.iconBtnCloseDash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnCloseDash.ForeColor = System.Drawing.Color.White;
            this.iconBtnCloseDash.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconBtnCloseDash.IconColor = System.Drawing.Color.White;
            this.iconBtnCloseDash.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnCloseDash.IconSize = 25;
            this.iconBtnCloseDash.Location = new System.Drawing.Point(123, 0);
            this.iconBtnCloseDash.Name = "iconBtnCloseDash";
            this.iconBtnCloseDash.Size = new System.Drawing.Size(37, 36);
            this.iconBtnCloseDash.TabIndex = 0;
            this.iconBtnCloseDash.UseVisualStyleBackColor = false;
            this.iconBtnCloseDash.Click += new System.EventHandler(this.BtnCloseDash_Click);
            this.iconBtnCloseDash.MouseHover += new System.EventHandler(this.BtnCloseDash_MouseHover);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.panelTitleBar.Controls.Add(this.labelTitle);
            this.panelTitleBar.Controls.Add(this.panel2);
            this.panelTitleBar.Controls.Add(this.panel1);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 38);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1468, 215);
            this.panelTitleBar.TabIndex = 4;
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("MS Reference Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.labelTitle.Location = new System.Drawing.Point(319, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Padding = new System.Windows.Forms.Padding(20, 30, 20, 30);
            this.labelTitle.Size = new System.Drawing.Size(830, 215);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "Udruženje za zaštitu životinja Banja Luka";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.iconBtnSignOut);
            this.panel2.Controls.Add(this.labelUsernameLogIn);
            this.panel2.Controls.Add(this.iconBtnEdit);
            this.panel2.Controls.Add(this.labelStatus);
            this.panel2.Controls.Add(this.iconPictureBox1);
            this.panel2.Controls.Add(this.iconPictureBox2);
            this.panel2.Controls.Add(this.iconPictureBox3);
            this.panel2.Controls.Add(this.labelIDLogIn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1149, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 215);
            this.panel2.TabIndex = 10;
            // 
            // iconBtnSignOut
            // 
            this.iconBtnSignOut.AutoSize = true;
            this.iconBtnSignOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnSignOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconBtnSignOut.FlatAppearance.BorderSize = 0;
            this.iconBtnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnSignOut.Font = new System.Drawing.Font("Microsoft YaHei", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnSignOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnSignOut.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.iconBtnSignOut.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.iconBtnSignOut.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnSignOut.IconSize = 32;
            this.iconBtnSignOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnSignOut.Location = new System.Drawing.Point(267, 166);
            this.iconBtnSignOut.Name = "iconBtnSignOut";
            this.iconBtnSignOut.Size = new System.Drawing.Size(40, 40);
            this.iconBtnSignOut.TabIndex = 10;
            this.iconBtnSignOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnSignOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnSignOut.UseVisualStyleBackColor = false;
            this.iconBtnSignOut.Click += new System.EventHandler(this.BtnSignOut_Click);
            // 
            // labelUsernameLogIn
            // 
            this.labelUsernameLogIn.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.labelUsernameLogIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.labelUsernameLogIn.Location = new System.Drawing.Point(147, 30);
            this.labelUsernameLogIn.Name = "labelUsernameLogIn";
            this.labelUsernameLogIn.Size = new System.Drawing.Size(148, 23);
            this.labelUsernameLogIn.TabIndex = 2;
            this.labelUsernameLogIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconBtnEdit
            // 
            this.iconBtnEdit.AutoSize = true;
            this.iconBtnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconBtnEdit.FlatAppearance.BorderSize = 0;
            this.iconBtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnEdit.Font = new System.Drawing.Font("Microsoft YaHei", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnEdit.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.iconBtnEdit.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.iconBtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnEdit.IconSize = 32;
            this.iconBtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnEdit.Location = new System.Drawing.Point(221, 166);
            this.iconBtnEdit.Name = "iconBtnEdit";
            this.iconBtnEdit.Size = new System.Drawing.Size(40, 40);
            this.iconBtnEdit.TabIndex = 9;
            this.iconBtnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnEdit.UseVisualStyleBackColor = false;
            this.iconBtnEdit.Click += new System.EventHandler(this.BtnEdit_Click_1);
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.labelStatus.Location = new System.Drawing.Point(145, 132);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(116, 23);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 45;
            this.iconPictureBox1.Location = new System.Drawing.Point(95, 21);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.iconPictureBox1.Size = new System.Drawing.Size(45, 45);
            this.iconPictureBox1.TabIndex = 1;
            this.iconPictureBox1.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.UserTag;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 45;
            this.iconPictureBox2.Location = new System.Drawing.Point(95, 120);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(45, 45);
            this.iconPictureBox2.TabIndex = 7;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconPictureBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            this.iconPictureBox3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 45;
            this.iconPictureBox3.Location = new System.Drawing.Point(95, 72);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(45, 45);
            this.iconPictureBox3.TabIndex = 5;
            this.iconPictureBox3.TabStop = false;
            // 
            // labelIDLogIn
            // 
            this.labelIDLogIn.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.labelIDLogIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.labelIDLogIn.Location = new System.Drawing.Point(147, 81);
            this.labelIDLogIn.Name = "labelIDLogIn";
            this.labelIDLogIn.Size = new System.Drawing.Size(63, 23);
            this.labelIDLogIn.TabIndex = 6;
            this.labelIDLogIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 215);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::UZZZ_Dashboard.Properties.Resources.Shelter2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.panelMenu.Controls.Add(this.iconBtnDonation);
            this.panelMenu.Controls.Add(this.iconBtnMed);
            this.panelMenu.Controls.Add(this.iconBtnVaccine);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.iconBtnStaff);
            this.panelMenu.Controls.Add(this.iconBtnAdoption);
            this.panelMenu.Controls.Add(this.iconBtnAnimals);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 253);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(319, 753);
            this.panelMenu.TabIndex = 5;
            // 
            // iconBtnDonation
            // 
            this.iconBtnDonation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.iconBtnDonation.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnDonation.FlatAppearance.BorderSize = 0;
            this.iconBtnDonation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnDonation.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnDonation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnDonation.IconChar = FontAwesome.Sharp.IconChar.Donate;
            this.iconBtnDonation.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnDonation.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnDonation.IconSize = 40;
            this.iconBtnDonation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnDonation.Location = new System.Drawing.Point(0, 500);
            this.iconBtnDonation.Name = "iconBtnDonation";
            this.iconBtnDonation.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.iconBtnDonation.Size = new System.Drawing.Size(319, 100);
            this.iconBtnDonation.TabIndex = 15;
            this.iconBtnDonation.Text = "DONACIJA";
            this.iconBtnDonation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnDonation.UseVisualStyleBackColor = false;
            this.iconBtnDonation.Click += new System.EventHandler(this.BtnDonation_Click);
            // 
            // iconBtnMed
            // 
            this.iconBtnMed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.iconBtnMed.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnMed.FlatAppearance.BorderSize = 0;
            this.iconBtnMed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnMed.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnMed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnMed.IconChar = FontAwesome.Sharp.IconChar.PrescriptionBottleAlt;
            this.iconBtnMed.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnMed.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnMed.IconSize = 40;
            this.iconBtnMed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnMed.Location = new System.Drawing.Point(0, 400);
            this.iconBtnMed.Name = "iconBtnMed";
            this.iconBtnMed.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.iconBtnMed.Size = new System.Drawing.Size(319, 100);
            this.iconBtnMed.TabIndex = 13;
            this.iconBtnMed.Text = "TERAPIJA";
            this.iconBtnMed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnMed.UseVisualStyleBackColor = false;
            this.iconBtnMed.Click += new System.EventHandler(this.BtnMed_Click_1);
            // 
            // iconBtnVaccine
            // 
            this.iconBtnVaccine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.iconBtnVaccine.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnVaccine.FlatAppearance.BorderSize = 0;
            this.iconBtnVaccine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnVaccine.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnVaccine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnVaccine.IconChar = FontAwesome.Sharp.IconChar.Syringe;
            this.iconBtnVaccine.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnVaccine.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnVaccine.IconSize = 40;
            this.iconBtnVaccine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnVaccine.Location = new System.Drawing.Point(0, 300);
            this.iconBtnVaccine.Name = "iconBtnVaccine";
            this.iconBtnVaccine.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.iconBtnVaccine.Size = new System.Drawing.Size(319, 100);
            this.iconBtnVaccine.TabIndex = 12;
            this.iconBtnVaccine.Text = "VAKCINACIJA";
            this.iconBtnVaccine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnVaccine.UseVisualStyleBackColor = false;
            this.iconBtnVaccine.Click += new System.EventHandler(this.BtnVaccine_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(0, 716);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Udruženje za zaštitu životinja Banja Luka 2021.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // iconBtnStaff
            // 
            this.iconBtnStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.iconBtnStaff.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnStaff.FlatAppearance.BorderSize = 0;
            this.iconBtnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnStaff.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnStaff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnStaff.IconChar = FontAwesome.Sharp.IconChar.IdBadge;
            this.iconBtnStaff.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnStaff.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnStaff.IconSize = 40;
            this.iconBtnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnStaff.Location = new System.Drawing.Point(0, 200);
            this.iconBtnStaff.Name = "iconBtnStaff";
            this.iconBtnStaff.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.iconBtnStaff.Size = new System.Drawing.Size(319, 100);
            this.iconBtnStaff.TabIndex = 7;
            this.iconBtnStaff.Text = "ZAPOSLENI";
            this.iconBtnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnStaff.UseVisualStyleBackColor = false;
            this.iconBtnStaff.Click += new System.EventHandler(this.BtnStaff_Click);
            // 
            // iconBtnAdoption
            // 
            this.iconBtnAdoption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.iconBtnAdoption.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnAdoption.FlatAppearance.BorderSize = 0;
            this.iconBtnAdoption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnAdoption.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnAdoption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnAdoption.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconBtnAdoption.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnAdoption.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnAdoption.IconSize = 40;
            this.iconBtnAdoption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnAdoption.Location = new System.Drawing.Point(0, 100);
            this.iconBtnAdoption.Name = "iconBtnAdoption";
            this.iconBtnAdoption.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.iconBtnAdoption.Size = new System.Drawing.Size(319, 100);
            this.iconBtnAdoption.TabIndex = 6;
            this.iconBtnAdoption.Text = "USVAJANJE";
            this.iconBtnAdoption.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnAdoption.UseVisualStyleBackColor = false;
            this.iconBtnAdoption.Click += new System.EventHandler(this.BtnAdoption_Click);
            // 
            // iconBtnAnimals
            // 
            this.iconBtnAnimals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(94)))), ((int)(((byte)(159)))));
            this.iconBtnAnimals.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnAnimals.FlatAppearance.BorderSize = 0;
            this.iconBtnAnimals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnAnimals.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnAnimals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnAnimals.IconChar = FontAwesome.Sharp.IconChar.Paw;
            this.iconBtnAnimals.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(75)))));
            this.iconBtnAnimals.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnAnimals.IconSize = 40;
            this.iconBtnAnimals.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnAnimals.Location = new System.Drawing.Point(0, 0);
            this.iconBtnAnimals.Name = "iconBtnAnimals";
            this.iconBtnAnimals.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.iconBtnAnimals.Size = new System.Drawing.Size(319, 100);
            this.iconBtnAnimals.TabIndex = 5;
            this.iconBtnAnimals.Text = "ŠTIĆENICI";
            this.iconBtnAnimals.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnAnimals.UseVisualStyleBackColor = false;
            this.iconBtnAnimals.Click += new System.EventHandler(this.BtnAnimals_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.AutoScroll = true;
            this.panelChildForm.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panelChildForm.AutoScrollMinSize = new System.Drawing.Size(1920, 1080);
            this.panelChildForm.AutoSize = true;
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.panelChildForm.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(319, 253);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1149, 753);
            this.panelChildForm.TabIndex = 6;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1468, 1006);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panel4);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton iconBtnCloseDash;
        private FontAwesome.Sharp.IconButton iconBtnMinimize;
        private FontAwesome.Sharp.IconButton iconBtnShrink;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelUsernameLogIn;
        private FontAwesome.Sharp.IconButton iconBtnEdit;
        private System.Windows.Forms.Label labelStatus;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.Label labelIDLogIn;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconBtnStaff;
        private FontAwesome.Sharp.IconButton iconBtnAdoption;
        private FontAwesome.Sharp.IconButton iconBtnAnimals;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelChildForm;
        private FontAwesome.Sharp.IconButton iconBtnSignOut;
        private FontAwesome.Sharp.IconButton iconBtnDonation;
        private FontAwesome.Sharp.IconButton iconBtnMed;
        private FontAwesome.Sharp.IconButton iconBtnVaccine;
    }
}