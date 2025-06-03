namespace Perfomance.UnitTests
{
    [TestFixture]
    public class PerfomanceUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var romeo = CreateTestPerfomance();
            Assert.That(romeo.Name, Is.EqualTo("Ромео и Джульетта"));
            Assert.That(romeo.Duration, Is.EqualTo(new TimeSpan(2, 0, 0)));
            Assert.That(romeo.Beginning, Is.EqualTo(new DateTime(2025, 6, 10, 18, 0, 0)));
            Assert.That(romeo.Type, Is.EqualTo(PerfomanceType.Regular));
            Assert.That(romeo.Ending, Is.EqualTo(new DateTime(2025, 6, 10, 20, 0, 0)));
        }

        [Test]
        public void GetInfoTest()
        {
            var romeo = CreateTestPerfomance();
            romeo.Description = "История трагической любви";
            romeo.Coefficient = 0.0;
            var info = romeo.GetInfo();

            Assert.That(info.Length, Is.EqualTo(4));
            Assert.That($"Ромео и Джульетта 02:00:00", Is.EqualTo(info[0]));
            Assert.That(info[1], Is.EqualTo("Описание: История трагической любви"));
            Assert.That($"Начало: 10.06.2025 18:00:00, Окончание: 10.06.2025 20:00:00", Is.EqualTo(info[2]));
            Assert.That($"Тип: обычный, Скидка/Увеличение цены: 0", Is.EqualTo(info[3]));

            
        }
        private TheaterPerfomance CreateTestPerfomance()
        {
            return new TheaterPerfomance("Ромео и Джульетта", new TimeSpan(2, 0, 0), new DateTime(2025, 6, 10, 18, 0, 0), PerfomanceType.Regular);
        }
    }
    
}