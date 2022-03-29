using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UZZZ_Dashboard
{
    public partial class Vakcinacija : Form
    {
        public Vakcinacija()
        {
            InitializeComponent();
        }
        string conStr = "Server= computer_name; Database = Adoption; Integrated Security = true";
        string vaccineID = "";                  
        private void iconBtnViewPendingVaccines_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select Sticenik.Slika, Vakcinacija.ID_S as ID,Sticenik.Ime, Vakcinacija.ID as [ID_V],Vakcinacija.Vrsta as [Vrsta vakcine], Vakcinacija.Datum as [Datum vakcinacije]," +
                    "Vakcinacija.Ambulanta, Vakcinacija.Doktor as Veterinar, Vakcinacija.Datum_U, Vakcinacija.ID_U, Vakcinacija.Datum_A, " +
                    "Vakcinacija.ID_A from Sticenik join Vakcinacija on Vakcinacija.ID_S=Sticenik.ID where Datum>CURRENT_TIMESTAMP-372 and Sticenik.Dostupnost like 'Dostup%'";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                dataGridViewVaccine.DataSource = dt;
                con.Close();
                DataGridViewColumn column = dataGridViewVaccine.Columns[0];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ((DataGridViewImageColumn)dataGridViewVaccine.Columns[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    dataGridViewVaccine.Rows[i++].Height = 100;
                    dataGridViewVaccine.Columns[0].Width = 100;
                }
                labelListVacc.Text = "Potrebno vakcinisati:";
                

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            dataGridViewVaccine.ClearSelection();
        }

        private void iconBtnViewVaccinated_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select Sticenik.Slika, Vakcinacija.ID_S as ID, Sticenik.Ime,Vakcinacija.ID as [ID_V],Vakcinacija.Vrsta as [Vrsta vakcine], Vakcinacija.Datum as [Datum vakcinacije],Vakcinacija.Ambulanta, Vakcinacija.Doktor as Veterinar, Vakcinacija.Datum_U, Vakcinacija.ID_U, Vakcinacija.Datum_A, " +
                    "Vakcinacija.ID_A from Sticenik join Vakcinacija on Vakcinacija.ID_S=Sticenik.ID ";//where Sticenik.Dostupnost like 'Dostup%' ";

                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                dataGridViewVaccine.DataSource = dt;
                con.Close();
                DataGridViewColumn column = dataGridViewVaccine.Columns[0];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ((DataGridViewImageColumn)dataGridViewVaccine.Columns[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    dataGridViewVaccine.Rows[i++].Height = 100;
                    dataGridViewVaccine.Columns[0].Width = 100;
                }
                labelListVacc.Text = "Sve vakcinacije:";
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            dataGridViewVaccine.ClearSelection();
        }

        private void dataGridViewVaccine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBoxAnimal.Image = null;
            labelID.Text = "";
            textBoxName.Text = "";
            textBoxDoctor.Text = "";
            comboBoxVaccineType.SelectedIndex = -1;
            comboBoxHospital.SelectedIndex = -1;
            datePicker.Text = "";
            if (e.RowIndex>-1 && e.ColumnIndex>-1)
            {
                if (!string.IsNullOrEmpty(dataGridViewVaccine.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    byte[] bytes = (byte[])
                    dataGridViewVaccine.Rows[e.RowIndex].Cells[0].Value;
                    MemoryStream ms = new MemoryStream(bytes);
                    pictureBoxAnimal.Image = Image.FromStream(ms);

                }

                if (dataGridViewVaccine.Columns.Count == 3)
                {
                    labelID.Text = dataGridViewVaccine.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textBoxName.Text = dataGridViewVaccine.Rows[e.RowIndex].Cells[2].Value.ToString();
                    vaccineID = "";
                }
                else
                {
                    labelID.Text = dataGridViewVaccine.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textBoxName.Text = dataGridViewVaccine.Rows[e.RowIndex].Cells[2].Value.ToString();
                    vaccineID= dataGridViewVaccine.Rows[e.RowIndex].Cells[3].Value.ToString();
                    comboBoxVaccineType.Text = dataGridViewVaccine.Rows[e.RowIndex].Cells[4].Value.ToString();
                    datePicker.Text = dataGridViewVaccine.Rows[e.RowIndex].Cells[5].Value.ToString();
                    comboBoxHospital.Text = dataGridViewVaccine.Rows[e.RowIndex].Cells[6].Value.ToString();
                    textBoxDoctor.Text = dataGridViewVaccine.Rows[e.RowIndex].Cells[7].Value.ToString();
                }
            }
        }

        private void iconBtnSearchByName_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(conStr);
                    string str = "Select Slika, ID, Ime from Sticenik where Ime =N'" + textBoxName.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dt);

                    if (dt.Rows.Count > 1)
                    {
                        dataGridViewVaccine.DataSource = dt;
                        DataGridViewColumn column = dataGridViewVaccine.Columns[0];
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        ((DataGridViewImageColumn)dataGridViewVaccine.Columns[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        int i = 0;
                        while (i < dt.Rows.Count)
                        {
                            dataGridViewVaccine.Rows[i++].Height = 100;
                            dataGridViewVaccine.Columns[0].Width = 100;
                        }
                        labelListVacc.Text = "Štićenici sa imenom " + textBoxName.Text + ":";

                    }
                    else if (dt.Rows.Count == 1)
                    {
                        if (dt.Rows[0][0].Equals(""))
                        {
                            pictureBoxAnimal.Image = null;
                        }
                        else
                        {
                            byte[] bytes = (byte[])(dt.Rows[0][0]);
                            MemoryStream ms = new MemoryStream(bytes);
                            pictureBoxAnimal.Image = Image.FromStream(ms);
                        }


                        labelID.Text = dt.Rows[0][1].ToString();
                        textBoxName.Text = dt.Rows[0][2].ToString();
                        try
                        {
                            SqlConnection conS = new SqlConnection(conStr);
                            string strS = "Select Sticenik.Slika,Sticenik.ID,Sticenik.Ime, Vakcinacija.ID as [ID_V],Vakcinacija.Vrsta as [Vrsta vakcine], Vakcinacija.Datum as [Datum vakcinacije],Vakcinacija.Ambulanta, Vakcinacija.Doktor as Veterinar, Vakcinacija.Datum_U, Vakcinacija.ID_U, Vakcinacija.Datum_A, " +
                                "Vakcinacija.ID_A from Sticenik join Vakcinacija on Vakcinacija.ID_S=Sticenik.ID where Sticenik.ID='" + labelID.Text + "'";// where Datum>CURRENT_TIMESTAMP-358";
                            SqlCommand cmdS = new SqlCommand(strS, conS);
                            conS.Open();
                            DataTable dtS = new DataTable();
                            SqlDataAdapter sqlDataAdapterS = new SqlDataAdapter(cmdS);
                            sqlDataAdapterS.Fill(dtS);
                            conS.Close();
                            if (dtS.Rows.Count > 0)
                            {
                                dataGridViewVaccine.DataSource = dtS;
                                DataGridViewColumn column = dataGridViewVaccine.Columns[0];
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                ((DataGridViewImageColumn)dataGridViewVaccine.Columns[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                                int i = 0;
                                while (i <= dt.Rows.Count)
                                {
                                    dataGridViewVaccine.Rows[i++].Height = 100;
                                    dataGridViewVaccine.Columns[0].Width = 100;
                                }
                                labelListVacc.Text = "Vakcinacije štićenika " + textBoxName.Text + ":";

                            }
                            else
                                MessageBox.Show("Štićenik "+textBoxName.Text+" nema podatke o vakcinaciji!","Obvaještenje");


                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        dataGridViewVaccine.ClearSelection();

                    }
                    else
                        MessageBox.Show("Štićenik sa imenom " + textBoxName.Text + " nije pronađen u bazi podataka.", "Obavještenje");


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
                MessageBox.Show("Popunite polje ime za pretragu!","Obavještenje");
        }

        private void iconBtnViewSingleVaccine_Click(object sender, EventArgs e)
        {
            if (labelID.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(conStr);
                    string str = "Select Sticenik.Slika,Sticenik.ID,Sticenik.Ime,Vakcinacija.ID as [ID_V], Vakcinacija.Vrsta as [Vrsta vakcine], " +
                        "Vakcinacija.Datum as [Datum vakcinacije],Vakcinacija.Ambulanta, Vakcinacija.Doktor as Veterinar, Vakcinacija.Datum_U, Vakcinacija.ID_U, Vakcinacija.Datum_A, " +
                        "Vakcinacija.ID_A from Sticenik join Vakcinacija on Vakcinacija.ID_S=Sticenik.ID where Sticenik.ID='" + labelID.Text + "'";// where Datum>CURRENT_TIMESTAMP-358";
                    SqlCommand cmd = new SqlCommand(str, con);
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count > 0)
                    {

                        dataGridViewVaccine.DataSource = dt;
                        DataGridViewColumn column = dataGridViewVaccine.Columns[0];
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        ((DataGridViewImageColumn)dataGridViewVaccine.Columns[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        int i = 0;
                        while (i < dt.Rows.Count)
                        {
                            dataGridViewVaccine.Rows[i++].Height = 100;
                            dataGridViewVaccine.Columns[0].Width = 100;
                        }
                        labelListVacc.Text = "Vakcinacije štićenika " + textBoxName.Text;
                    }
                    else
                        MessageBox.Show("Štićenik " + textBoxName.Text + " nema podatke o vakcinaciji!", "Obvaještenje");

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                dataGridViewVaccine.ClearSelection();
            }
            else
                MessageBox.Show("Popunite polje ID štićenika za izlistavanje vakcinacija!", "Obavještenje");
        }

        private void iconBtnClear_Click(object sender, EventArgs e)
        {
            textBoxDoctor.Text = "";
            comboBoxVaccineType.SelectedIndex = -1;
            comboBoxHospital.SelectedIndex = -1;
            datePicker.Text = "";
            vaccineID = "";
        }

        private void iconBtnEdit_Click(object sender, EventArgs e)
        {
            if (vaccineID != "")
            {
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite ažurirati podatke o vakcinaciji sa indeksom " + vaccineID + "?", "Upozorenje!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(conStr);
                        string str = "Update Vakcinacija set Vrsta=@type,Ambulanta=@hospital,Doktor=@vet,Datum=@dat, Datum_A=@datA, ID_A=@idA where ID=@id";
                        SqlCommand cmd = new SqlCommand(str, con);

                        cmd.Parameters.AddWithValue("@type", comboBoxVaccineType.Text);
                        cmd.Parameters.AddWithValue("@hospital", comboBoxHospital.Text);
                        cmd.Parameters.AddWithValue("@vet", textBoxDoctor.Text);
                        cmd.Parameters.AddWithValue("@dat", datePicker.Value.ToString());
                        DateTime datetime = DateTime.UtcNow.Date;
                        cmd.Parameters.AddWithValue("@datA", datetime.ToString());
                        cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                        cmd.Parameters.AddWithValue("@id", vaccineID);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                            MessageBox.Show("Uspješno ste ažurirali podatke o vakcinaciji!", "Obavještenje");
                        else
                            MessageBox.Show("Došlo je do greške prilikom ažuriranja podataka o vakcinaciji!", "Obavještenje");


                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
                    
            }
            else
                MessageBox.Show("Odaberite vakcinaciju koju želite ažurirati!", "Obavještenje");
        }

        private void iconBtnAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text!="" && labelID.Text!="" && textBoxDoctor.Text!="" && comboBoxHospital.Text!="" && comboBoxVaccineType.Text!="" && datePicker.Text!="")
            {
                
                try
                {
                    SqlConnection con = new SqlConnection(conStr);
                    string str = "Insert into Vakcinacija (ID_S, Vrsta, Ambulanta, Doktor, Datum, Datum_U, ID_U Datum_A, ID_A) Values (@id, @type, @hospital, @vet, @dat, @datU, @idU, @datA, @idA)";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.Parameters.AddWithValue("@id", labelID.Text);
                    cmd.Parameters.AddWithValue("@type", comboBoxVaccineType.Text);
                    cmd.Parameters.AddWithValue("@hospital", comboBoxHospital.Text);
                    cmd.Parameters.AddWithValue("@vet", textBoxDoctor.Text);
                    cmd.Parameters.AddWithValue("@dat", datePicker.Value.ToString());
                    DateTime datetime = DateTime.UtcNow.Date;
                    cmd.Parameters.AddWithValue("@datU", datetime.ToString());
                    cmd.Parameters.AddWithValue("@idU", Dashboard.dashID);
                    cmd.Parameters.AddWithValue("@datA", datetime.ToString());
                    cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Uspješno ste unijeli podatke o vakcinaciji!", "Obavještenje");
                    else
                        MessageBox.Show("Došlo je do greške prilikom unosa podataka o vakcinaciji!", "Obavještenje");


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                

            }
            else
                MessageBox.Show("Za unos je potrebno popuniti sva polja!", "Obavještenje");
        }
    }
}
