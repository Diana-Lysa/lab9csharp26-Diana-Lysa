using System;
using System.Collections;

namespace Lab9
{
    public static class Task4
    {
        private static Hashtable catalog = new Hashtable();

        public static void Run()
        {
            Console.WriteLine("Виконання Завдання 4 ");

            AddDisk("Rock Classics");
            AddDisk("Pop Hits 2024");

            AddSongToDisk("Rock Classics", "Bohemian Rhapsody", "Queen");
            AddSongToDisk("Rock Classics", "Back in Black", "AC/DC");
            AddSongToDisk("Pop Hits 2024", "Flowers", "Miley Cyrus");
            AddSongToDisk("Pop Hits 2024", "Queen of my heart", "Queen"); 

            ShowFullCatalog();

            SearchByArtist("Queen");

            Console.WriteLine("\n[Видаляємо пісню 'Flowers' та диск 'Pop Hits 2024'...]");
            RemoveSongFromDisk("Pop Hits 2024", "Flowers");
            RemoveDisk("Pop Hits 2024");

            ShowFullCatalog();

        }

        static void AddDisk(string diskName)
        {
            if (!catalog.ContainsKey(diskName))
                catalog.Add(diskName, new MusicDisk(diskName));
        }

        static void RemoveDisk(string diskName) => catalog.Remove(diskName);

        static void AddSongToDisk(string diskName, string title, string artist)
        {
            if (catalog[diskName] is MusicDisk disk) disk.AddSong(title, artist);
        }

        static void RemoveSongFromDisk(string diskName, string title)
        {
            if (catalog[diskName] is MusicDisk disk) disk.RemoveSong(title);
        }

        static void ShowFullCatalog()
        {
            Console.WriteLine("\nПОВНИЙ КАТАЛОГ");
            foreach (DictionaryEntry entry in catalog)
            {
                MusicDisk disk = (MusicDisk)entry.Value;
                Console.WriteLine($"Диск: {disk.Name}");
                foreach (Song s in disk.Songs)
                {
                    Console.WriteLine($"  - {s}");
                }
            }
        }

        static void SearchByArtist(string artist)
        {
            Console.WriteLine($"\nПОШУК ВИКОНАВЦЯ: {artist}");
            bool found = false;
            foreach (DictionaryEntry entry in catalog)
            {
                MusicDisk disk = (MusicDisk)entry.Value;
                foreach (Song s in disk.Songs)
                {
                    if (s.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Знайдено на диску '{disk.Name}': {s.Title}");
                        found = true;
                    }
                }
            }
            if (!found) Console.WriteLine("Нічого не знайдено.");
        }
    }
}
