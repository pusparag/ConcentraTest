using BowlingGameConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTestProject
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void ComputeScoreTests()
        {
            var bowling = new Game();
            bowling.Roll(1);
            bowling.Roll(4);
            Assert.AreEqual(5, bowling.Score());
            bowling.Roll(4);
            bowling.Roll(5);
            Assert.AreEqual(14, bowling.Score());
            bowling.Roll(6);
            bowling.Roll(4);
            Assert.AreEqual(24, bowling.Score());
            bowling.Roll(5);
            Assert.AreEqual(34, bowling.Score());
            bowling.Roll(5);
            Assert.AreEqual(39, bowling.Score());
            bowling.Roll(10);
            Assert.AreEqual(59, bowling.Score());
            bowling.Roll(0);
            Assert.AreEqual(59, bowling.Score());
            bowling.Roll(1);
            Assert.AreEqual(61, bowling.Score());
            bowling.Roll(7);
            Assert.AreEqual(68, bowling.Score());
            bowling.Roll(3);
            Assert.AreEqual(71, bowling.Score());
            bowling.Roll(6);
            Assert.AreEqual(83, bowling.Score());
            bowling.Roll(4);
            Assert.AreEqual(87, bowling.Score());
            bowling.Roll(10);
            Assert.AreEqual(107, bowling.Score());
            bowling.Roll(2);
            Assert.AreEqual(111, bowling.Score());
            bowling.Roll(8);
            Assert.AreEqual(127, bowling.Score());
            bowling.Roll(6);
            Assert.AreEqual(133, bowling.Score());
        }
    }
}
