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

        public TrackBuilder((int, int)[] sectionInfos, bool closeTrack = false)
        {
            this.sectionInfos = sectionInfos;
            BuildTrack(closeTrack);
        }

        private void BuildTrack(bool closeTrack)
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
            if(closeTrack && sections.Count > 1)
            {
                Section first = sections[0];
                Section last = sections[^1];
                first.AddBeforeMe(last);
            }
            _track = new Track(sections);
        }
    }
}
