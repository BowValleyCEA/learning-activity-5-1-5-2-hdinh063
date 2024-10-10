namespace MyApp
{
    class POS
    {
        private List<User> _users = new List<User>();
        private List<Video> _videos = new List<Video>();

        public void RentAVideo()
        {
            ListVideos();
            Video? foundVideo = null;
            while (foundVideo == null)
            {
                int chosenId = Utils.InputANumber("Choose id of video to rent: ");
                foundVideo = _videos.Find(x => x.Id == chosenId);
                if (foundVideo == null) Console.WriteLine("Not found by Id");
                else if (foundVideo.RentedBy != null)
                {
                    Console.WriteLine("The video has already rented");
                    foundVideo = null;
                }
            }

            Console.Clear();
            ListUsers(_users);
            User foundUser = ChooseUser();

            foundUser.RentVideo(foundVideo);
            foundVideo.RentedBy = foundUser;

            Console.WriteLine($"{foundUser.Name} has rented the video {foundVideo.Name}");
        }

        public void ReturnAVideo()
        {
            ListUsers(_users);
            User foundUser = ChooseUser();

            Console.Clear();

            ListVideos(foundUser.CurrentlyRentedVideos);
            Video? foundVideo = null;
            while (foundVideo == null)
            {
                int chosenId = Utils.InputANumber("Choose id of video to return: ");
                foundVideo = foundUser.CurrentlyRentedVideos.Find(x => x.Id == chosenId);
                if (foundVideo == null) Console.WriteLine("Not found by Id");
            }

            foundVideo.RentedBy = null;
            foundUser.ReturnVideo(foundVideo);

            Console.WriteLine($"{foundUser.Name} has returned the video {foundVideo.Name}");
        }

        public User ChooseUser()
        {
            User? foundUser = null;
            while (foundUser == null)
            {
                int chosenId = Utils.InputANumber("Choose id of user to rent: ");
                foundUser = _users.Find(x => x.Id == chosenId);
                if (foundUser == null) Console.WriteLine("Not found by Id");
            }

            return foundUser;
        }

        public void ListVideos(List<Video> videos)
        {
            foreach (var item in videos)
            {
                string rentalStatus = item.RentedBy != null ? "(rented)" : "";
                Console.WriteLine($"{item.Id} - ({item.Genre}) {item.Name}. Duration: {item.Duration} {rentalStatus}");
            }
        }

        public void ListVideos()
        {
            ListVideos(_videos);
        }


        public void ListUsers(List<User> users)
        {
            foreach (var item in users)
            {
                Console.WriteLine($"{item.Id} - ({item.Name})");
            }
        }

        public List<Video> SearchVideo(string name)
        {
            return _videos.FindAll(v => v.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public User CreateUser(string name)
        {
            var user = new User(name);
            _users.Add(user);
            return user;
        }

        public Video AddVideo(string name, string genre, TimeSpan duration)
        {
            var video = new Video(name, genre, duration);
            _videos.Add(video);
            return video;
        }

        internal void CheckUsers()
        {
            foreach (var item in _users)
            {
                Console.WriteLine(item.Name);
                string rentedStatus = item.CurrentlyRentedVideos.Count > 0 ? "" : "No video";
                Console.WriteLine($"Currently Rented Videos: {rentedStatus}");
                foreach (var video in item.CurrentlyRentedVideos) {
                    Console.WriteLine("  " + video.Name);
                }
                string historyStatus = item.RentalHistory.Count > 0 ? "" : "No video";
                Console.WriteLine($"Rental History: {historyStatus}");
                foreach (var video in item.RentalHistory) {
                    Console.WriteLine("  " + video.Name);
                }
                Console.WriteLine();
            }
        }
    }
}