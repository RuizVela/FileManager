using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data
{
    interface IStudentFile
    {
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
    }
}
