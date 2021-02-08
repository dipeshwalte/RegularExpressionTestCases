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
        public void GivenNameCheckIfValid()
        {
            string pattern = "[A-Z][a-z]{2,}";
            Assert.AreEqual(uv.ValidatePattern(pattern, "dinesh"),false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "Dipesh"),true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "Di"),false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "Dha"), true);
        }
    }
}