using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace osu_jp
{

    public struct osuNote
    {

        public int xCoOrdinate;
        public int yCoOrdinate;
        public int timeMS;

        public osuNote(int x, int y, int time)
        {

            xCoOrdinate = x;
            yCoOrdinate = y;
            timeMS = time;

        }

    }

    public class Beatmap
    {

        public string songArtist;
        public string songTitle;
        public string mapCreator;
        public string mapDifficultyName;

        public List<osuNote> mapNotes;

        public double mapDrain;
        public double mapOverallDifficulty;
        public double mapCircleSize;
        public double mapApproachRate;
        public double mapSliderTickRate;
        public double mapSliderMultiplier;

        public Beatmap(StreamReader mapOsuFileReader)
        {

            mapNotes = new List<osuNote>();
            loadOsuFile(mapOsuFileReader);

        }

        /// <summary>
        /// Load file from given StreamReader into useable beatmap format. Data is saved to this object.
        /// </summary>
        /// <param name="mapOsuFileReader"></param>
        private void loadOsuFile(StreamReader mapOsuFileReader)
        {

            string currentLine;
            string leftSideOfColon;
            string rightSideOfColon = "";
            string[] splitAtColon;

            bool exitLoop = false;

            //Cycle through the map file until all lines have been processed.
            while (!mapOsuFileReader.EndOfStream)
            {

                currentLine = mapOsuFileReader.ReadLine();

                splitAtColon = currentLine.Split(':');

                leftSideOfColon = splitAtColon[0];

                if (splitAtColon.Count() > 1 && splitAtColon[1].Length > 0)
                {

                    rightSideOfColon = currentLine.Substring(leftSideOfColon.Length + 1);

                }

                switch (leftSideOfColon)
                {

                    case "Title":
                        songTitle = rightSideOfColon;
                        break;
                    case "Artist":
                        songArtist = rightSideOfColon;
                        break;
                    case "Creator":
                        mapCreator = rightSideOfColon;
                        break;
                    case "Version":
                        mapDifficultyName = rightSideOfColon;
                        break;
                    case "HPDrainRate":
                        mapDrain = double.Parse(rightSideOfColon);
                        break;
                    case "CircleSize":
                        mapCircleSize = double.Parse(rightSideOfColon);
                        break;
                    case "OverallDifficulty":
                        mapOverallDifficulty = double.Parse(rightSideOfColon);
                        break;
                    case "ApproachRate":
                        mapApproachRate = double.Parse(rightSideOfColon);
                        break;
                    case "SliderMultiplier":
                        mapSliderMultiplier = double.Parse(rightSideOfColon);
                        break;
                    case "SliderTickRate":
                        mapSliderTickRate = double.Parse(rightSideOfColon);
                        break;
                    case "[HitObjects]":
                        string[] currentLineSplit;
                        int thisNoteX;
                        int thisNoteY;
                        int thisNoteTime;
                        while ((currentLine = mapOsuFileReader.ReadLine()) != null)
                        {

                            currentLineSplit = currentLine.Split(',');

                            thisNoteX = int.Parse(currentLineSplit[0]);
                            thisNoteY = int.Parse(currentLineSplit[1]);
                            thisNoteTime = int.Parse(currentLineSplit[2]);

                            mapNotes.Add(new osuNote(thisNoteX, thisNoteY, thisNoteTime));

                        }
                        break;

                }

            }

        }

    }

}
