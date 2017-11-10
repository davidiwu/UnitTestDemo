using System;
using FeatureProject;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTestForIFoo
    {
        [Test]
        public void DoSomethingUnitTest()
        {
            var mockFoo = new Mock<IFoo>();
            mockFoo.Setup(foo => foo.DoSomething("ping")).Returns(true);

            var result = mockFoo.Object.DoSomething("ping");

            Assert.IsTrue(result);

            var result2 = mockFoo.Object.DoSomething("wrong");

            Assert.IsFalse(result2);
        }

        [Test]
        public void SubmitUnitTest()
        {
            var instance = new Bar();
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);

            var result = mock.Object.Submit(ref instance);
            Assert.IsTrue(result);

            var bar2 = new Bar();
            var result2 = mock.Object.Submit(ref bar2);
            Assert.IsFalse(result2);
        }

        [Test]
        public void DoSomethingStringyUnitTest()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomethingStringy(It.IsAny<string>()))
                .Returns((string s) => s.ToLower());

            var result = mock.Object.DoSomethingStringy("DDD");
            Assert.AreEqual("ddd", result);
        }

        [Test]
        public void GetCountUnitTest()
        {
            var count = 1;
            var mock = new Mock<IFoo>();
            mock.Setup(x => x.GetCount()).Returns(() => count);

            var result = mock.Object.GetCount();
            Assert.AreEqual(1, result);
        }

        [Test]
        public void GetCountMoreTimesUnitTest()
        {
            var count = 1;
            var mock = new Mock<IFoo>();
            mock.Setup(x => x.GetCount())
                .Returns(() => count)
                .Callback(() => count++);

            var result = mock.Object.GetCount();
            Assert.AreEqual(1, result);

            var result2 = mock.Object.GetCount();
            Assert.AreEqual(2, result2);

            var result3 = mock.Object.GetCount();
            Assert.AreEqual(3, result3);
        }

        [Test]
        public void DoSomethingWithExceptionUnitTest()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(x => x.DoSomething("")).
                Throws(new ArgumentException("command"));

            Assert.Throws<ArgumentException>(() =>
                mock.Object.DoSomething(""));
        }
    }
}
