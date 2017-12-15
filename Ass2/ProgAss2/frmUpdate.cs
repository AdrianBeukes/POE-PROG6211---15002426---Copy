//Name: Adrian Beukes
//Student Number: 15002426
//Date: 14 May 2016
//Description: this is my program assignment 2, I created a stock sytem for an extreme sport shop
//             In the the main menu you will find options on category's, which if selected will extend to all products
//             from the product view, you can select to update the stock
//             This part is focused on the update process
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
using System.Collections;

namespace ProgAss2
{
    public partial class frmUpdate : Form
    {
        //*************************************************************************************************************************************************
        public string Update
        {
            get
            {
                return this.lblSelected.Text;
            }
            set
            {
                this.lblSelected.Text = value;
            }
        }
        //*************************************************************************************************************************************************
        public frmUpdate()
        {
            InitializeComponent();
        }
        //*************************************************************************************************************************************************
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int newStock;
            bool positive = false;

            if (!int.TryParse(txtUpdate.Text, out newStock))                    //insures for only numbers in update field
            {
                MessageBox.Show("Please only enter numbers");
                return;
            }
            while(positive == false)                                            //checks that only positive value is entered
            {
                newStock = int.Parse(txtUpdate.Text);                           //recieves input, convert it to int
                if (newStock > 0)
                {
                    positive = true;
                }
                else
                {
                    MessageBox.Show("Value must be positive, please re-enter");
                    return;
                }
            }
            newStock = int.Parse(txtUpdate.Text);                           //recieves input, convert it to int
            string firstWord = lblSelected.Text.Split(' ').First();             //gets first word from selected ategory on which updateswill be done
            ArrayList arrStock = new ArrayList();

            using (StreamReader sr = new StreamReader("stock.txt"))             //loads text file
            {
                string line;
                string write = null;
                while ((line = sr.ReadLine()) != null)                          //reads text file, until there is a match or no more lines to read
                {
                    write = "";
                    string[] data = line.Split(' ');                            // split up each line between the delimiter
                    if (data[0] == firstWord)                                   //match chosen listbox item with text file
                    {
                        data[data.Length - 1] = "" + (Convert.ToInt32(data[data.Length - 1]) + newStock);  //adds the new stock 
                    }
                    for(int i = 0; i < data.Length; i++)
                    {
                        write = write + data[i];
                    }
                    arrStock.Add(write);
                }
            }
            using (StreamWriter sw = new StreamWriter("stock.txt"))                 //write back to text file                   
            {                                                                                                        
                for (int i = 0; i < arrStock.Count; i++)
                {
                    sw.WriteLine(arrStock[i]);
                }                                                                   //rewrites to text file with update
            }
            MessageBox.Show("Your product has been updated with " + newStock.ToString() + " new stock, will now show updated version");

            this.Hide();                                                             //hides current form
            frmDisplay DisplayForm = new frmDisplay();                               // Create a new instance of the Form class

            DisplayForm.Show();                                                      // Shows the Display form
        }
        //*************************************************************************************************************************************************
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)        //logout menu
        {
            this.Hide();                                                       //hides current form
            frmLogin loginForm = new frmLogin();                               // Create a new instance of the Form class

            loginForm.Show();                                                  // Shows the login form
        }
        //*************************************************************************************************************************************************
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)        //exit button
        {
            Environment.Exit(0);
        }
        //*************************************************************************************************************************************************
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)        //help button
        {
            this.Hide();                                                        //hides current form
            frmHelp HelpForm = new frmHelp();                                   // Create a new instance of the Form class

            HelpForm.Show();                                                    // Shows the help form
        }
        //*************************************************************************************************************************************************
        private void btnBack_Click(object sender, EventArgs e)                  //back button
        {
            this.Hide();                                                        //hides current form
            frmDisplay DisplayForm = new frmDisplay();                          // Create a new instance of the Form class

            DisplayForm.Show();                                                 // Shows the help form
        }
        //*************************************************************************************************************************************************
        public void lblSelected_Click(object sender, EventArgs e)
        {

        }
        //*************************************************************************************************************************************************
    }
}
