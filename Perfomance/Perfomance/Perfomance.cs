using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfomance
{

    public abstract class TheaterPerfomance : IComparable<TheaterPerfomance>
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description;
        public DateTime Beginning;
        public DateTime Ending => Beginning + Duration;
        public readonly PerfomanceType Type;
        public double Coefficient;

        public TheaterPerfomance(string name, TimeSpan duration, DateTime beginning, PerfomanceType type)
        {
            Name = name;
            Duration = duration;
            Beginning = beginning;
            Type = type;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[4];
            info[0] = $"{Name} {Duration}";
            info[1] = $"Описание: {Description}";
            info[2] = $"Начало: {Beginning}, Окончание: {Ending}";

            string type;
            if (Type == PerfomanceType.Regular)
                type = "обычный";
            else if (Type == PerfomanceType.Premiere)
                type = "премьера";
            else
                type = "последний сезон";

            info[3] = $"Тип: {type}, Скидка/Увеличение цены: {Coefficient}";
            return info;
        }
        public abstract string GetAuthors();

        public int CompareTo(TheaterPerfomance other) 
        {
            return Beginning.CompareTo(other.Beginning);
        }
    }
    
    public enum Month 
    {
        Январь = 1, Февраль, Март, Апрель, Май, Июнь, Июль, Август, Сентябрь, Октябрь, Ноябрь, Декабрь
    }

    public class Repertoire : IEnumerable<TheaterPerfomance> 
    {
        public Month Month { get; }
        public int Year { get; }
        List<TheaterPerfomance> perfomances;
        public int Count => perfomances.Count;
        public List<TheaterPerfomance> Perfomances => perfomances;

        public Repertoire(Month month, int year, IEnumerable<TheaterPerfomance> inputPerfomances) 
        {
            Month = month;
            Year = year;
            perfomances = new List<TheaterPerfomance>();
            foreach (var perf in inputPerfomances)
            {
                if (perf.Beginning.Month == (int)month && perf.Beginning.Year == year && !perfomances.Contains(perf))
                {
                    perfomances.Add(perf);
                }
            }
        }
        public IEnumerator<TheaterPerfomance> GetEnumerator() => perfomances.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class Opera : TheaterPerfomance 
    {
        public string Composer {  get; set; }
        public string LibrettoAuthor {  get; set; }
        public Opera(string name, TimeSpan duration, DateTime beginning, PerfomanceType type, string composer, string librettoAuthor)
            : base (name, duration, beginning, type) 
        {
            Composer = composer;
            LibrettoAuthor = librettoAuthor;
        }

        public override string GetAuthors() =>
            $"Композитор: {Composer}, автор/ы либретто: {LibrettoAuthor}";
        public override string[] GetInfo()
        {
            var info = new string[5];
            var playInfo = base.GetInfo();

            info[0] = playInfo[0];
            info[1] = playInfo[1]; 
            info[2] = playInfo[2];
            info[3] = playInfo[3];
            info[4] = GetAuthors();

            return info;
        }

    }

    public class Ballet : TheaterPerfomance
    {
        public string Composer { get; set; }
        public string Choreographer { get; set; }
        public Ballet(string name, TimeSpan duration, DateTime beginning, PerfomanceType type, string composer, string choreographer)
            : base(name, duration, beginning, type) 
        {
            Composer = composer;
            Choreographer = choreographer;
        }
        public override string GetAuthors() =>
           $"Композитор: {Composer}, хореограф: {Choreographer}";
        public override string[] GetInfo()
        {
            var info = new string[5];
            var playInfo = base.GetInfo();

            info[0] = playInfo[0];
            info[1] = playInfo[1];
            info[2] = playInfo[2];
            info[3] = playInfo[3];
            info[4] = GetAuthors();

            return info;
        }

    }
    public class Drama: TheaterPerfomance
    {
        public string PlayAuthor { get; set; }
        public Drama(string name, TimeSpan duration, DateTime beginning, PerfomanceType type, string playAuthor)
            : base(name, duration, beginning, type) 
        {
            PlayAuthor = playAuthor;
        }
        public override string GetAuthors() =>
           $"Автор пьесы: {PlayAuthor}";
        public override string[] GetInfo()
        {
            var info = new string[5];
            var playInfo = base.GetInfo();

            info[0] = playInfo[0];
            info[1] = playInfo[1];
            info[2] = playInfo[2];
            info[3] = playInfo[3];
            info[4] = GetAuthors();

            return info;
        }

    }

}