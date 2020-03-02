using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.Data
{
    public class FileFactory : IFileFactory<VuelingFile>
    {
        public VuelingFile Create(string FileType)
        {
            switch(FileType)
            {
                case "txt":
                    return new TxtFile();
                case "xml":
                    return new XmlFile();
                case "json":
                    return new JsonFile();
                default:
                    return null;
            }
        }
    }
}
