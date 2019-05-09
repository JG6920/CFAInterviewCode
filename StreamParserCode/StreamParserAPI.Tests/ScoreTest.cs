using System;
using NUnit.Framework;
using StreamParser.Models;
using StreamParser.Services;
using FakeItEasy;

namespace StreamParserAPI.Tests
{
    [TestFixture]
    public class ScoreTest
    {
        private IScoreService _scoreService;

        [Test]
        [TearDown]
        public void TestScore()
        {
            IResult<int> result = new Result();

            A.CallTo(() => _scoreService.getResult()).Returns<IResult<int>>(result);
            Assert.AreEqual(result, _scoreService.getResult());
            Assert.AreEqual(0, _scoreService.getResult().Score);
        }

        [SetUp]
        public void SetUp()
        {
            _scoreService = A.Fake<IScoreService>();

        }

    }
}
