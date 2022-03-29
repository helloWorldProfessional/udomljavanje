using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlTypes;

namespace UZZZ_Dashboard
{

    public partial class Sticenici : Form
    {
        public Sticenici()
        {
            InitializeComponent();
        }
        
        int updateTrig = 0;
        int deleteTrig = 0;
        string conStr = "Server= computer_name; Database = Adoption; Integrated Security = true";

        private void iconBtnEnterPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog browse = new OpenFileDialog();
            browse.Filter = "Images(.jpg,.png,.bmp)|*.jpg;*.png;*.bmp";
            if (browse.ShowDialog() == DialogResult.OK)
            {
                pictureBoxAnimal.ImageLocation = browse.FileName.ToString();
                
            }
        }
        
        private void iconBtnAdd_Click(object sender, EventArgs e)
        {
            
            if (textBoxName.Text=="" || comboBoxType.Text=="" || comboBoxGender.Equals(""))
            {
                MessageBox.Show("Obavezno popuniti polja Ime, Pol, Vrsta","Upozorenje!");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(conStr);

                    string str = "Insert into Sticenik  (Ime, Vrsta, Pol, Rasa, Starost, Boja, Velicina, Kilaza, Dostupnost, Sterilizovan, Datum_U,ID_U,Datum_A, ID_A, Box, Komentar)" +
                       "Values(@name, @type, @gender, @breed, @old, @color, @size, @weight, @available, @steril, @datU,@idU,@datA, @idA, @box, @comment)";

                    SqlCommand cmd = new SqlCommand(str, con);

                    cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@type", comboBoxType.Text);
                    cmd.Parameters.AddWithValue("@gender", comboBoxGender.Text);
                    cmd.Parameters.AddWithValue("@breed", textBoxBreed.Text);
                    cmd.Parameters.AddWithValue("@old", datePickerOld.Value.ToString());
                    cmd.Parameters.AddWithValue("@color", textBoxColor.Text);
                    cmd.Parameters.AddWithValue("@size", comboBoxSize.Text);
                    if (textBoxWeight.Text == "")
                        cmd.Parameters.AddWithValue("@weight", textBoxWeight.Text).Value = DBNull.Value;
                    else
                        cmd.Parameters.AddWithValue("@weight", textBoxWeight.Text);

                    if (comboBoxAvailable.Text == "Udomljen" || comboBoxAvailable.Text == "Udomljena")
                        MessageBox.Show("Dostupnost svakog unesenog štićenika je Dostupan/a");
                        
                    else if (comboBoxGender.Text == "M")
                        cmd.Parameters.AddWithValue("@available", "Dostupan");
                    else
                        cmd.Parameters.AddWithValue("@available", "Dostupna");
                    
                    cmd.Parameters.AddWithValue("@steril", comboBoxSteril.Text);
                    DateTime dateTime = DateTime.UtcNow.Date;
                    cmd.Parameters.AddWithValue("@datU", dateTime.ToString());
                    cmd.Parameters.AddWithValue("@idU", Dashboard.dashID);
                    cmd.Parameters.AddWithValue("@datA", dateTime.ToString());
                    cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                    if (comboBOXNo.Text == "")
                        cmd.Parameters.AddWithValue("@box", comboBOXNo.Text).Value = DBNull.Value;
                    else
                        cmd.Parameters.AddWithValue("@box", comboBOXNo.Text);
                    cmd.Parameters.AddWithValue("@comment", textBoxComment.Text);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result > 0)
                    {
                        //check if image is null
                        bool isNullOrEmpty = pictureBoxAnimal == null || pictureBoxAnimal.Image == null;
                        if (comboBoxSteril.Text == "Da")
                        {
                            SqlConnection con1 = new SqlConnection(conStr);
                            String str1 = "Update Sticenik set Datum_S=@datS where ID=(select max(ID) from Sticenik)";
                            SqlCommand cmd1 = new SqlCommand(str1, con1);
                            cmd1.Parameters.AddWithValue("@datS", dateTimeSteril.Value.ToString());
                            con1.Open();
                            cmd1.ExecuteNonQuery();
                            con1.Close();
                        }
                        if (!isNullOrEmpty)
                        {
                            SqlConnection con1 = new SqlConnection(conStr);
                            String str1 = "Update Sticenik set Slika=@img where ID=(select max(ID) from Sticenik)";
                            SqlCommand cmd1 = new SqlCommand(str1, con1);
                            MemoryStream stream = new MemoryStream();
                            pictureBoxAnimal.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] img = stream.ToArray();
                            cmd1.Parameters.AddWithValue("@img", img);
                            con1.Open();
                            cmd1.ExecuteNonQuery();
                            con1.Close();
                        }
                        
                        MessageBox.Show("Uspješno ste unijeli novog štićenika!", "Obavještenje");
                    }
                    else
                        MessageBox.Show("Došlo je do greške prilikom unosa!", "Obavještenje");
                    
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);   
                }
                
            }
        }

        private void iconBtnEdit_Click(object sender, EventArgs e)
        {
            if (labelID.Text != "")
            {

                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite ažurirati podatke o štićeniku sa indeksom " + labelID.Text + "?", "Upozorenje!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    if (Dashboard.dashStatus == "Admin")
                    {
                        try
                        {
                            bool isNullOrEmpty = pictureBoxAnimal == null || pictureBoxAnimal.Image == null;
                            if (!isNullOrEmpty)
                            {
                                SqlConnection con1 = new SqlConnection(conStr);
                                string str1 = "Update Sticenik set Slika=@img where ID=@id";
                                SqlCommand cmd1 = new SqlCommand(str1, con1);
                                MemoryStream stream = new MemoryStream();
                                pictureBoxAnimal.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                byte[] img = stream.ToArray();
                                cmd1.Parameters.AddWithValue("@img", img);
                                cmd1.Parameters.AddWithValue("@id", labelID.Text);
                                con1.Open();
                                cmd1.ExecuteNonQuery();
                                con1.Close();
                            }
                            SqlConnection con = new SqlConnection(conStr);
                            string str = "Update Sticenik set Ime=@name, Vrsta=@type, Pol=@gender, Rasa=@breed, Starost=@old, Boja=@color, Velicina=@size, Kilaza=@weight, Dostupnost=@available, Sterilizovan=@steril," +
                            " Datum_S=@datS, Datum_A=@datA, ID_A=@idA, Box=@box, Komentar=@comment where ID=@id";
                            SqlCommand cmd = new SqlCommand(str, con);

                            cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                            cmd.Parameters.AddWithValue("@type", comboBoxType.Text);
                            cmd.Parameters.AddWithValue("@gender", comboBoxGender.Text);
                            cmd.Parameters.AddWithValue("@breed", textBoxBreed.Text);
                            cmd.Parameters.AddWithValue("@old", datePickerOld.Value.ToString());
                            cmd.Parameters.AddWithValue("@color", textBoxColor.Text);
                            cmd.Parameters.AddWithValue("@size", comboBoxSize.Text);
                            if (textBoxWeight.Text == "")
                                cmd.Parameters.AddWithValue("@weight", textBoxWeight.Text).Value = DBNull.Value;
                            else
                                cmd.Parameters.AddWithValue("@weight", textBoxWeight.Text);
                            
                            if (comboBoxAvailable.Text == "Udomljen" || comboBoxAvailable.Text == "Udomljena")
                                    MessageBox.Show("Dostupnost svakog unesenog štićenika je Dostupan/a. Ovo polje moguće je promijeniti u okviru forme Usvajanje!", "Obavještenje");

                            else if (comboBoxGender.Text == "M")
                                cmd.Parameters.AddWithValue("@available", "Dostupan");
                            else
                                cmd.Parameters.AddWithValue("@available", "Dostupan");

                            cmd.Parameters.AddWithValue("@steril", comboBoxSteril.Text);
                            cmd.Parameters.AddWithValue("@datS", dateTimeSteril.Value.ToString());
                            DateTime datetime = DateTime.UtcNow.Date;
                            cmd.Parameters.AddWithValue("@datA", datetime.ToString());
                            cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                            cmd.Parameters.AddWithValue("@box", comboBOXNo.Text);
                            cmd.Parameters.AddWithValue("@comment", textBoxComment.Text);
                            cmd.Parameters.AddWithValue("@id", labelID.Text);

                            con.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                                MessageBox.Show("Uspješno ste ažuririrali podatke o štićeniku čiji je ID="+labelID.Text+"!", "Obavještenje");
                            con.Close();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }

                    }
                    else 
                    {
                        bool isNullOrEmpty = pictureBoxAnimal == null || pictureBoxAnimal.Image == null;
                        if (!isNullOrEmpty)
                        {
                            try
                            {
                                SqlConnection con = new SqlConnection(conStr);
                                string str = "Update Sticenik set Slika=@img, Datum_A=@datA, ID_A=@idA where ID=@id";
                                SqlCommand cmd = new SqlCommand(str, con);
                                MemoryStream stream = new MemoryStream();
                                pictureBoxAnimal.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                byte[] img = stream.ToArray();
                                cmd.Parameters.AddWithValue("@img", img);
                                DateTime datetime = DateTime.UtcNow.Date;
                                cmd.Parameters.AddWithValue("@datA", datetime.ToString());
                                cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                                cmd.Parameters.AddWithValue("@id", labelID.Text);
                                
                                con.Open();
                                updateTrig+=cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            

                        }
                        if (comboBoxSteril.Text=="Da")
                        {
                            try
                            {
                                SqlConnection con = new SqlConnection(conStr);
                                string str = "Update Sticenik set Sterilizovan=@steril,Datum_S=@datS, Datum_A=@datA, ID_A=@idA where ID=@id";
                                SqlCommand cmd = new SqlCommand(str, con);
                                cmd.Parameters.AddWithValue("@steril", comboBoxSteril.Text);
                                cmd.Parameters.AddWithValue("@datS", dateTimeSteril.Value);
                                DateTime datetime = DateTime.UtcNow.Date;
                                cmd.Parameters.AddWithValue("@datA", datetime.ToString());
                                cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                                cmd.Parameters.AddWithValue("@id", labelID.Text);

                                con.Open();
                                updateTrig +=cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            
                            
                        }
                        if (comboBoxSteril.Text=="Ne")
                        {
                            try
                            {
                                SqlConnection con = new SqlConnection(conStr);
                                string str = "Update Sticenik set Sterilizovan=@steril, Datum_A=@datA, ID_A=@idA where ID=@id";
                                SqlCommand cmd = new SqlCommand(str, con);
                                cmd.Parameters.AddWithValue("@steril", comboBoxSteril.Text);
                                DateTime datetime = DateTime.UtcNow.Date;
                                cmd.Parameters.AddWithValue("@datA", datetime.ToString());
                                cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                                cmd.Parameters.AddWithValue("@id", labelID.Text);

                                con.Open();
                                updateTrig += cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }


                        }
                       
                        
                    }
                    if(Dashboard.dashStatus != "Admin")
                    {
                        try
                        {
                            SqlConnection con1 = new SqlConnection(conStr);
                            string str1 = "Update Sticenik set Ime=@name, Rasa=@breed, Kilaza=@weight, Box=@box, Komentar=@comment, Datum_A=@datA, ID_A=@idA where ID=@id";
                            SqlCommand cmd1 = new SqlCommand(str1, con1);
                            cmd1.Parameters.AddWithValue("@name", textBoxName.Text);
                            if (textBoxWeight.Text == "")
                                cmd1.Parameters.AddWithValue("@weight", textBoxWeight.Text).Value = DBNull.Value;
                            else
                                cmd1.Parameters.AddWithValue("@weight", textBoxWeight.Text);
                            cmd1.Parameters.AddWithValue("@breed", textBoxBreed.Text);
                            cmd1.Parameters.AddWithValue("@comment", textBoxComment.Text);
                            cmd1.Parameters.AddWithValue("@box", comboBOXNo.Text);
                            DateTime dateTime = DateTime.UtcNow.Date;
                            cmd1.Parameters.AddWithValue("@datA", dateTime.ToString());
                            cmd1.Parameters.AddWithValue("@idA", Dashboard.dashID);
                            cmd1.Parameters.AddWithValue("@id", labelID.Text);
                            con1.Open();
                            int result = cmd1.ExecuteNonQuery();
                            if (result > 0 || updateTrig>0 )
                                MessageBox.Show("Uspješno ste ažurirali podatke za štićenika čiji je ID="+ labelID.Text,"Obavještenje");
                            else
                                MessageBox.Show("Došlo je do greške prilikom ažuriranja, provjerite polja.");
                            con1.Close();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }
                    updateTrig = 0;
                }
                
            }
            else
                MessageBox.Show("Ažuriranje se vrši na osnovu polja ID. Molim Vas popunite navedeno polje!", "Obavještenje");
            
        }

        private void iconBtnSearchByName_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select *from Sticenik where Ime =N'" + textBoxName.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);

                if (dt.Rows.Count > 1)
                {
                    dataGridSearch.DataSource = dt;
                    DataGridViewColumn column = dataGridSearch.Columns[1];
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    ((DataGridViewImageColumn)dataGridSearch.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        dataGridSearch.Rows[i++].Height = 200;
                        dataGridSearch.Columns[1].Width = 200;
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
                        byte[] bytes = (byte[]) (dt.Rows[0][1]);
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
                    comboBoxAvailable.Text = dt.Rows[0][10].ToString();
                    comboBoxSteril.Text = dt.Rows[0][11].ToString();
                    dateTimeSteril.Text = dt.Rows[0][12].ToString();
                    labelDateAdd.Text = dt.Rows[0][13].ToString();
                    labelDateUpdated.Text = dt.Rows[0][15].ToString();
                    labelIDOwner.Text = dt.Rows[0][17].ToString();
                    labelDateAdopted.Text = dt.Rows[0][18].ToString();
                    comboBOXNo.Text = dt.Rows[0][19].ToString();
                    textBoxComment.Text = dt.Rows[0][20].ToString();

                }
                else
                {
                    if (dt.Rows.Count < 1)
                        MessageBox.Show("Štićenik sa imenom " + textBoxName.Text + " nije pronađen u bazi podataka.", "Obavještenje");
                    else
                        MessageBox.Show("Štićenik sa imenom " + textBoxName.Text + " nije dostupan za udomljavanje ili ne postoji u bazi podataka.", "Obavještenje");
                    con.Close();
                }
                con.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void iconBtnView_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select*from Sticenik";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                dataGridSearch.DataSource = dt;
                con.Close();

                DataGridViewColumn column = dataGridSearch.Columns[1];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ((DataGridViewImageColumn)dataGridSearch.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                int i = 0;
                while (i < dt.Rows.Count)
                {
                    dataGridSearch.Rows[i++].Height = 200;
                    dataGridSearch.Columns[1].Width = 200;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            dataGridSearch.ClearSelection();
        }

        private void dataGridSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBoxAnimal.Image = null;
            labelID.Text = "";
            textBoxName.Text = "";
            comboBoxType.Text = "";
            comboBoxGender.SelectedIndex = -1;
            textBoxBreed.Text = "";
            datePickerOld.Text = "";
            textBoxColor.Text = "";
            comboBoxSize.SelectedIndex = -1;
            textBoxWeight.Text = "";
            comboBoxAvailable.SelectedIndex = -1;
            comboBoxSteril.SelectedIndex = -1;
            dateTimeSteril.Text = "";
            labelDateAdd.Text = "";
            labelDateUpdated.Text = "";
            comboBOXNo.SelectedIndex = -1;
            textBoxComment.Text = "";
            labelIDOwner.Text = "";
            labelDateAdopted.Text = "";


            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (!string.IsNullOrEmpty(dataGridSearch.Rows[e.RowIndex].Cells[1].Value.ToString()))
                {
                    byte[] bytes = (byte[])
                    dataGridSearch.Rows[e.RowIndex].Cells[1].Value;
                    MemoryStream ms = new MemoryStream(bytes);
                    pictureBoxAnimal.Image = Image.FromStream(ms);

                }

                labelID.Text = dataGridSearch.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBoxName.Text = dataGridSearch.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBoxType.Text = dataGridSearch.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBoxGender.Text = dataGridSearch.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBoxBreed.Text = dataGridSearch.Rows[e.RowIndex].Cells[5].Value.ToString();
                datePickerOld.Text = dataGridSearch.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBoxColor.Text = dataGridSearch.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboBoxSize.Text = dataGridSearch.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBoxWeight.Text = dataGridSearch.Rows[e.RowIndex].Cells[9].Value.ToString();
                comboBoxAvailable.Text = dataGridSearch.Rows[e.RowIndex].Cells[10].Value.ToString();
                comboBoxSteril.Text = dataGridSearch.Rows[e.RowIndex].Cells[11].Value.ToString();
                dateTimeSteril.Text = dataGridSearch.Rows[e.RowIndex].Cells[12].Value.ToString();
                labelDateAdd.Text = dataGridSearch.Rows[e.RowIndex].Cells[13].Value.ToString();
                labelDateUpdated.Text = dataGridSearch.Rows[e.RowIndex].Cells[15].Value.ToString();
                labelIDOwner.Text = dataGridSearch.Rows[e.RowIndex].Cells[17].Value.ToString();
                labelDateAdopted.Text = dataGridSearch.Rows[e.RowIndex].Cells[18].Value.ToString();
                comboBOXNo.Text = dataGridSearch.Rows[e.RowIndex].Cells[19].Value.ToString();
                textBoxComment.Text = dataGridSearch.Rows[e.RowIndex].Cells[20].Value.ToString();
            }
            dataGridSearch.ClearSelection();
        }

        private void iconBtnClear_Click(object sender, EventArgs e)
        {
            pictureBoxAnimal.Image = null;
            labelID.Text = "";
            textBoxName.Text = "";
            comboBoxType.SelectedIndex = -1;
            comboBoxGender.SelectedIndex = -1;
            textBoxBreed.Text = "";
            datePickerOld.Text = "";
            textBoxColor.Text = "";
            comboBoxSize.SelectedIndex = -1;
            textBoxWeight.Text = "";
            comboBoxAvailable.SelectedIndex = -1;
            comboBoxSteril.SelectedIndex = -1;
            dateTimeSteril.Text = "";
            labelDateAdd.Text = "";
            labelDateUpdated.Text = "";
            comboBOXNo.SelectedIndex = -1;
            textBoxComment.Text = "";
            labelIDOwner.Text = "";
            labelDateAdopted.Text = "";
            dataGridSearch.ClearSelection();
            
        }
        
        private void iconBtnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (dataGridSearch.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Za brisanje je potrebno selektovati polje iz tabele!", "Obavještenje");
            }
            else
            {
                int index = dataGridSearch.CurrentCell.RowIndex;

                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite izbrisati štićenika sa indeksom " + dataGridSearch.Rows[index].Cells[0].Value.ToString() + "?", "Upozorenje!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes && !string.IsNullOrEmpty(dataGridSearch.Rows[index].Cells[17].Value.ToString()))
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(conStr);
                        string str = "Select* from Sticenik where ID_Vlasnik=@id";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.Parameters.AddWithValue("@id", dataGridSearch.Rows[index].Cells[17].Value.ToString());
                        con.Open();
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapt.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 1)
                        {

                            try
                            {
                                SqlConnection con2 = new SqlConnection(conStr);
                                string str2 = "Delete from Sticenik where ID=@id";
                                SqlCommand cmd2 = new SqlCommand(str2, con2);
                                cmd2.Parameters.AddWithValue("@id", dataGridSearch.Rows[index].Cells[0].Value.ToString());
                                con2.Open();
                                deleteTrig = cmd2.ExecuteNonQuery();
                                con2.Close();


                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            try
                            {
                                SqlConnection con1 = new SqlConnection(conStr);
                                string str1 = "Delete from Usvajac where ID=@id";
                                SqlCommand cmd1 = new SqlCommand(str1, con1);
                                cmd1.Parameters.AddWithValue("@id", dataGridSearch.Rows[index].Cells[17].Value.ToString());
                                con1.Open();
                                int result2 = cmd1.ExecuteNonQuery();
                                con1.Close();
                                if (result2 > 0 && deleteTrig > 0)
                                {
                                    MessageBox.Show("Uspješno ste izbrisali podatke za štićenika sa indeksom " + labelID.Text + " i podatke o njegovom vlasniku.", "Obavještenje");
                                }
                                else
                                    MessageBox.Show("Došlo je do greške prilikom brisanja.", "Obavještenje");
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            deleteTrig = 0;
                        }
                        else
                        {
                            try
                            {
                                SqlConnection con2 = new SqlConnection(conStr);
                                string str2 = "Delete from Sticenik where ID=@id";
                                SqlCommand cmd2 = new SqlCommand(str2, con2);
                                cmd2.Parameters.AddWithValue("@id", dataGridSearch.Rows[index].Cells[0].Value.ToString());
                                con2.Open();
                                int result2 = cmd2.ExecuteNonQuery();
                                con2.Close();
                                if (result2 > 0)
                                {
                                    MessageBox.Show("Uspješno ste izbrisali podatke za štićenika sa indeksom " + dataGridSearch.Rows[index].Cells[0].Value.ToString() + ".", "Obavještenje");
                                }
                                else
                                    MessageBox.Show("Došlo je do greške prilikom brisanja.", "Obavještenje");

                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }

                }
                else if (dialogResult == DialogResult.Yes && string.IsNullOrEmpty(dataGridSearch.Rows[index].Cells[17].Value.ToString()))
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(conStr);
                        string str = "Delete from Sticenik where ID=@id";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.Parameters.AddWithValue("@id", dataGridSearch.Rows[index].Cells[0].Value.ToString());
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result > 0)
                        {
                            MessageBox.Show("Uspješno ste izbrisali podatke za štićenika sa indeksom " + dataGridSearch.Rows[index].Cells[0].Value.ToString() + ".", "Obavještenje");
                        }
                        else
                            MessageBox.Show("Došlo je do greške prilikom brisanja.", "Obavještenje");

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }

            }
            
        }

        private void iconBtnDeleteEntry_Click(object sender, EventArgs e)
        {
            if (labelID.Text=="")
            {
                MessageBox.Show("Za brisanje je potrebni popuniti polje ID štićenika!", "Obavještenje");
            }
            else
            {
                
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurno da želite izbrisati štićenika sa indeksom " + labelID.Text + "?", "Upozorenje!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes && labelIDOwner.Text != "")
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(conStr);
                        string str = "Select* from Sticenik where ID_Vlasnik=@id";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.Parameters.AddWithValue("@id", labelIDOwner.Text);
                        con.Open();
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapt.Fill(ds);
                        con.Close();
                        
                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            
                            try
                            {
                                SqlConnection con2 = new SqlConnection(conStr);
                                string str2 = "Delete from Sticenik where ID=@id";
                                SqlCommand cmd2 = new SqlCommand(str2, con2);
                                cmd2.Parameters.AddWithValue("@id", labelID.Text);
                                con2.Open();
                                deleteTrig = cmd2.ExecuteNonQuery();
                                con2.Close();
                                

                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            try
                            {
                                SqlConnection con1 = new SqlConnection(conStr);
                                string str1 = "Delete from Usvajac where ID=@id";
                                SqlCommand cmd1 = new SqlCommand(str1, con1);
                                cmd1.Parameters.AddWithValue("@id", labelIDOwner.Text);
                                con1.Open();
                                int result2 = cmd1.ExecuteNonQuery();
                                con1.Close();
                                if (result2 > 0 && deleteTrig > 0)
                                {
                                    MessageBox.Show("Uspješno ste izbrisali podatke za štićenika sa indeksom " + labelID.Text + " i podatke o njegovom vlasniku.", "Obavještenje");
                                }
                                else
                                    MessageBox.Show("Došlo je do greške prilikom brisanja.", "Obavještenje");
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            deleteTrig = 0;
                        }
                        else
                        {
                            try
                            {
                                SqlConnection con2 = new SqlConnection(conStr);
                                string str2 = "Delete from Sticenik where ID=@id";
                                SqlCommand cmd2 = new SqlCommand(str2, con2);
                                cmd2.Parameters.AddWithValue("@id", labelID.Text);
                                con2.Open();
                                int result2 = cmd2.ExecuteNonQuery();
                                con2.Close();
                                if (result2 > 0)
                                {
                                    MessageBox.Show("Uspješno ste izbrisali podatke za štićenika sa indeksom " + labelID.Text + ".", "Obavještenje");
                                }
                                else
                                    MessageBox.Show("Došlo je do greške prilikom brisanja.", "Obavještenje");

                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    
                }else if(dialogResult == DialogResult.Yes && labelIDOwner.Text == "")
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(conStr);
                        string str = "Delete from Sticenik where ID=@id";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.Parameters.AddWithValue("@id", labelID.Text);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result > 0)
                        {
                            MessageBox.Show("Uspješno ste izbrisali podatke za štićenika sa indeksom " + labelID.Text + ".", "Obavještenje");
                        }
                        else
                            MessageBox.Show("Došlo je do greške prilikom brisanja.", "Obavještenje");

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
                
            }
        }
       
    }
}
