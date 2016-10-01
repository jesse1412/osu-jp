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

        public int mapDrain;
        public int mapOverallDifficulty;
        public int mapCircleSize;
        public int mapApproachRate;
        public int mapSliderTickRate;
        public int mapSliderMultiplier;

        public Beatmap(StreamReader mapOsuFileReader)
        {

            loadOsuFile(mapOsuFileReader);

        }

        /// <summary>
        /// Load file from given StreamReader into useable beatmap format.
        /// </summary>
        /// <param name="mapOsuFileReader"></param>
        private void loadOsuFile(StreamReader mapOsuFileReader)
        {

            string currentLine;
            string leftSideOfColon;
            string rightSideOfColon = "";

            bool exitLoop = false;

            //Cycle through the map file until all lines have been processed.
            while ((currentLine = mapOsuFileReader.ReadLine()) != "")
            {

                leftSideOfColon = currentLine.Split(':')[0];

                if (leftSideOfColon.Count() > 1)
                {

                    rightSideOfColon = currentLine.Substring(leftSideOfColon.Length + 2);

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
                        mapDrain = int.Parse(rightSideOfColon);
                        break;
                    case "CircleSize":
                        mapCircleSize = int.Parse(rightSideOfColon);
                        break;
                    case "OverallDifficulty":
                        mapOverallDifficulty = int.Parse(rightSideOfColon);
                        break;
                    case "ApproachRate":
                        mapApproachRate = int.Parse(rightSideOfColon);
                        break;
                    case "SliderMultiplier":
                        mapSliderMultiplier = int.Parse(rightSideOfColon);
                        break;
                    case "SliderTickRate":
                        mapSliderTickRate = int.Parse(rightSideOfColon);
                        break;
                    case "[HitObjects]":
                        string[] currentLineSplit;
                        int thisNoteX;
                        int thisNoteY;
                        int thisNoteTime;
                        while ((currentLine = mapOsuFileReader.ReadLine()) != "")
                        {
                            currentLineSplit = currentLine.Split(',');

                            thisNoteX = int.Parse(currentLineSplit[0]);
                            thisNoteY = int.Parse(currentLineSplit[1]);
                            thisNoteTime = int.Parse(currentLineSplit[2]);

                            mapNotes.Add(new osuNote());

                        }
                        exitLoop = true;
                        break;

                }

                if (exitLoop)
                {

                    break;

                }

            }

        }

    }

}
