using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Sources;
using HelpersEntities;
using NUnit.Framework;

namespace AlgorithmsTests
{
    [TestFixture]
    public class KNearestNeighborsTests
    {
        private IEnumerable<Moviegoer> _moviegoers;

        private Moviegoer _user;

        [SetUp]
        public void InitTestData()
        {
             _moviegoers ??= new List<Moviegoer>()
            {
                new Moviegoer(1, "Сергеева Арина Борисовна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 5},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 3},
                        {MovieGenre.Horror, 4},
                        {MovieGenre.Historical, 1},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 4}
                    }),
                new Moviegoer(2, "Щербакова Виктория Ярославовна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 4},
                        {MovieGenre.Detective, 5},
                        {MovieGenre.Horror, 2},
                        {MovieGenre.Historical, 4},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(3, "Федотов Егор Захарович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 2},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 1},
                        {MovieGenre.Horror, 3},
                        {MovieGenre.Historical, 4},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(4, "Комаров Илья Богданович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 1},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 1},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(5, "Семин Артемий Александрович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 2},
                        {MovieGenre.Comedy, 2},
                        {MovieGenre.Detective, 5},
                        {MovieGenre.Horror, 2},
                        {MovieGenre.Historical, 2},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(6, "Максимов Илья Петрович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 4},
                        {MovieGenre.Comedy, 4},
                        {MovieGenre.Detective, 3},
                        {MovieGenre.Horror, 4},
                        {MovieGenre.Historical, 1},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(7, "Калинин Артём Сергеевич",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 5},
                        {MovieGenre.Horror, 5},
                        {MovieGenre.Historical, 4},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(8, "Федорова Ольга Артёмовна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 3},
                        {MovieGenre.Comedy, 5},
                        {MovieGenre.Detective, 3},
                        {MovieGenre.Horror, 4},
                        {MovieGenre.Historical, 4},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(9, "Лебедева Ксения Викторовна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 5},
                        {MovieGenre.Comedy, 2},
                        {MovieGenre.Detective, 5},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 1},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(10, "Сидорова Алиса Максимовна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 2},
                        {MovieGenre.Comedy, 1},
                        {MovieGenre.Detective, 1},
                        {MovieGenre.Horror, 3},
                        {MovieGenre.Historical, 3},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(11, "Егоров Леонид Сергеевич",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 1},
                        {MovieGenre.Horror, 5},
                        {MovieGenre.Historical, 2},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(12, "Фомина Александра Макаровна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 3},
                        {MovieGenre.Comedy, 2},
                        {MovieGenre.Detective, 2},
                        {MovieGenre.Horror, 4},
                        {MovieGenre.Historical, 3},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(13, "Михайлова Мия Данииловна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 5},
                        {MovieGenre.Detective, 2},
                        {MovieGenre.Horror, 5},
                        {MovieGenre.Historical, 2},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(14, "Пантелеева Елизавета Сергеевна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 3},
                        {MovieGenre.Comedy, 4},
                        {MovieGenre.Detective, 3},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 5},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(16, "Данилова Алина Семёновна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 3},
                        {MovieGenre.Comedy, 4},
                        {MovieGenre.Detective, 3},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 5},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(17, "Виноградов Владимир Даниилович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 4},
                        {MovieGenre.Comedy, 2},
                        {MovieGenre.Detective, 1},
                        {MovieGenre.Horror, 2},
                        {MovieGenre.Historical, 4},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(18, "Королева Агния Ильинична",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 4},
                        {MovieGenre.Comedy, 2},
                        {MovieGenre.Detective, 2},
                        {MovieGenre.Horror, 2},
                        {MovieGenre.Historical, 4},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(19, "Румянцева Ульяна Максимовна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 5},
                        {MovieGenre.Comedy, 5},
                        {MovieGenre.Detective, 4},
                        {MovieGenre.Horror, 5},
                        {MovieGenre.Historical, 2},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(20, "Суворова Вероника Михайловна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 5},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 3},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 1},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(21, "Киселев Михаил Захарович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 2},
                        {MovieGenre.Horror, 5},
                        {MovieGenre.Historical, 1},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(22, "Родионов Алексей Богданович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 4},
                        {MovieGenre.Detective, 5},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 5},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(23, "Новиков Даниил Кириллович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 2},
                        {MovieGenre.Comedy, 4},
                        {MovieGenre.Detective, 1},
                        {MovieGenre.Horror, 4},
                        {MovieGenre.Historical, 1},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(24, "Корнеев Тимур Тигранович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 4},
                        {MovieGenre.Comedy, 4},
                        {MovieGenre.Detective, 3},
                        {MovieGenre.Horror, 3},
                        {MovieGenre.Historical, 3},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(25, "Иванов Семён Олегович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 5},
                        {MovieGenre.Comedy, 4},
                        {MovieGenre.Detective, 2},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 2},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(26, "Яковлева Ника Николаевна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 2},
                        {MovieGenre.Comedy, 5},
                        {MovieGenre.Detective, 2},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 5},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(27, "Михайлов Николай Андреевич",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 5},
                        {MovieGenre.Comedy, 1},
                        {MovieGenre.Detective, 2},
                        {MovieGenre.Horror, 2},
                        {MovieGenre.Historical, 1},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(28, "Комаров Сергей Гордеевич",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 3},
                        {MovieGenre.Comedy, 2},
                        {MovieGenre.Detective, 5},
                        {MovieGenre.Horror, 2},
                        {MovieGenre.Historical, 4},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(29, "Климова Вероника Фёдоровна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 4},
                        {MovieGenre.Comedy, 1},
                        {MovieGenre.Detective, 2},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 3},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(30, "Литвинова Алиса Алексеевна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 3},
                        {MovieGenre.Horror, 4},
                        {MovieGenre.Historical, 5},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(31, "Андреев Дмитрий Артёмович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 5},
                        {MovieGenre.Comedy, 1},
                        {MovieGenre.Detective, 4},
                        {MovieGenre.Horror, 5},
                        {MovieGenre.Historical, 2},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(32, "Давыдова Ника Дмитриевна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 4},
                        {MovieGenre.Comedy, 4},
                        {MovieGenre.Detective, 4},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 4},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(33, "Старостин Владимир Игоревич",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 4},
                        {MovieGenre.Comedy, 4},
                        {MovieGenre.Detective, 4},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 2},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(34, "Леонтьев Дмитрий Максимович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 3},
                        {MovieGenre.Comedy, 2},
                        {MovieGenre.Detective, 1},
                        {MovieGenre.Horror, 2},
                        {MovieGenre.Historical, 2},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(35, "Зайцева Василиса Михайловна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 1},
                        {MovieGenre.Detective, 5},
                        {MovieGenre.Horror, 2},
                        {MovieGenre.Historical, 1},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(36, "Сизов Даниил Львович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 4},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 3},
                        {MovieGenre.Horror, 2},
                        {MovieGenre.Historical, 2}
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(37, "Бобров Илья Максимович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 5},
                        {MovieGenre.Comedy, 5},
                        {MovieGenre.Detective, 2},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 5},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(38, "Гусева Софья Тиграновна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 3},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 1},
                        {MovieGenre.Horror, 3},
                        {MovieGenre.Historical, 1},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(39, "Котова Агата Максимовна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 4},
                        {MovieGenre.Detective, 5},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 2},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(40, "Дмитриева Анна Глебовна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 5},
                        {MovieGenre.Comedy, 4},
                        {MovieGenre.Detective, 2},
                        {MovieGenre.Horror, 3},
                        {MovieGenre.Historical, 4},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(41, "Софронов Эмиль Вячеславович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 2},
                        {MovieGenre.Comedy, 2},
                        {MovieGenre.Detective, 1},
                        {MovieGenre.Horror, 4},
                        {MovieGenre.Historical, 3},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(42, "Рябова Злата Мироновна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 5},
                        {MovieGenre.Detective, 5},
                        {MovieGenre.Horror, 4},
                        {MovieGenre.Historical, 5},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(43, "Котов Елисей Антонович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 2},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 3},
                        {MovieGenre.Horror, 2},
                        {MovieGenre.Historical, 5},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(44, "Касьянова Агата Игоревна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 1},
                        {MovieGenre.Horror, 5},
                        {MovieGenre.Historical, 2},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(45, "Платонов Михаил Дмитриевич",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 4},
                        {MovieGenre.Horror, 5},
                        {MovieGenre.Historical, 2},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(46, "Суворов Сергей Иванович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 1},
                        {MovieGenre.Detective, 3},
                        {MovieGenre.Horror, 2},
                        {MovieGenre.Historical, 3},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(47, "Петрова Сафия Максимовна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 2},
                        {MovieGenre.Comedy, 5},
                        {MovieGenre.Detective, 3},
                        {MovieGenre.Horror, 4},
                        {MovieGenre.Historical, 1},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(48, "Андреев Роберт Павлович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 2},
                        {MovieGenre.Detective, 1},
                        {MovieGenre.Horror, 5},
                        {MovieGenre.Historical, 2},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(49, "Сергеева Арина Борисовна",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 1},
                        {MovieGenre.Comedy, 1},
                        {MovieGenre.Detective, 2},
                        {MovieGenre.Horror, 1},
                        {MovieGenre.Historical, 1},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(50, "Галкин Даниил Арсентьевич",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 2},
                        {MovieGenre.Comedy, 3},
                        {MovieGenre.Detective, 2},
                        {MovieGenre.Horror, 3},
                        {MovieGenre.Historical, 5},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
                new Moviegoer(51, "Кононов Илья Ярославович",
                    new Dictionary<MovieGenre, int>()
                    {
                        {MovieGenre.Action, 5},
                        {MovieGenre.Comedy, 2},
                        {MovieGenre.Detective, 1},
                        {MovieGenre.Horror, 3},
                        {MovieGenre.Historical, 5},
                    },
                    new Dictionary<string, int>()
                    {
                        {"фильм1", 5}, {"фильм2", 4}, {"фильм3", 2}, {"фильм4", 3}, {"фильм5", 5}
                    }),
            };

            _user ??= new Moviegoer(100, "Иван Забава Кириллович",
                new Dictionary<MovieGenre, int>()
                {
                    {MovieGenre.Action, 5},
                    {MovieGenre.Comedy, 3},
                    {MovieGenre.Detective, 3},
                    {MovieGenre.Horror, 5},
                    {MovieGenre.Historical, 1},
                },
                new Dictionary<string, int>());
        }

        [TestCase(true, null)]
        [TestCase(false, null)]
        public void GetNearestNeighbors_ArgumentNullException_Test(bool isNull, Moviegoer user)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var moviegoers = isNull ? null : new List<Moviegoer>();
                var searcher = new KNearestNeighbors(moviegoers);
                searcher.GetNearestNeighbors(user);
            });
        }

        [Test]
        public void GetNearestNeighbors_Empty_Test()
        {
            var moviegoers = new List<Moviegoer>();
            var user = new Moviegoer(
                1,
                "Ilya",
                new Dictionary<MovieGenre, int>(),
                new Dictionary<string, int>());
            var searcher = new KNearestNeighbors(moviegoers);
            var neighbors = searcher.GetNearestNeighbors(user);
            Assert.AreEqual(0, neighbors.Count());
        }


        [TestCase(1, new int[] {1}, new string[] {"Сергеева Арина Борисовна"})]
        [TestCase(2, new int[] {1, 6}, new string[] {"Сергеева Арина Борисовна","Максимов Илья Петрович"})]
        [TestCase(3, new int[] {1, 6, 19}, new string[] {"Сергеева Арина Борисовна","Максимов Илья Петрович","Румянцева Ульяна Максимовна"})]
        [TestCase(4, new int[] {1, 6, 19, 31}, new string[] {"Сергеева Арина Борисовна","Максимов Илья Петрович","Румянцева Ульяна Максимовна","Андреев Дмитрий Артёмович"})]
        [TestCase(5, new int[] {1, 6, 19, 31, 24}, new string[] {"Сергеева Арина Борисовна","Максимов Илья Петрович","Румянцева Ульяна Максимовна","Андреев Дмитрий Артёмович","Корнеев Тимур Тигранович"})]
        [TestCase(6, new int[] {1, 6, 19, 31, 24, 12}, new string[] {"Сергеева Арина Борисовна","Максимов Илья Петрович","Румянцева Ульяна Максимовна","Андреев Дмитрий Артёмович","Корнеев Тимур Тигранович","Фомина Александра Макаровна"})]
        public void GetNearestNeighbors_Test(int neighborsCount, int[] expectedIds, string[] expectedNames)
        {
            var searcher = new KNearestNeighbors(_moviegoers);
            var neighbors = searcher.GetNearestNeighbors(_user, neighborsCount);
            Assert.AreEqual(neighbors.Count(), neighborsCount);
            var index = 0;
            foreach (var moviegoer in neighbors)
            {
                Assert.AreEqual(expectedIds[index], moviegoer.Id);
                Assert.AreEqual(expectedNames[index], moviegoer.Name);
                index++;
            }
        }

        [Test]
        public void GetRecommendations_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var searcher = new KNearestNeighbors(_moviegoers);
                searcher.GetRecommendations(null);
            });
        }

        [Test]
        public void GetRecommendations_Empty_Test()
        {
            var searcher = new KNearestNeighbors(new List<Moviegoer>());
            var recommendations = searcher.GetRecommendations(_user);
            Assert.AreEqual(string.Empty,recommendations);
        }
        
        [Test]
        public void GetRecommendations_Test()
        {
            var searcher = new KNearestNeighbors(_moviegoers);
            var recommendations = searcher.GetRecommendations(_user);
            Assert.AreEqual("фильм5",recommendations);
        }
        
    }
}