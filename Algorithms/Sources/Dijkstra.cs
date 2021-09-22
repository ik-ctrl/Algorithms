using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace Algorithms.Sources
{
    /// <summary>
    /// Алгоритм Дейкстры | O(V log V + E) - в лучшем случае
    /// </summary>
    public class Dijkstra : IAlgorithmStatistics
    {
        private long _timeSpent;
        private Dictionary<string, Dictionary<string, double>> _graph;
        private Dictionary<string, double> _nodeCosts;
        private Dictionary<string, string> _parents;
        private List<string> _processedNodes;

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="graph"> Исходный граф</param>
        public Dijkstra(Dictionary<string, Dictionary<string, double>> graph)
        {
            _graph = graph ?? throw new ArgumentNullException(nameof(_graph));
            _processedNodes = new List<string>();
        }

        /// <summary>
        /// Поиск кратчайшего пути и его стоимост   и
        /// </summary>
        /// <param name="startNode">Название стартового узла</param>
        /// <param name="endNode"> Название конечного узла</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">startNode or endNode is empty or null</exception>
        /// <exception cref="ArgumentNullException">startNode or endNode doesnt contains in _graph</exception>
        /// <exception cref="ArgumentNullException">_grap is Empty</exception>
        public (string, double) Search(string startNode, string endNode)
        {
            if (string.IsNullOrEmpty(startNode?.Trim()) || string.IsNullOrEmpty(endNode?.Trim()))
                throw new ArgumentNullException("startNode or endNode is empty or null");

            if (!_graph.Any())
                throw new ArgumentException("_grap is Empty");

            if (!_graph.ContainsKey(startNode) || !_graph.ContainsKey(endNode))
                throw new ArgumentException("startNode or endNode doesnt contains in _graph");

            if (startNode.Equals(endNode))
                return (string.Empty, 0.0d);

            Flush();
            _nodeCosts = FormNodeCostsTable(startNode, _graph);
            _parents = FromParentsTable(startNode, endNode, _graph);
            var watch = new Stopwatch();
            StartWatch(watch);
            var (lowerCostKey, lowerCost) = FindLowestCost(_nodeCosts, _processedNodes);
            while (!double.IsPositiveInfinity(lowerCost) && !lowerCostKey.Equals(string.Empty))
            {
                var cost = _nodeCosts[lowerCostKey];
                var neighbors = _graph[lowerCostKey];
                _processedNodes.Add(lowerCostKey);
                if (neighbors == null || !neighbors.Any())
                {
                    (lowerCostKey, lowerCost) = FindLowestCost(_nodeCosts, _processedNodes);
                    continue;
                }
                foreach (var nodeKey in neighbors?.Keys)
                {
                    var neighborsCost = double.IsNaN(neighbors[nodeKey]) ? 0 : neighbors[nodeKey];
                    var newCost = cost + neighborsCost;
                    if (double.IsNaN(_nodeCosts[nodeKey]) || _nodeCosts[nodeKey] > newCost)
                    {
                        _nodeCosts[nodeKey] = newCost;
                        _parents[nodeKey] = lowerCostKey;
                    }
                }
                (lowerCostKey, lowerCost) = FindLowestCost(_nodeCosts, _processedNodes);
            }

            var path = GeneratePath(startNode, endNode, _parents);
            var finalCost = !path.Equals("null") ? _nodeCosts[endNode] : -1;
            StopWatch(watch);
            return (path, finalCost);
        }

        /// <summary>
        /// Формирование таблицы родителей;
        /// </summary>
        /// <param name="startNode">Название стартого узла</param>
        /// <param name="endNode">Название конечного узла</param>
        /// <param name="graph">Граф</param>
        /// <returns>Таблицу Родителей</returns>
        private Dictionary<string, string> FromParentsTable(string startNode, string endNode, Dictionary<string, Dictionary<string, double>> graph)
        {
            var parents = new Dictionary<string, string>();
            var nodeNames = _graph.Keys.ToList();
            var startNeighbors = _graph[startNode];
            nodeNames.ForEach((x) => { parents.Add(x, startNeighbors.ContainsKey(x) ? startNode : null); });
            return parents;
        }

        /// <summary>
        /// Формруем таблицу  стоимостей узлов по заданному узлу
        /// </summary>
        /// <param name="startNodeKey">Имя стартового узла</param>
        /// <param name="graph">Граф</param>
        /// <returns>Таблица стоимостей узлов от стартовой точки</returns>
        private Dictionary<string, double> FormNodeCostsTable(string startNodeKey, Dictionary<string, Dictionary<string, double>> graph)
        {
            var costs = new Dictionary<string, double>();
            var nodeNames = _graph.Keys.ToList();
            var startNeighbors = _graph[startNodeKey];
            nodeNames.ForEach((x) => { costs.Add(x, startNeighbors.ContainsKey(x) ? startNeighbors[x] : double.PositiveInfinity); });
            return costs;
        }

        /// <summary>
        /// Формирование результатов ответа
        /// </summary>
        /// <param name="startNode">Имя стартового узла</param>
        /// <param name="endNode">Имя конечного узла</param>
        /// <param name="parents">Таблица  родителей</param>
        /// <returns>Возвращает путь</returns>
        private string GeneratePath(string startNode, string endNode, Dictionary<string, string> parents)
        {
            var pathList = new List<string>();
            var key = parents[endNode];
            pathList.Add(endNode);
            pathList.Add(key);
            for (var i = 0; i < parents.Count; i++)
            {
                if (pathList.Contains(startNode)||pathList.Contains(null))
                    break;
                var nextKey = parents[key];
                pathList.Add(nextKey);
                key = nextKey;
            }
            pathList.Reverse();
            return pathList.Contains(startNode) && pathList.Contains(endNode) ? string.Join("->", pathList) : "null";
        }

        /// <summary>
        /// Поиск наименьшей цены перехода
        /// </summary>
        /// <param name="nodeCosts">Массив</param>
        /// <param name="processedNode"></param>
        /// <returns></returns>
        private (string, double) FindLowestCost(Dictionary<string, double> nodeCosts, List<string> processedNode)
        {
            var lowerCost = double.PositiveInfinity;
            var lowerCostKey = string.Empty;
            foreach (var edgeCost in nodeCosts)
            {
                if (lowerCost > edgeCost.Value && !_processedNodes.Contains(edgeCost.Key) &&
                    edgeCost.Value != double.NaN)
                {
                    lowerCost = edgeCost.Value;
                    lowerCostKey = edgeCost.Key;
                }
            }

            return (lowerCostKey, lowerCost);
        }

        //todo: удалить потом
        public int StepsCount { get; }

        /// <summary>
        /// Временные задачи
        /// </summary>
        public long TimeSpent => _timeSpent;

        /// <summary>
        /// Сброс времени
        /// </summary>
        public void Flush()
        {
            _timeSpent = default;
            _processedNodes = new List<string>();
        }

        /// <summary>
        /// Запуск таймера
        /// </summary>
        /// <param name="watch">Секундомер</param>
        private void StartWatch(Stopwatch watch) => watch?.Restart();

        /// <summary>
        /// Фиксация времени в переменную _tineSpent и остановка секундомера
        /// </summary>
        /// <param name="watch">Секундомер</param>
        private void StopWatch(Stopwatch watch)
        {
            _timeSpent = watch.ElapsedMilliseconds;
            watch?.Stop();
        }
    }
}