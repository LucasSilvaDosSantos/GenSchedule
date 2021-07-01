using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GenSchedule.Entities;
using GenSchedule.Helpers;

namespace GenScheduleTest.Helpers
{
    [TestClass()]
    public class DisciplineHelperTest
    {
        [TestMethod()]
        public void MultipleDisciplinesiplines_Discipline_MultipleLessons()
        {
            var discipline1 = new Discipline("1", "Test1", 4, 0, new Professor("1", "TestP"));
            var discipline2 = new Discipline("2", "Test2", 2, 0, new Professor("1", "TestP"));

            var disciplines = DisciplineHelper.MultipleDisciplinesiplines(new List<Discipline> { discipline1, discipline2 });

            Assert.AreEqual(6, disciplines.Count());
        }
    }
}
