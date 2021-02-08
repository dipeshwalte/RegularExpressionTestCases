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

        [Test]
        public void GivenMobileCheckIfValid()
        {
            string pattern = @"^[0-9]{2}\s[0-9]{10}$";
            Assert.AreEqual(uv.ValidatePattern(pattern, "54 942242131"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "91 9422421317"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "9 9422421317"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "9422421315"), false);
        }

        [Test]
        public void GivenPassword8CharCheckIfValid()
        {
            string pattern = @"[0-9A-Za-z!@#\$%\^&\*\(\)\-\+]{8,}";
            Assert.AreEqual(uv.ValidatePattern(pattern, "12345678A"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "fdsaf"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "1A!2345678"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "1!!Asrwerds"), true);
        }

        [Test]
        public void GivenPasswordUpperCaseCheckIfValid()
        {
            string pattern = @"(?=.*[A-Z])[0-9A-Za-z!@#\$%\^&\*\(\)\-\+]{8,}";
            Assert.AreEqual(uv.ValidatePattern(pattern, "12345678A"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "fdsafade"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "fdsaf"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "1A!2345678"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "1!!Asrwerds"), true);
        }

        [Test]
        public void GivenPasswordWithNumericCheckIfValid()
        {
            string pattern = @"(?=.*[A-Z])(?=.*[0-9])[0-9A-Za-z!@#\$%\^&\*\(\)\-\+]{8,}";
            Assert.AreEqual(uv.ValidatePattern(pattern, "12345678A"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "fdsafade"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "fdsaf"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "1A!2345678"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "1!!Asrwerds"), true);
        }
        [Test]
        public void GivenPasswordWithExactly1SpecialCheckIfValid()
        {
            string pattern = @"(?=.*[A-Z])(?=.*[0-9])(?=[^.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\]*[.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\][^.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\]*$)[0-9A-Za-z!@#\$%\^&\*\(\)\-\+]{8,}";
            Assert.AreEqual(uv.ValidatePattern(pattern, "12345678A"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "fdsafade"),false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "fdsaf"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "1A!2345678"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "1!!Asrwerds"), false);
        }

        public void GivenEmailAllCasesCheckIfValid()
        {
            string pattern = @"^[0-9a-zA-Z]+[\-\.+]?[A-Za-z0-9]+@[0-9A-Za-z]+\.[a-zA-Z]{2,4}\.?([a-zA-Z]{2,4})?$";
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc..2002@gmail.com"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc@abc@gmail.com"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc.100@yahoo.com"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc.@gmail.com"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc@.com.my"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc@1.com"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc123@gmail.a"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc123@.com.com"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc@yahoo.com"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc.100@abc.com.au"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc-100@yahoo.com"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc-100@abc.net"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc()*@gmail.com"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc123@.com"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc@%*.com"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc111@abc.com"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc@gmail.com.aa.au"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc@gmail.com.com"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc+100@gmail.com"), true);
            Assert.AreEqual(uv.ValidatePattern(pattern, "abc@gmail.com.1a"), false);
            Assert.AreEqual(uv.ValidatePattern(pattern, ".abc@abc.com"), false);
        }
    }
}