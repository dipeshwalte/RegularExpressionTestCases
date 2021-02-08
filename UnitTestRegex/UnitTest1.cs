using NUnit.Framework;
using RegularExpressionTestCases;

namespace UnitTestRegex
{
    public class Tests
    {
        UserValidation uv;
        [SetUp]
        public void Setup()
        {
            uv = new UserValidation();
        }

        [Test]
        public void GivenFirstCheckIfValid()
        {
            string pattern = "[A-Z][a-z]{2,}";
            Assert.AreEqual(uv.ValidatePattern(pattern, "dinesh"),false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "Dipesh"),true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "Di"),false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "Dha"), true);
        }
        [Test]
        public void GivenLastNameCheckIfValid()
        {
            string pattern = "[A-Z][a-z]{2,}";
            Assert.AreEqual(uv.ValidatePattern(pattern, "walte"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "Walte"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "Wa"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "Wla"), true);
        }
        [Test]
        public void GivenEmailCheckIfValid()
        {
            string pattern = @"^[0-9a-zA-Z]+[\-\.+]?[A-Za-z0-9]*@[0-9A-Za-z]+\.[a-zA-Z]{2,4}\.?([a-zA-Z]{2,4})?$";
            Assert.AreEqual(uv.ValidatePattern(pattern, "abcde@bc.com"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc@bl.co"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc@bl"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc.xyz@bl.co.in"), true);
        }
    }
}