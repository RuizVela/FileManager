using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileManager.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data.Tests
{
    [TestClass()]
    public class StudentDaoTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var student = new Student();
            StudentDao.Add(student);
            Assert.Fail();
        }
    }
}