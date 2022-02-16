/**       
 * -------------------------------------------------------------------
 * 	   File name: Person.cs
 * 	Project name: Lab 3 - C Classes
 * -------------------------------------------------------------------
 * Author’s name and email:	Michael Ng, ngmw01@etsu.edu			
 *          Course-Section: CSCI-2910-001
 *           Creation Date:	02/08/2022	
 *           Last Modified: 02/09/2022
 * -------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3___C_Classes
{
    public class Person
    {
        List<string> _arrayOfFirstNames = new List<string> { "John", "Marie", "Devin", "May", "Connor", "Emily", "Nathan", "Joseph", 
            "Elissa", "Amy", "Peter", "Tina", "Lester", "Bennet", "Robin"}; 
        List<Dependent> dependents = new List<Dependent>();

        //init assigns a value to the property only during object construction.
        public string FirstName {  get; init; }
        public string LastName { get; init; }
        public DateTime BirthDate { get; init; }
        public SSN SSN { get; init; }
        public Phone Phone { get; init; }


        /**
         * The primary constructor for the Person Class.
         * 
         * Date Created: 02/08/2022
         */
        public Person() 
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(_arrayOfFirstNames.Count);

            FirstName = _arrayOfFirstNames[randomNumber];


            //Assign a random Last Name.
            //Thanks to: https://dirask.com/posts/C-NET-get-random-element-from-enum-X13Qrp
            Type type = typeof(LastName);
            Array values = type.GetEnumValues();
            randomNumber = rnd.Next(values.Length);
            LastName = values.GetValue(randomNumber).ToString();



            //Get a random Month
            int mon = rnd.Next(12) + 1;
            int day = rnd.Next(28) + 1;

            //If the month is not february, add 0-2 more days.
            if (mon != 2) 
            {
                day += rnd.Next(2);
            }

            //Determines if the month is a long month.
            //If so, turn isLongMonth true.
            Boolean isLongMonth = false;
            switch (mon) 
            {
                //January has 31 days.
                case 1:
                    isLongMonth = true;
                    break;
                //March has 31 days.
                case 3:
                    isLongMonth = true;
                    break;
                //May has 31 days.
                case 5:
                    isLongMonth = true;
                    break;
                //July has 31 days.
                case 7:
                    isLongMonth = true;
                    break;
                //August has 31 days.
                case 8:
                    isLongMonth = true;
                    break;
                //October has 31 days.
                case 10:
                    isLongMonth = true;
                    break;
                //December has 31 days.
                case 12:
                    isLongMonth = true;
                    break;
                default:
                    break;
            }
            //If the month is a month with 31 days, add 0-1 more days.
            if (isLongMonth)
            {
                day += rnd.Next(1);
            }

            BirthDate = DateTime.Parse($"{mon}/{day}/{DateTime.Now.Year - (rnd.Next(65) + 15)}");

            //Change the time of birth. 12:00:00 AM won't be everyone's time of birth.
            BirthDate = BirthDate.AddHours(rnd.Next(24));
            BirthDate = BirthDate.AddMinutes(rnd.Next(60));
            BirthDate = BirthDate.AddSeconds(rnd.Next(60));


            SSN = new SSN();

            Phone = new Phone();

            

            //Add a few dependents under the person's name.
            randomNumber = rnd.Next(3);
            for (int i = 0; i < randomNumber; i++) 
            {
                Dependent dp = new Dependent();
                addDependent(dp);
            }

        }

         /**
         * Determines the age of the person.
         * 
         * Date Created: 02/09/2022
         */
        public int Age() 
        {
            int thisYear = int.Parse(DateTime.Now.Year.ToString());
            int birthDateYear = int.Parse(BirthDate.Year.ToString());
            return thisYear - birthDateYear;
        }


        /**
         * A method used to add a dependent to the dependents List.
         * 
         * Date Created: 02/09/2022
         * 
         * @param dp (Dependent)
         */
        public void addDependent(Dependent dp) 
        {
            dependents.Add(dp);
        }


        /**
         * The toString() method for the Person class.
         * 
         * Date Created: 02/09/2022
         * 
         * @return sb.ToString() (string)
         */
        public string ToString(char separator) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{FirstName} {LastName} ({Age()})");
            sb.Append("\nDate of Birth: " + BirthDate);
            sb.Append("\n          SSN: " + SSN.ToString());
            sb.Append("\n Phone Number: " + Phone.Format(separator));
            sb.Append("\nDependents: \n");
            if (dependents.Count > 0)
            {
                foreach (Dependent dp in dependents)
                {
                    sb.Append($" - {dp.FirstName} {dp.LastName} ({dp.Age()})\n");
                }
            }
            else 
            {
                sb.Append("(This person has no dependents.)\n");
            }
            sb.Append("----------\n");

            return sb.ToString();
        }


        /**
         * A more condensed version of the toString method for the Person class.
         * 
         * Date Created: 02/09/2022
         * 
         * @return sb.ToString() (string)
         */
        public string ShortToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{FirstName} {LastName} ({Age()}, {dependents.Count} Dependents)");
            sb.Append($"\n - SSN: {SSN.ToString()}\n");

            return sb.ToString();
        }
    }
}

