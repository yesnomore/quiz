using System.Collections.Generic;
using System.Linq;
using quiz.entities;
using NUnit.Framework;
using quiz.api;
using quiz.core;
namespace quiz.test
{
    [TestFixture]
    public class StatTest
    {
         private IStat _statImpl;
         [SetUp]
         public void Init()
         {
             _statImpl = new StatImpl();
         }
         [Test]
         public void TestAddStat()
         {
             Stat stat = _statImpl.GetStat(1, 1);
             if(stat==null)
                _statImpl.AddStat(1, 1);
         }
         [Test]
         public void TestGetStat()
         {
            Stat stat =_statImpl.GetStat(1, 1);
            Assert.IsNotNull(stat);
         }
         [Test]
         public void TestCreateStats()
         {
             Assert.AreEqual(6, _statImpl.CreateStats(1).Count);
         }      
    }
}
