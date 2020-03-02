using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.Data
{
    public class FactoryProvider
    {
        public static IFileFactory<VuelingFile> CreateFactory(string choice)
        {
            switch(choice)
            {
                case "FileFactory":
                    return new FileFactory();
                default:
                    return null;
            }
        }
    }
}
