using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datastruct2
{
    class Program
    {
        static void Main(string[] args)
        {
            int iUserChoice1;
            int iUserStack;
            string sStackname;
            int iCount;
            string sSearchName;
            Boolean bStackmenu = true;
            Console.WriteLine(" 1. Stack\n 2. Queue\n 3. Dictionary\n 4. Exit\n");
        
        iUserChoice1 = Convert.ToInt32(Console.ReadLine());

            switch(iUserChoice1)
            {
                case 1://this case will be used for Stack

                    while (bStackmenu == true)
                    {
                        Console.WriteLine("\n1. Add one time to Stack\n2. Add Huge List of Items to Stack\n3. Display Stack\n4. Delete from Stack\n5. Clear Stack\n6. Search Stack\n7. Return to Main Menu\n");
                        iUserStack = Convert.ToInt32(Console.ReadLine());

                        
                            //Creating a stack datastructure
                            Stack<string> myStack = new Stack<string>();

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
                                    Console.WriteLine("\nWhich item would you like to delete?");
                                    sSearchName = Console.ReadLine();
                                    
                                    
                                    
                                    break;
                                case 5:
                                    break;
                                case 6:
                                    break;
                                case 7:
                                    break;
                                    ("this is ")

                            }
                        

                    } 


                    
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("1. Add one time to Queue\n2. Add Huge List of Items to Queue\n3. Display Queue\n4. Delete from Queue\n5. Clear Queue\n6. Search Queue\n7. Return to Main Menu");
                    break;
                case 3:
                    Console.WriteLine("1. Add one item to Dictionary\n2. Add Huge List of Items to Dictionary\n3. Display Dictionary\n4. Delete from Dictionary\n5. Clear Dictionary\n6. Search Dictionary\n7. Return to Main Menu");
                    break;
                //case4:
                    

            }

            }
}
}
