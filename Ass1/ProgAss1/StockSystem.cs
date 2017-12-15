//student nr - 15002426 Adrian Beukes
//date - april 2016
//This is an console application to take stock in a extreme sports store
//It will be able to display, recieve and output all information
//with integrated menu, for user choice on what to do
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgAss1
{
    class StockSystem
    {
        //*****************************************************************************************************************************************************
        static void Main(string[] args)                                            //main method
        {
            //declarations
            string menuSelection = null;
            string subSelection = null;

            try                                                                         //try catch to show where errors occurs
            {
                WelcomeMessage();
                menuSelection = MainMenu(menuSelection);                                //gives choice in methods, which one you would like to access
                Console.Clear();                                                        //clears console, make it neat
                subSelection = SubMenu(menuSelection, subSelection);                    //gives the sub menu options, of what you would like to do
                Console.Clear();
                Display(menuSelection, subSelection);                                   //Display's + updates results

                Console.ReadLine();                                                     //close up
            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
            }
            WelcomeMessage();
            menuSelection = MainMenu(menuSelection);                                //gives choice in methods, which one you would like to access
            subSelection = SubMenu(menuSelection, subSelection);                    //gives the sub menu options, of what you would like to do
            Display(menuSelection, subSelection);                                   //Display's + updates results

            Console.ReadLine();                                                     //close up
        }

        //*****************************************************************************************************************************************************
        private static void WelcomeMessage()                                            //display's the welcome message
        {
            Console.WriteLine("Welcome to the stock system of Extreme sports shop");
        }

        //*****************************************************************************************************************************************************
        private static string MainMenu(string menuSelection)
        {
            menuSelection = MainMenuSelection(menuSelection);                          //call method to make menu selection
            menuSelection = getMenuSelection(menuSelection);                           //gets the menu selection
            return menuSelection;
        }

        //*****************************************************************************************************************************************************
        private static string MainMenuSelection(string menuSelection)
        {
            bool exit = false;          //declaration for while loop
            do
            {
                Console.WriteLine("\nPlease make your selection on the menu below on what category you would like to see of the business");
                Console.WriteLine(@"
1) Surf
2) motocross
3) canoeing
4) parachuting
5) snowboarding
0) exit");                                                                              //the @ allows for multiline output, makes code neater than using \n(next line) command

                menuSelection = Console.ReadLine();
                if (menuSelection == "1" || menuSelection == "2" || menuSelection == "3" || menuSelection == "4" || menuSelection == "5")           //checks what menu key is pressed
                    exit = true;
                else if (menuSelection == "0")
                    Environment.Exit(0);                                                //safer way to terminate than application.exit command
                else
                    Console.WriteLine("Wrong input, please input correctly, using only 1, 2, 3, etc");      //checks that correct input is placed
            } while (exit == false);

            return menuSelection;
        }

        //*****************************************************************************************************************************************************
        private static string getMenuSelection(string menuSelection)                //get menu selected item
        {
            if (menuSelection == "1")                                               //returns the value selected
                menuSelection = "surf";
            else if (menuSelection == "2")
                menuSelection = "motocross";
            else if (menuSelection == "3")
                menuSelection = "canoeing";
            else if (menuSelection == "4")
                menuSelection = "parachuting";
            else
                menuSelection = "snowboarding";

            return menuSelection;
        }

        //*****************************************************************************************************************************************************
        private static string SubMenu(string menuSelection, string subSelection)
        {
            subSelection = SubMenuSelection(menuSelection, subSelection);                   //call method to make menu selection
            subSelection = getSubMenuSelection(subSelection);                               //gets the menu selection
            return subSelection;
        }

        //*****************************************************************************************************************************************************
        private static string SubMenuSelection(string menuSelection, string subSelection)
        {
            bool exit = false;          //declaration for while loop
            do
            {
                Console.WriteLine("Your menu selection was {0}, what would you like to see/do", menuSelection);
                Console.WriteLine(@"
1) See Current stock for this month
0) exit");
                subSelection = Console.ReadLine();
                if (subSelection == "1" || subSelection == "2" || subSelection == "3" || subSelection == "4")         //checks what menu key is pressed
                    exit = true;
                else if (subSelection == "0")
                    Environment.Exit(0);                                                //safer way to terminate than application.exit command
                else
                    Console.WriteLine("Wrong input, please input correctly, using only 1, 2, 3, etc");      //checks that correct input is placed
            } while (exit == false);

            return subSelection;
        }

        //*****************************************************************************************************************************************************
        private static string getSubMenuSelection(string subSelection)
        {
            if (subSelection == "1")                                                                        //gets submenu selected item
                subSelection = "See Current stock for this month";                                          //returns selected value
            return subSelection;
        }

        //*****************************************************************************************************************************************************
        private static void Display(string menuSelection, string subSelection)
        {
            //declarations
            string orderChoice = null;
            string updateChoice = null;
            int stockUpdate = 0;
            bool update = false;
            Random rnd = new Random();

            Console.WriteLine("You have chosen to {0} of the category {1}", subSelection, menuSelection);

            if (menuSelection == "surf" && subSelection == "See Current stock for this month")                  //checks what options were picked to run correct method
                surf(subSelection, orderChoice, updateChoice, stockUpdate, update, rnd);
            else if (menuSelection == "motocross" && subSelection == "See Current stock for this month")
                motocross(subSelection, orderChoice, updateChoice, stockUpdate, update, rnd);
            else if (menuSelection == "canoeing" && subSelection == "See Current stock for this month")
                canoeing(subSelection, orderChoice, updateChoice, stockUpdate, update, rnd);
            else if (menuSelection == "parachuting" && subSelection == "See Current stock for this month")
                parachuting(subSelection, orderChoice, updateChoice, stockUpdate, update, rnd);
            else if (menuSelection == "snowboarding" && subSelection == "See Current stock for this month")
                snowboarding(subSelection, orderChoice, updateChoice, stockUpdate, update, rnd);
        }

        //*****************************************************************************************************************************************************
        private static void canoeing(string subSelection, string orderChoice, string updateChoice, int stockUpdate, bool update, Random rnd)
        {
            //declarations
            bool checkPos = false;
            bool input = false;
            int s3 = 0;
            int s4 = 0;
            int random1 = rnd.Next(1, 35);                                          //random different sales figure for each
            int random2 = rnd.Next(1, 50);
            int random3 = rnd.Next(1, 45);
            object[,] canoeing = new object[,]                                      //places object into array
                {
                    {"canoe's", 35, null, null},                                      //fill array
                    {"paddle's", 50, null, null },
                    {"jackets", 45, null, null}
                };

            Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");             //table headings
            for (int i = 0; i < canoeing.Length / 4; i++)                           //run loop to display all data  divide by 4 for amount in array in each line
            {
                object names = canoeing[i, 0];
                object s2 = canoeing[i, 1];
                if (i == 0)
                {
                    s3 = random1;
                    s4 = (int)canoeing[i, 1] - s3;                                  //unboxing obj type back to an int
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
                Console.WriteLine("{0} \t {1} \t {2} \t {3}", names, s2, s3, s4);      //display's output
            }
            while (input == false)
            {
            Console.WriteLine(@"
Would you like to order new stock?
1) yes
2) no");
            orderChoice = Console.ReadLine();
            
                if (orderChoice == "1")                                                 //run choice pick
                {
                    input = true;
                    while (update == false)
                    {
                        Console.Clear();
                        Console.WriteLine(@"You selected yes, which one do you wish to order more stock of:
1) canoe's
2) paddle
3) jackets
0) exit");                                                                           //gives options on what to update
                        updateChoice = Console.ReadLine();
                        if (updateChoice == "1")
                        {
                            checkPos = false;
                            update = true;
                            while (checkPos == false)
                            {
                                checkPos = false;
                                Console.WriteLine("You selected canoe, how much stock do you want to order? Enter positive number");
                                while (!int.TryParse(Console.ReadLine(), out stockUpdate))                          //test that value entered is of type int
                                {
                                    Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                                }
                                if (stockUpdate >= 0)
                                {
                                    checkPos = true;
                                }
                                else
                                {
                                    Console.WriteLine("Enter wrong input");
                                }
                            }
                            Console.WriteLine("you choose to order {0} canoe, will now display updated stock take", stockUpdate);

                            Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
                            for (int i = 0; i < canoeing.Length / 4; i++)
                            {
                                object names = canoeing[i, 0];
                                object s2 = canoeing[i, 1];
                                if (i == 0)
                                {
                                    s3 = random1;
                                    s4 = (int)canoeing[i, 1] - s3;
                                    s4 = s4 + stockUpdate;                                          //updates the total column with the new amount of stock
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
                                Console.WriteLine("{0} \t {1} \t {2} \t {3}", names, s2, s3, s4);
                            }
                        }
                        else if (updateChoice == "2")
                        {
                            checkPos = false;
                            update = true;
                            while (checkPos == false)
                            {
                                checkPos = false;
                                Console.WriteLine("You selected paddle, how much stock do you want to order? Enter positive number");
                                while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                                {
                                    Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                                }
                                if (stockUpdate >= 0)
                                {
                                    checkPos = true;
                                }
                                else
                                {
                                    Console.WriteLine("Enter wrong input");
                                }
                            }

                            Console.WriteLine("you choose to order {0} paddle, will now display updated stock take", stockUpdate);

                            Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
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
                                    s4 = s4 + stockUpdate;
                                }
                                else if (i == 2)
                                {
                                    s3 = random3;
                                    s4 = (int)canoeing[i, 1] - s3;
                                }
                                Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                            }
                        }
                        else if (updateChoice == "3")
                        {
                            checkPos = false;
                            update = true;
                            while (checkPos == false)
                            {
                                checkPos = false;
                                Console.WriteLine("You selected jackets, how much stock do you want to order? Enter positive number");
                                while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                                {
                                    Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                                }
                                if (stockUpdate >= 0)
                                {
                                    checkPos = true;
                                }
                                else
                                {
                                    Console.WriteLine("Enter wrong input");
                                }
                            }
                            Console.WriteLine("you choose to order {0} jackets, will now display updated stock take", stockUpdate);

                            Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
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
                                    s4 = s4 + stockUpdate;
                                }
                                Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                            }
                        }
                        else if (updateChoice == "0")
                        {
                            update = true;
                            Environment.Exit(0);
                        }
                        else
                            Console.WriteLine("Error, incorrect input");

                        Console.WriteLine(@"Do you wish to order more stock?
1) yes
2) no");                                                                                            //lets you go back and order more stock
                        string endChoice = Console.ReadLine();
                        if (endChoice == "1")
                            update = false;
                        else if (endChoice == "2")
                        {
                            Console.WriteLine(@"Thanks for using extreme sports stock system
Press any key to exit");
                            Console.ReadKey();                                                           //allows for any key input, will end program with it
                            Environment.Exit(0);
                        }
                    }
                }
                else if (orderChoice == "2")
                {
                    input = true;
                    Console.WriteLine("You selected no");
                    Console.WriteLine(@"Thanks for using extreme sports stock system
Press any key to exit");                                                                                //end program
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("incorrect input, must be 1 or 2");
                    input = false;
                }
            }
        }

        //*****************************************************************************************************************************************************
        private static void snowboarding(string subSelection, string orderChoice, string updateChoice, int stockUpdate, bool update, Random rnd)
        {
            //declarations                                      //comments to follow top example from line 150
            bool checkPos = false;
            bool input = false;
            int s3 = 0;
            int s4 = 0;
            int random1 = rnd.Next(1, 40);                                          
            int random2 = rnd.Next(1, 30);
            int random3 = rnd.Next(1, 25);
            object[,] snowboarding = new object[,]
                {
                    {"snowboard", 40, null, null},
                    {"helmets", 30, null, null },
                    {"jackets", 25, null, null}
                };

            Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
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
                Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
            }
            while (input == false)
            {
            Console.WriteLine(@"
Would you like to order new stock?
1) yes
2) no");
            orderChoice = Console.ReadLine();

            if (orderChoice == "1")
            {
                while (update == false)
                {
                    Console.Clear();
                    Console.WriteLine(@"You selected yes, which one do you wish to order more stock of:
1) snowboard
2) helmets
3) jackets
0) exit");
                    updateChoice = Console.ReadLine();
                    if (updateChoice == "1")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected snowboard, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} snowboard, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
                        for (int i = 0; i < snowboarding.Length / 4; i++)                           
                        {
                            object s1 = snowboarding[i, 0];
                            object s2 = snowboarding[i, 1];
                            if (i == 0)
                            {
                                s3 = random1;
                                s4 = (int)snowboarding[i, 1] - s3;
                                s4 = s4 + stockUpdate;                                          
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
                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "2")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected helmets, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} helmets, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
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
                                s4 = s4 + stockUpdate;
                            }
                            else if (i == 2)
                            {
                                s3 = random3;
                                s4 = (int)snowboarding[i, 1] - s3;
                            }
                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "3")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected jackets, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} jackets, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
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
                                s4 = s4 + stockUpdate;
                            }
                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "0")
                    {
                        update = true;
                        Environment.Exit(0);
                    }
                    else
                        Console.WriteLine("Error, incorrect input");
                    Console.WriteLine(@"Do you wish to order more stock?
1) yes
2) no");
                    string endChoice = Console.ReadLine();
                    if (endChoice == "1")
                        update = false;
                    else if (endChoice == "2")
                    {
                        Console.WriteLine(@"Thanks for using extreme sports stock system
Press any key to exit");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
            else if (orderChoice == "2")
                {
                    input = true;
                    Console.WriteLine("You selected no");
                    Console.WriteLine(@"Thanks for using extreme sports stock system
Press any key to exit");                                                                                //end program
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("incorrect input, must be 1 or 2");
                    input = false;
                }
            }
        }

        //*****************************************************************************************************************************************************
        private static void parachuting(string subSelection, string orderChoice, string updateChoice, int stockUpdate, bool update, Random rnd)
        {
            //declarations               //comments to follow top example from line 150
            bool checkPos = false;
            bool input = false;
            int s3 = 0;
            int s4 = 0;
            int random1 = rnd.Next(1, 25);                                          
            int random2 = rnd.Next(1, 15);
            int random3 = rnd.Next(1, 25);
            object[,] parachuting = new object[,]
                {
                    {"parachute's", 25, null, null},
                    {"wingsuit", 15, null, null },
                    {"jackets", 25, null, null}
                };

            Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
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
                Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
            }
            while (input == false)
            {
            Console.WriteLine(@"
Would you like to order new stock?
1) yes
2) no");
            orderChoice = Console.ReadLine();

            if (orderChoice == "1")
            {
                while (update == false)
                {
                    Console.Clear();
                    Console.WriteLine(@"You selected yes, which one do you wish to order more stock of:
1) parachute's
2) wingsuit
3) jackets
0) exit");
                    updateChoice = Console.ReadLine();
                    if (updateChoice == "1")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected parachute, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} parachute's, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
                        for (int i = 0; i < parachuting.Length / 4; i++)                           
                        {
                            object s1 = parachuting[i, 0];
                            object s2 = parachuting[i, 1];
                            if (i == 0)
                            {
                                s3 = random1;
                                s4 = (int)parachuting[i, 1] - s3;
                                s4 = s4 + stockUpdate;
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
                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "2")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected wingsuit, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} wingsuit, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
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
                                s4 = s4 + stockUpdate;
                            }
                            else if (i == 2)
                            {
                                s3 = random3;
                                s4 = (int)parachuting[i, 1] - s3;
                            }
                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "3")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected jackets, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} jackets, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
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
                                s4 = s4 + stockUpdate;
                            }
                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "0")
                    {
                        update = true;
                        Environment.Exit(0);
                    }
                    else
                        Console.WriteLine("Error, incorrect input");

                    Console.WriteLine(@"Do you wish to order more stock?
1) yes
2) no");
                    string endChoice = Console.ReadLine();
                    if (endChoice == "1")
                        update = false;
                    else if (endChoice == "2")
                    {
                        Console.WriteLine(@"Thanks for using extreme sports stock system
Press any key to exit");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
            else if (orderChoice == "2")
                {
                    input = true;
                    Console.WriteLine("You selected no");
                    Console.WriteLine(@"Thanks for using extreme sports stock system
Press any key to exit");                                                                                //end program
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("incorrect input, must be 1 or 2");
                    input = false;
                }
            }
        }

        //*****************************************************************************************************************************************************
        private static void motocross(string subSelection, string orderChoice, string updateChoice, int stockUpdate, bool update, Random rnd)
        {
            //declaratons                                               //comments to follow top example from line 150
            bool checkPos = false;
            bool input = false;
            int s3 = 0;
            int s4 = 0;
            int random1 = rnd.Next(1, 20);                                          
            int random2 = rnd.Next(1, 20);
            int random3 = rnd.Next(1, 45);
            int random4 = rnd.Next(1, 30);
            object[,] motocross = new object[,]
                {
                    {"yamaha\t", 20, null, null},
                    {"honda\t", 20, null, null },
                    {"helmets\t", 45, null, null},
                    {"jackets\t", 30, null, null}
                };

            Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
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
                else if ( i == 3)
                {
                    s3 = random4;
                    s4 = (int)motocross[i, 1] - s3;
                }
                Console.WriteLine("{0}\t {1} \t {2} \t {3}", s1, s2, s3, s4);
            }
            while (input == false)
            {
            Console.WriteLine(@"
Would you like to order new stock?
1) yes
2) no");
            orderChoice = Console.ReadLine();

            if (orderChoice == "1")
            {
                while (update == false)
                {
                    Console.Clear();
                    Console.WriteLine(@"You selected yes, which one do you wish to order more stock of:
1) yamaha
2) honda
3) helmets
4) jackets
0) exit");
                    updateChoice = Console.ReadLine();
                    if (updateChoice == "1")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected yamaha, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} yamaha, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
                        for (int i = 0; i < motocross.Length / 4; i++)                           
                        {
                            object s1 = motocross[i, 0];
                            object s2 = motocross[i, 1];
                            if (i == 0)
                            {
                                s3 = random1;
                                s4 = (int)motocross[i, 1] - s3;
                                s4 = s4 + stockUpdate;
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

                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "2")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected honda, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} honda, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
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
                                s4 = s4 + stockUpdate;
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
                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "3")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected helmets, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} helmets, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
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
                                s4 = s4 + stockUpdate;
                            }
                            else if (i == 3)
                            {
                                s3 = random4;
                                s4 = (int)motocross[i, 1] - s3;
                            }

                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "4")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected jackets, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} jackets, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
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
                                s4 = s4 + stockUpdate;
                            }

                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "0")
                    {
                        update = true;
                        Environment.Exit(0);
                    }
                    else
                        Console.WriteLine("Error, incorrect input");

                    Console.WriteLine(@"Do you wish to order more stock?
1) yes
2) no");
                    string endChoice = Console.ReadLine();
                    if (endChoice == "1")
                        update = false;
                    else if (endChoice == "2")
                    {
                        Console.WriteLine(@"Thanks for using extreme sports stock system
Press any key to exit");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
            else if (orderChoice == "2")
                {
                    input = true;
                    Console.WriteLine("You selected no");
                    Console.WriteLine(@"Thanks for using extreme sports stock system
Press any key to exit");                                                                                //end program
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("incorrect input, must be 1 or 2");
                    input = false;
                }
            }
        }

        //*****************************************************************************************************************************************************
        private static void surf(string subSelection, string orderChoice, string updateChoice, int stockUpdate, bool update, Random rnd)
        {
            //declarations                                          //comments to follow top example from line 150
            bool checkPos = false;
            bool input = false;
            int s3 = 0;
            int s4 = 0;
            int random1 = rnd.Next(1, 50);                                         
            int random2 = rnd.Next(1, 45);
            int random3 = rnd.Next(1, 35);
            int random4 = rnd.Next(1, 20);
            object[,] surf = new object[,]
                {
                    {"surfboards", 50, null, null},
                    {"bodyboards", 45, null, null },
                    {"wet suits", 35, null, null},
                    {"SUP\t", 20, null, null}
                };

            Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
            for (int i = 0; i < surf.Length / 4; i++)                          
            {
                object s1 = surf[i, 0];
                object s2 = surf[i, 1];
                if (i == 0)
                {
                    s3 = random1;
                    s4 = (int)surf[i, 1] - s3;
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

                Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
            }
            while (input == false)
            {
            Console.WriteLine(@"
Would you like to order new stock?
1) yes
2) no");
            orderChoice = Console.ReadLine();

            if (orderChoice == "1")
            {
                while (update == false)
                {
                    Console.Clear();
                    Console.WriteLine(@"You selected yes, which one do you wish to order more stock of:
1) surfboards
2) bodyboards
3) wet suits
4) SUP
0) exit");
                    updateChoice = Console.ReadLine();
                    if (updateChoice == "1")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected surfboards, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input, must be positive and numeric");
                            }
                        }
                        Console.WriteLine("you choose to order {0} surfboards, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
                        for (int i = 0; i < surf.Length / 4; i++)                           
                        {
                            object s1 = surf[i, 0];
                            object s2 = surf[i, 1];
                            if (i == 0)
                            {
                                s3 = random1;
                                s4 = (int)surf[i, 1] - s3;
                                s4 = s4 + stockUpdate;

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

                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "2")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected bodyboards, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} bodyboards, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
                        for (int i = 0; i < surf.Length / 4; i++)                          
                        {
                            object s1 = surf[i, 0];
                            object s2 = surf[i, 1];
                            if (i == 0)
                            {
                                s3 = random1;
                                s4 = (int)surf[i, 1] - s3;
                            }
                            else if (i == 1)
                            {
                                s3 = random2;
                                s4 = (int)surf[i, 1] - s3;
                                s4 = s4 + stockUpdate;
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

                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "3")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected wet suits, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} wet suits, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
                        for (int i = 0; i < surf.Length / 4; i++)                           
                        {
                            object s1 = surf[i, 0];
                            object s2 = surf[i, 1];
                            if (i == 0)
                            {
                                s3 = random1;
                                s4 = (int)surf[i, 1] - s3;
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
                                s4 = s4 + stockUpdate;
                            }
                            else if (i == 3)
                            {
                                s3 = random4;
                                s4 = (int)surf[i, 1] - s3;
                            }

                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "4")
                    {
                        checkPos = false;
                        update = true;
                        while (checkPos == false)
                        {
                            checkPos = false;
                            Console.WriteLine("You selected SUP, how much stock do you want to order? Enter positive number");
                            while (!int.TryParse(Console.ReadLine(), out stockUpdate))
                            {
                                Console.WriteLine("The input must be of an positive numeric integer value, please enter value again");
                            }
                            if (stockUpdate >= 0)
                            {
                                checkPos = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter wrong input");
                            }
                        }
                        Console.WriteLine("you choose to order {0} SUP, will now display updated stock take", stockUpdate);

                        Console.WriteLine("\nItem \t\t start \t sale \t end nr\n");
                        for (int i = 0; i < surf.Length / 4; i++)                           
                        {
                            object s1 = surf[i, 0];
                            object s2 = surf[i, 1];
                            if (i == 0)
                            {
                                s3 = random1;
                                s4 = (int)surf[i, 1] - s3;
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
                                s4 = s4 + stockUpdate;
                            }

                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s1, s2, s3, s4);
                        }
                    }
                    else if (updateChoice == "0")
                    {
                        update = true;
                        Environment.Exit(0);
                    }
                    else
                        Console.WriteLine("Error, incorrect input");                                    

                    Console.WriteLine(@"Do you wish to order more stock?
1) yes
2) no");                                                                                               
                    string endChoice = Console.ReadLine();
                    if (endChoice == "1")
                        update = false;
                    else if (endChoice == "2")
                    {
                        Console.WriteLine(@"Thanks for using extreme sports stock system
Press any key to exit");                                                                                
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
            else if (orderChoice == "2")
            {
                input = true;
                Console.WriteLine("You selected no");
                Console.WriteLine(@"Thanks for using extreme sports stock system
Press any key to exit");                                                                                //end program
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("incorrect input, must be 1 or 2");
                input = false;
            }
            }
        }

        //*****************************************************************************************************************************************************   
    }
}
