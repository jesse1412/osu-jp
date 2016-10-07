using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace osu_jp
{

    class BeatmapDB
    {

        List<Beatmap> loadedMaps;

        public BeatmapDB(string osuDir)
        {

            if(checkDirectoryValidity(osuDir) != true)
            {

                throw new Exception("Invalid osu! directory. You should not have seen this exception; please contact the developer.");

            }

            else
            {

                loadedMaps = getBeatMaps(osuDir + "\\Songs");

            }

        }

        /// <summary>
        /// Check whether the given directory exists.
        /// </summary>
        /// <param name="assumedOsuDirectory">osu! Main directory.</param>
        /// <returns>True/false if directory is valid/invalid. Null if "C:\Program Files (x86)\osu!" found valid.</returns>
        public static bool? checkDirectoryValidity(string assumedOsuDirectory)
        {

            if (Directory.Exists(assumedOsuDirectory))
            {

                return true;

            }

            else if (Directory.Exists(@"C:\Program Files (x86)\osu!"))
            {

                return null;

            }

            else
            {

                return false;

            }

        }

        /// <summary>
        /// Load osu! maps from the given directory to this objects "loadedMaps".
        /// </summary>
        /// <param name="beatmapDirectory"></param>
        private List<Beatmap> getBeatMaps(string beatmapDirectory)
        {

            string[] songFolders;
            string[] songFiles;
            StreamReader osuFileReader;
            List<Beatmap> processingMaps = new List<Beatmap>();

            songFolders = Directory.GetDirectories(beatmapDirectory);
            songFiles = Directory.GetFiles(beatmapDirectory, "*.osu");

            foreach (string songFolder in songFolders)
            {

                songFiles.Concat(Directory.GetFiles(songFolder, "*.osu"));

            }

            foreach (string osuFile in songFiles)
            {

                osuFileReader = new StreamReader(osuFile);
                processingMaps.Add(new Beatmap(osuFileReader));
                osuFileReader.Close();

            }

            return processingMaps;

        }

    }

}
