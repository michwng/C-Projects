/**       
 * -------------------------------------------------------------------
 * 	   File name: Program.cs
 * 	Project name: Lab2 - C# Basics
 * -------------------------------------------------------------------
 * Author’s name and email:	Michael Ng, ngmw01@etsu.edu			
 *          Course-Section: CSCI-2910-001
 *           Creation Date:	02/01/2022		
 * -------------------------------------------------------------------
 */

using System.Text;

//numbersArray keeps track of the numbers used. 
//numbers at index 0 and 1 are used for adding.
//The number at index 2 is the sum. 
List<int> numbersArray = new List<int> { 0, 0, 0 };


//This code will continuously run until the user exits the program.
do
{
    Menu();
    MenuApplication();
} while (true);



/**       
 * -------------------------------------------------------------------
 * 	            Menu Methods
 * -------------------------------------------------------------------
 */
void Menu() 
{
    Boolean check = true;
    do
    {
        Console.WriteLine("\nPlease choose an application.");
        Console.WriteLine("1. Add 2 Numbers");
        Console.WriteLine("2. List Multiplication Table");
        Console.WriteLine("3. C# Type Information");
        Console.WriteLine("4. Palindrome Detector");
        Console.WriteLine("5. Collatz Conjecture");
        Console.WriteLine("6. Exit Application");
        Console.WriteLine("Type the number beside the application to use it.");


        try
        {
            numbersArray[0] = System.Convert.ToInt32(Console.ReadLine());
            //The number must be between 1 - 5. Then, it turns check to false.
            check = (numbersArray[0] >= 1 && numbersArray[0] <= 6) ? false : true;

            //if the user didn't enter a number between 1 - 5. Notifies them.
            if (check) 
            { 
                Console.WriteLine("-[That number wasn't between 1 - 6.]-");
            }
        }
        //Converting to an Int32 can have 2 exceptions. They are handled here:
        catch (FormatException)
        {
            Console.WriteLine("-[This is not a valid number.]-\n");
        }
        catch (OverflowException)
        {
            Console.WriteLine("-[That number's too big!]-\n");
        }
        //runs the while loop infinitely until the user inputs a valid number.
    } while (check);
}
//end Menu

void MenuApplication()
{
    Console.Clear();

    //Problem 1
    if (numbersArray[0] == 1)
    {
        AskForTwoNumbers(numbersArray);
        Add(numbersArray[0], numbersArray[1]);

        Console.WriteLine("\n----- End of Application -----\n\n");
    }
    //Problem 2
    else if (numbersArray[0] == 2)
    {
        AskForANumberAndMaximumMultiplier(numbersArray);
        ListMultiplicationTable(numbersArray);
        Console.WriteLine("\n----- End of Application -----\n\n");
    }
    //Problem 3
    else if (numbersArray[0] == 3)
    {
        ListTypeRangeAndBytes();
        Console.WriteLine("\n----- End of Application -----\n\n");
    }
    //Problem 4
    else if (numbersArray[0] == 4)
    {
        IdentifyPalindrome();
        Console.WriteLine("\n----- End of Application -----\n\n");
    }
    //Problem 5
    else if (numbersArray[0] == 5)
    {
        PerformCollatz();
        Console.WriteLine("\n----- End of Application -----\n\n");
    }
    else if (numbersArray[0] == 6) 
    {
        System.Environment.Exit(0);
    }

}
//end MenuApplication



/**       
 * -------------------------------------------------------------------
 * 	            
 * 	            Problem Methods
 * 	            
 * -------------------------------------------------------------------
 */


/**       
 * -------------------------------------------------------------------
 * 	            Methods for Problem 1
 * -------------------------------------------------------------------
 */
/**
 * This method adds 2 numbers and sets the 3rd item of the numbersArray to the result.
 * Also outputs the result.
 * 
 * Date Created: 02/01/2022
 * 
 * @param num1 (int), num2 (int)
 */
void Add(int num1, int num2)
{
    try
    {
        numbersArray[2] = numbersArray[0] + numbersArray[1];
        Console.WriteLine(numbersArray[0] + " + " + numbersArray[1] + " = " + numbersArray[2] + "!");
    }
    //Adding to have a number over what Int32 can handle will result in an OverFlowException.
    //This Try/Catch addresses the issue by using an Int64 for the sum.
    catch (OverflowException)
    {
        Int64 bigNumber = numbersArray[0] + numbersArray[1];
        Console.WriteLine("That was a big number, but the result is:\n" + bigNumber + "!");
    }
}
//end Add

