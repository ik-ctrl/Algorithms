using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HelpersEntities;

namespace Algorithms.Sources
{
    /// <summary>
    /// Поиск в ширину | O(V+E)
    /// </summary>
    public class BreadthFirstSearch : IAlgorithmStatistics
    {
        private Dictionary<Seller, List<Seller>> _graph;
        private long _timeSpent;
        private readonly Queue<Seller> _queue;

        public BreadthFirstSearch(Dictionary<Seller, List<Seller>> graph)
        {
            _graph = graph;
            _queue = new Queue<Seller>();
        }

        /// <summary>
        /// Поиск ближайшего необходимого продавща
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="needType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">_graph ==null || startNode==null</exception>
        /// <exception cref="ArgumentException"> Стартовый узел отсутствует </exception>
        public Seller Search(Seller startNode, ProductType needType)
        {
            if (_graph == null)
                throw new ArgumentNullException(nameof(_graph));

            if (startNode == null)
                throw new ArgumentNullException(nameof(startNode));

            if (!_graph.ContainsKey(startNode))
                throw new ArgumentException("start node does not contain  in graph");
            
            ResetCheckValue(_graph);
            var watch = new Stopwatch();
            StartWatch(watch);
            AddNeighborsToQueue(startNode);
            while (_queue.Any())
            {
                var seller = _queue.Dequeue();
                seller.IsChecked = true;
                if (seller.Type == needType)
                {
                    StopWatch(watch);
                    return seller;
                }
                AddNeighborsToQueue(seller);
            }
            StopWatch(watch);
            return null;
        }

        /// <summary>
        /// Добавление соседний узла в очередь
        /// </summary>
        /// <param name="sellerName">Имя продавца</param>
        private void AddNeighborsToQueue(Seller seller) => _graph[seller]?.ForEach((neighbor) =>
        {
            if (neighbor != null&&!neighbor.IsChecked) _queue.Enqueue(neighbor);
        });
        
        /// <summary>
        /// Время выполнения алгоритма
        /// </summary>
        public long TimeSpent => _timeSpent;

        /// <summary>
        /// Запуск таймера
        /// </summary>
        /// <param name="watch">таймер</param>
        private void StartWatch(Stopwatch watch)
        {
            watch?.Restart();
        }

        /// <summary>
        /// Фиксирования времени выполнения и остановка таймера
        /// </summary>
        /// <param name="stopwatch">Таймер/param>
        private void StopWatch(Stopwatch stopwatch)
        {
            _timeSpent = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
        } 
        
        /// <summary>
        /// Cброс значений таймера
        /// </summary>
        public void Flush()
        {
            _timeSpent = default;
        }

        /// <summary>
        /// Сброс значений проверки
        /// </summary>
        /// <param name="graph"></param>
        private void ResetCheckValue(Dictionary<Seller, List<Seller>> graph)
        {
            foreach (var key in graph.Keys)
            {
                var neighbors = graph[key];
                if (neighbors == null) continue;
                foreach (var neighbor in neighbors.Where(neighbor => neighbor != null))
                {
                    neighbor.IsChecked = false;
                }
            }
        }
    }
}