using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NoteTakingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            newnote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            n.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            open.Anchor = AnchorStyles.Top;
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            delete.Anchor = AnchorStyles.Top;
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            calendar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            DeleteBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            oep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            comboBox1.Anchor = AnchorStyles.Top ;
        }

        SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-U7IUME5; Initial Catalog=NoteDB; Integrated Security=True;");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            oep.Items.Clear();
            DeleteBox.Items.Clear();
            LoadComboBoxItems();
            string text = newnote.Text;
            string title = GetTitle();


            if (!string.IsNullOrWhiteSpace(newnote.Text))
            {
                try
                {
                    Conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Notes WHERE Title = @Title";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, Conn);
                    checkCmd.Parameters.AddWithValue("@Title", title);
                    int existingNotesCount = (int)checkCmd.ExecuteScalar();

                    if (existingNotesCount > 0)
                    {
                        // Update existing note
                        string updateQuery = "UPDATE Notes SET Content = @NewText, Timestamp = GETDATE()  WHERE Title = @Title";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, Conn);
                        updateCmd.Parameters.AddWithValue("@NewText", text);
                        updateCmd.Parameters.AddWithValue("@Title", title);
                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Note updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No notes were updated.");
                        }
                    }
                    else
                    {
                        DeleteBox.Items.Add(title);
                        oep.Items.Add(title);
                        string insertQuery = "INSERT INTO Notes (Title, Content) VALUES (@Title, @NewText)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, Conn);
                        insertCmd.Parameters.AddWithValue("@Title", title);
                        insertCmd.Parameters.AddWithValue("@NewText", text);
                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Note saved successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No notes were added.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    Conn.Close();
                }
            }
            newnote.Clear();
            calendar.Text = "";

        }
        private string GetTitle()
        {
            if (!string.IsNullOrWhiteSpace(newnote.Text))
            {
                string[] lines = newnote.Lines;
                return lines[0];
            }
            else
            {
                return string.Empty;
            }
        }
        private void LoadComboBoxItems()
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                string query = "SELECT Title FROM Notes";
                using (SqlCommand cmd = new SqlCommand(query, Conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oep.Items.Add(reader["Title"].ToString());
                            DeleteBox.Items.Add(reader["Title"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items from database: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBoxItems();
        }
        private void delete_Click_1(object sender, EventArgs e)
        {
            string deletetext = DeleteBox.Text;
            try
            {
                Conn.Open();
                string query = "DELETE FROM Notes WHERE Title = @title;";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@title", deletetext);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Note deleted successfully.");
                    DeleteBox.Items.Clear();
                    oep.Items.Clear();
                    LoadComboBoxItems();
                    newnote.Clear();
                    DeleteBox.Text = "";


                }
                else
                {
                    MessageBox.Show("No notes were deleted.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                string query = "SELECT Content, Timestamp FROM Notes WHERE @Title = Title";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@Title", oep.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string textFromDatabase = reader.GetString(0);
                    DateTime dateFromDatabase = reader.GetDateTime(1);
                    calendar.Text = dateFromDatabase.ToString("yyyy-MM-dd HH:mm:ss") + "(Last update)";
                    newnote.Text = textFromDatabase;
                    oep.Text = "";
                }
                else
                {
                    MessageBox.Show("No text found in the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "default":
                    this.BackColor = SystemColors.Control;
                    newnote.ForeColor = SystemColors.ControlText;
                    newnote.BackColor = SystemColors.Window;
                    save.ForeColor = SystemColors.ControlText;
                    save.BackColor = SystemColors.Control;
                    comboBox1.ForeColor = SystemColors.ControlText;
                    comboBox1.BackColor = SystemColors.Window;
                    n.ForeColor = SystemColors.ControlText;
                    label3.ForeColor = SystemColors.ControlText;
                    label4.ForeColor = SystemColors.ControlText;
                    open.ForeColor = SystemColors.ControlText;
                    open.BackColor = SystemColors.Window;
                    label5.ForeColor = SystemColors.ControlText;
                    label6.ForeColor = SystemColors.ControlText;
                    delete.ForeColor = SystemColors.ControlText;
                    delete.BackColor = SystemColors.Control;
                    label7.ForeColor = SystemColors.ControlText;
                    calendar.ForeColor = SystemColors.ControlText;
                    label1.ForeColor = SystemColors.ControlText;
                    label2.ForeColor = SystemColors.ControlText;
                    DeleteBox.ForeColor = SystemColors.ControlText;
                    DeleteBox.BackColor = SystemColors.Window;
                    oep.ForeColor = SystemColors.ControlText;
                    oep.BackColor = SystemColors.Window;

                    break;
                case "Earth":
                    this.BackColor = Color.FromArgb(16, 40, 32);
                    newnote.ForeColor = Color.FromArgb(202, 186, 156);
                    newnote.BackColor = Color.FromArgb(76, 100, 68);
                    save.ForeColor = Color.FromArgb(138, 98, 64);
                    save.BackColor = Color.FromArgb(16, 40, 32);
                    comboBox1.ForeColor = Color.FromArgb(202, 186, 156);
                    comboBox1.BackColor = Color.FromArgb(16, 40, 32);
                    n.ForeColor = Color.FromArgb(202, 186, 156);
                    label3.ForeColor = Color.FromArgb(202, 186, 156);
                    label4.ForeColor = Color.FromArgb(202, 186, 156);
                    open.ForeColor = Color.FromArgb(202, 186, 156);
                    open.BackColor = Color.FromArgb(76, 100, 68);
                    label5.ForeColor = Color.FromArgb(202, 186, 156);
                    label6.ForeColor = Color.FromArgb(202, 186, 156);
                    delete.ForeColor = Color.FromArgb(202, 186, 156);
                    delete.BackColor = Color.FromArgb(16, 40, 32);
                    label7.ForeColor = Color.FromArgb(202, 186, 156);
                    calendar.ForeColor = Color.FromArgb(76, 100, 68);
                    label1.ForeColor = Color.FromArgb(202, 186, 156);
                    label2.ForeColor = Color.FromArgb(202, 186, 156);
                    DeleteBox.ForeColor = Color.FromArgb(202, 186, 156);
                    DeleteBox.BackColor = Color.FromArgb(16, 40, 32);
                    oep.ForeColor = Color.FromArgb(202, 186, 156);
                    oep.BackColor = Color.FromArgb(16, 40, 32);


                    break;
                case "red dragon":
                    this.BackColor = Color.FromArgb(153, 25, 3);
                    newnote.ForeColor = Color.FromArgb(207, 144, 27);
                    newnote.BackColor = Color.FromArgb(188, 45, 21);
                    save.ForeColor = Color.FromArgb(228, 202, 93);
                    save.BackColor = Color.FromArgb(153, 25, 3);
                    comboBox1.ForeColor = Color.FromArgb(228, 202, 93);
                    comboBox1.BackColor = Color.FromArgb(188, 45, 21);
                    n.ForeColor = Color.FromArgb(207, 144, 27);
                    label3.ForeColor = Color.FromArgb(228, 202, 93);
                    label4.ForeColor = Color.FromArgb(207, 144, 27);
                    open.ForeColor = Color.FromArgb(228, 202, 93);
                    open.BackColor = Color.FromArgb(188, 45, 21);
                    label5.ForeColor = Color.FromArgb(228, 202, 93);
                    label6.ForeColor = Color.FromArgb(207, 144, 27);
                    delete.ForeColor = Color.FromArgb(207, 144, 27);
                    delete.BackColor = Color.FromArgb(153, 25, 3);
                    label7.ForeColor = Color.FromArgb(207, 144, 27);
                    calendar.ForeColor = Color.FromArgb(216, 174, 37);
                    label1.ForeColor = Color.FromArgb(228, 202, 93);
                    label2.ForeColor = Color.FromArgb(216, 174, 37);
                    DeleteBox.ForeColor = Color.FromArgb(207, 144, 27);
                    DeleteBox.BackColor = Color.FromArgb(153, 25, 3);
                    oep.ForeColor = Color.FromArgb(207, 144, 27);
                    oep.BackColor = Color.FromArgb(188, 45, 21);

                    break;
                case "passion fruit":
                    this.BackColor = Color.FromArgb(124, 33, 66);
                    newnote.ForeColor = Color.FromArgb(244, 221, 223);
                    newnote.BackColor = Color.FromArgb(244, 163, 180);
                    save.ForeColor = Color.FromArgb(222, 184, 11);
                    save.BackColor = Color.FromArgb(124, 33, 66);
                    comboBox1.ForeColor = Color.FromArgb(244, 221, 223);
                    comboBox1.BackColor = Color.FromArgb(124, 33, 66);
                    n.ForeColor = Color.FromArgb(244, 221, 223);
                    label3.ForeColor = Color.FromArgb(222, 184, 11);
                    label4.ForeColor = Color.FromArgb(244, 221, 223);
                    open.ForeColor = Color.FromArgb(244, 221, 223);
                    open.BackColor = Color.FromArgb(124, 33, 66);
                    label5.ForeColor = Color.FromArgb(222, 184, 11);
                    label6.ForeColor = Color.FromArgb(222, 184, 11);
                    delete.ForeColor = Color.FromArgb(244, 221, 223);
                    delete.BackColor = Color.FromArgb(124, 33, 66);
                    label7.ForeColor = Color.FromArgb(244, 221, 223);
                    calendar.ForeColor = Color.FromArgb(244, 163, 180);
                    label1.ForeColor = Color.FromArgb(222, 184, 11);
                    label2.ForeColor = Color.FromArgb(222, 184, 11);
                    DeleteBox.ForeColor = Color.FromArgb(244, 221, 223);
                    DeleteBox.BackColor = Color.FromArgb(124, 33, 66);
                    oep.ForeColor = Color.FromArgb(244, 221, 223);
                    oep.BackColor = Color.FromArgb(124, 33, 66);
                    break;
                case "sakura":
                    this.BackColor = Color.FromArgb(86, 33, 53);
                    newnote.ForeColor = Color.FromArgb(233, 177, 205);
                    newnote.BackColor = Color.FromArgb(195, 130, 158);
                    save.ForeColor = Color.FromArgb(252, 209, 215);
                    save.BackColor = Color.FromArgb(86, 33, 53);
                    comboBox1.ForeColor = Color.FromArgb(252, 209, 215);
                    comboBox1.BackColor = Color.FromArgb(195, 130, 158);
                    n.ForeColor = Color.FromArgb(233, 177, 205);
                    label3.ForeColor = Color.FromArgb(252, 209, 215);
                    label4.ForeColor = Color.FromArgb(233, 177, 205);
                    open.ForeColor = Color.FromArgb(252, 209, 215);
                    open.BackColor = Color.FromArgb(195, 130, 158);
                    label5.ForeColor = Color.FromArgb(252, 209, 215);
                    label6.ForeColor = Color.FromArgb(233, 177, 205);
                    delete.ForeColor = Color.FromArgb(233, 177, 205);
                    delete.BackColor = Color.FromArgb(86, 33, 53);
                    label7.ForeColor = Color.FromArgb(233, 177, 205);
                    calendar.ForeColor = Color.FromArgb(195, 130, 158);
                    label1.ForeColor = Color.FromArgb(252, 209, 215);
                    label2.ForeColor = Color.FromArgb(255, 231, 222);
                    DeleteBox.ForeColor = Color.FromArgb(233, 177, 205);
                    DeleteBox.BackColor = Color.FromArgb(86, 33, 53);
                    oep.ForeColor = Color.FromArgb(233, 177, 205);
                    oep.BackColor = Color.FromArgb(195, 130, 158);

                    break;
            }
        }
    }
}