/**
 * This method asks the user to input 2 numbers.
 * Because this is for Problem 1, this method is in its context.
 * 
 * Stores the inputs in the numbersArray.
 * The method also validates the inputs.
 * 
 * Date Created: 02/01/2022
 * 
 * @param numbersArray (List<int>)
 */
void AskForTwoNumbers(List<int> numbersArray) 
{
    Console.WriteLine("Please input the first number to add:");

    //check keeps the while loop running while the input is invalid.
    Boolean check = true;
    while (check)
    {
        //runs the while loop infinitely until the user inputs a valid number.
        try
        {
            numbersArray[0] = System.Convert.ToInt32(Console.ReadLine());
            //If the statement above didn't result in an Exception, 
            check = false;
        }
        //Converting to an Int32 can have 2 exceptions. They are handled here:
        catch (FormatException)
        {
            Console.WriteLine("This is not a valid number. Please input a number:");
        }
        catch (OverflowException)
        {
            Console.WriteLine("That number's too big! Please input a smaller number to add.");
        }
    }


    Console.WriteLine("Please input the second number to add:");

    //check is reused here for the second input.
    check = true;
    while (check)
    {
        //runs the while loop infinitely until the user inputs a valid number.
        try
        {
            numbersArray[1] = System.Convert.ToInt32(Console.ReadLine());
            //If the statement above didn't result in an Exception, 
            check = false;
        }
        //Converting to an Int32 can have 2 exceptions. They are handled here:
        catch (FormatException)
        {
            Console.WriteLine("This is not a valid number. Please input a number:");
        }
        catch (OverflowException)
        {
            Console.WriteLine("That number's too big! Please input a smaller number to add:");
        }
    }
}
//end AskForTwoNumbers


/**       
 * -------------------------------------------------------------------
 * 	            Methods for Problem 2
 * -------------------------------------------------------------------
 */

/**
 * A modified version of the AskForTwoNumbers method for problem 2. 
 * This method asks the user to input 2 numbers.
 * 
 * Stores the inputs in the numbersArray.
 * The method also validates the inputs.
 * 
 * Date Created: 02/01/2022
 * 
 * @param numbersArray (List<int>)
 */
void AskForANumberAndMaximumMultiplier(List<int> numbersArray)
{
    //Ask for the Number.
    Console.WriteLine("Please input a number to multiply:");

    //check keeps the while loop running while the input is invalid.
    Boolean check = true;
    while (check)
    {
        //runs the while loop infinitely until the user inputs a valid number.
        try
        {
            numbersArray[0] = System.Convert.ToInt32(Console.ReadLine());
            //If the statement above didn't result in an Exception, 
            check = false;
        }
        //Converting to an Int32 can have 2 exceptions. They are handled here:
        catch (FormatException)
        {
            Console.WriteLine("This is not a valid number. Please input a number:");
        }
        catch (OverflowException)
        {
            Console.WriteLine("That number's too big! Please input a smaller number to add:");
        }
    }

    //Ask for the Maximum Multiplier.

    //check is reused here for the second input.
    check = true;
    while (check)
    {
        Console.WriteLine("We will list the multiplication table for this number.");
        Console.WriteLine("How high do you want to multiply this by?");

        //runs the while loop infinitely until the user inputs a valid number.
        try
        {
            numbersArray[1] = System.Convert.ToInt32(Console.ReadLine());

            //If the statement above didn't result in an Exception, 
            check = false;

            if (numbersArray[1] > 12)
            {
                string decision = "";
                //Because any number high than 12 might fill the Console, we ask the user for confirmation.
                Console.WriteLine("Are you sure? We will multiply \"" + numbersArray[0] + "\" " + numbersArray[1] + " times!\n(Type \"No\" to go back, otherwise, type anything to proceed.)");
                decision = Console.ReadLine();

                //If the user input "No", keeps check true and reiterates. Otherwise, we continue. 
                check = (decision.ToLower() == "no" || decision.ToLower() == "\"no\"") ? true : false;
            }
        }
        //Converting to an Int32 can have 2 exceptions. They are handled here:
        catch (FormatException)
        {
            Console.WriteLine("This is not a valid number. Please input a number:");
        }
        catch (OverflowException)
        {
            Console.WriteLine("That number's too big! Please input a smaller number to add.");
        }
    }
}
//end AskForANumberAndMaximumMultiplier

/**
 * Writes a multiplication table in the Console based on user input.
 * 
 * Date Created: 02/01/2022
 * 
 * @param numbersArray (List<int>)
 */
