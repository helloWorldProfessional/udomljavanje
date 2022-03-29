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
using System.Data.SqlClient;


namespace UZZZ_Dashboard
{
    
    public partial class LogIn : Form
    {
        public static string userName="";
        public static string status="";
        public static string id="";
        public static string pass = "";

        public LogIn()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            
        }
       

        string conStr = "Server= computer_name; Database = Adoption; Integrated Security = true";
        
        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            labelMsg.Text = "";
            if (textBoxUsername.Text=="")
            {
                MessageBox.Show("Potrebno je unijeti username i password!");
                return;
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(conStr);
                    string str = "Select ID, Username, Status, Password from Zaposleni where (Username=@username and Password=@password)or(Username=@username and Password is null)";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.Parameters.AddWithValue("@password", textBoxPassword.Text); 
                    cmd.Parameters.AddWithValue("@username", textBoxUsername.Text);
                    con.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    con.Close();

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        
                        Hide();
                        id = ds.Tables[0].Rows[0][0].ToString();
                        userName = ds.Tables[0].Rows[0][1].ToString();
                        status = ds.Tables[0].Rows[0][2].ToString();
                        pass = ds.Tables[0].Rows[0][3].ToString();
                        textBoxUsername.Text = "";
                        textBoxPassword.Text = "";
                        using (Dashboard dashboard = new Dashboard())
                            dashboard.ShowDialog();
                        Show();
                    }
                    else
                    {
                        textBoxUsername.Text = "";
                        textBoxPassword.Text = "";
                        labelMsg.Text = "*Pogrešni kredencijali";
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }

        }
        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BtnClose_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.BtnClose, "Close");

        }

        
    }
}
