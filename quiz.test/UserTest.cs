using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using quiz.entities;
using NUnit.Framework;
using quiz.api;
using quiz.core;
namespace quiz.test
{

    [TestFixture]
    public class UserTest
    {
        private IUser _userImpl;
        [SetUp]
        public void Init()
        {
            _userImpl = new UserImpl();
        }
        [Test]
        public void TestGetUserByLoginAndPassword()
        {
           User user= _userImpl.GetUserByLoginAndPassword("sahbi", "sahbi");
           Assert.IsNotNull(user);
        }
        [Test]
        public void TestAddUserAnswers()
        {
            Answer answear = _userImpl.GetUserAnswer(1, 1);
            if (answear==null)
                 _userImpl.AddUserAnswer(1, 1);
        }
        [Test]
        public void TestGetUserAnswer()
        {
            Answer answear = _userImpl.GetUserAnswer(1, 1);
            Assert.IsNotNull(answear);
        }

       
    }
}
