using System;
using System.Collections; // para que ande la clase pila
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sintaxis
{
    class AnalisadorSint
    {
        Stack pila;
        Tas tas = new Tas();  // ver so de cargas tas
        string[] lexemas; // array de lexemas obtenidos de lexer  , seria los tipos de los lexemas


        public void ApilarCampo(string campo) //apila el campo de la tabla cuando coincide con el bufer de entrada
        {
            if (campo != null)  // no hace falta poner en la tas los epcilon , ya que en campo nulo no hace nada
            {
                string[] separados;
                separados = campo.Split(); // si te olvidad simbolos en tas no anda
                separados = separados.Where(i => i != "").ToArray();  // array con token separados segun el espacio (no poner " " con espacio) , referencia no establecia el valor pos esta mall(tabla mal hubicacion de simbolo)
                separados = separados.Reverse().ToArray();     // revierte el array para que se mas facil apilarlo
                int longseparados = separados.Length;

                for (int c = 0; c < longseparados; c++)
                {
                    pila.Push(separados[c]);
                }
            }
        }


        public void InicializarPila()  //inicializa la pila y aplica el simbolo fin y el primer token no termina de la gramatica
        {
          pila  = new Stack();
            pila.Push("$");
            pila.Push("A");
        }


        public bool Analizar()           // dvuelve true si la espresion es correcta , lexemas en orden obtenidos del lexer
        {
            int longlexemas = lexemas.Length;
               //puntero  para recorrer lexemas 
            string tope = Convert.ToString(pila.Peek());

            while (tope != "$" && lexemas[0] != "$" )  // mientras top sea deirente de fin y la lista no este vacia
            {
                if (tope == lexemas[0]) // se van eliminando el primero del vector con lexemas
                {
                    eliminarPrimero();
                    pila.Pop();
                    tope = Convert.ToString(pila.Peek());
                }
                else
                {
                    int poscolumna= tas.PosicionTerminales(lexemas[0]);     //fila lo del buffer de entrada
                    int posfila = tas.PosicionNoTerminales(tope);       // columna lo de a pila
                    string valorPosTas = tas.Elemento(posfila, poscolumna);
                    pila.Pop();                // desapila el top
                    ApilarCampo(valorPosTas); // apila lo correxpondiente a la interseccion de fila y columna , si el valor es nulo no hace nada
                    tope = Convert.ToString(pila.Peek());
                    

                }

                }
            if(tope == "$" && lexemas[0] == "$")
            { return true; }
            else
            { return false; }
        }

        public void SetTas()  // carga las tas
        { tas.CargarTas(); }


        public string[] eliminarPrimero() // elimina primer elemento de un array
        {
            string[] nuevoLexema;
            int longlexema = this.lexemas.Length;
            
                nuevoLexema = new string[longlexema - 1];
                for (int c = 0; c < longlexema - 1; c++)
                {

                    nuevoLexema[c] = lexemas[c + 1];

                }
            

            this.lexemas = nuevoLexema;
            return lexemas;
            
        }


        /*public void SetLexemas()
        {
            string[] carga = new string[] { "id", "=","(" ,"num","+" ,"num" ,")","/","num" , ";", "$"}; // hacer pruebas con otras cadenas (no dejar espacio entre comillas de los token)
            lexemas = carga;
        }*/

        public void SetLexemas(string[] lexemastipos)
        { lexemas = lexemastipos; }











    }
}
