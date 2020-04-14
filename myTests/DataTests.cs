using NUnit.Framework;
using Assets.Scripts.MODEL;

namespace myTests
{
    public class Tests
    {
        cData _data;
        [SetUp]
        public void Setup()
        {
            _data = new cData();
        }

        [Test]
        public void ReadDataTest()
        {
            _data.ReadData();
            Assert.Fail();
        }
    }
}