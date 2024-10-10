namespace MyApp
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Video> CurrentlyRentedVideos = new List<Video>();
        public List<Video> RentalHistory = new List<Video>();

        private static int LatestId = 1;

        public User(string name)
        {
            Id = LatestId++;
            Name = name;
        }

        public void RentVideo(Video video)
        {
            CurrentlyRentedVideos.Add(video);
            RentalHistory.Add(video);
        }

        public void ReturnVideo(Video video)
        {
            CurrentlyRentedVideos.Remove(video);
        }
    }
}