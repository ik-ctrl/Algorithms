using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Sources;
using HelpersEntities;
using NUnit.Framework;

namespace AlgorithmsTests
{
    [TestFixture]
    public class BreadthFirstSearchTests
    {
        private Dictionary<Seller, List<Seller>> _testGraph;

        [SetUp]
        public void Setup()
        {
            if (_testGraph != null)
                return;
            _testGraph = new Dictionary<Seller, List<Seller>>();
            var Ilya = new Seller() {Name = "Илья", Type = ProductType.Nothing};
            var Olga = new Seller() {Name = "Ольга", Type = ProductType.Nothing};
            var Denis = new Seller() {Name = "Денис", Type = ProductType.Game};
            var Ivan = new Seller() {Name = "Иван", Type = ProductType.Wear};
            var Nikita = new Seller() {Name = "Никита", Type = ProductType.Computer};
            var Ignat = new Seller() {Name = "Игнат", Type = ProductType.Mango};
            var Nastya = new Seller() {Name = "Настя", Type = ProductType.Phone};
            var Nina = new Seller() {Name = "Нина", Type = ProductType.Car};
            var Ryuk = new Seller() {Name = "Рюк", Type = ProductType.Apple};
            var Kirill = new Seller() {Name = "Кирилл", Type = ProductType.House};

            _testGraph.Add(Ilya, new List<Seller>() {Nikita, Denis, Olga});
            _testGraph.Add(Olga, new List<Seller>() {Kirill, Nastya});
            _testGraph.Add(Kirill, null);
            _testGraph.Add(Nastya, new List<Seller>() {Olga});
            _testGraph.Add(Denis, new List<Seller>() {Nikita, Ignat});
            _testGraph.Add(Ignat, null);
            _testGraph.Add(Nikita, new List<Seller>() {Denis, Nina, Ivan});
            _testGraph.Add(Nina, null);
            _testGraph.Add(Ivan, new List<Seller>() {Ryuk});
            _testGraph.Add(Ryuk, null);
        }

        [TestCase("null", ProductType.Nothing, true)]
        [TestCase("null", ProductType.Nothing, false)]
        public void BreadthFirstSearch_ArgumentNullException_Test(string startNodeKey, ProductType requiredType,
            bool useTestGraph)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var searcher = useTestGraph ? new BreadthFirstSearch(_testGraph) : new BreadthFirstSearch(null);
                Seller startNode = startNodeKey.Equals("null")
                    ? null
                    : new Seller() {Name = startNodeKey, Type = requiredType};
                searcher.Search(startNode, requiredType);
            });
        }

        [TestCase("Эцио", ProductType.Nothing)]
        public void BreadthFirstSearch_ArgumentException_Test(string startNodeKey, ProductType requiredType)
        {
            var searcher = new BreadthFirstSearch(_testGraph);
            var requiredSeller = new Seller() {Name = startNodeKey, Type = requiredType};
            Assert.Throws<ArgumentException>(() =>
            {
                var seller = searcher.Search(requiredSeller, ProductType.Apple);
            });
        }

        [TestCase("Илья", ProductType.Apple, "Рюк")]
        [TestCase("Илья", ProductType.Mango, "Игнат")]
        [TestCase("Илья", ProductType.Car, "Нина")]
        [TestCase("Илья", ProductType.Game, "Денис")]
        [TestCase("Илья", ProductType.Phone, "Настя")]
        [TestCase("Илья", ProductType.House, "Кирилл")]
        [TestCase("Денис", ProductType.Car, "Нина")]
        [TestCase("Денис", ProductType.House, "null")]
        public void BreadthFirstSearch_Test(string requiredStartNodeKey, ProductType requiredType,
            string expectedNodeKey)
        {
            var startNode = _testGraph.Keys.First(x => x.Name.Equals(requiredStartNodeKey));
            var searcher = new BreadthFirstSearch(_testGraph);
            var seller = searcher.Search(startNode, requiredType);
            if (expectedNodeKey.Equals("null"))
            {
                Assert.IsNull(seller);
                return;
            }

            Assert.AreEqual(expectedNodeKey, seller.Name);
        }
    }
}