/**       
 * -------------------------------------------------------------------
 * 	   File name: FileRoot.cs
 * 	Project name: Lab4-FileIOAndTextManipulation
 * -------------------------------------------------------------------
 * Author’s name and email:	Michael Ng, ngmw01@etsu.edu			
 *          Course-Section: CSCI-2910-001
 *           Creation Date:	02/15/2022	
 *           Last Modified: 02/16/2022
 * -------------------------------------------------------------------
 */
using Lab4_FileIOAndTextManipulation;
using System;
using System.IO;


namespace Lab4_FileIOAndTextManipulation
{
    public class FileRoot
    {
        //Fields for the FileRoot Class
        string path { get; init; }
        char separatorChar { get; init; }

        /**
         * The constructor of the FileRoot class.
         * Initializes the path to the top-level directory.
         * 
         * Date Created: 02/15/2022
         */
        public FileRoot() 
        {
            path = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent).ToString();
            separatorChar = Path.DirectorySeparatorChar;
        }

        /**
         * Overrides the ToString method and
         * returns the path instead.
         * 
         * Date Created: 02/16/2022
         */
        public override string ToString() 
        {
            return path;
        }
    }
}
