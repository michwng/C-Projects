/**       
 * -------------------------------------------------------------------
 * 	   File name: Dependent.cs
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
    //Dependent is a subclass of Person and inherits from them.
    public class Dependent: Person
    {
        /**
         * The constructor for the Dependent class.
         * It focuses on changing the Birthdate to be between 1 - 10 years old.
         * 
         * Date Created: 02/09/2022
         */
        public Dependent() : base()
        {
            Random rnd = new Random();

            //Get a random Month and Day.
            int mon = rnd.Next(12) + 1;
            int day = rnd.Next(28) + 1;

            //If the month is not february, add 0-2 more days.
            if (mon != 2)
            {
                day += rnd.Next(3);
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
            BirthDate = DateTime.Parse($"{mon}/{day}/{DateTime.Now.Year - (rnd.Next(10) + 1)}");

            //Change the time of birth. 12:00:00 AM won't be everyone's time of birth.
            BirthDate = BirthDate.AddHours(rnd.Next(24));
            BirthDate = BirthDate.AddMinutes(rnd.Next(60));
            BirthDate = BirthDate.AddSeconds(rnd.Next(60));
        }
    }
}
