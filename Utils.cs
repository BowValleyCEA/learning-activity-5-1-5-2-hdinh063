namespace MyApp
{
    class Utils
    {
        public static int ChooseOption(string[] options)
        {
            bool validSelection = false;
            int selection = 0;
            while (!validSelection)
            {
                Console.WriteLine("Would you like to:");
                foreach (var option in options)
                {
                    Console.WriteLine(option);
                }

                char keyChar = Console.ReadKey().KeyChar;
                if (int.TryParse(keyChar.ToString(), out selection) && selection >= 1 && selection <= options.Length)
                    validSelection = true;

                else Console.Clear();
            }

            return selection;

        }

        public static int InputANumber(string message)
        {
            bool validSelection = false;
            int number = 0;

            while (!validSelection)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out number))
                    validSelection = true;
            }

            return number;
        }

        public static void PauseScreen()
        {
            _ = Console.ReadKey();
        }
    }
}