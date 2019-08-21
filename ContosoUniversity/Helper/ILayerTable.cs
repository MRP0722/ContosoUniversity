using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Helper
{
    public interface ILayerTable
    {
        int Code { get; }

        string Msg { get; }
        
    }

    public interface ILayerTable<T> : ILayerTable, IList<T> {
        
    }
}
