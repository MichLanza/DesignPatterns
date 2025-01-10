using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DependencyInjection
{
    public class VideoGame
    {
        private string _name;
        private string _genre;
        public string Name { get => _name; }

        public VideoGame(string name, string genre)
        {
            _name = name;
            _genre = genre;
        }

    }
    
    public class PlayVideoGame
    {
        private VideoGame _videoGame;
        private string _console;

        public PlayVideoGame( VideoGame videoGame , string console)
        {
            _videoGame = videoGame;
            _console = console;
        }

        public void Play()
        {
            Console.WriteLine($"Playing {_videoGame.Name} on {_console}");
        }


    }
}
