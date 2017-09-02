using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterfaces
{
    class GenericGatoCol : IEnumerable
    {
        public GenericGatoCol(Gato[] gatos)
        {
            this.gatos = new Gato[gatos.Length];
            for (int i = 0; i < gatos.Length; i++)
            {
                this.gatos[i] = gatos[i];
            }
        }
        Gato[] gatos;

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < gatos.Length; i++)
            {
                yield return gatos[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GenericGato(gatos);
        }
    }

    public class GenericGato : IEnumerator
    {
        public Gato[] gatos;
        int position = -1;

        public GenericGato(Gato[] gatos)
        {
            this.gatos = gatos;
        }

        public bool MoveNext()
        {
            position++;
            return (position < gatos.Count());
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public Gato Current
        {
            get
            {
                try
                {
                    return gatos[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }


}