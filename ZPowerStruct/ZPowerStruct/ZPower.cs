using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPowerStruct
{
    public struct ZPower
    {
        public double Base { get; set; }
        public int Exponent { get; set; }
        public double Value => Math.Pow(Base, Exponent);
        public ZPower(double baseVal, int exponent)
        {
            Base = baseVal;
            Exponent = exponent;
        }
        public override string ToString()
        {
            return $"{Base}E{Exponent}";
        }
        public override bool Equals(object obj)
        {
            if (obj is ZPower other)
                return Math.Abs(Value - other.Value) < 1e-13;
            throw new ArgumentException("Некорректное сравнение");
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Base.GetHashCode();
                hash = hash * 23 + Exponent.GetHashCode();
                return hash;

            }
        }
        public static bool operator ==(ZPower a, ZPower b) => a.Equals(b);
        public static bool operator !=(ZPower a, ZPower b) => !a.Equals(b);
        public static ZPower operator *(ZPower a, ZPower b)
        {
            if (Math.Abs(a.Base - b.Base) > 1e-13)
                throw new InvalidOperationException("Основания должны быть равны");
            return new ZPower(a.Base, a.Exponent + b.Exponent);
        }
        public static ZPower operator /(ZPower a, ZPower b)
        {
            if (Math.Abs(a.Base - b.Base) > 1e-13)
                throw new InvalidOperationException("Основания должны быть равны");
            return new ZPower(a.Base, a.Exponent - b.Exponent);
        }

    }
}

