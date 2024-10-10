namespace MyApp
{
    class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public TimeSpan Duration { get; set; }
        public User? RentedBy { get; set; }

        private static int LatestId = 1;

        public Video(string name, string genre, TimeSpan duration)
        {
            Id = LatestId++;
            Name = name;
            Genre = genre;
            Duration = duration;
        }
    }
}