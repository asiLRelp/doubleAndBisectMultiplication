using NUnit.Framework;

namespace doubleAndBisectMultiplicationTests
{
    public class Tests
    {
        [Test]
        [TestCase(5,7)]
        [TestCase(-5,7)]
        [TestCase(5,-7)]
        [TestCase(-5,-7)]
        [TestCase(0,7)]
        [TestCase(5,0)]
        [TestCase(1,8)]
        [TestCase(0,0)]
        [TestCase(564233,456123542)]
        public void Assert_multiplication_gives_correct_result(int x, int y)
        {
            int expected = doubleAndBisectMultiplication.Program.Mul(x, y);

            Assert.AreEqual(expected,x*y);
        }
    }
}