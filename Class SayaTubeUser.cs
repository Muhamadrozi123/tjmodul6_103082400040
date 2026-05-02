using System;
using System.Collections.Generic;
using System.Text;

namespace tjmodul6_103082400040
{
    public class SayaTubeUser
    {
        private int id;
        private string username;
        private List<SayaTubeVideo> uploadedVideos;

        public SayaTubeUser(string username)
        {
            // Precondition: Username tidak null dan maksimal 100 karakter
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username), "Username tidak boleh null");
            }
            if (username.Length > 100)
            {
                throw new ArgumentException("Username maksimal 100 karakter");
            }

            this.username = username;
            this.uploadedVideos = new List<SayaTubeVideo>();

            // Generate random ID 5 digit
            Random random = new Random();
            this.id = random.Next(10000, 99999);
        }

        public void AddVideo(SayaTubeVideo video)
        {
            // Precondition: Video tidak boleh null
            if (video == null)
            {
                throw new ArgumentNullException(nameof(video), "Video yang ditambahkan tidak boleh null");
            }

            // Precondition: Video harus memiliki playCount < int.MaxValue
            if (video.GetPlayCount() >= int.MaxValue)
            {
                throw new ArgumentException("Video memiliki playCount yang melebihi batas");
            }

            this.uploadedVideos.Add(video);
        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (var video in uploadedVideos)
            {
                try
                {
                    checked
                    {
                        total = total + video.GetPlayCount();
                    }
                }
                catch (OverflowException)
                {
                    throw new OverflowException("Total play count melebihi batas integer maksimum");
                }
            }
            return total;
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine($"User: {username}");

            // Postcondition: Maksimal print 8 video
            int maxVideos = Math.Min(uploadedVideos.Count, 8);

            for (int i = 0; i < maxVideos; i++)
            {
                Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
            }

            if (uploadedVideos.Count > 8)
            {
                Console.WriteLine($"... dan {uploadedVideos.Count - 8} video lainnya");
            }
            Console.WriteLine();
        }

        public string GetUsername()
        {
            return username;
        }

        public int GetVideoCount()
        {
            return uploadedVideos.Count;
        }
    }
}