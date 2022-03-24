/**       
 * -------------------------------------------------------------------
 * 	   File name: Form1.cs
 * 	Project name: MusicPlayer
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/16/2022	
 *            Last Modified:    03/17/2022
 * -------------------------------------------------------------------
 */
using System.Text;

namespace MP3_Player
{
    //Credit to https://www.c-sharpcorner.com/UploadFile/8ea152/mp3-media-player-in-C-Sharp-4-0/
    //For code assistance.
    public partial class Form1 : Form
    {
        //Status can have the values -1, 0, and 1.
        //-1 means that the application is not playing any music.
        //0 means that the music being played is paused.
        //1 means that the application is currently playing the music.
        int status = -1;

        Player player = new Player();

        string Filename;
        StringBuilder Filepath = new StringBuilder();

        List<string> files = new List<string>();
        List<string> path = new List<string>();
        Boolean loopMusic = true;

        public Form1()
        {
            InitializeComponent();

            //Attempts to find musicDirectory.txt within the project's root folder.
            if (!File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.ToString() + "musicDirectoryLocation.txt"))
            {
                Console.WriteLine("Couldn't find mainDirectory.txt. \nMaking a new text file.");
                File.WriteAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.ToString() + "musicDirectoryLocation.txt", " ");
                openFileDialog1.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
                Filepath.Append(openFileDialog1.InitialDirectory);
            }
            else
            {
                //if musicDirectory.txt exists within the project's folder...
                openFileDialog1.InitialDirectory = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.ToString() + "musicDirectoryLocation.txt");
                Filepath.Append(openFileDialog1.InitialDirectory);
            }
            updateListBox();
        }

        /**
         * References the "Begin Playing" Button.
         * This method is called when the user clicks on the "Begin Playing" Button. 
         * (This is an EventHandler Method)
         * 
         * Begins playing an MP3 File.
         * 
         * Date Created: 03/16/2022
         */
        private void button1_Click(object sender, EventArgs e)
        {
            //Status 0 means paused.
            if (status == 0)
            {
                player.Play();
                status = 1;
            }
            else 
            {
                Filepath.Clear();

                openFileDialog1.Filter = "Audio Files (*.mp3;*.wav)|*.mp3;*.wav|All Files (*.*)|*.*";
                //Allows the use to select an MP3 or WAV file.
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    player.Stop();
                    player.Open(openFileDialog1.FileName);
                    player.Play();

                    string[] fullpath = openFileDialog1.FileName.Split(Path.DirectorySeparatorChar);

                    for (int i = 0; i < fullpath.Length - 1; i++)
                    {
                        Filepath.Append(fullpath[i] + Path.DirectorySeparatorChar);
                    }
                    Filename = fullpath[fullpath.Length - 1];
                    label3.Text = Filename;

                    //Update musicDirectoryLocation to the folder where the user selected the mp3/wav file.
                    File.WriteAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.ToString() + "musicDirectoryLocation.txt", Filepath.ToString());

                    updateListBox();
                }
            }
        }
        
        /**
         * Updates listBox1 to include all the .mp3 and .wav files in the same directory that the user selected.
         * 
         * Date Created: 03/16/2022
         */
        private void updateListBox() 
        {
            files.Clear();
            path.Clear();
            listBox1.Items.Clear();


            if (!files.Contains(Filename))
            {
                label3.Text = Filename;

                //Thanks to https://stackoverflow.com/questions/14330295/how-can-directory-getfiles-multi-searchpattern-filters-c-sharp
                //For allow me to figure out multi-pattern filters.

                //extensions specifies the file types that are accepted. There can be multiple values in it.
                string[] extensions = { "mp3", "wav" };

                string[] testerArray;

                try
                {
                    testerArray = Directory.GetFiles(Filepath.ToString(), "*.*").Where(f => extensions.Contains(f.Split('.').Last().ToLower())).ToArray();
                }
                catch (System.IO.DirectoryNotFoundException) 
                {
                    testerArray = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.*").Where(f => extensions.Contains(f.Split('.').Last().ToLower())).ToArray();
                }

                for (int j = 0; j < testerArray.Length; j++)
                {
                    Filepath.Clear();
                    string[] fullpath = testerArray[j].Split(Path.DirectorySeparatorChar);

                    for (int i = 0; i < fullpath.Length; i++)
                    {
                        Filepath.Append(fullpath[i]);

                        if (i != fullpath.Length - 1)
                            Filepath.Append(Path.DirectorySeparatorChar);
                    }

                    Filename = fullpath[fullpath.Length - 1];
                    files.Add(Filename);
                    listBox1.Items.Add(Filename);
                    path.Add(Filepath.ToString());
                }

                listBox1.Update();

                //files.Add(Filename);
                //path.Add(openFileDialog1.FileName);
                //listBox1.Items.Add(Filename);
            }
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
        }

        /**
         * References the "Stop Playing" Button.
         * This method is called when the user clicks on the "Stop Playing" Button. 
         * (This is an EventHandler Method)
         * 
         * Stops playing an MP3 File.
         * 
         * Date Created: 03/16/2022
         */
        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
            status = -1;
        }

        /**
         * References the "Pause Music" Button.
         * This method is called when the user clicks on the "Pause Music" Button. 
         * (This is an EventHandler Method)
         * 
         * Pauses an MP3 File.
         * 
         * Date Created: 03/16/2022
         */
        private void button3_Click(object sender, EventArgs e) 
        {
            if (status == 1) 
            {
                status = 0;
                player.Pause();
            }
        }

        /**
         * References the "Change Main Directory" Button.
         * This method is called when the user clicks on the "Change Main Directory" Button. 
         * (This is an EventHandler Method)
         * 
         * Changes the main directory. Sets openFileDialog1's InitialDirectory to the specified folder.
         * 
         * Date Created: 03/16/2022
         */
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Filepath.Clear();
                Filepath.Append(folderBrowserDialog1.SelectedPath);
                openFileDialog1.InitialDirectory = folderBrowserDialog1.SelectedPath;
                File.WriteAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.ToString() + "musicDirectoryLocation.txt", Filepath.ToString());
                updateListBox();
            }
        }

        /** -- Commented out: Method does not work --
         * References the "Play from" Button.
         * This method is called when the user clicks on the "Play from" Button. 
         * (This is an EventHandler Method)
         * 
         * Plays a music file from a starting point.
         * 
         * Date Created: 03/16/2022
         *
        private void button5_Click(object sender, EventArgs e)
        {
            if (status == 1)
            {
                player.Stop();
                player.PlayFrom(5000, 50000);
            }
            else if (status == 0) 
            {
                player.PlayFrom(5000, 50000);
            }
        }*/

        /**
         * References the "Loop Music" Button.
         * This method is called when the user clicks on the "Loop Music" Button. 
         * (This is an EventHandler Method)
         * 
         * Determines whether the music will be played repeatedly.
         * 
         * Date Created: 03/17/2022
         */
        private void button7_Click(object sender, EventArgs e)
        {
            if (loopMusic)
            {
                loopMusic = false;
                player.Pause();
                player.Play(false);
                button7.Text = "Loop Music (False)";
            }
            else 
            {
                loopMusic = true;
                player.Pause();
                player.Play();
                button7.Text = "Loop Music (True)";
            }
        }


        /**
         * References the ListBox.
         * This method is called when the user selects a different index in the ListBox. 
         * (This is an EventHandler Method)
         * 
         * Plays the music that the user has selected in the listbox.
         * 
         * Date Created: 03/17/2022
         */
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filepath.Clear();
            listBox1.SelectedItem = path[listBox1.SelectedIndex];

            Filename = listBox1.Text;
            label3.Text = Filename;

            player.Stop();
            player.Open(path[listBox1.SelectedIndex]);
            player.Play();

            status = 1;
        }
    }
}