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

namespace Final
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }
        //*************************************************************************************************************************************************
        private void timerLoad_Tick_1(object sender, EventArgs e)                       //timer on the progress bar
        {
            progBarLoad.Increment(1);
            lblPercentage.Text = progBarLoad.Value.ToString() + "%";                    //shows percentage value of progress bar as it increments
            if (progBarLoad.Value == 100)
                timerLoad.Stop();                                                       //stops the timer if progress bar reaches 100
        }
        //*************************************************************************************************************************************************
    }
}
