using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Sintaxis
{
    class SintDescNRP
    {
        public const int NODIS = 5000;

        private Pila _pila;
        private string[] _vts = { "", "id", "=", ";", "+", "-", "/", "num", "(", ")", "$" };
        private string[] _vns = { "", "A", "E", "E'", "T", "T'", "F" };
        private int[,] _prod ={{1,4,-1,-2,2,-3},          // A->id = E ; 
                           {2,2,4,3,0,0},          // E->T E' 
                           {3,3,-4,4,3,0},          // E'->+ T E' 
                           {3,3,-5,4,3,0},          // E'->- T E' 
                           {3,0,0,0,0,0},          // E'->£
                           {4,2,6,5,0,0},          // T->F T' 
                           {5,3,-4,6,5,0},          // T'->+ F T' 
                           {5,3,-6,6,5,0},          // T'->/ F T' 
                           {5,0,0,0,0,0},          // T'->£
                           {6,1,-1,0,0,0},          // F->id 
                           {6,1,-7,0,0,0},          // F->num 
                           {6,3,-8,2,-9,0}          // F->( E ) 
                          };
        private int[,] _m ={{1,1,0},
                         {2,1,1},
                         {2,7,1},
                         {2,8,1},
                         {3,4,2},
                         {3,5,3},
                         {3,3,4},
                         {3,9,4},
                         {4,1,5},
                         {4,7,5},
                         {4,8,5},
                         {5,4,6},
                         {5,6,7},
                         {5,5,8},
                         {5,3,8},
                         {5,9,8},
                         {6,1,9},
                         {6,7,10},
                         {6,8,11}
                        };

        private int _noVts;
        private int _noVns;
        private int _noProd;
        private int _noEnt;
        private int[] _di;
        private int _noDis;

        // Metodos 

        public SintDescNRP() // Constructor -----------------------
        {
            _pila = new Pila();
            _noVts = _vts.Length;
            _noVns = _vns.Length;
            _noProd = 12;
            _noEnt = 19;
            _di = new int[NODIS];
            _noDis = 0;
        }  // Fin del Constructor ---------------------------------------

        public void Inicia() // Constructor -----------------------
        {
            _pila.Inicia();
            _noDis = 0;
        }

        public int Analiza(Lexico oAnaLex)
        {
            SimbGram x = new SimbGram("");
            string a;
            int noProd;
            _pila.Inicia();
            _pila.Push(new SimbGram("$"));
            _pila.Push(new SimbGram(_vns[1]));
            oAnaLex.Anade("$", "$");
            int ae = 0;
            do
            {
                x = _pila.Tope;
                a = oAnaLex.Token[ae];
                if (EsTerminal(x.Elem))
                    if (x.Elem.Equals(a))
                    {
                        _pila.Pop();
                        ae++;
                    }
                    else
                        return 1;
                else
                {
                    if ((noProd = BusqProd(x.Elem, a)) >= 0)
                    {
                        _pila.Pop();
                        MeterYes(noProd);
                        _di[_noDis++] = noProd;
                    }
                    else
                        return 2;
                }
            } while (!x.Elem.Equals("$"));
            return 0;
        }

        public bool EsTerminal(string x)
        {
            for (int i = 1; i < _noVts; i++)
                if (_vts[i] == x)
                    return true;
            return false;
        }

        public int BusqProd(string x, string a)
        {
            int indiceX = 0;
            for (int i = 1; i < _noVns; i++)
                if (_vns[i] == x)
                {
                    indiceX = i;
                    break;
                }
            int indiceA = 0;
            for (int i = 1; i < _noVts; i++)
                if (_vts[i] == a)
                {
                    indiceA = i;
                    break;
                }
            for (int i = 0; i < _noEnt; i++)
                if (indiceX == _m[i, 0] && indiceA == _m[i, 1])
                    return _m[i, 2];
            return -1;
        }

        public void MeterYes(int noProd)
        {
            int noYes = _prod[noProd, 1];
            for (int i = 1; i <= noYes; i++)
                if (_prod[noProd, noYes + 2 - i] < 0)
                    _pila.Push(new SimbGram(_vts[-_prod[noProd, noYes + 2 - i]]));
                else
                    _pila.Push(new SimbGram(_vns[_prod[noProd, noYes + 2 - i]]));
        }

        public string[] Vts
        {
            get { return _vts; }
        }

        public string[] Vns
        {
            get { return _vns; }
        }

        public int[,] M
        {
            get { return _m; }
        }

        public int NoDis
        {
            get { return _noDis; }
        }

        public int[] Di
        {
            get { return _di; }
        }

        public int IndiceVn(string vn)
        {
            for (int i = 1; i < _noVns; i++)
                if (_vns[i] == vn)
                    return i;
            return 0;
        }

        public int IndiceVt(string vt)
        {
            for (int i = 1; i < _noVts; i++)
                if (_vts[i] == vt)
                    return i;
            return 0;
        }

        public int NoProd
        {
            get { return _noProd; }
        }





    }
}
