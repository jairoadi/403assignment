using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datastruct2
{
    class Program
    {
        //function for the user to be able to select options for a queue

        static void Main(string[] args)
        {
            int iUserChoice1;
            int iUserStack;
            string sStackname;
            int iCount;
            string sSearchName;
            Boolean bStackmenu = true;
            Boolean bMainmenu = true;
            Queue<string> qUserQueue = new Queue<string>();
            //Creating a stack datastructure
            Stack<string> myStack = new Stack<string>();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();





            while (bMainmenu == true)
            {
                Console.WriteLine(" 1. Stack\n 2. Queue\n 3. Dictionary\n 4. Exit\n");
                iUserChoice1 = Convert.ToInt32(Console.ReadLine());

                switch (iUserChoice1)
                {
                    case 1://this case will be used for Stack

                        while (bStackmenu == true)
                        {
                            Console.WriteLine("\n1. Add one time to Stack\n2. Add Huge List of Items to Stack\n3. Display Stack\n4. Delete from Stack\n5. Clear Stack\n6. Search Stack\n7. Return to Main Menu\n");
                            iUserStack = Convert.ToInt32(Console.ReadLine());

                            //switch statement used to allow the user to select a Stack menu
                            switch (iUserStack)
                            {
                                case 1:
                                    Console.WriteLine("\nEnter the name:");
                                    sStackname = Console.ReadLine();
                                    myStack.Push(sStackname);
                                    break;
                                case 2:
                                    //clearing the stack
                                    myStack.Clear();

                                    for (iCount = 0; iCount < 2000; iCount++)
                                    {

                                        sStackname = "New Entry " + Convert.ToString((iCount + 1));
                                        myStack.Push(sStackname);
                                    }

                                    break;
                                case 3:
                                    //if statement will be used in case the the stack is empty. The user will be informed if the stack is empty
                                    if (myStack.Count == 0)
                                    {
                                        Console.WriteLine("\nYour stack is currently empty, please select another option");

                                    }
                                    else
                                    {
                                        foreach (string name in myStack)
                                        {
                                            Console.WriteLine(name);
                                        }
                                    }

                                    break;
                                case 4:
                                    //asking for user's input
                                    Console.WriteLine("\nWhich item would you like to delete?");
                                    sSearchName = Console.ReadLine();


                                    //this for each will compare the user's entry against the stack
                                    foreach (string userSearch in myStack)
                                    {
                                        if (sSearchName.ToLower() == userSearch.ToLower())
                                        {
                                            myStack.Pop();
                                            break;

                                        }

                                    }

                                    break;
                                case 5:
                                    Console.WriteLine("Are you sure you want to wipe out all the data?(y/n)");
                                    string sDecision = Console.ReadLine();
                                    if (sDecision == "y")
                                    {
                                        myStack.Clear();
                                    }

                                    break;
                                case 6:
                                    Console.WriteLine("\nWhich item would you like to search?");
                                    sSearchName = Console.ReadLine();

                                    foreach (string userSearch in myStack)
                                    {
                                        sw.Start();
                                        if (sSearchName.ToLower() == userSearch.ToLower())
                                        {
                                            sw.Stop();
                                            Console.WriteLine("The item: " + sSearchName + " was found");
                                            Console.WriteLine("It took: " + sw.Elapsed + " to find the item");
                                        }
                                        else
                                        {
                                            sw.Stop();
                                            Console.WriteLine("The item: " + sSearchName + " wasn't found");
                                        }

                                    }
                                    break;
                                case 7:

                                    bStackmenu = false;

                                    break;
                            }


                        }

                        break;

                    //this case will be used for queue
                    case 2:
                        break;

                    //this case will be used for Dictionary
                    case 3:
                        break;
                   
                    //this case will be used to exit the menu
                    case 4:
                        bMainmenu = false;
                        break;
                          


                }


            }
        }
    }
}
