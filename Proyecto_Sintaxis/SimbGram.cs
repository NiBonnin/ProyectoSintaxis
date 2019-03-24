using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Sintaxis
{
    class SimbGram
    {
        string _elem;

        public SimbGram(string sValor)
        {
            _elem = sValor;
        }

        public string Elem
        {
            get { return _elem; }
        }

    }
}
