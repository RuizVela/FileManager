using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data
{
    public abstract class VuelingFile
    {
        string path { get; set; }
        string name { get; set; }

        public abstract void Add(Student student);
        public abstract void Edit(Student student);
        public abstract void Delete(Student student);
    }
}
