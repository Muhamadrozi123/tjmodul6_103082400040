using System;
using System.Collections.Generic;
using System.Text;

namespace tjmodul6_103082400040
{
    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            // Precondition: Title tidak null dan maksimal 200 karakter
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title), "Judul video tidak boleh null");
            }
            if (title.Length > 200)
            {
                throw new ArgumentException("Judul video maksimal 200 karakter");
            }

            this.title = title;
            this.playCount = 0;

            // Generate random ID 5 digit
            Random random = new Random();
            this.id = random.Next(10000, 99999);
        }

        public void IncreasePlayCount(int amount)
        {
            // Precondition: amount tidak negatif dan maksimal 25.000.000
            if (amount < 0)
            {
                throw new ArgumentException("Input play count tidak boleh negatif");
            }
            if (amount > 25000000)
            {
                throw new ArgumentException("Input penambahan play count maksimal 25.000.000");
            }

            // Exception: Cek overflow dengan checked
            try
            {
                checked
                {
                    this.playCount = this.playCount + amount;
                }
            }
            catch (OverflowException)
            {
                throw new OverflowException("Penambahan play count melebihi batas integer maksimum");
            }

            // Postcondition: playCount harus kurang dari int.MaxValue
            if (this.playCount >= int.MaxValue)
            {
                throw new OverflowException("playCount mencapai batas maksimum integer");
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine($"ID Video: {id}");
            Console.WriteLine($"Judul: {title}");
            Console.WriteLine($"Play Count: {playCount}");
            Console.WriteLine();
        }

        public int GetPlayCount()
        {
            return playCount;
        }

        public string GetTitle()
        {
            return title;
        }
    }
}
