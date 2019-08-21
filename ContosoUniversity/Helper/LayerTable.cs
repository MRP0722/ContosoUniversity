using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;

namespace ContosoUniversity.Helper
{
    public class LayerTable<T> : List<T>, IList<T>, ILayerTable, ILayerTable<T>
    {
        private int code;
        public int Code { get { return code; }  }

        private string msg;
        public string Msg { get { return msg; } }

        private int count;

        public new int Count { get { return count; }}

        private IEnumerable<T> data;
        public IEnumerable<T> Data { get { return data; } }

        public LayerTable(IEnumerable<T> item) {
            this.count=item.Count();
            this.code = 0;
            this.msg = "ksakfbaksbdfsa";
            this.data = item;
        }
    }
}
