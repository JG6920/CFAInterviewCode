using System;
using NUnit.Framework;
using StreamParser.Models;
using StreamParser.Services;
using FakeItEasy;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;

namespace StreamParserAPI.Tests
{
    public class TestInput : IInput<string>
    {
        public TestInput(string v) { this._input = v; }
        public string _input { get => this._input; set => this._input = value; }
    }

    [TestFixture]
    public class ParserTest
    {
        private IStreamParserService<IInput<string>, char> _mockParserService;

        [Test]
        [TearDown]
        public void TestIsGarbge()
        {
            A.CallTo(() => _mockParserService.isGarbage('<')).Returns<bool>(true);
            Assert.IsTrue(_mockParserService.isGarbage('<'));
            A.CallTo(() => _mockParserService.isGarbage('>')).Returns<bool>(true);
            Assert.IsTrue(_mockParserService.isGarbage('>'));
            A.CallTo(() => _mockParserService.isGarbage('{')).Returns<bool>(false);
            Assert.IsFalse(_mockParserService.isGarbage('{'));
        }

        [Test]
        [TearDown]
        public void TestIsGroup()
        {
            A.CallTo(() => _mockParserService.isGroup('{')).Returns<bool>(true);
            Assert.IsTrue(_mockParserService.isGroup('{'));
            A.CallTo(() => _mockParserService.isGroup('}')).Returns<bool>(true);
            Assert.IsTrue(_mockParserService.isGroup('}'));
            A.CallTo(() => _mockParserService.isGroup('>')).Returns<bool>(false);
            Assert.IsFalse(_mockParserService.isGroup('>'));
        }

        [Test]
        [TearDown]
        public void TestIsIgnore()
        {
            A.CallTo(() => _mockParserService.isIgnore('!')).Returns<bool>(true);
            Assert.IsTrue(_mockParserService.isIgnore('!'));
            A.CallTo(() => _mockParserService.isGarbage('>')).Returns<bool>(false);
            Assert.IsFalse(_mockParserService.isGarbage('>'));
        }

        [Test]
        [TearDown]
        public void TestParse()
        {
            IGroup group = new Group();
            A.CallTo(() => _mockParserService.Parse()).Returns(group);
            Assert.AreEqual(group,_mockParserService.Parse());
            IGroup group1 = new Group();
            Assert.AreNotEqual(group1, _mockParserService.Parse());
        }

        [SetUp]
        public void SetUp()
        {
            _mockParserService = A.Fake<StreamParserService>();

        }

    }
}
