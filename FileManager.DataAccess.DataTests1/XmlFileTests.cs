using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileManager.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Layer;
using System.Xml.Linq;
using System.IO;

namespace FileManager.DataAccess.Data.Tests
{
    [TestClass()]
    public class XmlFileTests
    {
        public static XmlFile xmlFile;
        public static Student student;
        public static int id = 1;
        public static string name = "Nombre";
        public static string surname = "Apellido";
        public static DateTime dateOfBirth = new DateTime(2010, 8, 18);

        [TestInitialize]
        public void Setup()
        {
            xmlFile = new XmlFile
            {
                path = "StudentsTest.xml"
            };
            student = new Student(id, name, surname, dateOfBirth);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            File.Delete(xmlFile.path);
        }
        [TestMethod()]
        public void AddTest()
        {
            xmlFile.Add(student);
            var exists = xmlFile.GetById(student);
            Assert.IsTrue(exists);
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception), "El ID del estudiante ya existe")]
        public void AddTest2()
        {
            xmlFile.Add(student);
            xmlFile.Add(student);
            var exists = xmlFile.GetById(student);
            Assert.IsTrue(exists);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "El estudiante no existe")]
        public void DeleteTest()
        {
            xmlFile.CreateFile();
            xmlFile.Delete(student);
        }
    }
}