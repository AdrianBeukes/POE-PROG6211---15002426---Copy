//Name: Adrian Beukes
//Student Number: 15002426
//Date: 14 May 2016
//Description: this is my program assignment 2, I created a login screen that will be the start up for the program
//             In the login you can enter the program as a registered user, or register yourself to gain access to the program
//             Note that registering requiers a alreaddy user on the system, which data will be recorded, in the case of fraud
//              This section is focused on the registration process
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
    public partial class frmRegister : Form
    {
        List<string> Accounts = new List<string>();                                 //Adds account list
        public frmRegister()
        {
            InitializeComponent();
        }
        //*************************************************************************************************************************************************
        private void btnClear_Click(object sender, EventArgs e)                 //clear button
        {
            txtName.Text = null;                                                //clears the typing fields of all information on this form
            txtPassword.Text = null;
            txtNewName.Text = null;
            txtNewPass.Text = null;
            txtRetype.Text = null;
        }
        //*************************************************************************************************************************************************
        private void btnBack_Click(object sender, EventArgs e)                 //back button
        {
            this.Hide();                                                       //hides current form
            frmLogin loginForm = new frmLogin();                               // Create a new instance of the Form class

            loginForm.Show();                                                  // Shows the login form
        }
        //*************************************************************************************************************************************************
        private void btnRegister_Click(object sender, EventArgs e)             //register button
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
                if (txtNewPass.Text.Equals(txtRetype.Text))                                    //checks that new password and retyped password matches
                {
                    string newAccount = txtNewName.Text + "," + txtNewPass.Text;  
                    Accounts.Add(newAccount);                                   //adds the new account to the list
                    using (StreamWriter SW = File.AppendText("Login.txt"))
                    {
                        for (int i = 0; i < Accounts.Count; i++)
                        {
                            SW.WriteLine(Accounts[i]);                          //saves the new account with a delimiter in the text file
                        }
                    }
                    MessageBox.Show("new user has been registered, and can now login");

                    this.Hide();                                                       //hides current form
                    frmLogin loginForm = new frmLogin();                               // Create a new instance of the Form class

                    loginForm.Show();                                                  // Shows the login form
                }
                else
                    MessageBox.Show("The password does not match the retyped password");
            }
            else
            {
                MessageBox.Show("registration failed, get an valid user to register new users");    //message failed to register
            }
        }
        //*************************************************************************************************************************************************
    }
}
