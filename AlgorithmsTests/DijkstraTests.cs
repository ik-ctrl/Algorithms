using System;
using System.Collections.Generic;
using Algorithms.Sources;
using NUnit.Framework;

namespace AlgorithmsTests
{
    [TestFixture]
    public class DijkstraTests
    {
        [TestCase(true, "a", "b")]
        [TestCase(false, "", "b")]
        [TestCase(false, "a", "")]
        [TestCase(false, null, "b")]
        [TestCase(false, "a", null)]
        public void Dijkstra_ArgumentNullExceptions_Test(bool isNull, string startNode, string endNode)
        {
            var graph = isNull ? null : new Dictionary<string, Dictionary<string, double>>();
            Assert.Throws<ArgumentNullException>(() =>
            {
                var searcher = new Dijkstra(graph);
                var result = searcher.Search(startNode, endNode);
            });
        }

        [TestCase(true, "a", "b")]
        [TestCase(false, "c", "b")]
        [TestCase(false, "a", "d")]
        public void Dijkstra_ArgumentExceptions_Test(bool isEmpty, string startNode, string endNode)
        {
            var graph = isEmpty
                ? new Dictionary<string, Dictionary<string, double>>()
                : new Dictionary<string, Dictionary<string, double>>()
                {
                    {"a", new Dictionary<string, double>() {{"b", 1.0d}}},
                    {"b", new Dictionary<string, double>() {{"a", 2.0}}},
                };
            Assert.Throws<ArgumentException>(() =>
            {
                var searcher = new Dijkstra(graph);
                var result = searcher.Search(startNode, endNode);
            });
        }
        
        [TestCase( "a", "a")]
        public void Dijkstra_StartNodeEqualEndNode_Test(string startNode, string endNode)
        {
            var graph = new Dictionary<string, Dictionary<string, double>>()
                {
                    {"a", new Dictionary<string, double>() {{"b", 1.0d}}},
                    {"b", new Dictionary<string, double>() {{"a", 2.0}}},
                };

            var searcher = new Dijkstra(graph);
            var (path,pathCost) = searcher.Search(startNode, endNode);
            Assert.AreEqual(string.Empty,path);
            Assert.AreEqual(0.0d,pathCost);
        }
        
        [TestCase("a", "d", "a->c->b->d", 6.0d)]
        [TestCase("a", "b", "a->c->b", 5.0d)]
        [TestCase("a", "c", "a->c", 2.0)]
        [TestCase("b", "d", "b->d", 1.0)]
        [TestCase("b", "a", "null", -1)]
        public void Dijkstra_Test(string startNode, string endNode,string expectedPath, double expectedCost)
        {
            var graph = new Dictionary<string, Dictionary<string, double>>()
            {
                {"a", new Dictionary<string, double>()
                {
                    {"b", 6.0d},
                    {"c",2.0d}
                }},
                {"b", new Dictionary<string, double>()
                {
                    {"c", 3.0d},
                    {"d",1.0d},
                }},
                {"c", new Dictionary<string, double>()
                {
                    {"b", 3.0d},
                    {"d",5.0d},
                }},
                {"d", null}
            };
            var searcher = new Dijkstra(graph);
            var (path, pathCost) = searcher.Search(startNode, endNode);
            Assert.AreEqual(expectedPath,path);
            Assert.AreEqual(expectedCost,pathCost);
        }

        [Test]
        public void Djikstra_TimeSpent_Test()
        {
            var graph = new Dictionary<string, Dictionary<string, double>>()
            {
                {"a", new Dictionary<string, double>()
                {
                    {"b", 6.0d},
                    {"c",2.0d}
                }},
                {"b", new Dictionary<string, double>()
                {
                    {"c", 3.0d},
                    {"d",1.0d},
                }},
                {"c", new Dictionary<string, double>()
                {
                    {"b", 3.0d},
                    {"d",5.0d},
                }},
                {"d", null}
            };
            var searcher = new Dijkstra(graph);
            var (path, pathCost) = searcher.Search("a", "d");
            Assert.AreNotEqual(0,searcher.TimeSpent);
        }
    }
}