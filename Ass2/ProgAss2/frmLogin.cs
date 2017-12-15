//Name: Adrian Beukes
//Student Number: 15002426
//Date: 14 May 2016
//Description: this is my program assignment 2, I created a login screen that will be the start up for the program
//             In the login you can enter the program as a registered user, or register yourself to gain access to the program
//             Note that registering requiers a alreaddy user on the system, which data will be recorded, in the case of fraud
//             This part is focused on the Login process
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

namespace ProgAss2
{
    public partial class frmLogin : Form
    {
        List<string> Accounts = new List<string>();                                 //Adds account list
        public frmLogin()
        {
            InitializeComponent();
        }
        //*************************************************************************************************************************************************
        private void btnReset_Click_1(object sender, EventArgs e)               //reset button
        {
            txtName = null;                                                     //makes the fields blank
            txtPassword = null;
        }
        //*************************************************************************************************************************************************
        private void btnSubmit_Click_1(object sender, EventArgs e)              //submit button
        {
            bool Valid = false;
            using (StreamReader sr = new StreamReader("Login.txt"))             //loads text file
            {
                string line;
                while ((line = sr.ReadLine()) != null)                          //reads text file, until there is a match or no more lines to read
                {
                    string[] data = line.Split(',');                            // split up each line between the delimiter
                    if (data[0] == txtName.Text && data[1] == txtPassword.Text)
                    {
                        Valid = true;                                           //places each line in a array, reading it, and looking for an exact match
                        break;
                    }
                }
            }
            if (Valid)
            {
                MessageBox.Show("Login succesfull");                             //message login worked

                this.Hide();                                                     //hides current form
                frmMainMenu MainMenuForm = new frmMainMenu();                    // Create a new instance of the Form class

                MainMenuForm.Show();                                             // Shows the MainMenu form
            }
            else
            {
                MessageBox.Show("Login failed");                                 //message login failed
            }
        }
        //*************************************************************************************************************************************************
        private void btnRegister_Click_1(object sender, EventArgs e)            //register button
        {
            this.Hide();                                                        //hides current form
            frmRegister RegisterForm = new frmRegister();                       // Create a new instance of the Form class

            RegisterForm.Show();                                                // Shows the Registration form
        }
        //*************************************************************************************************************************************************
    }
}
