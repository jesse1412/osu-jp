using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_jp
{

    class Contents
    {

        public BeatmapDB beatmaps;
        public string workingOsuDir;

        public Contents(string osuDirectory)
        {

            //Load cached DB.
            //Try to load from directory.
            workingOsuDir = osuDirectory;
            propogateBeatmaps();

        }

        public void propogateBeatmaps()
        {

            if(beatmaps != null)
            {

                //Checking for map changes.

            }

            else
            {

                beatmaps = new BeatmapDB(workingOsuDir);

            }

        }

    }

}
