using System.Runtime.InteropServices;

namespace MyApp
{
    class LearningActivity5_1
    {
        ScoreList _scoreList = new ScoreList();
        bool _isExitted = false;

        public void Run()
        {
            _isExitted = false;
            MockPlay();
            _scoreList.DisplayHighScores();
            Utils.PauseScreen();

            string[] gameOption = {
                "1. Play again",
                "2. See the list of high scores",
                "3. Exit the game?",
            };

            while (!_isExitted)
            {
                Console.Clear();
                GameSelection choice = (GameSelection)Utils.ChooseOption(gameOption);
                Console.Clear();

                switch (choice)
                {
                    case GameSelection.Play:
                        MockPlay();
                        _scoreList.DisplayHighScores();
                        Utils.PauseScreen();
                        break;
                    case GameSelection.SeeHighScore:
                        _scoreList.DisplayHighScores();
                        Utils.PauseScreen();
                        break;
                    case GameSelection.Exit:
                        _isExitted = true;
                        Console.WriteLine("Thanks for playing this game");
                        break;
                    default:
                        break;
                }
            }
        }

        private void MockPlay()
        {
            Console.WriteLine("Game is mock playing, wait 5 seconds...");
            Thread.Sleep(5000);
            Console.Clear();
            Random randomScore = new Random();
            int newHighScore = randomScore.Next(1000, 1000000);
            Console.WriteLine($"You finished with a score of {newHighScore}");
            Console.Write("Write your name to save your score: ");
            string name = Console.ReadLine() ?? "AAA";
            _scoreList.AddScore(name, newHighScore);

        }
    }
}