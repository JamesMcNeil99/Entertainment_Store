using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    class Game:IGame
    {
        Genre genre;

        public Game(Genre genre)
        {
            this.genre = genre;
        }

        public Genre getGenre()
        {
            return this.genre;
        }
    }
}
