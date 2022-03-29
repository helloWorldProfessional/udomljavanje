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
    public partial class Usvajanje : Form
    {
        public Usvajanje()
        {
            InitializeComponent();
        }
        string conStr = "Server= computer_name; Database = Adoption; Integrated Security = true";
        string idOwner="";
        // Animal information
        private void iconBtnViewAnimals_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select*from Sticenik where Dostupnost like 'Dostup%'";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                dataGridViewAnimals.DataSource = dt;
                con.Close();

                DataGridViewColumn column = dataGridViewAnimals.Columns[1];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ((DataGridViewImageColumn)dataGridViewAnimals.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                int i = 0;
                while (i<dt.Rows.Count)
                {
                    dataGridViewAnimals.Rows[i++].Height = 200;
                    dataGridViewAnimals.Columns[1].Width = 200;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            dataGridViewAnimals.ClearSelection();
        }

        private void dataGridViewAnimals_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBoxAnimal.Image = null;
            labelID.Text = "";
            textBoxName.Text = "";
            textBoxBreed.Text = "";
            textBoxColor.Text = "";
            comboBoxType.SelectedIndex = -1;
            textBoxWeight.Text = "";
            comboBoxSize.SelectedIndex = -1;
            datePickerOld.Text = "";
            comboBoxGender.SelectedIndex = -1;
            textBoxComment.Text = "";
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (!string.IsNullOrEmpty(dataGridViewAnimals.Rows[e.RowIndex].Cells[1].Value.ToString()))
                {
                    byte[] bytes = (byte[])
                    dataGridViewAnimals.Rows[e.RowIndex].Cells[1].Value;
                    MemoryStream ms = new MemoryStream(bytes);
                    pictureBoxAnimal.Image = Image.FromStream(ms);

                }
                labelID.Text= dataGridViewAnimals.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBoxName.Text = dataGridViewAnimals.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBoxType.Text = dataGridViewAnimals.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBoxGender.Text = dataGridViewAnimals.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBoxBreed.Text = dataGridViewAnimals.Rows[e.RowIndex].Cells[5].Value.ToString();
                datePickerOld.Text = dataGridViewAnimals.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBoxColor.Text = dataGridViewAnimals.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboBoxSize.Text = dataGridViewAnimals.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBoxWeight.Text = dataGridViewAnimals.Rows[e.RowIndex].Cells[9].Value.ToString();
                textBoxComment.Text = dataGridViewAnimals.Rows[e.RowIndex].Cells[20].Value.ToString();
            }
            dataGridViewAnimals.ClearSelection();



        }

        private void iconBtnClear_Click(object sender, EventArgs e)
        {
            pictureBoxAnimal.Image = null;
            labelID.Text = "";
            textBoxName.Text = "";
            textBoxBreed.Text = "";
            textBoxColor.Text = "";
            comboBoxType.SelectedIndex = -1;
            textBoxWeight.Text = "";
            comboBoxSize.SelectedIndex = -1;
            datePickerOld.Text = "";
            comboBoxGender.SelectedIndex = -1;
            textBoxComment.Text = "";
            dataGridViewAnimals.ClearSelection();
        }

        private void iconBtnSearchByName_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select *from Sticenik where Ime =N'"+ textBoxName.Text + "' and Dostupnost like 'Dostup%'";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 1)
                {
                    dataGridViewAnimals.DataSource = dt;
                    DataGridViewColumn column = dataGridViewAnimals.Columns[1];
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    ((DataGridViewImageColumn)dataGridViewAnimals.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        dataGridViewAnimals.Rows[i++].Height = 200;
                        dataGridViewAnimals.Columns[1].Width = 200;
                    }
                    dataGridViewAnimals.ClearSelection();

                }
                else if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][1].Equals(""))
                    {
                        pictureBoxAnimal.Image = null;

                    }
                    else
                    {
                        byte[] bytes = (byte[])(dt.Rows[0][1]);
                        MemoryStream ms = new MemoryStream(bytes);
                        pictureBoxAnimal.Image = Image.FromStream(ms);
                    }

                    labelID.Text = dt.Rows[0][0].ToString();
                    textBoxName.Text = dt.Rows[0][2].ToString();
                    comboBoxType.Text = dt.Rows[0][3].ToString();
                    comboBoxGender.Text = dt.Rows[0][4].ToString();
                    textBoxBreed.Text = dt.Rows[0][5].ToString();
                    datePickerOld.Text = dt.Rows[0][6].ToString();
                    textBoxColor.Text = dt.Rows[0][7].ToString();
                    comboBoxSize.Text = dt.Rows[0][8].ToString();
                    textBoxWeight.Text = dt.Rows[0][9].ToString();
                    textBoxComment.Text = dt.Rows[0][20].ToString();
                    
                }
                else
                {
                    if(dt.Rows.Count<1)
                        MessageBox.Show("Štićenik sa imenom "+textBoxName.Text+" nije pronađen u bazi podataka.", "Obavještenje");
                    else
                        MessageBox.Show("Štićenik sa imenom " + textBoxName.Text + " nije dostupan za udomljavanje ili ne postoji u bazi podataka.", "Obavještenje");
                    
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void iconBtnSearchByGender_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select * from Sticenik where (Dostupnost like 'Dostup%' and Pol = N'"+comboBoxGender.Text+"')";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                dataGridViewAnimals.DataSource = dt;
                con.Close();
                DataGridViewColumn column = dataGridViewAnimals.Columns[1];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                ((DataGridViewImageColumn)dataGridViewAnimals.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                int i=0;
                while (i < dt.Rows.Count)
                {
                    dataGridViewAnimals.Rows[i++].Height = 200;
                    dataGridViewAnimals.Columns[1].Width = 200;
                }
                dataGridViewAnimals.ClearSelection();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void iconBtnSearchByType_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select * from Sticenik where (Dostupnost like 'Dostup%' and Vrsta = N'" + comboBoxType.Text + "')";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                dataGridViewAnimals.DataSource = dt;
                con.Close();
                DataGridViewColumn column = dataGridViewAnimals.Columns[1];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                ((DataGridViewImageColumn)dataGridViewAnimals.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    dataGridViewAnimals.Rows[i++].Height = 200;
                    dataGridViewAnimals.Columns[1].Width = 200;
                }
                dataGridViewAnimals.ClearSelection();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void iconBtnSearchBySize_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select * from Sticenik where (Dostupnost like 'Dostup%' and Velicina = N'" + comboBoxSize.Text + "')";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                dataGridViewAnimals.DataSource = dt;
                con.Close();
                DataGridViewColumn column = dataGridViewAnimals.Columns[1];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                ((DataGridViewImageColumn)dataGridViewAnimals.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    dataGridViewAnimals.Rows[i++].Height = 200;
                    dataGridViewAnimals.Columns[1].Width = 200;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        // Owner information
        private void iconBtnViewOwners_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select*from Usvajac";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                dataGridViewOwner.DataSource = dt;
                con.Close();
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            dataGridViewOwner.ClearSelection();
        }

        private void dataGridViewOwner_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                // Animal information
                pictureBoxAnimal.Image = null;
                labelID.Text = "";
                textBoxName.Text = "";
                textBoxBreed.Text = "";
                textBoxColor.Text = "";
                comboBoxType.SelectedIndex = -1;
                textBoxWeight.Text = "";
                comboBoxSize.SelectedIndex = -1;
                datePickerOld.Text = "";
                comboBoxGender.SelectedIndex = -1;
                textBoxComment.Text = "";
                try
                {
                    SqlConnection con = new SqlConnection(conStr);
                    string str = "Select *from Sticenik where ID_Vlasnik='" + dataGridViewOwner.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dt);
                    con.Close();

                    if (dt.Rows.Count > 1)
                    {
                        dataGridViewAnimals.DataSource = dt;
                        DataGridViewColumn column = dataGridViewAnimals.Columns[1];
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                        ((DataGridViewImageColumn)dataGridViewAnimals.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        int i = 0;
                        while (i < dt.Rows.Count)
                        {
                            dataGridViewAnimals.Rows[i++].Height = 200;
                            dataGridViewAnimals.Columns[1].Width = 200;
                        }

                    }
                    else if (dt.Rows.Count == 1)
                    {
                        if (dt.Rows[0][1].Equals(""))
                        {
                            pictureBoxAnimal.Image = null;

                        }
                        else
                        {
                            byte[] bytes = (byte[])(dt.Rows[0][1]);
                            MemoryStream ms = new MemoryStream(bytes);
                            pictureBoxAnimal.Image = Image.FromStream(ms);
                        }

                        labelID.Text = dt.Rows[0][0].ToString();
                        textBoxName.Text = dt.Rows[0][2].ToString();
                        comboBoxType.Text = dt.Rows[0][3].ToString();
                        comboBoxGender.Text = dt.Rows[0][4].ToString();
                        textBoxBreed.Text = dt.Rows[0][5].ToString();
                        datePickerOld.Text = dt.Rows[0][6].ToString();
                        textBoxColor.Text = dt.Rows[0][7].ToString();
                        comboBoxSize.Text = dt.Rows[0][8].ToString();
                        textBoxWeight.Text = dt.Rows[0][9].ToString();
                        textBoxComment.Text = dt.Rows[0][20].ToString();
                        

                    }
                    else
                    {
                        /// do nothing
                    }

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

                // Owner information
                textBoxOwnerName.Text = "";
                textBoxOwnerLName.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
                textBoxAdress.Text = "";
                dateTimePickerDateOfBirthOwner.Text = "";
                idOwner = "";

                textBoxOwnerName.Text = dataGridViewOwner.Rows[e.RowIndex].Cells[1].Value.ToString(); 
                textBoxOwnerLName.Text = dataGridViewOwner.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateTimePickerDateOfBirthOwner.Text= dataGridViewOwner.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBoxAdress.Text = dataGridViewOwner.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBoxPhone.Text = dataGridViewOwner.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBoxEmail.Text = dataGridViewOwner.Rows[e.RowIndex].Cells[6].Value.ToString();
                idOwner= dataGridViewOwner.Rows[e.RowIndex].Cells[0].Value.ToString();
                
            }
            dataGridViewOwner.ClearSelection();
        }

        private void iconBtnSearchByDateOfBirth_Click(object sender, EventArgs e)
        {
            idOwner = "";
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select * from Usvajac where Datum_R='"+ dateTimePickerDateOfBirthOwner.Value.ToString()+ "'";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                con.Close();
                
                if (dt.Rows.Count > 1)
                {
                    dataGridViewOwner.DataSource = dt;
                    
                }
                else if (dt.Rows.Count == 1)
                {
                    
                    textBoxOwnerName.Text = dt.Rows[0][1].ToString();
                    textBoxOwnerLName.Text = dt.Rows[0][2].ToString();
                    dateTimePickerDateOfBirthOwner.Text = dt.Rows[0][3].ToString();
                    textBoxAdress.Text = dt.Rows[0][4].ToString();
                    textBoxPhone.Text = dt.Rows[0][5].ToString();
                    textBoxEmail.Text = dt.Rows[0][6].ToString();
                    idOwner = dt.Rows[0][0].ToString();
                    
                }
                else
                {
                    MessageBox.Show("Usvajač nije pronađen u bazi podataka.", "Obavještenje");
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void iconBtnClearOwner_Click(object sender, EventArgs e)
        {
            textBoxOwnerName.Text = "";
            textBoxOwnerLName.Text = "";
            textBoxPhone.Text = "";
            textBoxEmail.Text = "";
            textBoxAdress.Text = "";
            dateTimePickerDateOfBirthOwner.Text = "";
            idOwner = "";
        }

        private void iconBtnDeleteEntry_Click(object sender, EventArgs e)
        {

            if (idOwner=="")
            {
                MessageBox.Show("Unesite podatke koje želite obrisati!", "Obavještenje");
            }
            else
            {
                try
                {
                    SqlConnection conA = new SqlConnection(conStr);
                    string strA = "Select Usvajac.Ime, Usvajac.Prezime, Sticenik.ID, Sticenik.Pol from Usvajac join Sticenik on Sticenik.ID_Vlasnik = Usvajac.ID where Sticenik.ID_Vlasnik = '" + idOwner+"'";
                    SqlCommand cmdA = new SqlCommand(strA, conA);
                    conA.Open();
                    DataTable dtA = new DataTable();
                    SqlDataAdapter sqlDataAdapterA = new SqlDataAdapter(cmdA);
                    sqlDataAdapterA.Fill(dtA);
                    conA.Close();
                    
                    DialogResult dialogResult = MessageBox.Show("Da li ste sigurno da želite izbrisati usvajača " + dtA.Rows[0][0].ToString() + " " + dtA.Rows[0][1].ToString() + "  čiji je ID=" + idOwner + "?", "Upozorenje!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes && Dashboard.dashStatus != "Volonter")
                    {
                        DialogResult dialogResultAnimal = MessageBox.Show("Usvajač " + dtA.Rows[0][0].ToString() + " " + dtA.Rows[0][1].ToString() + " je vlasnik " + dtA.Rows.Count + " štićenika. Da li želite izbrisati i podatke o štićenicima?", "Upozorenje!", MessageBoxButtons.YesNo);
                        if (dialogResultAnimal == DialogResult.Yes)
                        {
                            SqlConnection con = new SqlConnection(conStr);
                            string str = "Delete from Sticenik where ID_Vlasnik='" + idOwner + "'";
                            SqlCommand cmd = new SqlCommand(str, con);
                            con.Open();
                            int result=cmd.ExecuteNonQuery();
                            con.Close();
                            if (result > 0)
                            {
                                MessageBox.Show("Uspješno ste izbrisali podatke o štićeniku/štićenicima čiji je vlasnik " + dtA.Rows[0][0].ToString() + " " + dtA.Rows[0][1].ToString() + "!", "Obavještenje");
                                string strOwner= "Delete from Usvajac where ID = '" + idOwner + "'";
                                SqlCommand cmd2 = new SqlCommand(strOwner, con);
                                con.Open();
                                int r = cmd2.ExecuteNonQuery();
                                con.Close();
                                if (r > 0)
                                {
                                    MessageBox.Show("Uspješno ste izbrisali podatke o usvajaču " + dtA.Rows[0][0].ToString() + " " + dtA.Rows[0][1].ToString() + "  čiji je ID=" + idOwner + "!", "Obavještenje");
                                }
                                else
                                    MessageBox.Show("Došlo je do greške prilikom brisanja usvajača!", "Obavještenje");

                            }
                            else
                                MessageBox.Show("Došlo je do greške prilikom brisanja štićenika!", "Obavještenje");
                            
                        }
                        else
                        {
                            SqlConnection con = new SqlConnection(conStr);
                            string str = "Update Sticenik set Dostupnost=@available, ID_Vlasnik=@owner, Datum_A=@datA, ID_A=@idA, Datum_Usvajanja=@datAdopt where ID_Vlasnik=@idOwner";
                            SqlCommand cmd = new SqlCommand(str, con);

                            if (dtA.Rows[0][3].ToString() == "M")
                                cmd.Parameters.AddWithValue("@available", "Dostupan");
                            else
                                cmd.Parameters.AddWithValue("@available", "Dostupna");
                            cmd.Parameters.AddWithValue("@owner", idOwner).Value = DBNull.Value;
                            DateTime dateTime = DateTime.UtcNow.Date;
                            cmd.Parameters.AddWithValue("@datA", dateTime.ToString());
                            cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                            cmd.Parameters.AddWithValue("@datAdopt", idOwner).Value = DBNull.Value;
                            cmd.Parameters.AddWithValue("@idOwner", idOwner);

                            con.Open();
                            int result = cmd.ExecuteNonQuery();
                            con.Close();
                            if (result > 0)
                            {
                                SqlConnection conU = new SqlConnection(conStr);
                                MessageBox.Show("Uspješno ste ažurirači podatke o štićeniku/štićenicima čiji je vlasnik " + dtA.Rows[0][0].ToString() + " " + dtA.Rows[0][1].ToString() + "!", "Obavještenje");
                                string strOwner = "Delete from Usvajac where ID = '" + idOwner + "'";
                                SqlCommand cmd2 = new SqlCommand(strOwner, conU);
                                conU.Open();
                                int r = cmd2.ExecuteNonQuery();
                                conU.Close();
                                if (r > 0)
                                {
                                    MessageBox.Show("Uspješno ste izbrisali podatke o usvajaču " + dtA.Rows[0][0].ToString() + " " + dtA.Rows[0][1].ToString() + "!", "Obavještenje");
                                }
                                else
                                    MessageBox.Show("Došlo je do greške prilikom brisanja usvajača!", "Obavještenje");
                            }
                            else
                                MessageBox.Show("Došlo je do greške prilikom ažuriranja štićenika!", "Obavještenje");
                            
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void iconBtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = "";
                string lname = "";
            
                if (idOwner!="" && Dashboard.dashStatus=="Admin")
                {
                
                    SqlConnection con = new SqlConnection(conStr);
                    string str = "Select Ime, Prezime from Usvajac where ID='" + idOwner + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dt);
                    con.Close();
                    name = dt.Rows[0][0].ToString();
                    lname = dt.Rows[0][1].ToString();
                    DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite ažurirati sve podatke o usvajaču "+name+" "+ lname + " sa indeksom " + idOwner + "?", "Upozorenje!", MessageBoxButtons.YesNo);
                    if (dialogResult==DialogResult.Yes)
                    {
                        SqlConnection conU = new SqlConnection(conStr);
                        string strU = "Update Usvajac set Ime=@name, Prezime=@lname, Datum_R=@datR, Adresa=@adress, Telefon=@phone, email=@email, Datum_A=@datA, ID_A=@idA  where ID=@id";
                        SqlCommand cmdU = new SqlCommand(strU, conU);
                        conU.Open();
                        cmdU.Parameters.AddWithValue("@name", textBoxOwnerName.Text);
                        cmdU.Parameters.AddWithValue("@lname", textBoxOwnerLName.Text);
                        cmdU.Parameters.AddWithValue("@datR", dateTimePickerDateOfBirthOwner.Value.ToString());
                        cmdU.Parameters.AddWithValue("@adress", textBoxAdress.Text);
                        cmdU.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                        cmdU.Parameters.AddWithValue("@email", textBoxEmail.Text);
                        DateTime dateTime = DateTime.UtcNow.Date;
                        cmdU.Parameters.AddWithValue("@datA", dateTime.ToString());
                        cmdU.Parameters.AddWithValue("@idA", Dashboard.dashID);
                        cmdU.Parameters.AddWithValue("@id", idOwner);

                        int result= cmdU.ExecuteNonQuery();
                        conU.Close();
                        if (result > 0)
                            MessageBox.Show("Uspješno ste ažurirali podatke usvajača "+dt.Rows[0][0].ToString()+" "+ dt.Rows[0][1].ToString() + "!","Obavještenje");
                        else
                            MessageBox.Show("Došlo je do greške prilikom ažuriranja!", "Obavještenje");
                    }
                }
                else if (idOwner != "" && Dashboard.dashStatus != "Volonter")
                {
                    SqlConnection con = new SqlConnection(conStr);
                    string str = "Update Usvajac set Adresa=@adress, Telefon=@phone, email=@email, Datum_A=@datA, ID_A=@idA  where ID=@id";
                    SqlCommand cmd = new SqlCommand(str, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@adress", textBoxAdress.Text);
                    cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                    cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                    DateTime dateTime = DateTime.UtcNow.Date;
                    cmd.Parameters.AddWithValue("@datA", dateTime.ToString());
                    cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                    cmd.Parameters.AddWithValue("@id", idOwner);
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                        MessageBox.Show("Uspješno ste ažurirali podatke usvajača " + name + " " + lname + "!", "Obavještenje");
                    else
                        MessageBox.Show("Došlo je do greške prilikom ažuriranja!", "Obavještenje");
                }
                else
                {
                    if(idOwner=="")
                        MessageBox.Show("Unesite ID usvajača čije podatke želite ažurirati!", "Obavještenje");
                    else
                        MessageBox.Show("Niste ovlašteni za ažuriranje podataka!", "Obavještenje");
                }

            }
            catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            idOwner = "";
        }
        
        private void iconBtnAdd_Click(object sender, EventArgs e)
        {
            if (Dashboard.dashStatus != "Volonter")
            {
                if (labelID.Text != "" && textBoxOwnerName.Text != "" && textBoxOwnerName.Text != "" && dateTimePickerDateOfBirthOwner.Text != "" && textBoxPhone.Text != "")
                {
                    try
                    {
                        string num = "";
                        SqlConnection conCheck = new SqlConnection(conStr);
                        string strCheck = "Select ID from Usvajac where Ime=N'" + textBoxOwnerName.Text + "' and Prezime=N'" + textBoxOwnerLName.Text + "' " +
                            "and Datum_R='" + dateTimePickerDateOfBirthOwner.Value.ToString() + "' and Telefon='" + textBoxPhone.Text + "' " +
                            "and Adresa=N'" + textBoxAdress.Text + "' and email=N'" + textBoxEmail.Text + "'";
                        SqlCommand cmdCHeck = new SqlCommand(strCheck, conCheck);
                        conCheck.Open();
                        using (SqlDataReader sqlDataReader = cmdCHeck.ExecuteReader())
                        {
                            if (sqlDataReader.Read())
                            {
                                num = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ID")).ToString();
                            }
                        }
                        conCheck.Close();
                        if (!string.IsNullOrEmpty(num))
                        {
                            MessageBox.Show("Unos je onemogućen! Korisnik postoji u bazi podataka a njegov ID=" + num, "Obavještenje");
                        }
                        else
                        {
                            
                            SqlConnection con = new SqlConnection(conStr);
                            string str = "Insert into Usvajac  (Ime, Prezime, Datum_R, Adresa, Telefon, email, Datum_U, ID_U, Datum_A, ID_A)" +
                            "Values(@name, @lname, @datR, @adress, @phone, @email, @datU, @idU, @datA, @idA)";

                            SqlCommand cmd = new SqlCommand(str, con);
                            cmd.Parameters.AddWithValue("@name", textBoxOwnerName.Text);
                            cmd.Parameters.AddWithValue("@lname", textBoxOwnerLName.Text);
                            cmd.Parameters.AddWithValue("@datR", dateTimePickerDateOfBirthOwner.Value.ToString());
                            cmd.Parameters.AddWithValue("@adress", textBoxAdress.Text);
                            cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                            cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                            DateTime dateTime = DateTime.UtcNow.Date;
                            cmd.Parameters.AddWithValue("@datU", dateTime.ToString());
                            cmd.Parameters.AddWithValue("@idU", Dashboard.dashID);
                            cmd.Parameters.AddWithValue("@datA", dateTime.ToString());
                            cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                            con.Open();
                            int result = cmd.ExecuteNonQuery();
                            con.Close();
                            if (result > 0)
                            {
                                SqlConnection conS = new SqlConnection(conStr);
                                string strS = "Select ID from Usvajac where Ime=N'" + textBoxOwnerName.Text + "' and Prezime=N'" + textBoxOwnerLName.Text + "' " +
                                    "and Datum_R='" + dateTimePickerDateOfBirthOwner.Value.ToString() + "' and Telefon='" + textBoxPhone.Text + "'";
                                SqlCommand cmdS = new SqlCommand(strS, conS);
                                conS.Open();
                                using (SqlDataReader sqlDataReader = cmdS.ExecuteReader())
                                {
                                    if (sqlDataReader.Read())
                                    {
                                        idOwner = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ID")).ToString();
                                    }
                                }
                                conS.Close();

                                SqlConnection conU = new SqlConnection(conStr);
                                string strU = "Update Sticenik set Dostupnost=@available, ID_Vlasnik=@idOwner, Datum_A=@datA, ID_A=@idA, Datum_Usvajanja=@datAdopt where ID=@id";
                                SqlCommand cmdU = new SqlCommand(strU, conU);

                                if (comboBoxGender.Text == "M")
                                    cmdU.Parameters.AddWithValue("@available", "Udomljen");
                                else
                                    cmdU.Parameters.AddWithValue("@available", "Udomljena");
                                cmdU.Parameters.AddWithValue("@idOwner", idOwner);
                                DateTime date = DateTime.UtcNow.Date;
                                cmdU.Parameters.AddWithValue("@datA", date.ToString());
                                cmdU.Parameters.AddWithValue("@idA", Dashboard.dashID);
                                cmdU.Parameters.AddWithValue("@datAdopt", date.ToString());
                                cmdU.Parameters.AddWithValue("@id", labelID.Text);
                                conU.Open();
                                int r = cmdU.ExecuteNonQuery();
                                conU.Close();
                                if (r > 0)
                                    MessageBox.Show(textBoxOwnerName.Text + " " + textBoxOwnerLName.Text + " uspješno je udomio/udomila štićenika " + textBoxName.Text + "!", "Čestitamo!");
                                else
                                    MessageBox.Show("Došlo je do greške prilikom udomljavanja!", "Obavještenje");
                            }
                            else
                                MessageBox.Show("Došlo je do greške prilikom unosa podataka o usvajaču!", "Obavještenje");
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
                else
                    MessageBox.Show("Obavezno je popuniti polja Ime, Prezime, Datum rođenja, Telefon i ID štićenika kojeg želite udomiti!", "Obavještenje");
                
            }
            else
                MessageBox.Show("Niste ovlašteni da unosite podatke u bazu podataka!", "Obavještenje");
            idOwner = "";
        }
    }
}
