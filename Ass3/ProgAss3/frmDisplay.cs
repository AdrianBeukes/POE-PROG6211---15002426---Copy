//Name: Adrian Beukes
//Student Number: 15002426
//Date: 27 May 2016
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

namespace ProgAss3
{
    public partial class frmDisplay : Form,Iexit
    {
        //*************************************************************************************************************************************************
        public string Table                                                         //allows the fields in this form, to be edited in a different form
        {
            get
            {
                return this.lblTable.Text;
            }
            set
            {
                this.lblTable.Text = value;
            }
        }
        //*************************************************************************************************************************************************
        public dynamic List                                                        //allows the fields in this form, to be edited in a different form
        {
            get
            {
                return this.lstboxStock.Items;
            }
            set
            {
                this.lstboxStock.Items.Add(value);
            }
        }
        //*************************************************************************************************************************************************
        public frmDisplay()
        {
            InitializeComponent();
        }
        //*************************************************************************************************************************************************
        public virtual void showmessage()                                               //interface method
        {
            MessageBox.Show("Thank you for using our program :D");
            Environment.Exit(0);                                                //safely exits the program
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)    //menu exit
        {
            showmessage();                                                //calls the interface
        }
        //*************************************************************************************************************************************************
        private void btnExit_Click(object sender, EventArgs e)                  //exit button
        {
            showmessage();                                                
        }
        //*************************************************************************************************************************************************
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)    //menu signout
        {
            this.Hide();                                                        //hides current form
            frmLogin LoginForm = new frmLogin();                                // Create a new instance of the Form class

            LoginForm.Show();                                                   // Shows the login form
        }
        //*************************************************************************************************************************************************
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)    //menu help
        {
            this.Hide();                                                        //hides current form
            frmHelp HelpForm = new frmHelp();                                   // Create a new instance of the Form class

            HelpForm.Show();                                                    // Shows the help form
        }
        //*************************************************************************************************************************************************
        private void btnBack_Click(object sender, EventArgs e)                  //back button
        {
            this.Hide();                                                        //hides current form
            frmMainMenu MainForm = new frmMainMenu();                           // Create a new instance of the Form class

            MainForm.Show();                                                    // Shows the main menu form
        }
        //*************************************************************************************************************************************************
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmUpdate UpdateForm = new frmUpdate();                               // Create a new instance of the Form class
            if (lstboxStock.SelectedIndex == -1)                                      //checks to see if listbox is selected
                MessageBox.Show("Please select an product to update first");
            else
            {
                UpdateForm.Update = lstboxStock.SelectedItem.ToString();              //adds listbox item selected to Update form
                this.Hide();                                                          //hides current form
                UpdateForm.Show();                                                    // Shows the Update form
            }
        }
        //*************************************************************************************************************************************************
    }
}
