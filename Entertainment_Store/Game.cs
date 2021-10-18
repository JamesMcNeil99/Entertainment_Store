using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    class Game:IGame
    {
        Genre genre;
        string title;
        public Game(Genre genre, string title)
        {
            this.genre = genre;
            this.title = title;
        }

        public Genre getGenre()
        {
            return this.genre;
        }
        public string getTitle()
        {
            return this.title;
        }
    }
}
