//Name: Adrian Beukes
//Student Number: 15002426
//Date: 10 June 2016
//Description: this is my program assignment 3, I created a stock sytem for an extreme sport shop
//             In the the main menu you will find options on category's, which if selected will extend to all products
//             from the product view, you can select to update the stock
//             This part is focused on the display process
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
using System.Threading;


namespace Final
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        //*************************************************************************************************************************************************
        private void btnReset_Click_1(object sender, EventArgs e)               //reset button
        {
            txtName.Text = null;                                                     //makes the fields blank
            txtPassword.Text = null;
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
                    string[] data = line.Split(',');
                    ChildExtreme login = new ChildExtreme(data[0], data[1]);    // split up each line between the delimiter
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

                //Creating thread for BeginSplash Method so it can start and stop           //when successfully logged in, it will start the splash screen
                Thread thrd = new Thread(new ThreadStart(BeginSplash));
                thrd.Start();
                Thread.Sleep(8500);

                thrd.Abort();                                                    //when timer stops, so will the splash screen

                frmMainMenu MainMenuForm = new frmMainMenu();                    // Create a new instance of the Form class

                MainMenuForm.Show();                                             // Shows the MainMenu form
            }
            else
            {
                MessageBox.Show("Login failed");                                 //message login failed
            }
        }
        //*************************************************************************************************************************************************
        public void BeginSplash()                                               //method to call splash screen to appear
        {
            //Runs form (Splash screen)
            Application.Run(new frmSplash());
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
