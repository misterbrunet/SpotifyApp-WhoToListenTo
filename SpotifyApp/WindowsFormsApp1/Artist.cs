using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoToListenTo
{
    /// <summary>
    /// Object representing stacked features describing one particular Artist.
    /// </summary>
    public class Artist
    {
        public string artistID { get; set; }
        public string artist_name { get; set; }
        public long followers { get; set; }
        public string[] genres { get; set; }
        public double danceability { get; set; }
        public double energy { get; set; }
        public double loudness { get; set; }
        public double tempo { get; set; }
        public short count { get; set; }
    }
}
