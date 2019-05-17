using AdventOfCode2017.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2017Tests.Helpers
{
    public class UnionFindTests
    {
        [Fact]
        public void UnionFind_Find_Test()
        {
            var uf = new UnionFind(3);
            uf.Union(1, 2);
            Assert.True(uf.Find(1) == uf.Find(2));
        }

        [Fact]
        public void UnionFind_Union_Count_Test()
        {
            var uf = new UnionFind(3);
            Assert.Equal(3, uf.Count);
            uf.Union(1, 2);
            Assert.Equal(2, uf.Count);
        }
    }
}
