using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginForm
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                //Connection
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                //Select
                string select;
                select = "select * from database.users where Name = '" + this.username_txt.Text + "' ";
                select += "and password = '" + this.password_txt.Text + "';";
                MySqlCommand SelectCommand = new MySqlCommand(select, myConn);

                myConn.Open();
                //Reading
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                bool userAvailable = false; 
                while (myReader.Read())
                    userAvailable = true;
     
                if(userAvailable)
                    MessageBox.Show("Access Granted");
                else
                    MessageBox.Show("Incorrect username or password");
     
                myConn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
