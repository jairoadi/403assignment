/*
 * Colby Thomas / Jairo Franco / Shiblon Pahulu / Marc Oelkers
 * Group 2-15
 * Secion 2
 * 
 * --------------------------------
 * DATA STRUCTURES GROUP ASSIGNMENT
 * --------------------------------
 * 
 * This program simulates a stack, queue, and dictionary data structure. The program has 8 built in options for each
 * structure, allowing the user to 1) Add one item to the structure, 2) Add a Huge List of items to the structure,
 * 3) Display the structure, 4) Delete from the structure, 5) Clear the structure, 6) Search the structure, 7) Import 
 * from File, and 8) Return to the main menu.
 */



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures2
{
    class Program
    {

        #region GLOBAL VARIABLES
        /*These are variables that must have universal access throughout the program.
            Some, like sInput and iInput are meant to be constantly overriden*/
        public static Stack<string> myStack = new Stack<string>();
        public static Queue<string> myQueue = new Queue<string>();
        public static Dictionary<string, int> myDictionary = new Dictionary<string, int>();
        public static int dictCounter = 0;


        public static string sInput;
        public static int iInput;
        #endregion

        #region MAIN MENU
        static public void menu()
        /*The first function call of the program. Allows the user to specify which data structure to work with*/
        {
            Console.WriteLine("\n---------");
            Console.WriteLine("MAIN MENU\n");
            Console.WriteLine("1. Stack");
            Console.WriteLine("2. Queue");
            Console.WriteLine("3. Dictionary");
            Console.WriteLine("4. Exit");
            Console.WriteLine("---------");


            try
            {
                iInput = Convert.ToInt32(Console.ReadLine());

                switch (iInput)
                {
                    case 1:
                        stackMenu();
                        break;
                    case 2:
                        queueMenu();
                        break;
                    case 3:
                        dictionaryMenu();
                        break;
                    case 4:         //exits program
                        break;
                    default:        //invalid int input, restarts menu
                        menu();
                        break;
                }

            }
            catch           //invalid input that is not int
            {
                menu();
            }

        }
        #endregion

        #region STACK
        static public void stackMenu()
        /*Stack options*/
        {
            Console.WriteLine("\n----------");
            Console.WriteLine("STACK MENU");
            Console.WriteLine("\n1. Add one item to Stack");
            Console.WriteLine("2. Add Huge List of Items to Stack");
            Console.WriteLine("3. Display Stack");
            Console.WriteLine("4. Delete from Stack");
            Console.WriteLine("5. Clear Stack");
            Console.WriteLine("6. Search Stack");
            Console.WriteLine("7. Import from File");
            Console.WriteLine("8. Return to Main Menu");
            Console.WriteLine("----------");


            try
            {
                iInput = Convert.ToInt32(Console.ReadLine());

                switch (iInput)
                {
                    case 1:
                        addOneStack();
                        break;
                    case 2:
                        addManyStack();
                        break;
                    case 3:
                        displayStack();
                        break;
                    case 4:
                        deleteFromStack();
                        break;
                    case 5:
                        clearStack();
                        break;
                    case 6:
                        searchStack();
                        break;
                    case 7:             //reads in file data 
                        readFileStack();
                        break;
                    case 8:
                        menu();
                        break;
                    default:
                        break;
                }

            }
            catch
            {
                menu();
            }
        }
        static public void addOneStack()
        {
            Console.Write("\nWhat would you like to add to the stack? ");
            myStack.Push(Console.ReadLine());           //Push item on stack
            stackMenu();

        }       //add one item to stack
        static public void addManyStack()
        {
            myStack.Clear();
            for (int i = 1; i <= 2000; i++)         //Push 2000 items on stack
            {
                myStack.Push("New Entry " + i);
            }
            stackMenu();
        }       //add many items to stack
        static public void displayStack()    
        {
            Console.WriteLine("");
            foreach (string el in myStack)         //for each string in stack
            {
                Console.WriteLine(el);
            }
            stackMenu();
        }       //display stack
        static public void deleteFromStack()
        {
            Console.Write("\nWhat item would you like to delete from the stack? ");
            sInput = Console.ReadLine();
            int counter = myStack.Count();
            Stack<string> tempStack = new Stack<string>();      //tempStack holder
            bool isFound = false;                       // allows us to tell if they actually entered something in the stack
            for (int i = 0; i < counter; i++)
            {
                if (myStack.Peek() != sInput)           // if the value is not sInput, push it on new stack
                {
                    tempStack.Push(myStack.Peek());
                    myStack.Pop();

                }
                else
                {                       /*value has been found and will be deleted*/
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDELETED: " + myStack.Peek());
                    Console.ForegroundColor = ConsoleColor.White;
                    myStack.Pop();
                    isFound = true;     //found it
                }
            }

            if (!isFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nUnable to find: " + sInput);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                counter--;          //counter is now one less than before, since 1 element has been deleted
            }

            for (int i = 0; i < counter; i++)       // add tempStack back into myStack
            {
                myStack.Push(tempStack.Peek());
                tempStack.Pop();
            }

            stackMenu();
        }       //delete value from stack
        static public void clearStack()
        {
            myStack.Clear();
            stackMenu();
        }       //clear stack
        static public void searchStack()
        {
            Console.Write("What item would you like to search for in the stack? ");
            sInput = Console.ReadLine();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();       //init stopwatch
            sw.Start();     //start it

            for (int i = 0; i < myStack.Count(); i++)
            {
                if (myStack.ElementAt(i) == sInput)
                {
                    sw.Stop();      //found it, stop stopwatch
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nFound: \"" + sInput + "\"\nTime: " + sw.Elapsed);          //how long it took to find
                    Console.ForegroundColor = ConsoleColor.White;
                    stackMenu();

                }
            }
            Console.ForegroundColor = ConsoleColor.Red;         //couldn't find it
            Console.WriteLine("\nUnable to find: \"" + sInput + "\"");
            Console.ForegroundColor = ConsoleColor.White;
            stackMenu();

        }       //search stack
        static public void readFileStack()
        {
            myStack.Clear();
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            Console.Write("What is the path of the file you want imported? ");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;         //couldn't find it
                Console.WriteLine("\nInvalid path");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {

                System.IO.StreamReader file =
            new System.IO.StreamReader(fileName);
                while ((line = file.ReadLine()) != null)
                {
                    myStack.Push(line);
                    counter++;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nFile found!");
                Console.ForegroundColor = ConsoleColor.White;
                file.Close();
            }



            stackMenu();
        }       //read file from computer and add values to stack
        #endregion

        #region QUEUE
        static public void queueMenu()
        {
            Console.WriteLine("\n----------");
            Console.WriteLine("QUEUE MENU");
            Console.WriteLine("\n1. Add one item to Queue");
            Console.WriteLine("2. Add Huge List of Items to Queue");
            Console.WriteLine("3. Display Queue");
            Console.WriteLine("4. Delete from Queue");
            Console.WriteLine("5. Clear Queue");
            Console.WriteLine("6. Search Queue");
            Console.WriteLine("7. Import from File");
            Console.WriteLine("8. Return to Main Menu");

            Console.WriteLine("----------");


            try
            {
                iInput = Convert.ToInt32(Console.ReadLine());

                switch (iInput)
                {
                    case 1:
                        addOneQueue();
                        break;
                    case 2:
                        addManyQueue();
                        break;
                    case 3:
                        displayQueue();
                        break;
                    case 4:
                        deleteFromQueue();
                        break;
                    case 5:
                        clearQueue();
                        break;
                    case 6:
                        searchQueue();
                        break;
                    case 7:
                        readFileQueue();
                        break;
                    case 8:
                        menu();
                        break;
                    default:
                        break;
                }

            }
            catch
            {
                menu();
            }
        }
        static public void addOneQueue()
        {
            Console.Write("\nWhat would you like to add to the queue? ");
            myQueue.Enqueue(Console.ReadLine());
            queueMenu();

        }       //add one item to queue
        static public void addManyQueue()
        {
            myQueue.Clear();
            for (int i = 1; i <= 10; i++)
            {
                myQueue.Enqueue("New Entry " + i);
            }
            queueMenu();
        }       //add many items to queue
        static public void displayQueue()
        {
            Console.WriteLine("");
            foreach (string el in myQueue)
            {
                Console.WriteLine(el);
            }
            queueMenu();
        }       //display queue
        static public void deleteFromQueue()
        {
            Console.Write("\nWhat item would you like to delete from the queue? ");
            sInput = Console.ReadLine();
            int counter = myQueue.Count();
            Queue<string> tempQueue = new Queue<string>();
            bool isFound = false;
            for (int i = 0; i < counter; i++)
            {
                if (myQueue.Peek() != sInput)
                {
                    tempQueue.Enqueue(myQueue.Peek());
                    myQueue.Dequeue();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDELETED: " + myQueue.Peek());
                    Console.ForegroundColor = ConsoleColor.White;
                    myQueue.Dequeue();
                    isFound = true;
                }
            }

            if (!isFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nUnable to find: " + sInput);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                counter--;          //counter is now one less than before, since 1 element has been deleted
            }

            for (int i = 0; i < counter; i++)
            {
                myQueue.Enqueue(tempQueue.Peek());
                tempQueue.Dequeue();
            }

            queueMenu();
        }       //delete value from queue
        static public void clearQueue()
        {
            myQueue.Clear();
            queueMenu();
        }       //clear queue
        static public void searchQueue()
        {
            Console.Write("What item would you like to search for in the queue? ");
            sInput = Console.ReadLine();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            for (int i = 0; i < myQueue.Count(); i++)
            {
                if (myQueue.ElementAt(i) == sInput)
                {
                    sw.Stop();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nFound: \"" + sInput + "\"\nTime: " + sw.Elapsed);
                    Console.ForegroundColor = ConsoleColor.White;
                    queueMenu();

                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nUnable to find: \"" + sInput + "\"");
            Console.ForegroundColor = ConsoleColor.White;
            queueMenu();

        }       //search for value in queue
        static public void readFileQueue()      //read in file and put into queue
        {
            myQueue.Clear();
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            Console.Write("What is the path of the file you want imported? ");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))             //file doesn't exist!
            {
                Console.ForegroundColor = ConsoleColor.Red;      
                Console.WriteLine("\nInvalid path");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {

                System.IO.StreamReader file =
            new System.IO.StreamReader(fileName);
                while ((line = file.ReadLine()) != null)            //if there is still more text to be read
                {
                    myQueue.Enqueue(line);
                    counter++;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nFile found!");         //found it
                Console.ForegroundColor = ConsoleColor.White;
                file.Close();           //close file
            }
            queueMenu();
        }
        #endregion

        #region DICTIONARY
        static public void dictionaryMenu()
        {
            Console.WriteLine("\n---------------");
            Console.WriteLine("DICTIONARY MENU");
            Console.WriteLine("\n1. Add one item to Dictionary");
            Console.WriteLine("2. Add Huge List of Items to Dictionary");
            Console.WriteLine("3. Display Dictionary");
            Console.WriteLine("4. Delete from Dictionary");
            Console.WriteLine("5. Clear Dictionary");
            Console.WriteLine("6. Search Dictionary");
            Console.WriteLine("7. Import from File");
            Console.WriteLine("8. Return to Main Menu");

            Console.WriteLine("---------------");



            try
            {
                iInput = Convert.ToInt32(Console.ReadLine());

                switch (iInput)
                {
                    case 1:
                        addOneDictionary();
                        break;
                    case 2:
                        addManyDictionary();
                        break;
                    case 3:
                        displayDictionary();
                        break;
                    case 4:
                        deleteFromDictionary();
                        break;
                    case 5:
                        clearDictionary();
                        break;
                    case 6:
                        searchDictionary();
                        break;
                    case 7:
                        readFileDictionary();
                        break;
                    case 8:
                        menu();
                        break;
                    default:
                        break;
                }

            }
            catch
            {
                menu();
            }
        }
        static public void addOneDictionary()
        {
            Console.Write("\nWhat would you like to add to the dictionary? ");
            dictCounter++;
            myDictionary.Add(Console.ReadLine(), dictCounter);
            dictionaryMenu();

        }           //add one item to dictionary
        static public void addManyDictionary()
        {
            myDictionary.Clear();
            dictCounter = 0;
            for (int i = 1; i <= 2000; i++)
            {
                myDictionary.Add("New Entry " + i, i);
            }
            dictionaryMenu();
        }       //ad many items to dictionary
        static public void displayDictionary()
        {
            Console.WriteLine("");
            foreach (object el in myDictionary)
            {
                Console.WriteLine(el);
            }
            dictionaryMenu();
        }       //display dictionary
        static public void deleteFromDictionary()
        {
            Console.Write("\nWhat item would you like to delete from the dictionary? ");
            sInput = Console.ReadLine();
            if (myDictionary.ContainsKey(sInput))
            {
                myDictionary.Remove(sInput);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDELETED: " + sInput);
                Console.ForegroundColor = ConsoleColor.White;
                dictionaryMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCannot delete \"" + sInput + "\" because it does not exit");
                Console.ForegroundColor = ConsoleColor.White;
            }
            dictionaryMenu();
        }       //delete value from dictionary by key
        static public void clearDictionary()
        {
            myDictionary.Clear();
            dictCounter = 0;
            dictionaryMenu();
        }       //clear dictionary
        static public void searchDictionary()
        {
            Console.Write("What item would you like to search for in the dictionary? ");
            sInput = Console.ReadLine();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            if (myDictionary.ContainsKey(sInput))
            {
                sw.Stop();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nFound: \"" + sInput + "\"\nTime: " + sw.Elapsed);
                Console.ForegroundColor = ConsoleColor.White;
                dictionaryMenu();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nUnable to find: \"" + sInput + "\"");
            Console.ForegroundColor = ConsoleColor.White;
            dictionaryMenu();

        }       //search dictionary by key
        static public void readFileDictionary()         //read in file and add values to dictionary
        {
            myDictionary.Clear();
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            Console.Write("What is the path of the file you want imported? ");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;        
                Console.WriteLine("\nInvalid path");                //file doesn't exist at that location
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {

                System.IO.StreamReader file =
            new System.IO.StreamReader(fileName);
                while ((line = file.ReadLine()) != null)
                {
                    myDictionary.Add(line, counter);                //add to dictionary and use counter for value
                    counter++;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nFile found!");             //found it
                Console.ForegroundColor = ConsoleColor.White;
                file.Close();
            }
            dictionaryMenu();
        }
        #endregion

        #region MAIN
        static void Main(string[] args)
        {
            Console.Write("Colby Thomas");
            menu();     //first call

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();              //exit program
        }
        #endregion
    }
}