void ListMultiplicationTable(List<int> numbersArray)
{
    //Remember,
    //numbersArray[0] stores the number being multiplied.
    //numbersArray[1] stores the maximum multiplier.

    for (int i = 0; i <= numbersArray[1]; i++) 
    {
        try
        {
            int smallNumber = numbersArray[0] * i;
            Console.Write(smallNumber + "\n");
        }
        //This number may overflow, so we add an Int64.
        catch (OverflowException) 
        {
            try
            {
                Int64 biggerNumber = numbersArray[0] * i;
                Console.Write(biggerNumber);
            }
            //If the number becomes too big for an Int64, we stop the operation.
            catch (OverflowException)
            {
                Console.WriteLine("This number is WAYYY too big! We'll stop here.");
                return;
            }
        }
    }
} 
//end ListMultiplicationTable


/**       
 * -------------------------------------------------------------------
 * 	            Methods for Problem 3
 * -------------------------------------------------------------------
 */
/**
 * Lists type information for C# in the Console.
 * 
 * Date Created: 02/01/2022
 */
void ListTypeRangeAndBytes()
{
    //sbyte
    Console.WriteLine("\n----------\nsbyte\n----------\n");
    Console.WriteLine("Bytes of Memory: " + 1);
    Console.WriteLine("Minimum value: " + sbyte.MinValue);
    Console.WriteLine("Maximum value: " + sbyte.MaxValue);

    //byte
    Console.WriteLine("\n----------\nbyte\n----------\n");
    Console.WriteLine("Bytes of Memory: " + 1);
    Console.WriteLine("Minimum value: " + byte.MinValue);
    Console.WriteLine("Maximum value: " + byte.MaxValue);

    //short
    Console.WriteLine("\n----------\nshort\n----------\n");
    Console.WriteLine("Bytes of Memory: " + 2);
    Console.WriteLine("Minimum value: " + short.MinValue);
    Console.WriteLine("Maximum value: " + short.MaxValue);

    //ushort
    Console.WriteLine("\n----------\nushort\n----------\n");
    Console.WriteLine("Bytes of Memory: " + 2);
    Console.WriteLine("Minimum value: " + ushort.MinValue);
    Console.WriteLine("Maximum value: " + ushort.MaxValue);

    //int
    Console.WriteLine("\n----------\nint\n----------\n");
    Console.WriteLine("Bytes of Memory: " + 4);
    Console.WriteLine("Minimum value: " + int.MinValue);
    Console.WriteLine("Maximum value: " + int.MaxValue);

    //uint
    Console.WriteLine("\n----------\nuint\n----------\n");
    Console.WriteLine("Bytes of Memory: " + 4);
    Console.WriteLine("Minimum value: " + uint.MinValue);
    Console.WriteLine("Maximum value: " + uint.MaxValue);

    //long
    Console.WriteLine("\n----------\nlong\n----------\n");
    Console.WriteLine("Bytes of Memory: " + 8);
    Console.WriteLine("Minimum value: " + long.MinValue);
    Console.WriteLine("Maximum value: " + long.MaxValue);

    //ulong
    Console.WriteLine("\n----------\nulong\n----------\n");
    Console.WriteLine("Bytes of Memory: " + 8);
    Console.WriteLine("Minimum value: " + ulong.MinValue);
    Console.WriteLine("Maximum value: " + ulong.MaxValue);

    //float
    Console.WriteLine("\n----------\nfloat\n----------\n");
    Console.WriteLine("Bytes of Memory: " + 4);
    Console.WriteLine("Minimum value: " + float.MinValue);
    Console.WriteLine("Maximum value: " + float.MaxValue);

    //double
    Console.WriteLine("\n----------\ndouble\n----------\n");
    Console.WriteLine("Bytes of Memory: " + 8);
    Console.WriteLine("Minimum value: " + double.MinValue);
    Console.WriteLine("Maximum value: " + double.MaxValue);

    //decimal
    Console.WriteLine("\n----------\ndecimal\n----------\n");
    Console.WriteLine("Bytes of Memory: " + 16);
    Console.WriteLine("Minimum value: " + decimal.MinValue);
    Console.WriteLine("Maximum value: " + decimal.MaxValue);
} 
//end ListTypeRangeAndBytes


/**       
 * -------------------------------------------------------------------
 * 	            Method for Problem 4
 * -------------------------------------------------------------------
 */

/**
 * Asks the user for a word and identifies if it is a Palindrome.
 * 
 * Date Created: 02/01/2022
 */
