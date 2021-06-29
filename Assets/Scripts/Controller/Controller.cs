using System;
using _Core;

// (MVC) - Controller Burada tutuluyor.
namespace Controller
{
    public class Controller
    {
        public ScoreModel.ScoreModel model { get; private set; }
        public PlayerView.PlayerView view { get; private set; }
        public Controller(ScoreModel.ScoreModel model, PlayerView.PlayerView view)
        {
            this.model = model;
            this.view = view;
        }

        public void EarnScore(int score)
        {
            model.Scoreboard = score;
        }
    }
}


