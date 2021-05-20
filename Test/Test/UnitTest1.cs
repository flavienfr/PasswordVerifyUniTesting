using NUnit.Framework;
using static Calculator.PasswordVerifier;

namespace Test
{
    public class Tests
    {
        [Test]
        public void PasswordShouldBeLargerThan8Chars()
        {
            var result = Verify("!1234567");
            Assert.IsFalse(result);
        }

        [Test]
        public void PasswordShouldBeNotNull()
        {
            var result = Verify(null);
            Assert.IsFalse(result);
        }

        [Test]
        public void PassWordShouldHaveOneUpperCaseAtLeast()
        {
            var result1 = Verify("!12345678a");
            var result2 = Verify("!12345678Aa");
            var result3 = Verify("!12345678ABa");

            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [Test]
        public void PassWordShouldHaveOneLowerCaseAtLeast()
        {
            var result1 = Verify("!12345678AB");
            var result2 = Verify("!12345678Aa");
            var result3 = Verify("!12345678AbBa");

            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [Test]
        public void PassWordShouldHaveOneDigitCaseAtLeast()
        {
            var result1 = Verify("!ABCDEFghij");
            var result2 = Verify("!ABCDEFghij1");
            var result3 = Verify("!1ABCDEFghij23");

            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [Test]
        public void PassWordShouldHaveASpecialCaracter()
        {
            var result1 = Verify("ABCDEFghij");
            var result2 = Verify("ABCDEFghij1$");
            var result3 = Verify("1ABCDE!Fghij23?");

            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }
    }
}