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
     abstract class SuperExtreme                    //super class
    {
         protected string Name;

         public SuperExtreme()                      //constructor
         {
         }

         public string name                         //get and sets to retrieve and assign
         {
             get { return Name; }
             set { Name = value; }
         }
    }
}
