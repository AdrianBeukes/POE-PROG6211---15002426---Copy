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

namespace Final
{
    public partial class frmDelete : Form
    {
        frmDisplay DisplayForm = new frmDisplay();
        //*************************************************************************************************************************************************
        public string dlt                                                      //allows for editing of labels in this form, from another form
        {
            get
            {
                return this.lblSelected.Text;
            }
            set
            {
                this.lblSelected.Text = value;
            }
        //*************************************************************************************************************************************************
        }
        public frmDelete()
        {
            InitializeComponent();
        }
        //*************************************************************************************************************************************************
        private void btnYes_Click(object sender, EventArgs e)                       //yes button
        {
            string line = null;
            string lineDelete = lblSelected.Text;                                   //get selected product

            using (StreamReader reader = new StreamReader("stock.txt"))
            {
                using (StreamWriter writer = new StreamWriter("stock2.txt"))        //need new text file to save updated information on
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (String.Compare(line, lineDelete) == 0)                  //removes the line when match is found on the product
                            continue;
                        writer.WriteLine(line);
                    }
                }
            }
            MessageBox.Show("Product has been removed");

            using (StreamReader sr = new StreamReader("stock2.txt"))                 //opens file reader, where stock was saved from main menu
            {
                var line2 = "";                                                      //decalration
                while ((line2 = sr.ReadLine()) != null)                              //read files untill there is nothing left
                {
                    DisplayForm.List = line2;                                        //add files to the list box
                }
            }
            this.Hide();                                                             //hides current form
            DisplayForm.Show();                                                      // Shows the Display form
        }
        //*************************************************************************************************************************************************
        private void btnNo_Click(object sender, EventArgs e)                        //no button
        {
            using (StreamReader sr = new StreamReader("stock.txt"))                 //opens file reader, where stock was saved from main menu
            {
                var line2 = "";                                                     //decalration
                while ((line2 = sr.ReadLine()) != null)                             //read files untill there is nothing left
                {
                    DisplayForm.List = line2;                                       //add files to the list box
                }
            }
            this.Hide();                                                             //hides current form
            DisplayForm.Show();                                                      // Shows the Display form
        }
        //*************************************************************************************************************************************************
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)    //menu help
        {
            this.Hide();                                                        //hides current form
            frmHelp HelpForm = new frmHelp();                                   // Create a new instance of the Form class

            HelpForm.Show();                                                    // Shows the help form
        }
        //*************************************************************************************************************************************************
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)    //menu login
        {
            this.Hide();                                                            //hides current form
            frmLogin LoginForm = new frmLogin();                                    // Create a new instance of the Form class

            LoginForm.Show();                                                       // Shows the login form
        }
        //*************************************************************************************************************************************************
        public virtual void showmessage()                                           //interface method
        {
            MessageBox.Show("Thank you for using our program :D");
            Environment.Exit(0);                                                    //safely exits the program
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)        //menu exit
        {
            showmessage();                                                          //calls method
        }
        //*************************************************************************************************************************************************
    }
}
