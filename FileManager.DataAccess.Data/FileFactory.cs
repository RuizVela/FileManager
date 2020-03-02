using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.Data
{
    public class FileFactory : IFileFactory<IVuelingFile>
    {
        public IVuelingFile Create(string FileType)
        {
            return null;
        }
    }
}
