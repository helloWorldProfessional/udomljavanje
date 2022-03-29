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
    public partial class Terapija : Form
    {
        public Terapija()
        {
            InitializeComponent();
        }
        string conStr = "Server= computer_name; Database = Adoption; Integrated Security = true";
        string medsID = "";
        
        private void iconBtnViewPendingMeds_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select Sticenik.Slika, Terapija.ID_S as ID,Sticenik.Ime, Terapija.ID as [ID_T],Terapija.Lijek," +
                    "Terapija.Količina,Terapija.Početak,Terapija.Kraj,Terapija.Doktor as Veterinar,Terapija.Ambulanta, Sticenik.Box, " +
                    "Terapija.Datum_U, Terapija.ID_U, Terapija.Datum_A, Terapija.ID_A from Sticenik join Terapija on Terapija.ID_S = Sticenik.ID" +
                    " where Terapija.Kraj > CURRENT_TIMESTAMP and Sticenik.Dostupnost like 'Dostup%'";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                dataGridViewMeds.DataSource = dt;
                con.Close();
                DataGridViewColumn column = dataGridViewMeds.Columns[0];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ((DataGridViewImageColumn)dataGridViewMeds.Columns[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    dataGridViewMeds.Rows[i++].Height = 100;
                    dataGridViewMeds.Columns[0].Width = 100;
                }
                labelTitle.Text = "Primaju terapiju:";
            

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            dataGridViewMeds.ClearSelection();
        }

        private void iconBtnViewAllMeds_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select Sticenik.Slika, Terapija.ID_S as ID,Sticenik.Ime, Terapija.ID as [ID_T],Terapija.Lijek," +
                    "Terapija.Količina,Terapija.Početak,Terapija.Kraj,Terapija.Doktor as Veterinar,Terapija.Ambulanta, Sticenik.Box, " +
                    "Terapija.Datum_U, Terapija.ID_U, Terapija.Datum_A, Terapija.ID_A from Sticenik join Terapija on Terapija.ID_S=Sticenik.ID";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                dataGridViewMeds.DataSource = dt;
                con.Close();
                DataGridViewColumn column = dataGridViewMeds.Columns[0];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ((DataGridViewImageColumn)dataGridViewMeds.Columns[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    dataGridViewMeds.Rows[i++].Height = 100;
                    dataGridViewMeds.Columns[0].Width = 100;
                }
                labelTitle.Text = "Prikaz svih dosadašnjih terapija:";


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            dataGridViewMeds.ClearSelection();
        }

        private void dataGridViewMeds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBoxAnimal.Image = null;
            labelID.Text = "";
            textBoxName.Text = "";
            textBoxDoctor.Text = "";
            textBoxMeds.Text = "";
            textBoxMedsDose.Text = "";
            comboBoxHospital.SelectedIndex = -1;
            datePickerBeginning.Text = "";
            datePickerEnd.Text = "";
            medsID = "";
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (!string.IsNullOrEmpty(dataGridViewMeds.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    byte[] bytes = (byte[])
                    dataGridViewMeds.Rows[e.RowIndex].Cells[0].Value;
                    MemoryStream ms = new MemoryStream(bytes);
                    pictureBoxAnimal.Image = Image.FromStream(ms);

                }
                
                if (dataGridViewMeds.Columns.Count < 5)
                {
                    labelID.Text = dataGridViewMeds.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textBoxName.Text = dataGridViewMeds.Rows[e.RowIndex].Cells[2].Value.ToString();
                    medsID = "";
                }
                else
                {
                    labelID.Text = dataGridViewMeds.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textBoxName.Text = dataGridViewMeds.Rows[e.RowIndex].Cells[2].Value.ToString();
                    medsID = dataGridViewMeds.Rows[e.RowIndex].Cells[3].Value.ToString();
                    textBoxMeds.Text = dataGridViewMeds.Rows[e.RowIndex].Cells[4].Value.ToString();
                    textBoxMedsDose.Text = dataGridViewMeds.Rows[e.RowIndex].Cells[5].Value.ToString();
                    datePickerBeginning.Text = dataGridViewMeds.Rows[e.RowIndex].Cells[6].Value.ToString();
                    datePickerEnd.Text = dataGridViewMeds.Rows[e.RowIndex].Cells[7].Value.ToString();
                    textBoxDoctor.Text = dataGridViewMeds.Rows[e.RowIndex].Cells[8].Value.ToString();
                    comboBoxHospital.Text = dataGridViewMeds.Rows[e.RowIndex].Cells[9].Value.ToString();
                }
            }
            dataGridViewMeds.ClearSelection();

        }

        private void iconBtnSearchByName_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(conStr);
                    string str = "Select Slika, ID, Ime from Sticenik where Ime =N'" + textBoxName.Text + "' and Dostupnost like 'Dostup%'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dt);

                    if (dt.Rows.Count > 1)
                    {
                        dataGridViewMeds.DataSource = dt;
                        DataGridViewColumn column = dataGridViewMeds.Columns[0];
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        ((DataGridViewImageColumn)dataGridViewMeds.Columns[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        int i = 0;
                        while (i < dt.Rows.Count)
                        {
                            dataGridViewMeds.Rows[i++].Height = 100;
                            dataGridViewMeds.Columns[0].Width = 100;
                        }
                        labelTitle.Text = "Štićenici sa imenom " + textBoxName.Text + ":";

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
                            string strS = "Select Sticenik.Slika, Terapija.ID_S as ID,Sticenik.Ime, Terapija.ID as [ID_T],Terapija.Lijek," +
                            "Terapija.Količina,Terapija.Početak,Terapija.Kraj,Terapija.Doktor as Veterinar,Terapija.Ambulanta, Sticenik.Box, " +
                            "Terapija.Datum_U, Terapija.ID_U, Terapija.Datum_A, Terapija.ID_A from Sticenik join Terapija on Terapija.ID_S=Sticenik.ID where Terapija.ID_S='"+labelID.Text+"'";

                            SqlCommand cmdS = new SqlCommand(strS, conS);
                            conS.Open();
                            DataTable dtS = new DataTable();
                            SqlDataAdapter sqlDataAdapterS = new SqlDataAdapter(cmdS);
                            sqlDataAdapterS.Fill(dtS);
                            conS.Close();
                            if (dtS.Rows.Count > 0)
                            {
                                dataGridViewMeds.DataSource = dtS;
                                DataGridViewColumn column = dataGridViewMeds.Columns[0];
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                ((DataGridViewImageColumn)dataGridViewMeds.Columns[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                                int i = 0;
                                while (i < dt.Rows.Count)
                                {
                                    dataGridViewMeds.Rows[i++].Height = 100;
                                    dataGridViewMeds.Columns[0].Width = 100;
                                }
                               labelTitle.Text = "Terapije štićenika " + textBoxName.Text + ":";

                            }
                            else
                                MessageBox.Show("Štićenik " + textBoxName.Text + " nema podatke o terapijama!", "Obvaještenje");
                            
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        dataGridViewMeds.ClearSelection();

                    }
                    else
                        MessageBox.Show("Štićenik sa imenom " + textBoxName.Text + " nije pronađen u bazi podataka ili je udomljen.", "Obavještenje");
                    
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
                MessageBox.Show("Popunite polje ime za pretragu!", "Obavještenje");
        }

        private void iconBtnClear_Click(object sender, EventArgs e)
        {
            pictureBoxAnimal.Image = null;
            textBoxDoctor.Text = "";
            textBoxMeds.Text = "";
            textBoxMedsDose.Text = "";
            comboBoxHospital.SelectedIndex = -1;
            datePickerBeginning.Text = "";
            datePickerEnd.Text = "";
            medsID = "";
            dataGridViewMeds.ClearSelection();
        }

        private void iconBtnViewSingleMeds_Click(object sender, EventArgs e)
        {
           
            if (labelID.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(conStr);
                    string str = "Select Sticenik.Slika, Terapija.ID_S as ID,Sticenik.Ime, Terapija.ID as [ID_T],Terapija.Lijek," +
                            "Terapija.Količina,Terapija.Početak,Terapija.Kraj,Terapija.Doktor as Veterinar,Terapija.Ambulanta, Sticenik.Box, " +
                            "Terapija.Datum_U, Terapija.ID_U, Terapija.Datum_A, Terapija.ID_A from Sticenik join Terapija on " +
                            "Terapija.ID_S=Sticenik.ID where Terapija.ID_S='" + labelID.Text + "'";

                    SqlCommand cmd = new SqlCommand(str, con);
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count > 0)
                    {

                        dataGridViewMeds.DataSource = dt;
                        DataGridViewColumn column = dataGridViewMeds.Columns[0];
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        ((DataGridViewImageColumn)dataGridViewMeds.Columns[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        int i = 0;
                        while (i < dt.Rows.Count)
                        {
                            dataGridViewMeds.Rows[i++].Height = 100;
                            dataGridViewMeds.Columns[0].Width = 100;
                        }
                        labelTitle.Text = "Terapije štićenika " + textBoxName.Text+":";
                    }
                    else
                        MessageBox.Show("Štićenik " + textBoxName.Text + " nema podatke o terapijama!", "Obvaještenje");

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                dataGridViewMeds.ClearSelection();
            }
            else
                MessageBox.Show("Popunite polje ID štićenika za izlistavanje terapija!", "Obavještenje");
        }

        private void iconBtnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(labelID.Text);
            if (medsID != "")
            {
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite ažurirati podatke o terapiji sa indeksom " + medsID + "?", "Upozorenje!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(conStr);
                        string str = "Update Terapija set Lijek=@meds, Količina=@medsDose, Početak=@datB, Kraj=@datE, Doktor=@vet, " +
                            "Ambulanta=@hospital, Datum_A=@datA, ID_A=@idA where ID=@id";
                        SqlCommand cmd = new SqlCommand(str, con);

                        cmd.Parameters.AddWithValue("@meds", textBoxMeds.Text);
                        cmd.Parameters.AddWithValue("@medsDose", textBoxMedsDose.Text);
                        cmd.Parameters.AddWithValue("@datB", datePickerBeginning.Value.ToString());
                        cmd.Parameters.AddWithValue("@datE", datePickerEnd.Value.ToString());
                        cmd.Parameters.AddWithValue("@vet", textBoxDoctor.Text);
                        cmd.Parameters.AddWithValue("@hospital", comboBoxHospital.Text);
                        DateTime datetime = DateTime.UtcNow.Date;
                        cmd.Parameters.AddWithValue("@datA", datetime.ToString());
                        cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                        cmd.Parameters.AddWithValue("@id", medsID);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                            MessageBox.Show("Uspješno ste ažurirali podatke o terapiji!", "Obavještenje");
                        else
                            MessageBox.Show("Došlo je do greške prilikom ažuriranja podataka o terapiji!", "Obavještenje");


                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }

            }
            else
                MessageBox.Show("Odaberite terapiju koju želite ažurirati!", "Obavještenje");
        }

        private void iconBtnAdd_Click(object sender, EventArgs e)
        {
            if (labelID.Text != "" && textBoxName.Text != "" && textBoxDoctor.Text != "" && comboBoxHospital.Text != "" && textBoxMeds.Text != "" && textBoxMedsDose.Text != "" && datePickerBeginning.Text != "" && datePickerEnd.Text != "")
            {
                
                try
                {
                    SqlConnection con = new SqlConnection(conStr);
                    string str = "Insert into Terapija (ID_S, Lijek, Količina, Početak, Kraj, Doktor, Ambulanta,  Datum_U, ID_U, Datum_A, ID_A) " +
                        "Values (@idS, @meds, @medsDose, @datB, @datE, @vet, @hospital, @datU, @idU, @datA, @idA)";
                    SqlCommand cmd = new SqlCommand(str, con);

                    cmd.Parameters.AddWithValue("@idS", labelID.Text);
                    cmd.Parameters.AddWithValue("@meds", textBoxMeds.Text);
                    cmd.Parameters.AddWithValue("@medsDose", textBoxMedsDose.Text);
                    cmd.Parameters.AddWithValue("@datB", datePickerBeginning.Value.ToString());
                    cmd.Parameters.AddWithValue("@datE", datePickerEnd.Value.ToString());
                    cmd.Parameters.AddWithValue("@vet", textBoxDoctor.Text);
                    cmd.Parameters.AddWithValue("@hospital", comboBoxHospital.Text);
                    DateTime datetime = DateTime.UtcNow.Date;
                    cmd.Parameters.AddWithValue("@datU", datetime.ToString());
                    cmd.Parameters.AddWithValue("@idU", Dashboard.dashID);
                    cmd.Parameters.AddWithValue("@datA", datetime.ToString());
                    cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                    
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Uspješno ste unijeli podatke o terapiji!", "Obavještenje");
                    else
                        MessageBox.Show("Došlo je do greške prilikom unosa podataka o terapiji!", "Obavještenje");


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
