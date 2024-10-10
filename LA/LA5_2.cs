namespace MyApp
{
    class LearningActivity5_2
    {
        
        private bool _isExitted = false;
        private POS _pos = new POS();

        public LearningActivity5_2()
        {
            _pos.CreateUser("Alice");
            _pos.CreateUser("Bob");

            _pos.AddVideo("The Matrix", "Action", TimeSpan.FromHours(2));
            _pos.AddVideo("Finding Nemo", "Animation", TimeSpan.FromHours(1.5));
            _pos.AddVideo("Toy Story", "Animation", TimeSpan.FromHours(1.33));
            _pos.AddVideo("Pulp Fiction", "Crime", TimeSpan.FromHours(2.5));
        }

        public void Run()
        {
            _isExitted = false;
            string[] gameOption = {
                "1. Search Video",
                "2. Rent a Video",
                "3. Return a Video",
                "4. List Videos",
                "5. Check Users",
                "6. Exit"
            };

            while (!_isExitted)
            {
                Console.Clear();
                POSSelection choice = (POSSelection)Utils.ChooseOption(gameOption);
                Console.Clear();

                switch (choice)
                {
                    case POSSelection.Search:
                        Console.Write("Search keyword: ");
                        string searchTerm = Console.ReadLine() ?? "";
                        List<Video> foundVideos = _pos.SearchVideo(searchTerm);
                        if (foundVideos.Count > 0)
                        {
                            Console.WriteLine($"Found {foundVideos.Count} result(s):");
                            _pos.ListVideos(foundVideos);
                        }
                        else
                        {
                            Console.WriteLine("No result");
                        }
                        break;
                    case POSSelection.Rent:
                        _pos.RentAVideo();
                        break;
                    case POSSelection.Return:
                        _pos.ReturnAVideo();
                        break;
                    case POSSelection.List:
                        _pos.ListVideos();
                        break;
                    case POSSelection.CheckUser:
                        _pos.CheckUsers();
                        break;
                    case POSSelection.Exit:
                        Console.WriteLine("POS is exitted");
                        _isExitted = true;
                        break;
                    default:
                        break;
                }
                if (choice != POSSelection.Exit)
                {
                    Utils.PauseScreen();
                }
            }
        }
    }
}