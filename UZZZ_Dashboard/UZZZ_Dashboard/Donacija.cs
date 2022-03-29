using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace UZZZ_Dashboard
{
    public partial class Donacija : Form
    {
        public Donacija()
        {
            InitializeComponent();
         
        }
        


        string conStr = "Server= computer_name; Database = Adoption; Integrated Security = true";
        int counter = 0;
        int pointer = 0;
        int rowsPerPage = 29;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DateTime dateT = DateTime.UtcNow.Date;
            string header = "Udruženje za zaštitu životinja Banjaluka" + dateT.ToString();
            Graphics gf = e.Graphics;
            gf.DrawString(header, new Font("Arial", 5, FontStyle.Bold), Brushes.Black, 10, 10);
            SizeF sf = gf.MeasureString(textBoxName.Text + " " + textBoxLastName.Text + " donirao/la je sredstva u iznosu od " + textBoxMoney.Text + "KM udruženju za zaštitu životinja Banja Luka. Vaša stredstva pomažu nezbrinutim štićenicima našeg doma u nabavci hrane i regulisanju ostalih troškova. Naši štićenici su Vam neizmjerno zahvalni.",
                            new Font(new FontFamily("Arial"), 14), 800);
            gf.DrawString(textBoxName.Text + " " + textBoxLastName.Text + " donirao/la je sredstva u iznosu od " + textBoxMoney.Text + "KM udruženju za zaštitu životinja Banja Luka. Vaša stredstva pomažu nezbrinutim štićenicima našeg doma u nabavci hrane i regulisanju ostalih troškova. Naši štićenici su Vam neizmjerno zahvalni.",
                            new Font(new FontFamily("Arial"), 10F), Brushes.Black,
                            new RectangleF(new PointF(50F, 400F), sf),
                            StringFormat.GenericTypographic);
            gf.DrawString("DONACIJA", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 360, 340);
            gf.DrawString("__________________________", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 60, 560);
            gf.DrawString("__________________________", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 590, 560);
            gf.DrawString(textBoxName.Text + " " + textBoxLastName.Text, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 60, 590);
            gf.DrawString("Goran Savić", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 590, 590);
            System.Drawing.Image img = System.Drawing.Image.FromFile("C: \\Users\\sc21l\\Desktop\\CSharpProject\\Shelter2.png");
            gf.DrawImage(img, new PointF(320F, 30F));
            
        }

        private void iconBtnPrint_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text=="" || textBoxLastName.Text=="" || textBoxMoney.Text=="")
            {
                MessageBox.Show("Potrebno je popuniti polja ime, prezime i vrijednost za štampanje!", "Obavještenje");
            }
            else
                printPreviewDialog1.ShowDialog();

            
        }

        private void iconBtnView_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select*from Donacija";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                dataGridViewDonation.DataSource = dt;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            dataGridViewDonation.ClearSelection();
        }

        private void iconBtnDeleteSelected_Click(object sender, EventArgs e)
        {

            if (Dashboard.dashStatus != "Admin" || Dashboard.dashStatus != "Administracija")
            {
                MessageBox.Show("Nemate ovlaštenje za brisanje podataka o donaciji!", "Obavještenje");
                return;
            }
            else if (dataGridViewDonation.CurrentCell.RowIndex < 0)
            { MessageBox.Show("Potrebno je selektovati polje iz tabele koje želite izbrisati!", "Obavještenje"); }
            else
            {
                int index = dataGridViewDonation.CurrentCell.RowIndex;
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite izbrisati donaciju sa indeksom " + dataGridViewDonation.Rows[index].Cells[0].Value.ToString() + "?", "Upozorenje!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(conStr);
                        string str = "Delete from Donacija where ID=@id";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.Parameters.AddWithValue("@id", dataGridViewDonation.Rows[index].Cells[0].Value.ToString());
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                            MessageBox.Show("Uspješno ste obrisali donaciju čiji je ID=" + dataGridViewDonation.Rows[index].Cells[0].Value.ToString() + "!", "Obavještenje");
                        con.Close();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
        }

        private void iconBtnPrintSelected_Click(object sender, EventArgs e)
        {
            
            printPreviewDialog2.ShowDialog();
            
        }

        private void iconBtnSearch_Click(object sender, EventArgs e)
        {
            dataGridViewDonation.ClearSelection();
            if (textBoxName.Text == "" && textBoxLastName.Text == "")
                MessageBox.Show("Popunite podatke za pretragu!", "Obavještenje");
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(conStr);
                    string str = "Select*from Donacija where (Ime=N'"+textBoxName.Text+ "') or (Prezime=N'" + textBoxLastName.Text + "')";
                    SqlCommand cmd = new SqlCommand(str, con);
                    con.Open();
                    
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dt);
                    dataGridViewDonation.DataSource = dt;
                    con.Close();
                                        
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            
        }

        private void iconBtnAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textBoxLastName.Text == "" || textBoxMoney.Text=="")
                MessageBox.Show("Za unos je potrebno popuniti sve podatke!", "Obavještenje");
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(conStr);
                    String str = "Insert into Donacija  (Ime, Prezime, Vrijednost, Datum_U, ID_U, Datum_A, ID_A) Values(@name, @lname, @money, @datU,@idU,@datA, @idA)";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@lname", textBoxLastName.Text);
                    cmd.Parameters.AddWithValue("@money", textBoxMoney.Text);
                    DateTime dateTime = DateTime.UtcNow.Date;
                    cmd.Parameters.AddWithValue("@datU", dateTime.ToString());
                    cmd.Parameters.AddWithValue("@idU", Dashboard.dashID);
                    cmd.Parameters.AddWithValue("@datA", dateTime.ToString());
                    cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Uspešno ste unijeli podatke o donaciji.", "Obavještenje");
                    else
                        MessageBox.Show("Došlo je do greške prilikom unosa podataka o donaciji. Provjerite polja!", "Obavještenje");

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }

        }

        private void dataGridViewDonation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxName.Text = "";
            textBoxLastName.Text = "";
            textBoxMoney.Text = "";

            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                

                textBoxName.Text = dataGridViewDonation.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBoxLastName.Text = dataGridViewDonation.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBoxMoney.Text = dataGridViewDonation.Rows[e.RowIndex].Cells[3].Value.ToString();
                
            }
            dataGridViewDonation.ClearSelection();
            
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(conStr);
                string str1 = "Select sum(Vrijednost) from Donacija";
                SqlCommand cmd1 = new SqlCommand(str1, con1);
                con1.Open();
                DataTable dt1 = new DataTable();
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(cmd1);
                sqlDataAdapter1.Fill(dt1);
                con1.Close();
                string sumDonation=dt1.Rows[0][0].ToString();

                SqlConnection con = new SqlConnection(conStr);
                string str = "Select Ime, Prezime, Vrijednost, Datum_U, ID_U from Donacija";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    int maxR = dt.Rows.Count;
                    int y = 130;
                    int x = 50;
                    DateTime date = DateTime.UtcNow.Date;
                    string header = "Udruženje za zaštitu životinja Banjaluka " + date.ToString();
                    Graphics g = e.Graphics;
                    g.DrawString(header, new Font("Arial", 5, FontStyle.Bold), Brushes.Black, 10, 10);
                    g.DrawString("DONACIJE", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 350, 60);
                    g.DrawString("===================================================================================================", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 10, y - 30);
                    g.DrawString("Ime", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, x, y);
                    g.DrawString("Prezime", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, x + 180, y);
                    g.DrawString("Vrijednost", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, x + 360, y);
                    g.DrawString("Datum_U", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, x + 540, y);
                    g.DrawString("ID_U", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, x + 720, y);
                    g.DrawString("===================================================================================================", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 10, y + 30);
                    y += 50;
                    int n = 0;
                    
                    if (maxR <= 29)
                    {
                        for (int row = pointer; row < dt.Rows.Count; row++)
                        {
                            x = 50;
                            n = 0;
                            for (int column = 0; column < dt.Columns.Count; column++)
                            {
                                n++;
                                g.DrawString(dt.Rows[row][column].ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, x, y);
                                if (n == 1)
                                {
                                    g.DrawString("=============================================================================================", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, x - 10, y + 15);
                                }
                                x += 180;
                            }
                            y += 30;
                            
                        }
                    }
                    else 
                    {

                        for (int row = pointer; row <= rowsPerPage; row++)
                        {
                            if (counter < 29)
                            {
                                counter++;
                                e.HasMorePages = false;
                            }
                            else
                            {
                                counter = 0;
                                pointer = rowsPerPage;
                                rowsPerPage = maxR - 1;
                                y = 180;
                                e.HasMorePages = true;
                                return;
                            }
                            x = 50;
                            n = 0;
                            for (int column = 0; column < dt.Columns.Count; column++)
                            {
                                n++;
                                g.DrawString(dt.Rows[row][column].ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, x, y);
                                if (n == 1)
                                {
                                    g.DrawString("=============================================================================================", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, x - 10, y + 15);
                                }
                                x += 180;
                            }
                            y += 30;
                        }
                    }

                    g.DrawString("===================================================================================================", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 10, y + 20);
                    g.DrawString("SUMA = " + sumDonation + "KM", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 650, y + 40);
                    g.DrawString("===================================================================================================", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 10, y + 60);

                }
                else
                    MessageBox.Show("Podaci nisu pronađeni u bazi podataka!","Obavještenje");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
           
        }
    }
}
