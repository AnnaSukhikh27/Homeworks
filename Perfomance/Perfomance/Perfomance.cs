using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfomance
{

    public class TheaterPerfomance
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
    }

}