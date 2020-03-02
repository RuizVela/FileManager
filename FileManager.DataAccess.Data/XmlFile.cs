using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
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
                   new XElement("Students"
                   )
                   ).Save(path);
        }
        private void AppendStudent(Student student)
        {
            if (GetById(student)) {
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
        private List<int> GetIds()
        {
            List<int> list = new List<int>();
            XDocument document = XDocument.Load(path);
            foreach (var item in document.Element("Students").Elements("Student").Elements("Id"))
            {
                list.Add(int.Parse(item.Value));
            }
            return list;
        }
        public bool GetById(Student student)
        {
            var list = GetIds();
            if (!list.Contains(student.id))
            {
                return false;
            }
            return true;
        } 
        public override void Delete(Student student)
        {
            if (!GetById(student)) 
            {
                throw new Exception("El estudiante no existe");
            }
        }
        public override void Edit(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
