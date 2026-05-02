using System;
using tjmodul6_103082400040;

namespace modul6_103082400040
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== IMPLEMENTASI DESIGN BY CONTRACT ===\n");

            // Buat user dengan nama panggilan Anda
            SayaTubeUser user = new SayaTubeUser("MuhamadRozi");

            // Tambahkan minimal 10 film dengan format "Review Film <judul> oleh <nama>"
            string[] filmTitles = new string[]
            {
                "Review Film The Shawshank Redemption oleh MuhamadRozi",
                "Review Film The Godfather oleh MuhamadRozi",
                "Review Film The Dark Knight oleh MuhamadRozi",
                "Review Film Pulp Fiction oleh MuhamadRozi",
                "Review Film Forrest Gump oleh MuhamadRozi",
                "Review Film Inception oleh MuhamadRozi",
                "Review Film The Matrix oleh MuhamadRozi",
                "Review Film Goodfellas oleh MuhamadRozi",
                "Review Film The Silence of the Lambs oleh MuhamadRozi",
                "Review Film Schindler's List oleh MuhamadRozi",
                "Review Film Fight Club oleh MuhamadRozi",
                "Review Film The Lord of the Rings oleh MuhamadRozi"
            };

            // Buat video dan tambahkan ke user
            foreach (string title in filmTitles)
            {
                SayaTubeVideo video = new SayaTubeVideo(title);
                user.AddVideo(video);
            }

            Console.WriteLine("=== DETAIL SEMUA VIDEO ===");
            // Increase play count untuk beberapa video
            var videos = user.GetType().GetField("uploadedVideos",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);

            // Simulasi increase play count
            Console.WriteLine("\n=== MENAMBAHKAN PLAY COUNT ===");
            // Catatan: Untuk demo, kita akan buat video terpisah untuk testing

            SayaTubeVideo testVideo1 = new SayaTubeVideo("Test Video 1");
            testVideo1.IncreasePlayCount(1000);
            testVideo1.PrintVideoDetails();

            SayaTubeVideo testVideo2 = new SayaTubeVideo("Test Video 2");
            testVideo2.IncreasePlayCount(5000);
            testVideo2.PrintVideoDetails();

            // Print semua video (maksimal 8)
            Console.WriteLine("\n=== PRINT SEMUA VIDEO (MAKSIMAL 8) ===");
            user.PrintAllVideoPlaycount();

            // Test Precondition - Username null
            Console.WriteLine("\n=== TEST PRECONDITION: USERNAME NULL ===");
            try
            {
                SayaTubeUser invalidUser = new SayaTubeUser(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Test Precondition - Judul terlalu panjang
            Console.WriteLine("\n=== TEST PRECONDITION: JUDUL TERLALU PANJANG ===");
            try
            {
                string longTitle = new string('A', 201);
                SayaTubeVideo invalidVideo = new SayaTubeVideo(longTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Test Precondition - Play count negatif
            Console.WriteLine("\n=== TEST PRECONDITION: PLAY COUNT NEGATIF ===");
            try
            {
                SayaTubeVideo video = new SayaTubeVideo("Test");
                video.IncreasePlayCount(-100);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Test Precondition - Play count > 25.000.000
            Console.WriteLine("\n=== TEST PRECONDITION: PLAY COUNT > 25.000.000 ===");
            try
            {
                SayaTubeVideo video = new SayaTubeVideo("Test");
                video.IncreasePlayCount(25000001);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Test Exception - Overflow
            Console.WriteLine("\n=== TEST EXCEPTION: OVERFLOW ===");
            try
            {
                SayaTubeVideo video = new SayaTubeVideo("Overflow Test");
                video.IncreasePlayCount(int.MaxValue - 100);
                video.IncreasePlayCount(200); // Ini akan menyebabkan overflow
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Test Postcondition - Video null
            Console.WriteLine("\n=== TEST PRECONDITION: VIDEO NULL ===");
            try
            {
                SayaTubeUser user2 = new SayaTubeUser("TestUser");
                user2.AddVideo(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n=== PROGRAM SELESAI ===");
            Console.ReadLine();
        }
    }
}