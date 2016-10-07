using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_jp
{

    class Program
    {

        static void Main(string[] args)
        {


            Contents mainContent = new Contents(promptOsuDir());

        }

        /// <summary>
        /// Prompt user for desired song directory.
        /// </summary>
        /// <returns>Valid directory containing a "Songs" folder.</returns>
        public static string promptOsuDir()
        {

            const string DEFAULT_OSU_DIR = @"C:\Program Files (x86)\osu!";
            string readLine;
            bool? dirValidity;

            if (BeatmapDB.checkDirectoryValidity(DEFAULT_OSU_DIR) == true)
            {

                while (true)
                {

                    Console.WriteLine("Use this as target osu! directory: \"" + DEFAULT_OSU_DIR + "\"");
                    Console.WriteLine("Y/N?");

                    readLine = Console.ReadLine().Trim().ToLower();

                    if (readLine == "y")
                    {

                        return DEFAULT_OSU_DIR;

                    }

                    else if (readLine == "n")
                    {

                        break;

                    }

                    else
                    {

                        Console.WriteLine("Only Y/N Accepted.\n");

                    }

                }

            }

            while(true)
            {

                Console.WriteLine("Enter target osu! directory (any directory which contains a valid \"Songs\" folder):");
                readLine = Console.ReadLine().Trim();
                dirValidity = BeatmapDB.checkDirectoryValidity(readLine);

                if (dirValidity == true)
                {

                    return readLine;

                }

                else if (dirValidity == null)
                {

                    Console.WriteLine("Invalid directory.");
                    return promptOsuDir();

                }

                else
                {

                    Console.WriteLine("Invalid directory.");

                }

            }

        }

    }

}
