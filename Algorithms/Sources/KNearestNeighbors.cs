using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HelpersEntities;

namespace Algorithms.Sources
{
    /// <summary>
    /// Алгоритм  поиска к ближайших алгоритмов ()
    /// </summary>
    public class KNearestNeighbors : IAlgorithmStatistics
    {
        private long _timeSpent;
        private IEnumerable<Moviegoer> _moviegoers;

        /// <summary>
        /// Инициализация 
        /// </summary>
        /// <param name="moviegoers">Статистика пользователей</param>
        /// <exception cref="ArgumentNullException">moviegoers ==null</exception>
        public KNearestNeighbors(IEnumerable<Moviegoer> moviegoers)
        {
            _moviegoers = moviegoers ?? throw new ArgumentNullException(nameof(moviegoers));
        }

        /// <summary>
        ///  Определение  ближайших соседей
        /// </summary>
        /// <param name="currentUser">Текуший пользовательс</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>Списое ближайших соседей</returns>
        public IEnumerable<Moviegoer> GetNearestNeighbors(Moviegoer currentUser, int neighborsCount = 0)
        {
            if (currentUser == null)
                throw new ArgumentNullException(nameof(currentUser));

            Flush();
            var neighbors = new List<Moviegoer>();

            if (!_moviegoers.Any())
                return neighbors;

            var watch = new Stopwatch();
            StartWatch(watch);
            var nCount = neighborsCount <= 0 ? (int) Math.Sqrt(_moviegoers.Count()) : neighborsCount;
            var moviegoersDistances = new Dictionary<int, double>();
            foreach (var moviegoer in _moviegoers)
            {
                if (currentUser.Id == moviegoer.Id)
                    continue;
                var distance = Math.Sqrt(
                    Math.Pow(moviegoer.GenrePreference[MovieGenre.Action] - currentUser.GenrePreference[MovieGenre.Action], 2)+
                    Math.Pow(moviegoer.GenrePreference[MovieGenre.Comedy] - currentUser.GenrePreference[MovieGenre.Comedy], 2)+
                    Math.Pow(moviegoer.GenrePreference[MovieGenre.Detective] - currentUser.GenrePreference[MovieGenre.Detective], 2)+
                    Math.Pow(moviegoer.GenrePreference[MovieGenre.Historical] - currentUser.GenrePreference[MovieGenre.Historical], 2)+
                    Math.Pow(moviegoer.GenrePreference[MovieGenre.Horror] - currentUser.GenrePreference[MovieGenre.Horror], 2)
                );
                moviegoersDistances.Add(moviegoer.Id,distance);
            }
            moviegoersDistances = moviegoersDistances.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var neighborsCounter = 1;
            foreach (var neighborsId in moviegoersDistances.Keys)
            {
                if (neighborsCounter > nCount)
                    break;
                neighbors.Add(_moviegoers.First(x=>x.Id==neighborsId));
                neighborsCounter++;
            }
            StopWatch(watch);
            return neighbors;
        }
        
        //todo: слишком просто. нужно как-то усложнить
        /// <summary>
        /// Рекомендация для просмотра
        /// </summary>
        /// <param name="currentUser">Текущий пользователь</param>
        /// <returns>Рекомендация для текущего пользователя</returns>
        public string GetRecommendations(Moviegoer currentUser)
        {
            if (currentUser == null)
                throw new ArgumentNullException(nameof(currentUser));
            
            var watch = new Stopwatch();
            StartWatch(watch);
            var neighbors = GetNearestNeighbors(currentUser, 1);
            //todo:как max dictionary?
            var recommendations= !neighbors.Any() ? string.Empty : neighbors.First().ViewingHistory.Max(x=>x.Key);
            StopWatch(watch);
            return recommendations;
        }

        /// <summary>
        /// Временные затраты
        /// </summary>
        public long TimeSpent => _timeSpent;

        /// <summary>
        /// Сброс статистики
        /// </summary>
        public void Flush()
        {
            _timeSpent = default;
        }

        /// <summary>
        /// Запуск таймера
        /// </summary>
        /// <param name="watch"></param>
        private void StartWatch(Stopwatch watch) => watch.Restart();

        /// <summary>
        /// Остановка таймера и фиксация времени
        /// </summary>
        /// <param name="watch"></param>
        private void StopWatch(Stopwatch watch)
        {
            _timeSpent = watch.ElapsedMilliseconds;
            watch.Stop();
        }
    }
}