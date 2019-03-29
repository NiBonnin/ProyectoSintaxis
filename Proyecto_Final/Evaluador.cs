using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final
{
    class Evaluador
    {
        const String SENT = "SENT";
        const String ASIGNACION = "ASIGNACION";
        const String EXPRESION = "EXPRESION";
        const String LEER = "LEER";
        const String ESCRIBIR = "ESCRIBIR";
        const String CONDICIONAL = "CONDICIONAL";
        const String CICLO = "CICLO";
        const String CONDICION = "CONDICION";
        const String SINO = "SINO";
        const String CONDAND = "CONAND";
        const String CONDNOT = "CONDNOT";
        const String TERMINO = "TERMINO";
        const String DTERMINO = "DTERMINO";
        const String FACTOR = "DFACTOR";
        const String DFACTOR = "DFACTOR";
        Dictionary<String, Double> mapaDatos;
        List<String> listaMostrar;

        public List<String> EvalProgPrincipal(CArbol arbol)
        {
            listaMostrar = new List<String>();
            mapaDatos = new Dictionary<String, Double>();
            CNodo nodoEncontrado = arbol.Buscar(SENT, arbol.Raiz);
            if(nodoEncontrado != null)
            {
                EvalSentencia(nodoEncontrado.Hijo);
                if(nodoEncontrado.Hermano.Hermano.Hijo != null)
                {
                    EvalProg(nodoEncontrado.Hermano.Hermano);
                }
            }
            foreach (KeyValuePair<String, Double> pair in mapaDatos)
            {
                listaMostrar.Add(pair.Key + "   " + pair.Value);
            }
            return listaMostrar;
        }

        public void EvalProg(CNodo nodo)
        {
            if (nodo.Hijo != null)
            {
                EvalSentencia(nodo.Hijo);
                CNodo siguienteProg = nodo.Hijo.Hermano.Hermano;
                if (siguienteProg.Hijo != null)
                {
                    EvalProg(siguienteProg);
                }
            }
        }

        public void EvalSentencia(CNodo nodo)
        {
            CNodo nodoHijo = nodo;
            if(nodoHijo != null)
            {
                switch (nodo.Dato)
                {
                    case ASIGNACION:
                        EvalAsignacion(nodoHijo);
                        break;
                    case LEER:
                        EvalLeer(nodoHijo);
                        break;
                    case ESCRIBIR:
                        EvalEscribir(nodoHijo);
                        break;
                    case CONDICIONAL:
                        EvalCondicional(nodoHijo);
                        break;
                    case CICLO:
                        EvalCiclo(nodoHijo);
                        break;
                    default:
                        break;
                }
            }
        }

        public void EvalAsignacion(CNodo nodo)
        {
            CNodo nodoVariable = nodo.Hijo;
            CNodo nodoExpresion = nodoVariable.Hermano.Hermano;
            mapaDatos.Add(nodoVariable.Dato, EvalExpresion(nodoExpresion));
        }

        public void EvalLeer(CNodo nodo)
        {
            String mostrar = nodo.Hijo.Hermano.Hermano.Dato;
            Double valorIngresado = 0D;
            FormLeer formLeer = new FormLeer(mostrar);
            formLeer.ShowDialog();
            if (String.IsNullOrEmpty(formLeer.ValorIngresado))
            {
                throw new ArgumentException("Debe de agregar un valor", "parametro");
            }
            Double.TryParse(formLeer.ValorIngresado, out valorIngresado);
            mapaDatos.Add(nodo.Hijo.Hermano.Hermano.Hermano.Hermano.Dato, valorIngresado);
        }

        public void EvalEscribir(CNodo nodo)
        {
            String mostrar = nodo.Hijo.Hermano.Hermano.Dato;
            Double expresionUsuario = EvalExpresion(nodo.Hijo.Hermano.Hermano.Hermano.Hermano);
            listaMostrar.Add(mostrar + expresionUsuario);
        }

        public void EvalCondicional(CNodo nodo)
        {
            CNodo nodoIF = nodo.Hijo;
            CNodo nodoProg = null;
            if (EvalCondicion(nodoIF.Hermano))
            {
                nodoProg = nodoIF.Hermano.Hermano.Hermano;
            }
            else
            {
                CNodo nodoSino = nodoIF.Hermano.Hermano.Hermano.Hermano;
                if(nodoSino != null)
                {
                    nodoProg = nodoSino.Hijo.Hermano;
                }
            }
            if (nodoProg != null)
            {
                EvalProg(nodoProg);
            }
        }

        public Boolean EvalCondicion(CNodo nodo)
        {
            return EvalCondAnd(nodo.Hijo) || EvalOr(nodo.Hijo.Hermano);
        }

        public void EvalCiclo(CNodo nodo)
        {
            while (EvalCondicion(nodo.Hijo.Hermano))
            {
                EvalProg(nodo.Hijo.Hermano.Hermano.Hermano);
            }
        }

        public Double EvalExpresion(CNodo nodo)
        {
            CNodo nodoTermino = nodo.Hijo;
            if(nodoTermino != null)
            {
                Double var1 = EvalTermino(nodoTermino);
                CNodo nodoOperacionSumaResta = nodoTermino.Hermano.Hijo;
                if (nodoOperacionSumaResta != null) {
                    Double var2 = EvalExpresion(nodoOperacionSumaResta.Hermano);
                    var1 += (nodoOperacionSumaResta.Dato == "+") ? var2 : (var2 * -1); //evalua expresion, si verdadero suma var2, else suma negativo var2
                }
                return var1;
            }
            return 0D;
        }

        public Double EvalTermino(CNodo nodo)
        {
            CNodo nodoFactor = nodo.Hijo;
            if(nodoFactor.Hijo != null)
            {
                Double var1 = EvalFactor(nodoFactor.Hijo);
                CNodo nodoOperacionMultDiv = nodoFactor.Hijo.Hermano;
                if(nodoOperacionMultDiv != null)
                {
                    Double var2 = EvalTermino(nodoOperacionMultDiv.Hermano);
                    if(nodoOperacionMultDiv.Dato == "*")
                    {
                        var1 = var1 * var2;
                    }
                    else
                    {
                        var1 = var1 / var2;
                    }
                }
            }
            return 0D;
        }

        public Double EvalFactor(CNodo nodo)//nodo dato, que puede ser num, id o exp
        {
            String dato = nodo.Dato;
            Double valor = 0D;
            if (!Double.TryParse(dato, out valor))
            {
                if (dato.First() == '(')
                {
                    valor = EvalExpresion(nodo.Hermano);
                }
                else
                {
                    mapaDatos.TryGetValue(dato, out valor);
                }
            }
            return valor;
        }

        public Boolean EvalCondAnd(CNodo nodo)
        {
            return EvalCondNot(nodo.Hijo) && EvalAnd(nodo.Hijo.Hermano);
        }

        public Boolean EvalAnd(CNodo nodo)
        {
            if(nodo.Hijo != null)
            {
                return EvalCondAnd(nodo.Hijo.Hermano);
            }
            return true;
        }

        public Boolean EvalOr(CNodo nodo)
        {
            if (nodo.Hijo != null)
            {
                return EvalCondicion(nodo.Hijo.Hermano);
            }
            return true;
        }

        public Boolean EvalCondNot(CNodo nodo)
        {
            String valorHijo = nodo.Hijo.Dato;
            if (valorHijo.Equals("NOT"))
            {
                return !EvalCondNot(nodo.Hijo.Hermano);
            }
            else if(valorHijo.Equals("["))
            {
                return EvalCondicion(nodo.Hijo.Hermano);
            }
            else
            {
                Double val1 = EvalExpresion(nodo.Hijo);
                String op = nodo.Hijo.Hermano.Dato;
                Double val2 = EvalExpresion(nodo.Hijo.Hermano.Hermano);
                switch (op)
                {
                    case "<": return val1 < val2;
                    case ">": return val1 > val2;
                    case "==": return val1 == val2;
                    case "!=": return val1 != val2;
                    case "<=": return val1 <= val2;
                    case ">=": return val1 >= val2;
                    default: return true;
                }
            }
        }
    }
}
