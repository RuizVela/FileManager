using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Common.Layer
{
    public class Student
    {
        public int id;
        public string name;
        public string surname;
        public DateTime dateOfBirth;
        public Student (int id, string name, string surname, DateTime dateOfBrith)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.dateOfBirth = dateOfBrith;
        }
    }
}
