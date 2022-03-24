/**       
 * -------------------------------------------------------------------
 * 	   File name: Address.cs
 * 	Project name: Lab4-FileIOAndTextManipulation
 * -------------------------------------------------------------------
 * Author’s name and email:	Michael Ng, ngmw01@etsu.edu			
 *          Course-Section: CSCI-2910-001
 *           Creation Date:	02/15/2022	
 *           Last Modified: 02/17/2022
 * -------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_FileIOAndTextManipulation
{
    public class Address
    {
        //Fields for the Address class.
        int Number { get; init; }
        string Street { get; init; }
        string? County { get; init; }
        string City { get; init; }
        State State { get; init; }
        int ZipCode { get; init; }

        /*
         * The constructor for the Address class.
         * 
         * Date Created: 02/17/2022
         * @param number, ZipCode (int)
         * @param city, state (string)
         */
        public Address(string address, string city, string state, string zipCode, string? county) 
        {
            //We will need to format address to get number and street.
            string[] addressParts = address.Split(' ');

            //The number comes first, then the street.
            Number = int.Parse(addressParts[0]);

            //Assemble the street using a for-loop.
            StringBuilder street = new StringBuilder();
            for (int i = 1; i < addressParts.Length; i++) 
            {
                street.Append(addressParts[i]);
            }

            County = county;

            Street = street.ToString();

            City = city;

            State = new State(state);

            ZipCode = int.Parse(zipCode);
        }


        /*
         * The overriding ToString for the Address class.
         * 
         * Date Created: 02/17/2022
         * @return $"{Number} {Street} | {City} {State.FullName}, {ZipCode}"
         */
        public override string ToString() 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Number} {Street} | {City} {State.FullName}, {ZipCode}");

            //If County is not null, we append it to sb.
            if (County != null) 
            {
                sb.Append($" | {County}");
            }

            return sb.ToString();
        }


        /*
         * The overriding ToString for the Address class.
         * 
         * Date Created: 02/17/2022
         * @return $"{Number} {Street} | {City} {State.FullName}, {ZipCode}"
         */
        public string ShortToString()
        {
            return $"{City}, {State.FullName}";
        }

    }
}
