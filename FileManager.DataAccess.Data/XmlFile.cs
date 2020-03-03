using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data
{
    public class XmlFile : VuelingFile
    {
        public string path;
        string name;

        public override void Add(Student student)
        {
            if (!File.Exists(path))
            {
                CreateFile();
            }
            AppendStudent(student);
        }
        public void CreateFile()
        {
            new XDocument(
                   new XElement("Students")).Save(path);
        }
        private void AppendStudent(Student student)
        {
            if (GetStudent(student) != null) {
                throw new Exception("El ID del estudiante ya existe");
            }
            XDocument document = XDocument.Load(path);
            XElement child = new XElement("Student");
            child.Add(new XElement("Id", student.id.ToString()));
            child.Add(new XElement("Name", student.name));
            child.Add(new XElement("Surname", student.surname));
            child.Add(new XElement("DateOfBirth", student.dateOfBirth.ToString("dd/MM/yyyy")));
            document.Root.Add(child);
            document.Save(path);
        }
        private List<Student> GetStudents()
        {
            List<Student> list = new List<Student>();
            if (File.Exists(path))
            { 
            XmlDocument document = new XmlDocument();
            document.Load(path);
            var studentData = document.SelectNodes("Students/Student");
            foreach (XmlNode node in studentData)
            {
                var studentId = int.Parse(node.SelectSingleNode("Id").InnerText);
                var studentName = node.SelectSingleNode("Name").InnerText;
                var studentSurname = node.SelectSingleNode("Surname").InnerText;
                var studentDateOfBirth = Convert.ToDateTime(node.SelectSingleNode("DateOfBirth").InnerText);
                var student = new Student(studentId, studentName, studentSurname, studentDateOfBirth);
                list.Add(student);
            }
            }
            return list;
        }
        public Student GetStudent(Student student)
        {
            var list = GetStudents();
            var storedStudent = list.Find(x => x.id.Equals(student.id));
            return storedStudent;
        } 
        public override void Delete(Student student)
        {
            if (!File.Exists(path))
            {
                throw new Exception("El archivo no existe");
            }
            if (GetStudent(student) == null) 
            {
                throw new Exception("El estudiante no existe");
            }
            XDocument document = XDocument.Load(path);
            XElement toDelete = document.Root.Elements("Student")
                .SingleOrDefault(x => x.Element("Id").Value.Equals(student.id.ToString()));
            toDelete.Remove();
            document.Save(path);

        }
        public override void Edit(Student student)
        {
            XDocument document = XDocument.Load(path);
            IEnumerable<XElement> toEdit = document.Root.Elements("Student")
    .Where(x => x.Element("Id").Value.Equals(student.id.ToString()));
            toEdit.Elements("Name").FirstOrDefault().Value = student.name;
            toEdit.Elements("Surname").FirstOrDefault().Value = student.surname;
            toEdit.Elements("DateOfBirth").FirstOrDefault().Value = student.dateOfBirth.ToString("dd/MM/yyyy");
            document.Save(path);
        }
    }
}
