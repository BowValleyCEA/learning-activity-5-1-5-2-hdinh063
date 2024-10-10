namespace MyApp
{
    class LearningActivity5
    {
        public static void Main(string[] args)
        {
            bool isExitted = false;
            LearningActivity5_1 pacman = new LearningActivity5_1();
            LearningActivity5_2 pos = new LearningActivity5_2();

            while (!isExitted)
            {
                string[] appOption = {
                    "1. Open Pacman",
                    "2. Open POS",
                    "3. Exit",
                };
                Console.Clear();
                int choice = Utils.ChooseOption(appOption);
                Console.Clear();

                switch (choice)
                {
                    case (int)AppSelection.Pacman:
                        pacman.Run();
                        break;
                    case (int)AppSelection.POS:
                        pos.Run();
                        break;
                    case (int)AppSelection.Exit:
                        isExitted = true;
                        Console.WriteLine("Thanks for using this app");
                        break;
                    default:
                        break;
                }

                Utils.PauseScreen();
            }
        }
    }
}