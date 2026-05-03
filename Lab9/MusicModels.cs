using System;
using System.Collections;

namespace Lab9
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString() => $"{Artist} - {Title}";
    }

    public class MusicDisk
    {
        public string Name { get; set; }
        public ArrayList Songs { get; set; } = new ArrayList();

        public MusicDisk(string name)
        {
            Name = name;
        }

        public void AddSong(string title, string artist)
        {
            Songs.Add(new Song(title, artist));
        }

        public void RemoveSong(string title)
        {
            Song toRemove = null;
            foreach (Song s in Songs)
            {
                if (s.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    toRemove = s;
                    break;
                }
            }
            if (toRemove != null) Songs.Remove(toRemove);
        }
    }
}