void IdentifyPalindrome() 
{
    string word;
    //Because string is immutable, we need a StringBuilder.
    StringBuilder palindrome = new StringBuilder();

    Boolean invalid = true;
    do 
    {
        Console.WriteLine("Please input a word to identify as a Palindrome:");
        word = Console.ReadLine();
        word.Trim();

        //The input can be any word, as long as it's not null.
        invalid = (word == null) ? true : false;

        //Tells the user that they will need to input something.
        if (invalid)
        {
            Console.WriteLine("There doesn't seem to be any input. Please try again.");
        }

    } while(invalid);


    for(int i = word.Length - 1; i >= 0; i--) 
    {
        char letter = word[i];
        palindrome.Append(letter);
    }

    Console.WriteLine("Word Inputted: " + word);
    Console.WriteLine("   Palindrome: " + palindrome);

    if (word == palindrome.ToString())
    {
        Console.WriteLine("This word is a Palindrome!");
    }
    else 
    {
        Console.WriteLine("This word is not a Palindrome.");
    }
} 
//end IdentifyPalindrome


/**       
 * -------------------------------------------------------------------
 * 	            Methods for Problem 5
 * -------------------------------------------------------------------
 */
/**
 * Asks the user for a number and performs a Collatz Conjecture on the number.
 * 
 * Date Created: 02/01/2022
 */
void PerformCollatz() 
{
    int iterations = 0;

    Console.WriteLine("Please input a number to perform a Collatz Conjecture.");

    //check keeps the while loop running while the input is invalid.
    Boolean check = true;
    while (check)
    {
        //runs the while loop infinitely until the user inputs a valid number.
        try
        {
            numbersArray[0] = System.Convert.ToInt32(Console.ReadLine());

            //numbersArray[1] will keep track of the original number, as numbersArray[0] will be modifed.
            numbersArray[1] = numbersArray[0];


            string decision = "";
            //Ask the user for confirmation.
            Console.WriteLine("Are you sure you want to use " + numbersArray[0] + " for the Collatz Conjecture?\n(Type \"No\" to go back, otherwise, type anything to proceed.)");
            decision = Console.ReadLine();

            //If the user input "No", keeps check true and reiterates. Otherwise, continue. 
            check = (decision.ToLower() == "no" || decision.ToLower() == "\"no\"") ? true : false;
        }
        //Converting to an Int32 can have 2 exceptions. They are handled here:
        catch (FormatException)
        {
            Console.WriteLine("This is not a valid number. Please input a number:");
        }
        catch (OverflowException)
        {
            Console.WriteLine("That number's too big! Please input a smaller number to add.");
        }
    }

    //Loosely determines if the code should continue.
    Boolean continueIteration = true;
    StringBuilder endingString = new StringBuilder();

    //This while loop keeps running until we hit the (4, 2, 1) sequence 3 times.
    while (true)
    {
        //4 signifies an infinite loop, so we "stop" our loop there.
        if (numbersArray[0] <= 4 && numbersArray[0] != 3) 
        {
            //Performs a fixed amount of loops.
            continueIteration = false;
            iterations += 2;
        }

        Boolean isOdd = numbersArray[0] % 2 == 1;

        //continueIteration becomes false when a 4 is sensed.
        if (continueIteration)
        {
            if (isOdd)
            {
                //Statement has a chance of throwing an OverFlowException.
                //A try-catch could be added here, but it will interfere with the loop.
                numbersArray[0] = (numbersArray[0] * 3) + 1;
            }
            else
            {
                numbersArray[0] = numbersArray[0] / 2;
            }
            endingString.Append(numbersArray[0] + " -> ");
            iterations++;
        }
        //when false, we continue the loop for a fixed amount of times before ending.
        else 
        {
            for (int i = 0; i < 8; i++) 
            {
                isOdd = numbersArray[0] % 2 == 1;
                if (isOdd)
                {
                    //Statement has a chance of throwing an OverFlowException.
                    //A try-catch could be added here, but it will interfere with the loop.
                    numbersArray[0] = (numbersArray[0] * 3) + 1;
                }
                else
                {
                    numbersArray[0] = numbersArray[0] / 2;
                }
                endingString.Append(numbersArray[0] + " -> ");
            }
            break;
        }
    }

    Console.WriteLine("\nInput: " + numbersArray[1]);
    Console.WriteLine("Output: " + endingString.ToString().Remove(endingString.Length - 4));
    Console.WriteLine(iterations + " Hailstones");
} 
//end PerformCollatz



















