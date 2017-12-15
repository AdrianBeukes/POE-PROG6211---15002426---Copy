//Name: Adrian Beukes
//Student Number: 15002426
//Date: 27 May 2016
//Description: this is my program assignment 3, I created a stock sytem for an extreme sport shop
//             In the the main menu you will find options on category's, which if selected will extend to all products
//             from the product view, you can select to update the stock
//             This part is focused on the main menu process
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
    public partial class frmMainMenu : Form,Iexit
    {
        int s3, s4;                                                    //use of polymorhism to change declaratioin value throughout rest of mehtod
        public frmMainMenu()
        {
            InitializeComponent();
        }
        //*************************************************************************************************************************************************
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)    //menu logout
        {
            this.Hide();                                                        //hides current form
            frmLogin LoginForm = new frmLogin();                                // Create a new instance of the Form class

            LoginForm.Show();                                                   // Shows the login form
        }
        //*************************************************************************************************************************************************
        public virtual void showmessage()                                               //calls interface
        {
            MessageBox.Show("Thank you for using our program :D");
            Environment.Exit(0);                                                //safely exits the program
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)        //menu Exit
        {
            showmessage();
        }
        //*************************************************************************************************************************************************
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)        //menu help
        {
            this.Hide();                                                        //hides current form
            frmHelp HelpForm = new frmHelp();                                   // Create a new instance of the Form class

            HelpForm.Show();                                                    // Shows the help form
        }
        //*************************************************************************************************************************************************
        private void btnSelect_Click(object sender, EventArgs e)                    //select button
        {
            Random rnd = new Random();                                              //instantiate the random class
            frmDisplay DisplayForm = new frmDisplay();                               // Create a new instance of the Form class

            //*************************************************************************************************************************************************
            if(radbtnSurf.Checked)                                                  //if surf is selected as a radio button
            {
                 s3 = 0;                                                         //declarations
                 s4 = 0;
                int random1 = rnd.Next(1, 50);                                      //randoms a number between the suggested values
                int random2 = rnd.Next(1, 45);
                int random3 = rnd.Next(1, 35);
                int random4 = rnd.Next(1, 20);
                dynamic[,] surf = new dynamic[,]                                      //creates an array with all the information, notes its obj type
                {
                    {"surfboards", 50, null, null},
                    {"bodyboards", 45, null, null },
                    {"wet suits\t  ", 35, null, null},
                    {"SUP\t", 20, null, null}
                };

                using (StreamWriter SW = new StreamWriter("stock.txt"))              //creates text file
                for (int i = 0; i < surf.Length / 4; i++)
                {
                    object s1 = surf[i, 0];
                    object s2 = surf[i, 1];
                    if (i == 0)
                    {
                        s3 = random1;
                        s4 = (int)surf[i, 1] - s3;                                   //unboxing obj type back to an int
                    }
                    else if (i == 1)
                    {
                        s3 = random2;
                        s4 = (int)surf[i, 1] - s3;
                    }
                    else if (i == 2)
                    {
                        s3 = random3;
                        s4 = (int)surf[i, 1] - s3;
                    }
                    else if (i == 3)
                    {
                        s3 = random4;
                        s4 = (int)surf[i, 1] - s3;
                    }

                    if (cboxStart.Checked && cboxSales.Checked)                      //insure what checkboxes where ticked to only save that information
                    {
                        DisplayForm.Table = "Product     \t\t|  Start  \t|  Sale  \t|  End  \t|                     \n";        //adds table headings
                        SW.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);                                               //writes to the text file
                    }  
                    else if (cboxStart.Checked)
                    {
                        DisplayForm.Table = "Product     \t\t|  Start  \t|   End  \t|                                \n";
                        SW.WriteLine("{0} \t {1} \t {2}", s1, s2, s4);
                    }
                    else if (cboxSales.Checked)
                    {
                        DisplayForm.Table = "Product     \t\t|  Sale  \t|   End  \t|                                 \n";
                        SW.WriteLine("{0} \t {1} \t {2}", s1, s3, s4);
                    }
                    else
                    {
                        DisplayForm.Table = "Product     \t\t|   End  \t|                                              \n";
                        SW.WriteLine("{0} \t {1}", s1, s4);
                    }
                }
            }
            //*************************************************************************************************************************************************
            else if (radbtnMotocross.Checked)                                                  //if motocross is selected as a radio button
            {
                 s3 = 0;                                                         //declarations to follow description on line 50
                 s4 = 0;
                int random1 = rnd.Next(1, 20);
                int random2 = rnd.Next(1, 20);
                int random3 = rnd.Next(1, 45);
                int random4 = rnd.Next(1, 30);
                dynamic[,] motocross = new dynamic[,]
                {
                    {"yamaha\t", 20, null, null},
                    {"honda\t", 20, null, null },
                    {"helmets\t", 45, null, null},
                    {"jackets\t", 30, null, null}
                };

                using (StreamWriter SW = new StreamWriter("stock.txt"))
                for (int i = 0; i < motocross.Length / 4; i++)
                {
                    object s1 = motocross[i, 0];
                    object s2 = motocross[i, 1];
                    if (i == 0)
                    {
                        s3 = random1;
                        s4 = (int)motocross[i, 1] - s3;
                    }
                    else if (i == 1)
                    {
                        s3 = random2;
                        s4 = (int)motocross[i, 1] - s3;
                    }
                    else if (i == 2)
                    {
                        s3 = random3;
                        s4 = (int)motocross[i, 1] - s3;
                    }
                    else if (i == 3)
                    {
                        s3 = random4;
                        s4 = (int)motocross[i, 1] - s3;
                    }

                    if (cboxStart.Checked && cboxSales.Checked)                      
                    {
                        DisplayForm.Table = "Product     \t\t|  Start  \t|  Sale  \t|  End  \t|                     \n";        
                        SW.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);                                               
                    }
                    else if (cboxStart.Checked)
                    {
                        DisplayForm.Table = "Product     \t\t|  Start  \t|   End  \t|                                \n";
                        SW.WriteLine("{0} \t {1} \t {2}", s1, s2, s4);
                    }
                    else if (cboxSales.Checked)
                    {
                        DisplayForm.Table = "Product     \t\t|  Sale  \t|   End  \t|                                 \n";
                        SW.WriteLine("{0} \t {1} \t {2}", s1, s3, s4);
                    }
                    else
                    {
                        DisplayForm.Table = "Product     \t\t|   End  \t|                                              \n";
                        SW.WriteLine("{0} \t {1}", s1, s4);
                    } 
                }

            }
            //*************************************************************************************************************************************************
            else if (radbtnCanoeing.Checked)                                                  //if canoeing is selected as a radio button
            {
                 s3 = 0;                                                         //declarations to follow description on line 50
                 s4 = 0;
                int random1 = rnd.Next(1, 35);                                          
                int random2 = rnd.Next(1, 50);
                int random3 = rnd.Next(1, 45);
                int random4 = rnd.Next(1, 60);
                dynamic[,] canoeing = new dynamic[,]                                     
                {
                    {"canoe's \t", 35, null, null},                                     
                    {"paddle's \t", 50, null, null },
                    {"jackets \t", 45, null, null},
                    {"backpacks", 60, null, null}
                };

                using (StreamWriter SW = new StreamWriter("stock.txt"))
                for (int i = 0; i < canoeing.Length / 4; i++)                           
                {
                    object s1 = canoeing[i, 0];
                    object s2 = canoeing[i, 1];
                    if (i == 0)
                    {
                        s3 = random1;
                        s4 = (int)canoeing[i, 1] - s3;                                  
                    }
                    else if (i == 1)
                    {
                        s3 = random2;
                        s4 = (int)canoeing[i, 1] - s3;
                    }
                    else if (i == 2)
                    {
                        s3 = random3;
                        s4 = (int)canoeing[i, 1] - s3;
                    }
                    else if (i == 3)
                    {
                        s3 = random4;
                        s4 = (int)canoeing[i, 1] - s3;
                    }

                    if (cboxStart.Checked && cboxSales.Checked)                     
                    {
                        DisplayForm.Table = "Product     \t\t|  Start  \t|  Sale  \t|  End  \t|                     \n";        
                        SW.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);                                              
                    }
                    else if (cboxStart.Checked)
                    {
                        DisplayForm.Table = "Product     \t\t|  Start  \t|   End  \t|                                \n";
                        SW.WriteLine("{0} \t {1} \t {2}", s1, s2, s4);
                    }
                    else if (cboxSales.Checked)
                    {
                        DisplayForm.Table = "Product     \t\t|  Sale  \t|   End  \t|                                 \n";
                        SW.WriteLine("{0} \t {1} \t {2}", s1, s3, s4);
                    }
                    else
                    {
                        DisplayForm.Table = "Product     \t\t|   End  \t|                                              \n";
                        SW.WriteLine("{0} \t {1}", s1, s4);
                    } 
                }
            }
            //*************************************************************************************************************************************************
            else if (radbtnParachuting.Checked)                                                  //if parachuting is selected as a radio button
            {
                 s3 = 0;                                                         //declarations to follow description on line 50
                 s4 = 0;
                int random1 = rnd.Next(1, 25);
                int random2 = rnd.Next(1, 15);
                int random3 = rnd.Next(1, 25);
                int random4 = rnd.Next(1, 60);
                dynamic[,] parachuting = new dynamic[,]
                {
                    {"parachute's", 25, null, null},
                    {"wingsuit \t", 15, null, null },
                    {"jackets \t", 25, null, null},
                    {"backpack", 60, null, null}
                };

                using (StreamWriter SW = new StreamWriter("stock.txt"))
                for (int i = 0; i < parachuting.Length / 4; i++)
                    {
                        object s1 = parachuting[i, 0];
                        object s2 = parachuting[i, 1];
                        if (i == 0)
                        {
                            s3 = random1;
                            s4 = (int)parachuting[i, 1] - s3;
                        }
                        else if (i == 1)
                        {
                            s3 = random2;
                            s4 = (int)parachuting[i, 1] - s3;
                        }
                        else if (i == 2)
                        {
                            s3 = random3;
                            s4 = (int)parachuting[i, 1] - s3;
                        }
                        else if (i == 3)
                        {
                            s3 = random4;
                            s4 = (int)parachuting[i, 1] - s3;
                        }

                        if (cboxStart.Checked && cboxSales.Checked)                      
                        {
                            DisplayForm.Table = "Product     \t\t|  Start  \t|  Sale  \t|  End  \t|                     \n";        
                            SW.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);                                               
                        }
                        else if (cboxStart.Checked)
                        {
                            DisplayForm.Table = "Product     \t\t|  Start  \t|   End  \t|                                \n";
                            SW.WriteLine("{0} \t {1} \t {2}", s1, s2, s4);
                        }
                        else if (cboxSales.Checked)
                        {
                            DisplayForm.Table = "Product     \t\t|  Sale  \t|   End  \t|                                 \n";
                            SW.WriteLine("{0} \t {1} \t {2}", s1, s3, s4);
                        }
                        else
                        {
                            DisplayForm.Table = "Product     \t\t|   End  \t|                                              \n";
                            SW.WriteLine("{0} \t {1}", s1, s4);
                        } 
                    }
            }
            //*************************************************************************************************************************************************
            else if (radbtnSnowboarding.Checked)                                                  //if snowboarding is selected as a radio button
            {
                 s3 = 0;                                                         //declarations to follow description on line 50
                 s4 = 0;
                int random1 = rnd.Next(1, 40);
                int random2 = rnd.Next(1, 30);
                int random3 = rnd.Next(1, 25);
                int random4 = rnd.Next(1, 60);
                dynamic[,] snowboarding = new dynamic[,]
                {
                    {"snowboard", 40, null, null},
                    {"helmets \t", 30, null, null },
                    {"jackets \t", 25, null, null},
                    {"backpack", 60, null, null}
                };

                using (StreamWriter SW = new StreamWriter("stock.txt"))
                for (int i = 0; i < snowboarding.Length / 4; i++)
                    {
                        object s1 = snowboarding[i, 0];
                        object s2 = snowboarding[i, 1];
                        if (i == 0)
                        {
                            s3 = random1;
                            s4 = (int)snowboarding[i, 1] - s3;
                        }
                        else if (i == 1)
                        {
                            s3 = random2;
                            s4 = (int)snowboarding[i, 1] - s3;
                        }
                        else if (i == 2)
                        {
                            s3 = random3;
                            s4 = (int)snowboarding[i, 1] - s3;
                        } 
                        else if (i == 3)
                        {
                            s3 = random4;
                            s4 = (int)snowboarding[i, 1] - s3;
                        }

                        if (cboxStart.Checked && cboxSales.Checked)                      
                        {
                            DisplayForm.Table = "Product     \t\t|  Start  \t|  Sale  \t|  End  \t|                     \n";        
                            SW.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);                                               
                        }
                        else if (cboxStart.Checked)
                        {
                            DisplayForm.Table = "Product     \t\t|  Start  \t|   End  \t|                                \n";
                            SW.WriteLine("{0} \t {1} \t {2}", s1, s2, s4);
                        }
                        else if (cboxSales.Checked)
                        {
                            DisplayForm.Table = "Product     \t\t|  Sale  \t|   End  \t|                                 \n";
                            SW.WriteLine("{0} \t {1} \t {2}", s1, s3, s4);
                        }
                        else
                        {
                            DisplayForm.Table = "Product     \t\t|   End  \t|                                              \n";
                            SW.WriteLine("{0} \t {1}", s1, s4);
                        } 
                    }
            }
            //*************************************************************************************************************************************************
            using (StreamReader sr = new StreamReader("stock.txt"))                 //opens file reader, where stock was saved from main menu
            {
                var line = "";                                                        //decalration
                while ((line = sr.ReadLine()) != null)                              //read files untill there is nothing left
                {
                    DisplayForm.List = line;                                    //add files to the list box
                }
            }

            this.Hide();                                                       //hides current form       
            DisplayForm.Show();                                                  // Shows the Display form
        }
        //*************************************************************************************************************************************************
    }
}
