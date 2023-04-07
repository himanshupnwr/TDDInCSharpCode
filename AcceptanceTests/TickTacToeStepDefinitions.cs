using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using TickTacToe;

namespace AcceptanceTests
{
    [Binding]
    public class TickTacToeStepDefinitions
    {
        private Game _game;

        [Given(@"I started a new game")]
        public void GivenIStartedANewGame()
        {
            _game = new Game();
        }

        [When(@"I put three crosses in a row")]
        public void WhenIPutThreeCrossesInARow()
        {
            _game.MakeMove(1); //1
            _game.MakeMove(4);
            _game.MakeMove(2); //2
            _game.MakeMove(5);
            _game.MakeMove(3); //3
        }

        [Then(@"I should win")]
        public void ThenIShouldWin()
        {
            Assert.AreEqual(Winner.Crosses, _game.GetWinner());
        }
    }
}
