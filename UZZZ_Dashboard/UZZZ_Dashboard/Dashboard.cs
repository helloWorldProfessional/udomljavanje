using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FontAwesome.Sharp;



namespace UZZZ_Dashboard
{
    public partial class Dashboard : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public static string dashUserName = "";
        public static string dashStatus = "";
        public static string dashID = "";

        public Dashboard()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 100);
            panelMenu.Controls.Add(leftBorderBtn);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            

        }

        //form resize --not working
        private const int cGrip = 16;
        private const int cCaption = 32;
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }

            base.WndProc(ref m);
        }

        //button state
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(5, 68, 94);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(53, 94, 159);
                currentBtn.ForeColor = Color.FromArgb(110, 191, 75);
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(110, 191, 75);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        //child form opening method
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da se odjavitе?", "Upozorenje", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                //LogIn login = new LogIn();
                //login.Show();
            }
        }
        private void BtnCloseDash_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite izaći iz aplikacije?", "Upozorenje", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                //for (int i = 0; i < Application.OpenForms.Count; i++)
                //{
                //        Application.OpenForms[i].Close();
                //}
                
                //close formse including main LogIn hiden form
            }
            
        }
        
        //mouse hover and minimize/maximize/close buttons
        private void BtnEdit_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.iconBtnEdit, "Edit");
        }

        private void BtnShrink_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void BtnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
     
        private void BtnMinimize_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.iconBtnMinimize, "Minimize");
            
        }

        private void BtnShrink_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.iconBtnShrink, "Maximize/Restore Down");
            
        }

        private void BtnCloseDash_MouseHover(object sender, EventArgs e)
        {
                System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                ToolTip1.SetToolTip(this.iconBtnCloseDash, "Close");
           
        }

        //maximize/minimize doubleclick
        private void panel4_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite izlogovati iz aplikacije?", "Upozorenje", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                this.Close();

            }
        }

        //menu buttons
        private void BtnAdoption_Click(object sender, EventArgs e)
        {
            
            if (Dashboard.dashStatus == "Administracija")
            {
                MessageBox.Show("Nemate ovlaštenje za pristup podacima!", "Obavještenje");
            }
            else
            {
                ActivateButton(sender, Color.FromArgb(110, 191, 75));
                OpenChildForm(new Usvajanje());
            }
        }

        private void BtnAnimals_Click(object sender, EventArgs e)
        {
            if (Dashboard.dashStatus == "Administracija")
            {
                MessageBox.Show("Nemate ovlaštenje za pristup podacima!", "Obavještenje");
            }
            else
            {

                ActivateButton(sender, Color.FromArgb(110, 191, 75));
                OpenChildForm(new Sticenici());
            
            }
        }

        private void BtnStaff_Click(object sender, EventArgs e)
        {
                ActivateButton(sender, Color.FromArgb(110, 191, 75));
                OpenChildForm(new Zaposleni());
            
        }
        
        private void BtnEdit_Click_1(object sender, EventArgs e)
        {
            DisableButton();
            OpenChildForm(new Zaposleni());
            
        }

        private void BtnMed_Click_1(object sender, EventArgs e)
        {
            if (Dashboard.dashStatus == "Administracija")
            {
                MessageBox.Show("Nemate ovlaštenje za pristup podacima!", "Obavještenje");
            }
            else
            {
                ActivateButton(sender, Color.FromArgb(110, 191, 75));
                OpenChildForm(new Terapija());
            }
        }
        
        private void BtnDonation_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(110, 191, 75));
            OpenChildForm(new Donacija());
        }

        private void BtnVaccine_Click(object sender, EventArgs e)
        {
            if (Dashboard.dashStatus == "Administracija")
            {
                MessageBox.Show("Nemate ovlaštenje za pristup podacima!", "Obavještenje");
            }
            else
            {
                ActivateButton(sender, Color.FromArgb(110, 191, 75));
                OpenChildForm(new Vakcinacija());
            }
            
        }
        public string Username
        {
            get
            {
                return labelUsernameLogIn.Text;
            }
            set
            {
                labelUsernameLogIn.Text = value;
            }
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            labelUsernameLogIn.Text = LogIn.userName;
            dashUserName = labelUsernameLogIn.Text;
            labelIDLogIn.Text = LogIn.id;
            dashID = labelIDLogIn.Text;
            labelStatus.Text = LogIn.status;
            dashStatus = labelStatus.Text;
            string pass = LogIn.pass;
            if (pass=="")
                MessageBox.Show("Vaš nalog nije zaštićen password-om. Ažurirajte kredencijale!", "Upozorenje");
        }
    }
}
