/**       
 * -------------------------------------------------------------------
 * 	   File name: Phone.cs
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
    public class Phone
    {
        //The only field of the Phone Class.
        public string Number { get; init; }

        /**
         * This constructor creates a random 10-digit number 
         * and assigns it to the Number field.
         * 
         * Date Created: 02/09/2022
         */
        public Phone() 
        {
            // ------ Random Phone Number Building -----
            Random rnd = new Random();
            // The "" makes the compiler think this is a string.
            Number = (rnd.NextInt64(8000000000) + 2000000000) + "";
        }

        /**
         * A ToString method for the Number class.
         * Utilizes an optional argument.
         * 
         * Date Created: 02/09/2022
         * @param separator (char)
         * @return Number (string)
         */
        public string Format(char separator = '-') 
        {

            try
            {
                return $"{Number.Substring(0, 3)}{separator}{Number.Substring(3, 3)}{separator}{Number.Substring(6, 4)}";
            }
            //A "Just-In-Case" Try/Catch method.
            catch (ArgumentOutOfRangeException) 
            {
                return $"{Number.Substring(0, 3)}{separator}{Number.Substring(3, 3)}{separator}{Number.Substring(6, 3)}";
            }
            
        }
    }
}
