/**       
 * -------------------------------------------------------------------
 * 	   File name: repo.cs
 * 	Project name: WebAPIClient
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/30/2022	
 *            Last Modified:    03/30/2022
 * -------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WebAPIClient
{
    //This class is meant to represent the JSON object returned from the GitHub API.
    //This class displays a list of repository names.
    public class Repository
    {
        //With this addition, Name appears as "name" in JSON.
        [JsonPropertyName("name")]
        public string Name { get; set; }

        //With this addition, Description appears as "description" in JSON.
        [JsonPropertyName("description")]
        public string Description { get; set; }

        //GitHubHomeUrl appears as "html_url" in JSON.
        [JsonPropertyName("html_url")]
        public Uri GitHubHomeUrl { get; set; }

        //Homepage appears as "homepage" in JSON.
        [JsonPropertyName("homepage")]
        public Uri Homepage { get; set; }

        //Watchers appears as "watchers" in JSON.
        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        //The Uri and int types can convert to and from string representation.
        //No extra code is needed to deserialize from JSON string format
        //to those target types.

        //Date is formatted as this in JSON: YYYY-MM-DDTHH:MM:SSZ
        //For example: 2016-02-08T21:27:00Z.
        //LastPushUtc appears as "pushed_at" in JSON.
        [JsonPropertyName("pushed_at")]
        public DateTime LastPushUtc { get; set; }
        public DateTime LastPush => LastPushUtc.ToLocalTime();
    }
}
