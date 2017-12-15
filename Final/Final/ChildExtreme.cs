//Name: Adrian Beukes
//Student Number: 15002426
//Date: 10 June 2016
//Description: this is my program assignment 3, I created a stock sytem for an extreme sport shop
//             In the the main menu you will find options on category's, which if selected will extend to all products
//             from the product view, you can select to update the stock
//             This part is focused on the display process
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    sealed class ChildExtreme : SuperExtreme                            //inheritance from Superextreme
    {
        //*************************************************************************************************************************************************
        private string Password;
        public ChildExtreme()                                           //default constructor
        {
        }
        //*************************************************************************************************************************************************
        public ChildExtreme(string name, string pass)                   //constructor
        {
            Name = name;
            Password = pass;
        }
        //*************************************************************************************************************************************************
        public string Pass                                              //get and set
        {
            get { return Password; }
            set { Password = value; }
        }
        //*************************************************************************************************************************************************
    }
}
