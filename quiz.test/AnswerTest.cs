using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using quiz.entities;
using NUnit.Framework;
using quiz.api;
using quiz.core;
namespace quiz.test
{
    [TestFixture]
    public class AnswerTest
    {
        private IAnswer _answerImpl;
        [SetUp]
        public void Init()
        {
            _answerImpl = new AnswerImpl();
        }
        [Test]
        public void TestGetListAnswerByQuestionId()
        {
            Assert.AreEqual(6, _answerImpl.GetListAnswerByQuestionId(1));
        }
    }
}
