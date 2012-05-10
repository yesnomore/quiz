using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using quiz.entities;
using NUnit.Framework;
using quiz.core;
using quiz.api;
namespace quiz.test
{
    [TestFixture]
    public class ResultTest
    {
        private IResult _result;
        [SetUp]
        public void Init()
        {
            _result = new ResultImpl();
        }
        [Test]
        public void TestGetResults()
        {
            Assert.AreEqual(6,_result.GetResults(1, 1));
        }
    }
}
