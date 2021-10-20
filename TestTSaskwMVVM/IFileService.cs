using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTakMVVM
{
    public interface IFileService
    {
        List<Parametr> Open(string filename);
        void Save(string filename, List<Parametr> ParametrsList);
    }
}
