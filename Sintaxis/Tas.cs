using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sintaxis
{
    class Tas
    {
        readonly string[] noTerminales = new string[] { "", "A", "E", "E'", "T", "T'", "F" }; // serian las filas de las tas
        readonly string[] terminales = new string[] { "", "id", "=", ";", "+", "-", "*", "/", "num", "(", ")" }; // columnas de la tas
        string[,] tas; // hay que ponerle filas y columas

        public void CargarTas()  //cargar componentes a mano de la tas
        {
            this.tas = new string[7,11];  // matriz primer celda "0" no "1"
            tas[1,0] = "A";
            tas[2,0] = "E";
            tas[3,0] = "E'";
            tas[4,0] = "T";
            tas[5,0] = "T'";
            tas[6,0] = "F";
            tas[0,1] = "id";
            tas[0,2] = "=";
            tas[0,3] = ";";
            tas[0,4] = "+";
            tas[0,5] = "-";
            tas[0, 6] = "*";
            tas[0,7] = "/";
            tas[0,8] = "num";
            tas[0,9] = "(";
            tas[0, 10] = ")";
            //////////////////////////////////////////////////////////////////////  no pener los epcilon
            tas[1, 1] = "id = E ;"; 
            tas[2,1] = "T E'" ;
            tas[2,8] = "T E'" ;
            tas[2,9] = "T E'";
            //tas[3,3] = "";
            tas[3,4] = "+ T E'" ;
            tas[3,5] = "- T E'" ;
            //tas[3,10] = "" ;
            tas[4,1] = "F T'" ;
            tas[4,8] = "F T'" ;
            tas[4,9] = "F T'" ;
           // tas[5,3] = "" ;
           // tas[5,4] = "" ;
           // tas[5,5] = "" ;
            tas[5,6] = "* F T'" ;
            tas[5,7] = "/ F T'" ;
           // tas[5,10] = "" ;
            tas[6,1] = "id" ;
            tas[6,8] = "num" ;
            tas[6,9] ="( E )" ;
        }

        
       
        /*public int PosicionFilas(string token) // posicion en fila donde aparece el token
        {int pos = Array.IndexOf(filas, token);
            return pos;               }

        public int PosicionColumnas(string token) // posicion en  coluna donde aparece el token
        {
            int pos = Array.IndexOf(columnas, token);
            return pos;
        }*/

         public int PosicionTerminales(string token) // se saca de la cadena de entrada
         { int pos = 0;
            for(int c=0; c <terminales.Length; c++ )       // no importa recorrerlo entero ya que sol oaparece 1 vez cada simbolo
            {
                if (terminales[c] == token)
                {
                    pos = c;
                }

            }
            return pos;

         }

        public int PosicionNoTerminales(string token)  // se sacan de la pila
        {
            int pos = 0;
            for (int c = 0; c < noTerminales.Length; c++)       // no importa recorrerlo entero ya que sol oaparece 1 vez cada simbolo
            {
                if (noTerminales[c] == token)
                {
                    pos = c;
                }

            }
            return pos;

        }



        public string Elemento(int fila, int colunma)  // devuelve elemnto en posicion de la tas
        { string elemento = tas[fila, colunma];
            return elemento; }


    }
}
