//Name: Adrian Beukes
//Student Number: 15002426
//Date: 14 May 2016
//Description: this is my program assignment 2, I created a stock sytem for an extreme sport shop
//             In the the main menu you will find options on category's, which if selected will extend to all products
//             from the product view, you can select to update the stock
//             This part is focused on the help menu process
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgAss2
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }
        private void frmHelp_Load(object sender, EventArgs e)
        {

        }
        //*************************************************************************************************************************************************
        private void btnExit_Click(object sender, EventArgs e)          //exit button
        {
            Environment.Exit(0);                                        //safely exits the program
        }
        //*************************************************************************************************************************************************
        private void btnSubmit_Click(object sender, EventArgs e)            //submit button
        {
            if (comboxReturn.SelectedItem.ToString().Equals("Main menu"))
            {
                this.Hide();                                                //hides current form
                frmMainMenu MainMenuForm = new frmMainMenu();               // Create a new instance of the Form class

                MainMenuForm.Show();                                        // Shows the MainMenu form
            }
            else if (comboxReturn.SelectedItem.ToString().Equals("Sign-out"))
            {
                this.Hide();                                                //hides current form
                frmLogin LoginForm = new frmLogin();               // Create a new instance of the Form class

                LoginForm.Show();                                        // Shows the Login form
            }
            else
                MessageBox.Show("No input selected, select an item from the drop down list");
        }
        //*************************************************************************************************************************************************
        private void button2_Click(object sender, EventArgs e)              //exit button
        {
            Environment.Exit(0);
        }
        //*************************************************************************************************************************************************
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboxReturn.SelectedItem.ToString().Equals("Main menu"))
            {
                this.Hide();                                                //hides current form
                frmMainMenu MainMenuForm = new frmMainMenu();               // Create a new instance of the Form class

                MainMenuForm.Show();                                        // Shows the MainMenu form
            }
            else if (comboxReturn.SelectedItem.ToString().Equals("Sign-out"))
            {
                this.Hide();                                                //hides current form
                frmLogin LoginForm = new frmLogin();               // Create a new instance of the Form class

                LoginForm.Show();                                        // Shows the Login form
            }
            else
                MessageBox.Show("No input selected, select an item from the drop down list");
        }
        //*************************************************************************************************************************************************
    }
}
