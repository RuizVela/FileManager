using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.Data
{
    public interface IVuelingFile
    {
        string path();
        string name();
        void Add();
        void Edit();
        void Delete();
    }
}
