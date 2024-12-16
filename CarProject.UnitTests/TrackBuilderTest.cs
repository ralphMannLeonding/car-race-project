using CarProject.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarProject.UnitTests
{
    [TestClass]
    public class TrackBuilderTest
    {
        [TestMethod]
        public void ItShouldBuildAConnectedTrack_GivenSectionInformation()
        {
            (int,int)[] sectionInfos = {(10,10),(20,20),(30,30)};
            TrackBuilder builder = new TrackBuilder(sectionInfos);
            Assert.AreEqual(new Section(10,10), builder.Track.StartSection);
        }
        [TestMethod]
        public void ItShouldCloseTheTrack_GivenCloseTrackIsTrue()
        {
            (int, int)[] sectionInfos = { (10, 10), (20, 20), (30, 30) };
            TrackBuilder builder = new TrackBuilder(sectionInfos, true);

            Section start = builder.Track.StartSection;
            Section second = start.NextSection;
            Section third = second.NextSection;

            Assert.AreEqual(start, third.NextSection);
        }
        [TestMethod]
        public void ItShouldLinkSectionsInOrder_GivenCloseTrackIsFalse()
        {
            (int, int)[] sectionInfos = { (10, 10), (20, 20), (30, 30) };
            TrackBuilder builder = new TrackBuilder(sectionInfos, false);

            Section start = builder.Track.StartSection;
            Assert.AreEqual(new Section(10, 10), start);

            Section second = start.NextSection;
            Assert.AreEqual(new Section(20, 20), second);

            Section third = second.NextSection;
            Assert.AreEqual(new Section(30, 30), third);

            Assert.IsNull(third.NextSection);
        }
    }
}
