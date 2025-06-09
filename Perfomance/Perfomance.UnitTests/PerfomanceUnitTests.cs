namespace Perfomance.UnitTests
{
    [TestFixture]
    public class TheaterPerfomanceTests 
    {
        [Test]
        public void CompareToTest() 
        {
            var shelkunchik = new Ballet("Щелкунчик", new TimeSpan(2, 30, 0), new DateTime(2025, 10, 11, 18, 0, 0), PerfomanceType.LastSeason, "Пётр Чайковский", "Мариус Петипа");
            var zhizel = new Ballet("Жизель", new TimeSpan(2, 0, 0), new DateTime(2025, 10, 11, 20, 40, 0), PerfomanceType.Premiere, "Адольф Адан", "Жан Коралли");
            var don = new Opera("Дон Жуан", new TimeSpan(1, 30, 0), new DateTime(2026, 12, 12, 18, 0, 0), PerfomanceType.Regular, "Вольфганг Амадей Моцарт", "Лоренцо да Понте");
            var sad = new Drama("Вишневый сад", new TimeSpan(2, 50, 0), new DateTime(2025, 9, 10, 18, 0, 0), PerfomanceType.Premiere, "Антон Чехов");
            var dno = new Drama("На дне", new TimeSpan(2, 0, 0), new DateTime(2025, 10, 11, 18, 0, 0), PerfomanceType.Premiere, "Максим Горький");

            Assert.That(shelkunchik.CompareTo(zhizel), Is.LessThan(0));
            Assert.That(shelkunchik.CompareTo(dno), Is.EqualTo(0));
            Assert.That(don.CompareTo(sad), Is.GreaterThan(0));
            Assert.That(dno.CompareTo(sad), Is.GreaterThan(0));
            Assert.That(zhizel.CompareTo(don), Is.LessThan(0));
        }
    }

    public class RepertoireTests 
    {
        Repertoire repertoire;
        TheaterPerfomance[] perfomancesInTheater;

        [SetUp]
        public void Setup() 
        {
            var shelkunchik = new Ballet("Щелкунчик", new TimeSpan(2, 30, 0), new DateTime(2025, 10, 11, 18, 0, 0), PerfomanceType.LastSeason, "Пётр Чайковский", "Мариус Петипа");
            var zhizel = new Ballet("Жизель", new TimeSpan(2, 0, 0), new DateTime(2025, 10, 11, 20, 40, 0), PerfomanceType.Premiere, "Адольф Адан", "Жан Коралли");
            var dno = new Drama("На дне", new TimeSpan(2, 0, 0), new DateTime(2025, 10, 11, 18, 0, 0), PerfomanceType.Premiere, "Максим Горький");
            
            perfomancesInTheater = new TheaterPerfomance[] {shelkunchik, zhizel, dno};
            repertoire = new Repertoire(Month.Октябрь, 2025, perfomancesInTheater);
        }
        [Test]
        public void ConstructorTest() 
        {
            Assert.That(repertoire.Month, Is.EqualTo(Month.Октябрь));
            Assert.That(repertoire.Year, Is.EqualTo(2025));

            foreach (var perfomance in perfomancesInTheater)
                Assert.That(repertoire.Perfomances.Contains(perfomance) && repertoire.Perfomances.IndexOf(perfomance) == repertoire.Perfomances.LastIndexOf(perfomance), Is.True);
        }

        [Test]
        public void CountTest()
        {
            Assert.That(repertoire.Count, Is.EqualTo(3));
        }

        [Test]
        public void IEnumerableTest()
        {
            var i = 0;
            foreach (var perfomance in repertoire)
                Assert.That(perfomance, Is.SameAs(perfomancesInTheater[i++]));
        }
    }
    public class PerfomanceDramaUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var romeo = CreateTestDramaPerfomance();
            Assert.That(romeo.Name, Is.EqualTo("Ромео и Джульетта"));
            Assert.That(romeo.Duration, Is.EqualTo(new TimeSpan(2, 0, 0)));
            Assert.That(romeo.Beginning, Is.EqualTo(new DateTime(2025, 6, 10, 18, 0, 0)));
            Assert.That(romeo.Type, Is.EqualTo(PerfomanceType.Regular));
            Assert.That(romeo.Ending, Is.EqualTo(new DateTime(2025, 6, 10, 20, 0, 0)));
        }

        [Test]
        public void GetInfoTest()
        {
            var romeo = CreateTestDramaPerfomance();
            romeo.Description = "История трагической любви";
            romeo.Coefficient = 0.0;
            var info = romeo.GetInfo();

            Assert.That(info.Length, Is.EqualTo(5));
            Assert.That($"Ромео и Джульетта 02:00:00", Is.EqualTo(info[0]));
            Assert.That(info[1], Is.EqualTo("Описание: История трагической любви"));
            Assert.That($"Начало: 10.06.2025 18:00:00, Окончание: 10.06.2025 20:00:00", Is.EqualTo(info[2]));
            Assert.That($"Тип: обычный, Скидка/Увеличение цены: 0", Is.EqualTo(info[3]));
            Assert.That(info[4], Is.EqualTo("Автор пьесы: Уильям Шекспир"));


        }

        [Test]
        public void GetAuthorsTest()
        {
            var drama = CreateTestDramaPerfomance();
            Assert.That(drama.GetAuthors, Is.EqualTo("Автор пьесы: Уильям Шекспир"));
        }
        private TheaterPerfomance CreateTestDramaPerfomance()
        {
            return new Drama("Ромео и Джульетта", new TimeSpan(2, 0, 0), new DateTime(2025, 6, 10, 18, 0, 0), PerfomanceType.Regular, "Уильям Шекспир");
        }
    }

    public class PerfomanceOperaUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var karmen = CreateTestOperaPerfomance();
            Assert.That(karmen.Name, Is.EqualTo("Кармен"));
            Assert.That(karmen.Duration, Is.EqualTo(new TimeSpan(3, 10, 0)));
            Assert.That(karmen.Beginning, Is.EqualTo(new DateTime(2025, 8, 8, 18, 0, 0)));
            Assert.That(karmen.Type, Is.EqualTo(PerfomanceType.Premiere));
            Assert.That(karmen.Ending, Is.EqualTo(new DateTime(2025, 8, 8, 21, 10, 0)));
        }

        [Test]
        public void GetInfoTest()
        {
            var karmen = CreateTestOperaPerfomance();
            karmen.Description = "Трагическая история о сильной и свободолюбивой цыганке Кармен, чья жизнь полна страсти и перемен.";
            karmen.Coefficient = 0.1;
            var info = karmen.GetInfo();

            Assert.That(info.Length, Is.EqualTo(5));
            Assert.That($"Кармен 03:10:00", Is.EqualTo(info[0]));
            Assert.That(info[1], Is.EqualTo("Описание: Трагическая история о сильной и свободолюбивой цыганке Кармен, чья жизнь полна страсти и перемен."));
            Assert.That($"Начало: 08.08.2025 18:00:00, Окончание: 08.08.2025 21:10:00", Is.EqualTo(info[2]));
            Assert.That($"Тип: премьера, Скидка/Увеличение цены: 0,1", Is.EqualTo(info[3]));
            Assert.That(info[4], Is.EqualTo("Композитор: Жорж Бизе, автор/ы либретто: Анри Мельяк, Людовик Галеви"));


        }
        [Test]
        public void GetAuthorsTest()
        {
            var opera = CreateTestOperaPerfomance();
            Assert.That(opera.GetAuthors, Is.EqualTo("Композитор: Жорж Бизе, автор/ы либретто: Анри Мельяк, Людовик Галеви"));
        }
        private TheaterPerfomance CreateTestOperaPerfomance()
        {
            return new Opera(
                "Кармен",
                new TimeSpan(3, 10, 0),
                new DateTime(2025, 8, 8, 18, 0, 0),
                PerfomanceType.Premiere,
                "Жорж Бизе",
                "Анри Мельяк, Людовик Галеви");
        }
    }
    public class PerfomanceBalletUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var lake = CreateTestBalletPerfomance();
            Assert.That(lake.Name, Is.EqualTo("Лебединое озеро"));
            Assert.That(lake.Duration, Is.EqualTo(new TimeSpan(1, 20, 0)));
            Assert.That(lake.Beginning, Is.EqualTo(new DateTime(2025, 7, 7, 18, 0, 0)));
            Assert.That(lake.Type, Is.EqualTo(PerfomanceType.LastSeason));
            Assert.That(lake.Ending, Is.EqualTo(new DateTime(2025, 7, 7, 19, 20, 0)));
        }

        [Test]
        public void GetInfoTest()
        {
            var lake = CreateTestBalletPerfomance();
            lake.Description = "История принца Зигфрида, который влюбляется в прекрасную Одетту.";
            lake.Coefficient = 0.0;
            var info = lake.GetInfo();

            Assert.That(info.Length, Is.EqualTo(5));
            Assert.That($"Лебединое озеро 01:20:00", Is.EqualTo(info[0]));
            Assert.That(info[1], Is.EqualTo("Описание: История принца Зигфрида, который влюбляется в прекрасную Одетту."));
            Assert.That($"Начало: 07.07.2025 18:00:00, Окончание: 07.07.2025 19:20:00", Is.EqualTo(info[2]));
            Assert.That($"Тип: последний сезон, Скидка/Увеличение цены: 0", Is.EqualTo(info[3]));
            Assert.That(info[4], Is.EqualTo("Композитор: Пётр Чайковский, хореограф: Вацлав Резингер"));


        }
        [Test]
        public void GetAuthorsTest()
        {
            var ballet = CreateTestBalletPerfomance();
            Assert.That(ballet.GetAuthors, Is.EqualTo("Композитор: Пётр Чайковский, хореограф: Вацлав Резингер"));
        }
        private TheaterPerfomance CreateTestBalletPerfomance()
        {
            return new Ballet(
                "Лебединое озеро",
                new TimeSpan(1, 20, 0),
                new DateTime(2025, 7, 7, 18, 0, 0),
                PerfomanceType.LastSeason,
                "Пётр Чайковский",
                "Вацлав Резингер");
        }
    }


}
