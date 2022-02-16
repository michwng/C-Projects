/**       
 * -------------------------------------------------------------------
 * 	   File name: Program.cs
 * 	Project name: Lab 3 - C Classes
 * -------------------------------------------------------------------
 * Author’s name and email:	Michael Ng, ngmw01@etsu.edu			
 *          Course-Section: CSCI-2910-001
 *           Creation Date:	02/08/2022	
 *           Last Modified: 02/09/2022
 * -------------------------------------------------------------------
 */


//Import other classes into Program.cs.
using Lab_3___C_Classes;


//Fields for Program.cs.
int menuChoice;
List<Person> listOfPeople = new List<Person>();
char defaultPhoneFormat = '-';


//The 'main method'.
while (true) 
{
    menu();
    launchMethod();
}



/**       
 * -------------------------------------------------------------------
 * 	            
 * 	            Menu Methods
 * 	            
 * -------------------------------------------------------------------
 */
/**
 * This method acts as the menu. 
 * Lists the available applications and inputs.
 * Validates user input.
 * 
 * Date Created: 02/08/2022
 */
void menu() 
{
    Console.WriteLine("Welcome to the Random Data Generator Console!");

    //Continues asking the user for the right input.
    do 
    {
        Console.WriteLine("Please type the number next to the option to proceed:");
        Console.WriteLine("1. Create a Person Object");
        Console.WriteLine("2. View All Person Objects (Short)");
        Console.WriteLine("3. View All Person Objects");
        Console.WriteLine("4. Remove a Person Object");
        Console.WriteLine("5. Get a Random Last Name");
        Console.WriteLine("6. Get a Random SSN");
        Console.WriteLine("7. Get a Random Phone Number");
        Console.WriteLine("8. Exit the Application");
        try
        {
            String input;
            input = Console.ReadLine();

            menuChoice = Int32.Parse(input.Trim());

            if (menuChoice > 0 && menuChoice < 9)
            {
                break;
            }
            else
            {
                Console.WriteLine("Oops! This number is not an option.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Oops! This isn't a number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Oops! This number is not an option.");
        }
        catch (ArgumentNullException) 
        {
            //Repeat the top message again, asking the user to input a number.
        }
    }
    while(true);
}
//end menu()

/**
 * This method launches a method based on 
 * user input in the menu() method.
 * 
 * Date Created: 02/08/2022
 */
void launchMethod() 
{
    Console.Clear();

    switch (menuChoice) 
    {
        //Create a Person Object
        case 1:
            createAPerson();
            break;


        //View All Person Objects (Short)
        case 2:
            viewAllPeople(true);
            break;


        //View All Person Objects
        case 3:
            viewAllPeople(false);
            break;


        //Remove a Person Object
        case 4:
            removeAPerson();
            break;


        //Get a Random Last Name
        case 5:
            getRandomLastName();
            break;


        //Get a Random SSN
        case 6:
            getRandomSSN();
            break;


        //Get a Random Phone Number
        case 7:
            getRandomPhoneNumber();
            break;


        //Exit the Application
        case 8:
            Console.WriteLine("Thank you for using RandomDataGenerator!");
            System.Environment.Exit(0);
            break;


        //Debug variable, in case there are errors with the Console.
        default:
            Console.WriteLine("Oops! An error happened somewhere. Ending the Application.");
            System.Environment.Exit(0);
            break;
    }

    Console.WriteLine("\n----- End of Method -----\n\n");
}
//end launchMethod()



/**       
 * -------------------------------------------------------------------
 * 	            
 * 	            Program Methods
 * 	            
 * -------------------------------------------------------------------
 */

/**
 * Creates a person based on user input and 
 * stores the newly made person into the listOfPeople list.
 * 
 * A few attributes are validated.
 * 
 * Date Created: 02/08/2022
 */
void createAPerson() 
{
    Person person = new Person();

    Console.WriteLine("A Person has been created!");
    Console.WriteLine($"{person.FirstName} {person.LastName} ({person.Age()})");
    Console.WriteLine($" - SSN: {person.SSN.ToString()}\n");

    //Add the newly created person if there are less than 10 people in the listOfPeople.
    if (listOfPeople.Count > 9)
    {
        Console.WriteLine("-------------------------------------------" +
                          "\nThere are too many people in the List! " +
                          "\nPlease remove one in order to make more.\n" +
                          "-------------------------------------------\n");
    }
    else
    {
        listOfPeople.Add(person);
    }
}



/**
 * Allows the user to view the people they've 'made'.
 * 
 * Date Created: 02/09/2022
 */
void viewAllPeople(Boolean concise) 
{
    if (listOfPeople.Count > 0)
    {
        //If there are 5 or less people, show the full details of all of them.
        if (!concise)
        {
            char separator;
            Console.WriteLine("Please input a character to use as a separator for the Phone Number.\n" +
                "(For Example, type \"-\" to format Phone Numbers as XXX-XXX-XXXX.");
            try
            {
                separator = Console.ReadLine().ToString().ToCharArray()[0];
                defaultPhoneFormat = separator;
            }
            //May throw an IndexOutOfRangeException if the user enters nothing.
            catch (IndexOutOfRangeException) 
            {
                //"-" is the default separator, so we use it if the user enters nothing.
                separator = '-';
            }



            Console.WriteLine("---------- Start of List ----------\n");
            foreach (Person person in listOfPeople)
            {
                Console.WriteLine(person.ToString(separator));
            }
            Console.WriteLine("\n---------- End of List ----------\n");
        }
        else
        {
            Console.WriteLine("---------- Start of List ----------\n");
            foreach (Person person in listOfPeople)
            {
                Console.WriteLine(person.ShortToString());
            }
            Console.WriteLine("---------- End of List ----------\n");
        }
        Console.WriteLine("<<<You can scroll up to view people at the top of the list.>>>");
    }
    else 
    {
        Console.WriteLine("There is noone to view. \nPlease create a Person.");
    }
}




/**
 * Removes a person from the list as indicated by the user.
 * 
 * Date Created: 02/09/2022
 */
void removeAPerson() 
{
    //There must be someone in the listOfPeople to remove.
    if (listOfPeople.Count > 0)
    {
        do
        {
            foreach (Person person in listOfPeople)
            {
                Console.WriteLine(person.ShortToString());
            }
            Console.WriteLine("Please write the SSN of the Person you want to Remove. (Type \"-1\" to exit.)");
            string input = Console.ReadLine();
            if (input.Length == 11)
            {
                foreach (Person person in listOfPeople)
                {
                    if (input == person.SSN.ToString())
                    {
                        Console.WriteLine($"{person.FirstName} {person.LastName} was successfully removed.");
                        listOfPeople.Remove(person);
                        return;
                    }
                }
                Console.WriteLine("This SSN doesn't appear to match anyone's SSN.");
            }
            else if (input.Trim() == "-1")
            {
                return;
            }
            else 
            {
                Console.WriteLine("This SSN might not be correctly formatted.\nType as \"XXX-XX-XXXX\".\n\n");
            }

        } while (true);
    }
    else 
    {
        Console.WriteLine("There is noone to remove. \nPlease create a Person.");
    }
}



/**
 * Gets a random last name from the listOfPeople list. 
 * 
 * Date Created: 02/09/2022
 */
void getRandomLastName()
{
    if (listOfPeople.Count > 0)
    {
        Random random = new Random();
        int randomIndex = random.Next(listOfPeople.Count);

        Console.WriteLine("Random Last Name: " + listOfPeople.ElementAt(randomIndex).LastName);
        Console.WriteLine("Info about the Person:\n" + listOfPeople.ElementAt(randomIndex).ToString(defaultPhoneFormat));
    }
    else 
    {
        Console.WriteLine("You haven't created a Person yet.\nPlease create a person.");
    }
}


/**
 * Gets a random SSN from the listOfPeople list.
 * 
 * Date Created: 02/09/2022
 */
void getRandomSSN()
{
    if (listOfPeople.Count > 0)
    {
        Random random = new Random();
        int randomIndex = random.Next(listOfPeople.Count);

        Console.WriteLine("Random SSN: " + listOfPeople.ElementAt(randomIndex).SSN.ToString());
        Console.WriteLine("Info about the Person:\n" + listOfPeople.ElementAt(randomIndex).ToString(defaultPhoneFormat));
    }
    else
    {
        Console.WriteLine("You haven't created a Person yet.\nPlease create a person.");
    }
}


/**
 * Gets a random Phone Number from the listOfPeople list.
 * 
 * Date Created: 02/09/2022
 */
void getRandomPhoneNumber()
{
    if (listOfPeople.Count > 0)
    {
        Random random = new Random();
        int randomIndex = random.Next(listOfPeople.Count);

        Console.WriteLine("Random Phone Number: " + listOfPeople.ElementAt(randomIndex).Phone.Format(defaultPhoneFormat));
        Console.WriteLine("Info about the Person:\n" + listOfPeople.ElementAt(randomIndex).ToString(defaultPhoneFormat));
    }
    else
    {
        Console.WriteLine("You haven't created a Person yet.\nPlease create a person.");
    }
}




