﻿using System.Linq;
using Xunit;
using Zxcvbn;

namespace zxcvbn_test
{
    public class ZxcvbnTest
    {
        //[Fact]
        public void SpatialMatcher()
        {
            var sm = new Zxcvbn.Matcher.SpatialMatcher();

            var res = sm.MatchPassword("qwert");
            Assert.Equal(1, res.Count());
            var m1 = res.First();
            Assert.Equal("qwert", m1.Token);
            Assert.Equal(0, m1.i);
            Assert.Equal(4, m1.j);

            res = sm.MatchPassword("plko14569852pyfdb");
            Assert.Equal(6, res.Count()); // Multiple matches from different keyboard types
        }

        //[Fact]
        public void TimeDisplayStrings()
        {
            // Note that the time strings should be + 1
            Assert.Equal("11 minutes", Utility.DisplayTime(60 * 10, Translation.English));
            Assert.Equal("2 days", Utility.DisplayTime(60 * 60 * 24, Translation.English));
            Assert.Equal("17 years", Utility.DisplayTime(60 * 60 * 24 * 365 * 15.4, Translation.English));
        }

        //[Fact]
        public void TimeDisplayStringsGerman()
        {
            // Note that the time strings should be + 1
            Assert.Equal("11 Minuten", Utility.DisplayTime(60 * 10, Translation.German));
            Assert.Equal("2 Tage", Utility.DisplayTime(60 * 60 * 24, Translation.German));
            Assert.Equal("17 Jahre", Utility.DisplayTime(60 * 60 * 24 * 365 * 15.4, Translation.German));
        }
    }
}