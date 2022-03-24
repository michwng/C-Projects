/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 4/28/2014
 * Time: 2:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 * Found at: https://github.com/danogwok/mp3player/blob/master/Player.cs
 * Thanks again to Daniel for sharing the source code! (Username: danogwok)
 */
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MP3_Player
{
	/// <summary>
	/// Description of Player.
	/// </summary>
	public class Player
	{
		//Import the dll "winmn.dll", which allows the application to play mp3 files.
		[DllImport("winmm.dll")]

		//mciSendString controls the usage of mp3 files.
		//The most important parameter is lpstrCommand, which is where we control the mp3 file.
		private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);


		//Opens the music file.
		public void Open(string file)
		{
			string command = "open \"" + file + "\" type MPEGVideo alias Music";
			mciSendString(command, null, 0, 0);
		}

		//An addition to the original source code
		//Adder: Michael Ng, ngmw01@etsu.edu
		public void Pause() 
		{
			string command = "pause Music wait";
			mciSendString(command, null, 0, 0);
		}

		//Another addition to the original source code
		//Adder: Michael Ng, ngmw01@etsu.edu
		public void PlayFrom(int startMilliseconds, int endMilliseconds)
		{
			string command = "play Music from {startMilliseconds} to {endMilliseconds} wait";
			mciSendString(command, null, 0, 0);
		}

		//Modified original code. Added " repeat" after "play Music".
		public void Play()
		{
			string command = "play Music repeat";
			mciSendString(command, null, 0, 0);
		}

		//Added overriding method.
		//Allows the user to determine whether or not they want to loop the song.
		public void Play(Boolean loop = false)
		{
			if (loop)
			{
				string command = "play Music repeat";
				mciSendString(command, null, 0, 0);
			}
			else 
			{
				string command = "play Music";
				mciSendString(command, null, 0, 0);
			}
		}

		//Stops the music and closes the music file.
		public void Stop()
		{
			string command = "stop Music";
			mciSendString(command, null, 0, 0);

			command = "close Music";
			mciSendString(command, null, 0, 0);
		}
	}

}