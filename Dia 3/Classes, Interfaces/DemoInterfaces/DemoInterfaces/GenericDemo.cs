using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterfaces
{
    class GenericDemo:IEnumerable<Gato>
    {

        List<int> listEnteros;
        List<string> listString;
        List<Perro> listPerro;
        Queue<Lobo> listLobo;
        Dictionary<Guid, Paloma> diccionarioRatas;

        public IEnumerator<Gato> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
