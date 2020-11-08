using NUnit.Framework;
using System;

namespace doubleAndBisectMultiplicationTests
{
    public class Tests
    {
        [Test]
        // Testing even and odd numbers
        [TestCase(16, 7)]
        [TestCase(-16, 7)]
        [TestCase(7, 16)]
        [TestCase(16, -7)]
        [TestCase(-16, -7)]
        // Testing zero and one
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(1, 1)]
        [TestCase(1, -1)]
        [TestCase(-1, 1)]
        [TestCase(-1, -1)]
        // Testing edge cases
        [TestCase(Int32.MinValue+1,1)]
        [TestCase(1,Int32.MaxValue)]
        public void Assert_multiplication_gives_correct_result(int x, int y)
        {
            int actual = doubleAndBisectMultiplication.Program.Mul(x, y);

            Assert.AreEqual(x*y, actual);
        }
    }
}