﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.Data
{
    public class FactoryProvider
    {
        public static IFileFactory<IVuelingFile> CreateFactory(string choice)
        {
            throw new NotImplementedException();
        }
    }
}