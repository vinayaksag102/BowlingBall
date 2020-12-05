using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        private Game game;


        [TestInitialize]
        public void Initialize()
        {
            game = new Game();

        }

        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            RollMany(0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

       
        [TestMethod]
        public void CanRollAllOnes_test()
        {
            RollMany(1, 20);
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void CanRollSpare_test()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollMany(0, 17);
            Assert.AreEqual(16, game.GetScore());
        }

        [TestMethod]
        public void CanRollStrike_test()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            RollMany(0, 16);
            Assert.AreEqual(24, game.GetScore());
        }

        [TestMethod]
        public void CanRollPerfectGame_test()
        {

            // No. of pins knocked in each  Roll
            List<int> RollList = new List<int>() { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };

            foreach (var roll in RollList)
                game.Roll(roll);

            Assert.AreEqual(187, game.GetScore());
        }

        private void RollMany(int pins, int rolls)
        {
            for (int i = 0; i < rolls; i++)
                game.Roll(pins);
        }

        
    }
}
