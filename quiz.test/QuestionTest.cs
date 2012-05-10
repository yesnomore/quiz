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
    public class QuestionTest
    {
        private IQuestion _questionImpl;
        [SetUp]
        public void Init()
        {
            _questionImpl =  new QuestionImpl();
        }
        [Test]
        public void TestGetQuestionIdsByQuizId()
        {
            Assert.AreEqual(6, _questionImpl.GetQuestionIdsByQuizId(1).Count);
        }
        [Test]
        public void GetQuestionById(int questionId)
        {
            Question question=_questionImpl.GetQuestionById(1);
            Assert.IsNotNull(question);
        } 
        [Test]
        public void GetQuestionsByQuizId(int quizId)
        {
            Assert.AreEqual(6, _questionImpl.GetQuestionsByQuizId(1).Count);
        }
    }
}
