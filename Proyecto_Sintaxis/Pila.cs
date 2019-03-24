using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Sintaxis
{
    class Pila
    {
        const int MAX = 5000;
        SimbGram[] _elems;
        int _tope;

        public Pila()
        {
            _elems = new SimbGram[MAX];
            for (int i = 0; i < _elems.Length; i++)
                _elems[i] = new SimbGram("");
            _tope = 0;
        }
        public bool Empty()
        {
            return _tope == 0 ? true : false;
        }
        public bool Full()
        {
            return _tope == _elems.Length ? true : false;
        }
        public void Push(SimbGram oElem)
        {
            _elems[_tope++] = oElem;
        }
        public int Length
        {
            get { return _tope; }
        }
        public SimbGram Pop()
        {
            return _elems[--_tope];
        }

        public void Inicia()
        {
            _tope = 0;
        }

        public SimbGram Tope
        {
            get { return _elems[_tope - 1]; }
        }

    }  // Fin de la clase Pila------------------------------------------------
}

