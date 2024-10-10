namespace MyApp
{
    class ScoreList
    {
        private List<PlayerScore> _scoreList = [];

        public void AddScore(string name, int score)
        {
            _scoreList.Add(new PlayerScore(name, score));
        }

        public void DisplayHighScores()
        {
            Console.WriteLine("Top High Scores:");
            List<PlayerScore> top5HighScores = _scoreList.OrderByDescending(x => x.Score).Take(5).ToList();
            foreach (var score in top5HighScores)
            {
                Console.WriteLine($"{score.Name}: {score.Score}");
            }
        }
    }
}