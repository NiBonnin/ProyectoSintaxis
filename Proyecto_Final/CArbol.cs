using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    class CArbol
    {
        private CNodo raiz;
        private CNodo trabajo;

        internal CNodo Raiz { get =>this.raiz; }

        public CArbol()
        {
            this.raiz = new CNodo();
        }
         
        public CNodo Insertar(string pDato, CNodo pNodo)
        {
            //si no hay nodo donde insertar, tomamos como si fuera en la raiz
            if(pNodo==null)
            {
                raiz = new CNodo();
                raiz.Dato = pDato;
                raiz.Descripcion = pNodo.Descripcion;
                raiz.Tratado = false;
                raiz.Hijo = null;
                raiz.Hermano = null;
                return raiz;
            }
            if(pNodo.Hijo==null)
            {
                CNodo temp = new CNodo();

                temp.Dato = pDato;
                temp.Descripcion = pNodo.Descripcion;

                // Conectamos el nuevo nodo como hijo
                pNodo.Hijo = temp;

                return temp;
            }
            else // ya tiene un hijo tenemos que insertarlo como hermano
            {
                trabajo = pNodo.Hijo;

                //Avanzamos hasta el ultimo hermano
                while(trabajo.Hermano!=null)
                {
                    trabajo = trabajo.Hermano;
                }

                // creamos nodo temporal
                CNodo temp = new CNodo();

                temp.Dato = pDato;
                temp.Descripcion = pNodo.Descripcion;
                temp.Tratado = false;

                // Unimos el temp al ultimo hermano
                trabajo.Hermano = temp;

                return temp;
            }

           }

        public CNodo Buscar(string pDato, CNodo pNodo)  // Recursivo, busca un nodo segun un dato y a partir de un nodo ingresado para iniciar la busqueda
        { 
            CNodo encontrado = null;

            if (pNodo == null)
                return encontrado;

            if (pNodo.Dato.CompareTo(pDato)==0)
            {
                encontrado = pNodo;
                return encontrado;
            }

            //luego proceso al hijo
            if (pNodo.Hijo != null)
            {
                encontrado = Buscar(pDato, pNodo.Hijo);

                if (encontrado != null)
                    return encontrado;
            }

            // Si tiene hermano los proceso
            if (pNodo.Hermano != null)
            {
                encontrado = Buscar(pDato, pNodo.Hermano);

                if (encontrado != null)
                    return encontrado;
            }
            return encontrado;
        }

        public CNodo BuscarNoTratado(string pDato, CNodo pNodo)  // Recursivo , siempre buscar desde la raiz, por el tratado
        {
            CNodo encontrado = null;

            if (pNodo == null)
                return encontrado;

            if (pNodo.Dato.CompareTo(pDato) == 0 && !pNodo.Tratado)
            {
                encontrado = pNodo;
                return encontrado;
            }

            //luego proceso al hijo
            if (pNodo.Hijo != null)
            {
                encontrado = BuscarNoTratado(pDato, pNodo.Hijo);

                if (encontrado != null)
                    return encontrado;
            }

            // Si tiene hermano lo proceso
            if (pNodo.Hermano != null)
            {
                encontrado = BuscarNoTratado(pDato, pNodo.Hermano);

                if (encontrado != null)
                    return encontrado;
            }
            return encontrado;
        }

        public static bool IsNullOrEmpty(String[] array)
        {
            return (array == null || array.Length == 0);
        }
    }
}
