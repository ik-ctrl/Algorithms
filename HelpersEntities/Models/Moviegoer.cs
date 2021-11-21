using System.Collections.Generic;

namespace HelpersEntities
{
    /// <summary>
    /// Кинозритель
    /// </summary>
    public class Moviegoer
    {
        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="name">Имя ползователя</param>
        /// <param name="genrePreference"></param>
        /// <param name="viewingHistory"></param>
        public Moviegoer(int id, string name, Dictionary<MovieGenre, int> genrePreference, Dictionary<string, int> viewingHistory)
        {
            Id = id;
            Name = name;
            GenrePreference = genrePreference;
            ViewingHistory = viewingHistory;
        }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get;  }
        
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get;  }
        
        /// <summary>
        /// Жанровые предпочтения
        /// </summary>
        public Dictionary<MovieGenre,int> GenrePreference { get; }
        
        /// <summary>
        /// История просмотра фильмов с оценками
        /// </summary>
        public Dictionary<string, int> ViewingHistory { get; }
    }
}