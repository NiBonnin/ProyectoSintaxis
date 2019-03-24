using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    class Tas
    {
        readonly string[] noTerminales = new string[] {"","PROG","SENT","CONDICIONAL","SINO","CICLO","CONDICION","T","CONDAND","S","CONDNOT","ASIGNACION","EXPRESION","DTERMINO","TERMINO","DFACTOR","FACTOR","LEER","ESCRIBIR" };// ver poner "" o "" , serian las filas de las tas
        readonly string[] terminales = new string[] {"", ";", "IF", "THEN", "END", "ELSE", "WHILE", "DO", "id", "=", "NOT", "AND", "OR", "[", "]", "(", ")", "num", "oprel", ",", "+", "-", "*","/","READ","STRING","WRITE","$" };// columnas de la tas
        string[,] tas; // hay que ponerle filas y columas

        public void CargarTas()  //carga de componentes de la tas
        {
            tas = new string[noTerminales.Length,terminales.Length]; ///11,27

            /////////////Primer elemento de fila y columna////////////////////
            tas[1,0]= "PROG";
            tas[2,0]= "SENT";
            tas[3,0]= "CONDICIONAL";
            tas[4,0]= "SINO";
            tas[5,0]= "CICLO";
            tas[6,0]= "CONDICION";
            tas[7,0]= "T";
            tas[8,0]= "CONDADN";
            tas[9,0]= "S";
            tas[10, 0] = "CONDNOT";
            tas[11,0]= "ASIGNACION";
            tas[12,0]= "EXPRESION";
            tas[13,0]= "DTERMINO";
            tas[14,0]= "TERMINO";
            tas[15,0]= "DFACTOR";
            tas[16,0]= "FACTOR";
            tas[17,0]= "LEER";
            tas[18,0]= "ESCRIBIR";
            tas[0,1]= ";";
            tas[0,2]= "IF";
            tas[0,3]= "THEN";
            tas[0,4]= "END";
            tas[0,5]= "ELSE";
            tas[0,6]= "WHILE";
            tas[0,7]= "DO";
            tas[0,8]= "id";
            tas[0,9]= "=";
            tas[0,10]= "NOT";
            tas[0,11]= "AND";
            tas[0,12]= "OR";
            tas[0,13]= "[";
            tas[0,14]= "]";
            tas[0,15]= "(";
            tas[0,16]= ")";
            tas[0,17]= "num";
            tas[0,18]= "oprel";
            tas[0,19]= ",";
            tas[0,20]= "+";
            tas[0,21]= "-";
            tas[0,22]= "*";
            tas[0,23]= "/";
            tas[0,24]= "READ";
            tas[0,25]= "STRING";
            tas[0,26]= "WRITE";
            tas[0, 27] = "$";

            //////////////////////ELEMENTOS DE LAS INTERSECCIONES///////////////////////
            tas[1,2]= "SENT ; PROG";
            tas[2,2]= "CONDICIONAL";
            tas[3,2]= "IF CONDICION THEN PROG SINO END";
            tas[4,5]= "ELSE PROG";
            tas[1,6]= "SENT ; PROG";
            tas[2,6]= "CICLO";
            tas[5,6]= "WHILE CONDICION DO PROG END";
            tas[1,8]= "SENT ; PROG";
            tas[2,8]= "ASIGNACION";
            tas[6,8]= "CONDAND T";
            tas[8,8]= "CONDNOT S";
            tas[10,8]= "EXPRESION oprel EXPRESION";
            tas[11,8]= "id = EXPRESION";
            tas[12,8]= "TERMINO DTERMINO";
            tas[14,8]= "FACTOR DFACTOR";
            tas[16,8]= "id";
            tas[6,10]= "CONDAND T";
            tas[8,10]= "CONDNOT S";
            tas[10,10]= "NOT CONDNOT";
            tas[9,11]= "AND CONDAND";
            tas[7,12]= "OR CONDICION";
            tas[6,13]= "CONDAND T";
            tas[8,13]= "CONDNOT S";
            tas[10,13]= "[ CONDICION ]";
            tas[6,15]= "CONDAND T";
            tas[8,15]= "CONDNOT S";
            tas[10,15]= "EXPRESION oprel EXPRESION";
            tas[12,15]= "TERMINO DTERMINO";
            tas[14,15]= "FACTOR DFACTOR";
            tas[16,15]= "( EXPRESION )";
            tas[6,17]= "CONDAND T";
            tas[8,17]= "CONDNOT S";
            tas[10,17]= "EXPRESION oprel EXPRESION";
            tas[12,17]= "TERMINO DTERMINO";
            tas[14,17]= "FACTOR DFACTOR";
            tas[16,17]= "num";
            tas[13,20]= "+ EXPRESION";
            tas[13,21]= "- EXPRESION";
            tas[15,22]= "* TERMINO";
            tas[15,23]= "/ TERMINO";
            tas[1,24]= "SENT ; PROG";
            tas[2,24]= "LEER";
            tas[17,24]= "READ ( STRING , id )";
            tas[1,26]= "SENT ; PROG";
            tas[2,26]= "ESCRIBIR";
            tas[18,26]= "WRITE ( STRING , EXPRESION )";

        }

        public int PosicionTerminales(string token) // se saca de la cadena de entrada
        {
            int pos = 0;
            for (int c = 0; c < terminales.Length; c++) // no importa recorrerlo entero ya que solo aparece una vez cada simbolo
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
            for (int c = 0; c < noTerminales.Length; c++) // no importa recorrerlo entero ya que solo aparece una vez cada simbolo
            {
                if (noTerminales[c] == token)
                {
                    pos = c;
                }

            }
            return pos;

        }

        public string Elemento(int fila, int colunma)  // devuelve elemento en posicion de la tas
        {
            string elemento = tas[fila, colunma];
            return elemento;
        }

        public string[] GetTerminales()
        { return terminales; }
    }

}

