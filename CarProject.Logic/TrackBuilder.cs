using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Logic
{
    public class TrackBuilder
    {
        private (int, int)[] sectionInfos;
        private Track _track;

        public Track Track => _track;

        public TrackBuilder((int, int)[] sectionInfos)
        {
            this.sectionInfos = sectionInfos;
            BuildTrack();
        }

        private void BuildTrack()
        {
            List<Section> sections = new();
            foreach((int speed, int length) in sectionInfos)
            {
                Section newSection = new Section(speed, length);
                sections.Add(newSection);
            }
            for(int i = 0; i < sections.Count -1; i++)
            {
                sections[i].AddAfterMe(sections[i+1]);
            }
            _track = new Track(sections);
        }
    }
}
