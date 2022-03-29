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

namespace UZZZ_Dashboard
{
    public partial class Zaposleni : Form
    {
        public Zaposleni()
        {
            InitializeComponent();
        }
        string conStr = "Server= computer_name; Database = Adoption; Integrated Security = true";
        string idStaff = "";
        //staff information 
        private void iconBtnViewStaff_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select ID,Ime,Prezime,Datum_R,Status,Adresa,Telefon,email,Username, Datum_U, ID_U,Datum_A, ID_A from Zaposleni";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                dataGridViewStaff.DataSource = dt;
                con.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            dataGridViewStaff.ClearSelection();
        }

        private void dataGridViewStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idStaff = "";
            textBoxName.Text = "";
            textBoxLName.Text = "";
            textBoxPhone.Text = "";
            textBoxAdress.Text = "";
            textBoxEmail.Text = "";
            comboBoxStatus.SelectedIndex = -1;
            dateTimePickerDateOfBirth.Text = "";
            textBoxUserName.Text = "";

            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                idStaff = dataGridViewStaff.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBoxName.Text = dataGridViewStaff.Rows[e.RowIndex].Cells[1].Value.ToString(); 
                textBoxLName.Text = dataGridViewStaff.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateTimePickerDateOfBirth.Text = dataGridViewStaff.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBoxStatus.Text = dataGridViewStaff.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBoxAdress.Text = dataGridViewStaff.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBoxPhone.Text = dataGridViewStaff.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBoxEmail.Text = dataGridViewStaff.Rows[e.RowIndex].Cells[7].Value.ToString();
                
            }
            dataGridViewStaff.ClearSelection();
        }

        private void iconBtnSearchByDateOfBirth_Click(object sender, EventArgs e)
        {
            idStaff = "";
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                string str = "Select ID,Ime,Prezime,Datum_R,Status,Adresa,Telefon,email,Username, Datum_U, ID_U,Datum_A, ID_A from Zaposleni where Datum_R='" + dateTimePickerDateOfBirth.Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 1)
                {
                    dataGridViewStaff.DataSource = dt;

                }
                else if (dt.Rows.Count == 1)
                {
                    idStaff = dt.Rows[0][0].ToString();
                    textBoxName.Text = dt.Rows[0][1].ToString();
                    textBoxLName.Text = dt.Rows[0][2].ToString();
                    dateTimePickerDateOfBirth.Text = dt.Rows[0][3].ToString();
                    comboBoxStatus.Text= dt.Rows[0][4].ToString();
                    textBoxAdress.Text = dt.Rows[0][5].ToString();
                    textBoxPhone.Text = dt.Rows[0][6].ToString();
                    textBoxEmail.Text = dt.Rows[0][7].ToString();
                    textBoxOldUserName.Text = dt.Rows[0][8].ToString();

                }
                else
                {
                    MessageBox.Show("Zaposleni nije pronađen u bazi podataka.", "Obavještenje");
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void iconBtnClear_Click(object sender, EventArgs e)
        {
            idStaff = "";
            textBoxName.Text = "";
            textBoxLName.Text = "";
            textBoxPhone.Text = "";
            textBoxAdress.Text = "";
            textBoxEmail.Text = "";
            comboBoxStatus.SelectedIndex = -1;
            dateTimePickerDateOfBirth.Text = "";
            textBoxUserName.Text = "";
            
        }

        private void iconBtnDeleteEntry_Click(object sender, EventArgs e)
        {
            if (idStaff != "" && Dashboard.dashID != idStaff && (Dashboard.dashStatus == "Admin" || Dashboard.dashStatus == "Zaposleni"))
            {
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite izbrisati zaposlenog iz baze podataka", "Upozorenje", MessageBoxButtons.YesNo);
                if (dialogResult==DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(conStr);
                        string str = "Delete from Zaposleni where ID='" + idStaff + "'";
                        SqlCommand cmd = new SqlCommand(str, con);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        con.Close();
                        if (result > 0)
                            MessageBox.Show("Uspješno ste izbrisali zaposlenog čije je ID=" + idStaff, "Obavještenje");
                        else
                            MessageBox.Show("Došlo je do greške prilikom brisanja!", "Obavještenje");

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }  
            }
            else
            {
                if (idStaff == "")
                    MessageBox.Show("Potrebno je selektovati nalog za brisanje!", "Obavještenje");
                else if(idStaff==Dashboard.dashID)
                    MessageBox.Show("Onemogućeno brisanje sopstvenog naloga!", "Obavještenje");
                else
                    MessageBox.Show("Nemate ovlaštenje za brisanje podataka!", "Obavještenje");
            }
        }

        private void iconBtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (Dashboard.dashStatus == "Admin" && idStaff!="")
                {
                    DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite ažurirati sve podatke?", "Upozorenje!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SqlConnection conU = new SqlConnection(conStr);
                        string strU = "Update Zaposleni set Ime=@name, Prezime=@lname, Datum_R=@datR, Status=@status, Adresa=@adress, Telefon=@phone, email=@email,  Datum_A=@datA, ID_A=@idA  where ID=@id";
                        SqlCommand cmdU = new SqlCommand(strU, conU);
                        conU.Open();
                        cmdU.Parameters.AddWithValue("@name", textBoxName.Text);
                        cmdU.Parameters.AddWithValue("@lname", textBoxLName.Text);
                        cmdU.Parameters.AddWithValue("@datR", dateTimePickerDateOfBirth.Value.ToString());
                        cmdU.Parameters.AddWithValue("@status", comboBoxStatus.Text);
                        cmdU.Parameters.AddWithValue("@adress", textBoxAdress.Text);
                        cmdU.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                        cmdU.Parameters.AddWithValue("@email", textBoxEmail.Text);
                        DateTime dateTime = DateTime.UtcNow.Date;
                        cmdU.Parameters.AddWithValue("@datA", dateTime.ToString());
                        cmdU.Parameters.AddWithValue("@idA", Dashboard.dashID);
                        cmdU.Parameters.AddWithValue("@id", idStaff);

                        int result = cmdU.ExecuteNonQuery();
                        conU.Close();
                        if (result > 0) 
                            MessageBox.Show("Uspješno ste ažurirali podatke o zaposlenom " + textBoxName.Text + " " + textBoxLName + "!", "Obavještenje");
                        else
                            MessageBox.Show("Došlo je do greške prilikom ažuriranja!", "Obavještenje");
                    }
                }
                else if(idStaff==Dashboard.dashID && Dashboard.dashStatus !="Admin" && idStaff != "") 
                {
                    DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite ažurirati sve podatke?", "Upozorenje!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SqlConnection conU = new SqlConnection(conStr);
                        string strU = "Update Zaposleni set Ime=@name, Prezime=@lname, Datum_R=@datR, Adresa=@adress, Telefon=@phone, email=@email,  Datum_A=@datA, ID_A=@idA  where ID=@id";
                        SqlCommand cmdU = new SqlCommand(strU, conU);
                        conU.Open();
                        cmdU.Parameters.AddWithValue("@name", textBoxName.Text);
                        cmdU.Parameters.AddWithValue("@lname", textBoxLName.Text);
                        cmdU.Parameters.AddWithValue("@datR", dateTimePickerDateOfBirth.Value.ToString());
                        cmdU.Parameters.AddWithValue("@adress", textBoxAdress.Text);
                        cmdU.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                        cmdU.Parameters.AddWithValue("@email", textBoxEmail.Text);
                        DateTime dateTime = DateTime.UtcNow.Date;
                        cmdU.Parameters.AddWithValue("@datA", dateTime.ToString());
                        cmdU.Parameters.AddWithValue("@idA", Dashboard.dashID);
                        cmdU.Parameters.AddWithValue("@id", idStaff);

                        int result = cmdU.ExecuteNonQuery();
                        conU.Close();
                        if (result > 0)
                            MessageBox.Show("Uspješno ste ažurirali podatke o zaposlenom " + textBoxName.Text + " " + textBoxLName + "!", "Obavještenje");
                        else
                            MessageBox.Show("Došlo je do greške prilikom ažuriranja!", "Obavještenje");
                    }
                }
                else
                {
                    if (idStaff == "")
                        MessageBox.Show("Unesite ID zaposlenog čije podatke želite ažurirati!", "Obavještenje");
                    else
                        MessageBox.Show("Niste ovlašteni za ažuriranje podataka!", "Obavještenje");

                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void iconBtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string num = "";
                SqlConnection conCheck = new SqlConnection(conStr);
                string strCheck = "Select ID from Zaposleni where Ime=N'" + textBoxName.Text + "' and Prezime=N'" + textBoxLName.Text + "' " +
                    "and Datum_R='" + dateTimePickerDateOfBirth.Value.ToString() + "' and Telefon='" + textBoxPhone.Text + "' " +
                    "and Adresa=N'" + textBoxAdress.Text + "' and email=N'" + textBoxEmail.Text + "' and Status='"+comboBoxStatus.Text+"'";
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
                    MessageBox.Show("Unos je onemogućen! Zaposleni postoji u bazi podataka a njegov ID=" + num, "Obavještenje");
                }
                else
                {
                    if ((Dashboard.dashStatus == "Admin" || Dashboard.dashStatus == "Zaposleni")&&(textBoxName.Text!="" && textBoxLName.Text!="" && textBoxPhone.Text!="" && textBoxAdress.Text!="" && dateTimePickerDateOfBirth.Value.ToString()!=""))
                    {
                        DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite dodati novog zaposlenog?", "Upozorenje!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            SqlConnection con = new SqlConnection(conStr);
                            
                            string str= "Insert into Zaposleni (Ime, Prezime, Datum_R, Status, Adresa, Telefon, email, Username, Datum_U, ID_U, Datum_A, ID_A)" +
                            "Values(@name, @lname, @datR, @status, @adress, @phone, @email, @userName, @datU, @idU, @datA, @idA)";
                            SqlCommand cmd = new SqlCommand(str, con);
                            con.Open();
                            cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                            cmd.Parameters.AddWithValue("@lname", textBoxLName.Text);
                            cmd.Parameters.AddWithValue("@datR", dateTimePickerDateOfBirth.Value.ToString());
                            if (comboBoxStatus.Text=="Admin" && Dashboard.dashStatus=="Admin")
                                cmd.Parameters.AddWithValue("@status", comboBoxStatus.Text);
                            else
                            {
                                cmd.Parameters.AddWithValue("@status", "Volonter");
                                MessageBox.Show("Nemate ovlaštenje za kreiranje naloga sa Admin statusom. Nalog će biti kreiran sa statusom Volonter!", "Obavještenje");
                            }
                            cmd.Parameters.AddWithValue("@adress", textBoxAdress.Text);
                            cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                            cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                            cmd.Parameters.AddWithValue("@userName", textBoxUserName.Text);
                            DateTime dateTime = DateTime.UtcNow.Date;
                            cmd.Parameters.AddWithValue("@datA", dateTime.ToString());
                            cmd.Parameters.AddWithValue("@idA", Dashboard.dashID);
                            cmd.Parameters.AddWithValue("@datU", dateTime.ToString());
                            cmd.Parameters.AddWithValue("@idU", Dashboard.dashID);

                            int result = cmd.ExecuteNonQuery();
                            con.Close();
                            if (result > 0)
                                MessageBox.Show("Uspješno ste dodali novi nalog zaposlenog " + textBoxName.Text + " " + textBoxLName + "!", "Obavještenje");
                            else
                                MessageBox.Show("Došlo je do greške prilikom kreiranja novog naloga!", "Obavještenje");
                        }
                    }
                    else
                    {
                        if (textBoxName.Text == "" || textBoxLName.Text == "" || textBoxPhone.Text == "" || textBoxAdress.Text == "" || dateTimePickerDateOfBirth.Value.ToString() == "")
                            MessageBox.Show("Unesite polja ime, prezime, datum rođenja, telefon i adresu!", "Obavještenje");
                        else
                            MessageBox.Show("Niste ovlašteni za kreiranje novog naloga zaposlenog!", "Obavještenje");
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //login information
        private void iconBtnClearLogInInfo_Click(object sender, EventArgs e)
        {
            textBoxOldUserName.Text = "";
            textBoxOldPassword.Text = "";
            textBoxNewPassword.Text = "";
            textBoxNewPasswordConfirm.Text = "";
            textBoxNewUsername.Text = "";
        }
        string userID="";
        string userName = "";
        string userLName = "";
        private void iconBtnChangeUserNamePass_Click(object sender, EventArgs e)
        {
            if ((textBoxOldPassword.Text != "" || textBoxOldUserName.Text != "") && (textBoxNewUsername.Text != "" || (textBoxNewPassword.Text != "" && textBoxNewPasswordConfirm.Text != "")))
            {
                if (textBoxOldUserName.Text == Dashboard.dashUserName || Dashboard.dashStatus == "Admin")
                {

                    SqlConnection con = new SqlConnection(conStr);
                    string str = "Select ID, Ime, Prezime from Zaposleni where (Username='" + textBoxOldUserName.Text + "' and Password='"+textBoxOldPassword.Text+ "') or (Username='" + textBoxOldUserName.Text + "' and Password is null)";
                    SqlCommand cmd = new SqlCommand(str, con);
                    con.Open();
                    using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            userID = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ID")).ToString();
                            userName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Ime")).ToString();
                            userLName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Prezime")).ToString();
                        }
                    }
                    
                    con.Close();
                    
                    if (userID!="")
                    {
                        
                        if ((textBoxNewPassword.Text == textBoxNewPasswordConfirm.Text) && (textBoxNewPassword.Text != "" && textBoxNewPasswordConfirm.Text != "" && textBoxNewPassword.Text.Length > 6))
                        {
                            
                            if (textBoxNewUsername.Text != "")
                            {

                                // password and username change
                                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite promijeniti USERNAME i PASSWORD korisnika "+userName+" "+userLName+"?", "Upozorenje", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    try
                                    {
                                        SqlConnection conS = new SqlConnection(conStr);
                                        string strS = "Select Ime, Prezime from Zaposleni where Username='" + textBoxNewUsername.Text + "'";
                                        SqlCommand cmdS = new SqlCommand(strS, conS);
                                        conS.Open();
                                        DataTable dt = new DataTable();
                                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmdS);
                                        sqlDataAdapter.Fill(dt);
                                        conS.Close();
                                        
                                        if (dt.Rows.Count > 0)
                                        {
                                            MessageBox.Show("Uneseni USERNAME je zauzet. Koristi ga zaposleni " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + "!", "Obavještenje");
                                        }
                                        else
                                        {
                                            SqlConnection conU = new SqlConnection(conStr);
                                            string strU = "Update Zaposleni set Username=@userN, Password=@pass, Datum_A=@datA, ID_A=@idA where ID=@idUser";
                                            SqlCommand cmdU = new SqlCommand(strU, conU);
                                            conU.Open();
                                            cmdU.Parameters.AddWithValue("@userN", textBoxNewUsername.Text);
                                            cmdU.Parameters.AddWithValue("@pass", textBoxNewPassword.Text);
                                            DateTime dateTime = DateTime.UtcNow.Date;
                                            cmdU.Parameters.AddWithValue("@datA", dateTime.ToString());
                                            cmdU.Parameters.AddWithValue("@idA", Dashboard.dashID);
                                            cmdU.Parameters.AddWithValue("@idUser", userID);
                                            int updateResult = cmdU.ExecuteNonQuery();
                                            conU.Close();
                                            if (updateResult > 0)
                                            {
                                                MessageBox.Show("Uspješno ste ažurirali username i password korisnika "+userName+" "+userLName+"! Novi USERNAME="+textBoxNewUsername.Text, "Obavještenje");
                                                if (userID == Dashboard.dashID)
                                                {
                                                    Dashboard update = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                                                    update.Username = textBoxNewUsername.Text;
                                                    
                                                }
                                            }
                                            else
                                                MessageBox.Show("Došlo je do greške prilikom ažuriranja kredencijala!", "Obavještenje");
                                        }
                                        
                                    }
                                    catch (Exception err)
                                    {
                                        MessageBox.Show(err.Message);
                                    }
                                }


                            }
                            else 
                            {
                                //password change
                                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite promijeniti PASSWORD korisnika " + userName + " " + userLName+"?", "Upozorenje", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    try
                                    {
                                        SqlConnection conU = new SqlConnection(conStr);
                                        string strU = "Update Zaposleni set Password=@pass, Datum_A=@datA, ID_A=@idA where ID=@idUser";
                                        SqlCommand cmdU = new SqlCommand(strU, conU);
                                        conU.Open();
                                        cmdU.Parameters.AddWithValue("@pass", textBoxNewPassword.Text);
                                        DateTime dateTime = DateTime.UtcNow.Date;
                                        cmdU.Parameters.AddWithValue("@datA", dateTime.ToString());
                                        cmdU.Parameters.AddWithValue("@idA", Dashboard.dashID);
                                        cmdU.Parameters.AddWithValue("@idUser", userID);
                                        int updateResult = cmdU.ExecuteNonQuery();
                                        conU.Close();
                                        if (updateResult > 0)
                                            MessageBox.Show("Uspješno ste ažurirali password korisnika " + userName + " " + userLName + "!", "Obavještenje");
                                        else
                                            MessageBox.Show("Došlo je do greške prilikom ažuriranja password-a!", "Obavještenje");
                                    }
                                    catch (Exception err)
                                    {
                                        MessageBox.Show(err.Message);
                                    }
                                }
                            }


                        }
                        else if ((textBoxNewPassword.Text != textBoxNewPasswordConfirm.Text) && (textBoxNewPassword.Text != "" || textBoxNewPassword.Text != ""))
                            MessageBox.Show("Passwordi se ne podudaraju!", "Obavještenje");
                        else if ((textBoxNewPassword.Text.Length > 6 && textBoxNewPassword.Text != "") || (textBoxNewPassword.Text.Length > 6 && textBoxNewPassword.Text != ""))
                            MessageBox.Show("Password nije dovoljno jak. Minimalan broj karaktera je 6!", "Obavještenje");
                        else if (textBoxNewUsername.Text != "")
                        {
                            //username change
                            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite promijeniti USERNAME korisnika " + userName + " " + userLName+"?", "Upozorenje", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                try
                                {
                                    SqlConnection conS = new SqlConnection(conStr);
                                    string strS = "Select Ime, Prezime from Zaposleni where Username='" + textBoxNewUsername.Text + "'";
                                    SqlCommand cmdS = new SqlCommand(strS, conS);
                                    conS.Open();
                                    DataTable dt = new DataTable();
                                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmdS);
                                    sqlDataAdapter.Fill(dt);
                                    conS.Close();

                                    if (dt.Rows.Count > 0)
                                    {
                                        MessageBox.Show("Uneseni USERNAME je zauzet. Koristi ga zaposleni " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + "!", "Obavještenje");
                                    }
                                    else
                                    {
                                        SqlConnection conU = new SqlConnection(conStr);
                                        string strU = "Update Zaposleni set Username=@userN, Datum_A=@datA, ID_A=@idA where ID=@idUser";
                                        SqlCommand cmdU = new SqlCommand(strU, conU);
                                        conU.Open();
                                        cmdU.Parameters.AddWithValue("@userN", textBoxNewUsername.Text);
                                        DateTime dateTime = DateTime.UtcNow.Date;
                                        cmdU.Parameters.AddWithValue("@datA", dateTime.ToString());
                                        cmdU.Parameters.AddWithValue("@idA", Dashboard.dashID);
                                        cmdU.Parameters.AddWithValue("@idUser", userID);
                                        int updateResult = cmdU.ExecuteNonQuery();
                                        conU.Close();
                                        if (updateResult > 0)
                                        {
                                            MessageBox.Show("Uspješno ste ažurirali username korisnika " + userName + " " + userLName + "! Novi USERNAME = " + textBoxNewUsername.Text, "Obavještenje");
                                            if (userID == Dashboard.dashID)
                                            {
                                                Dashboard update = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                                                update.Username = textBoxNewUsername.Text;
                                            }
                                        }
                                        else
                                            MessageBox.Show("Došlo je do greške prilikom ažuriranja username-a!", "Obavještenje");
                                    }

                                }
                                catch (Exception err)
                                {
                                    MessageBox.Show(err.Message);
                                }
                            }
                        }
                    }
                    else
                        MessageBox.Show("Uneseni kredencijali su pogrešni!","Obavještenje");
                }
                else
                    MessageBox.Show("Nemate ovlaštenje za modifikaciju kredencijala koji Vam ne pripadaju!","Obavještenje");
            }
            else
                MessageBox.Show("Unesite Vaše postojeće kredencijale i polja koja želite modifikovati!", "Obavještenje");
            
        }
    }
}
