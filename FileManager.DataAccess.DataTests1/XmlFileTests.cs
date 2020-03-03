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
        public void Add_method_add_a_student_to_the_file()
        {
            xmlFile.Add(student);
            var response = xmlFile.GetStudent(student);
            Assert.AreEqual(student.id, response.id);
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception), "El ID del estudiante ya existe")]
        public void Add_method_cant_add_new_student_with_same_id()
        {
            xmlFile.Add(student);
            xmlFile.Add(student);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "El estudiante no existe")]
        public void Delete_method_throw_error_if_student_doesnt_exists()
        {
            xmlFile.CreateFile();
            xmlFile.Delete(student);
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception), "El archivo no existe")]
        public void Delete_method_throw_error_if_file_doesnt_exists()
        {
            xmlFile.Delete(student);
        }
        [TestMethod()]
        public void Delete_method_deletes_a_student_from_the_file()
        {
            xmlFile.Add(student);
            xmlFile.Delete(student);
            var expected = xmlFile.GetStudent(student);
            Assert.IsNull(expected);
        }

        [TestMethod()]
        public void CreateFile_method_creates_the_file()
        {
            xmlFile.CreateFile();
            var expected = File.Exists(xmlFile.path);
            Assert.IsTrue(expected);
        }

        [TestMethod()]
        public void Edit_method_update_the_fields_of_an_existing_student()
        {
            var newName = "Name";
            var newSurname = "Surname";
            var newDateOfBirth = new DateTime(1991, 11, 11);
            var student2 = new Student(id, newName, newSurname, newDateOfBirth);
            xmlFile.Add(student);
            xmlFile.Edit(student2);
            var editedStudent = xmlFile.GetStudent(student);
            bool areEqual = student.id == editedStudent.id && newName == editedStudent.name && 
                newSurname == editedStudent.surname && newDateOfBirth == editedStudent.dateOfBirth;
            Assert.IsTrue(areEqual);
        }

        [TestMethod()]
        public void GetStudent_method_returns_the_student_from_the_file()
        {
            xmlFile.Add(student);
            var expected = xmlFile.GetStudent(student);
            Assert.AreEqual(student.id, expected.id);
        }
    }
}