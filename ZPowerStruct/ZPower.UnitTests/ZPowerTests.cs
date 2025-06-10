namespace ZPower.UnitTests
{
    [TestFixture]
    public class ZPowerTests
    {
        [Test]
        public void ConstructorTest()
        {
            var power = new ZPowerStruct.ZPower(2.0, 3);
            Assert.That(power.Base, Is.EqualTo(2.0));
            Assert.That(power.Exponent, Is.EqualTo(3));
        }

        [TestCase(10.0, -1, 0.1)]
        [TestCase(1.0, 0, 1)]
        [TestCase(2.0, 3, 8)]
        public void ValueTest(double b, int e, double expected)
        {
            var power = new ZPowerStruct.ZPower(b, e);
            Assert.That(power.Value, Is.EqualTo(expected).Within(1e-13));
        }

        [Test]

        [TestCase(2.0, 3, "2E3")]
        [TestCase(-1.5, -2, "-1,5E-2")]
        [TestCase(0, 0, "0E0")]
        public void ToStringTest(double b, int e, string expected)
        {
            var power = new ZPowerStruct.ZPower(b, e);
            Assert.That(power.ToString(), Is.EqualTo(expected));
        }


        [Test]
        [TestCase(2.0, 3, 8.0, 1, true)]
        [TestCase(3.0, 2, 9.0, 1, true)]
        [TestCase(2.0, 3, 2.0, 2, false)]
        [TestCase(4.0, 2, 3.0, 2, false)]
        public void Equals_SameValue_ExpectedResult(double b1, int e1, double b2, int e2, bool result)
        {
            var a = new ZPowerStruct.ZPower(b1, e1);
            var b = new ZPowerStruct.ZPower(b2, e2);
            Assert.That(a.Equals(b), Is.EqualTo(result));
        }

        [Test]
        public void Equals_DifferentValue_ArgumentException()
        {
            var a = new ZPowerStruct.ZPower();
            var b = new object();
            
            Assert.That(() => a.Equals(b), Throws.ArgumentException);
        }

        [Test]
        public static void GetHashCodeTest()
        {
            var a = new ZPowerStruct.ZPower(2, 3);
            var b = new ZPowerStruct.ZPower(2, 3);
            var c = new ZPowerStruct.ZPower(2, 4);
            Assert.That(a.Equals(b), Is.True);
            Assert.That(a.Equals(c), Is.False);
        }

        [Test]
        [TestCase(2.0, 3, 2.0, 4, 2.0, 7)]
        [TestCase(5.0, 1, 5.0, 0, 5.0, 1)]
        [TestCase(10.0, -2, 10.0, 1, 10.0, -1)]
        public void Multiply_SameBase_ExpectedResult(double b1, int e1, double b2, int e2, double expectedB, int expectedE)
        {
            var a = new ZPowerStruct.ZPower(b1, e1);
            var b = new ZPowerStruct.ZPower(b2, e2);
            var result = a * b;
            Assert.That(result.Exponent, Is.EqualTo(expectedE));
            Assert.That(result.Base, Is.EqualTo(expectedB));
        }

        [Test]
        [TestCase(2.0, 5, 2.0, 2, 2.0, 3)]
        [TestCase(10.0, 1, 10.0, 1, 10.0, 0)]
        [TestCase(3.0, 4, 3.0, 6, 3.0, -2)]
        public void Divide_SameBase_ExpectedResult(double b1, int e1, double b2, int e2, double expectedB, int expectedE)
        {
            var a = new ZPowerStruct.ZPower(b1, e1);
            var b = new ZPowerStruct.ZPower(b2, e2);
            var result = a / b;
            Assert.That(result.Exponent, Is.EqualTo(expectedE));
            Assert.That(result.Base, Is.EqualTo(expectedB));
        }

        [Test]
        public void Multiply_DifferentBase_ArgumentException()
        {
            var a = new ZPowerStruct.ZPower(2, 3);
            var b = new ZPowerStruct.ZPower(3, 2);
            Assert.That(() => { var c = a * b; }, Throws.InvalidOperationException);
        }

        [Test]
        public void Divide_DifferentBase_ArgumentException()
        {
            var a = new ZPowerStruct.ZPower(2, 3);
            var b = new ZPowerStruct.ZPower(4, 1);
            Assert.That(() => { var c = a / b; }, Throws.InvalidOperationException);
        }
    }
}