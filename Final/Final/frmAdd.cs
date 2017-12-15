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
    public partial class frmAdd : Form
    {
        frmDisplay DisplayForm = new frmDisplay();
        public frmAdd()
        {
            InitializeComponent();
        }
        //*************************************************************************************************************************************************
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool end = false;                                                   //declarations 
            while(end == false)                                                 //while loop start
            {
            string Name = txtName.Text;
            int StartStock = int.Parse(txtStart.Text);
            int SoldStock = int.Parse(txtSold.Text);
            int EndStock = 0;
            string line;

            if (!int.TryParse(txtStart.Text, out StartStock))                    //insures for only numbers in creating new product field
            {
                MessageBox.Show("Please only enter numbers");
                return;
            }
            if (!int.TryParse(txtSold.Text, out SoldStock))
            {
                MessageBox.Show("Please only enter numbers");
                return;
            }
                if(StartStock<SoldStock)                                                                //checks that approriate integers are entered
                    MessageBox.Show("Your sold stock, cant be more than your starting stock");
                else
                {
                    EndStock = StartStock - SoldStock;                                                  //runs if correct information is entered

                    line = (Name + "\t\t" + StartStock + " \t" + SoldStock + " \t" + EndStock);

                    using (StreamWriter sw = File.AppendText("stock.txt"))                              //adds new product at the end of text file
                    {
                        sw.WriteLine(line);
                    }
                    end = true;
                }
                MessageBox.Show("The new product has been added successfully");

                using (StreamReader sr = new StreamReader("stock.txt"))                             //opens file reader, where stock was saved from main menu
                {
                    var line2 = "";                                                                 //decalration
                    while ((line2 = sr.ReadLine()) != null)                                         //read files untill there is nothing left
                    {
                        DisplayForm.List = line2;                                                   //add files to the list box
                    }
                }
                this.Hide();                                                                        //hides current form
                DisplayForm.Show();                                                                 // Shows the Display form
            }
        }
        //*************************************************************************************************************************************************
        private void btnBack_Click(object sender, EventArgs e)                      //back button
        {
            using (StreamReader sr = new StreamReader("stock.txt"))                 //opens file reader, where stock was saved from main menu
            {
                var line3 = "";                                                     //decalration
                while ((line3 = sr.ReadLine()) != null)                             //read files untill there is nothing left
                {
                    DisplayForm.List = line3;                                       //add files to the list box
                }
            }
            this.Hide();                                                            //hides current form
            DisplayForm.Show();                                                     // Shows the Display form
        }
        //*************************************************************************************************************************************************
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)    //menu help
        {
            this.Hide();                                                        //hides current form
            frmHelp HelpForm = new frmHelp();                                   // Create a new instance of the Form class

            HelpForm.Show();                                                    // Shows the help form
        }
        //*************************************************************************************************************************************************
        public virtual void showmessage()                                       //calls interface
        {
            MessageBox.Show("Thank you for using our program :D");
            Environment.Exit(0);                                                //safely exits the program
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)        //menu exit
        {
            showmessage();                                                      //calls method
        }
        //*************************************************************************************************************************************************
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)    //menu login
        {
            this.Hide();                                                       //hides current form
            frmLogin loginForm = new frmLogin();                               // Create a new instance of the Form class

            loginForm.Show();                                                  // Shows the login form
        }
        //*************************************************************************************************************************************************
    }
}
