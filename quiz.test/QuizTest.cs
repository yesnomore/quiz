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
    public class QuizTest
    {
        private IQuiz _quizImpl;
        [SetUp]
        public void Init()
        {
            _quizImpl = new QuizImpl();
        }
        [Test]
        public void TestGetAllQuizs()
        {
            Assert.AreEqual(1, _quizImpl.GetAllQuizs().Count);
        }
        [Test]
        public void TestGetQuizById()
        {
           Quiz quiz= _quizImpl.GetQuizById(1);
           Assert.IsNotNull(quiz);
        }
    }
}
