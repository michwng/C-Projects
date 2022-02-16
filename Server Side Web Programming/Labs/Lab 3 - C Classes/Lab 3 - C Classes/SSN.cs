/**       
 * -------------------------------------------------------------------
 * 	   File name: SSN.cs
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
    public class SSN
    {
        //The only field for the SSN class.
        public string Number { get; init; }


        /**
         * Using http://probativity.com/invalid-or-impossible-social-security-numbers/#:~:text=The%20following%20SSNs%20are%20invalid%20and%20do%20not,July%201%2C%201963%2C%20then%20discontinued%29%20More%20items...%20
         * for Invalid Social Security number references.
         * The listed 4 at the middle of the webpage are used for all invalid SSN implementations.
         * This constructor builds the invalid SSN.
         * 
         * Date Created: 02/09/2022
         */
        public SSN() 
        {
            Random rnd = new Random();
            // ------ Random SSN Building -----
            StringBuilder temp = new StringBuilder();
            int randomNumber = rnd.Next(4);

            // === Appending the first 3 digits
            //Determine the type of invalid SSN.
            switch (randomNumber) 
            {
                //Area composed of all 0's.
                case 0:
                    temp.Append("000");
                    break;

                //Area composed of The Cursed Number.
                case 1:
                    temp.Append("666");
                    break;

                //Area composed of numbers from 700 - 728.
                case 2:
                    randomNumber = rnd.Next(29);
                    temp.Append((700 + randomNumber).ToString());
                    break;

                //Area composed of numbers from 900-999
                case 3:
                    randomNumber = rnd.Next(100);
                    temp.Append((900 + randomNumber).ToString());
                    break;

                //Defaults to all 0's for area.
                default:
                    temp.Append("000");
                    break;
            }

            // === Appending the next 2 digits
            randomNumber = rnd.Next(100);
            //randomNumber could be 7, so we add a placeholder 0 if so.
            //So, we have 07.
            if (randomNumber.ToString().Length == 1)
            {
                temp.Append(0);
            }
            //Middle 2 Digits
            temp.Append(randomNumber);

            // === Appending the last 4 digits
            randomNumber = rnd.Next(10000);
            //randomNumber could be 3 or less digits, so we add these to append placeholder 0's.
            //So, we have 4 digits.
            if (randomNumber.ToString().Length <= 3)
            {
                temp.Append(0);
            }
            if (randomNumber.ToString().Length <= 2)
            {
                temp.Append(0);
            }
            if (randomNumber.ToString().Length == 1)
            {
                temp.Append(0);
            }
            //Last 4 digits
            temp.Append(randomNumber);

            Number = temp.ToString();
        }

        /**
         * A ToString method to correctly format the SSN.
         * 
         * Date Created: 02/09/2022
         * @return Number
         */
        public string ToString()
        {
            return Number.Substring(0, 3) + "-" + Number.Substring(3, 2) + "-" + Number.Substring(5, 4);
        }
    }
}
