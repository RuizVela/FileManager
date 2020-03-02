using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.Data
{
    public interface IFileFactory<VuelignFile>
    {
        VuelingFile Create(string FileType);
    }
}
