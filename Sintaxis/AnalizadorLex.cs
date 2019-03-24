using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sintaxis
{
    class AnalizadorLex
    {
        string cadenaentrada; // obteniada del scaner (para facilitar se eliminan los espacios y salto de lineas y otros)
        char cadenaconcatenar;  //componente a nalizar
        string lexema = " ";
        string num = "0123456789";
        string carac = "abcdefghijkmnlopqrstuvwxyz";
        string op = "+-*/="; //el igual es de asignacion
        string esp = ")(;"; //simbolos especiales
        string[] lexemas; //va a guardar el lexema  y que es (numero, id , etc.)
        string[] tipos; // el tipo dde lexema
        int inicioEstado = 0;
        int estadoPrincipal = 0;

        public void AutomataReconocedor()
        {
            lexemas = new string[50];
            tipos = new string[50];
            int c = 0; // puntero para recorrer array lexemas

            for(inicioEstado = 0; inicioEstado < cadenaentrada.Length; inicioEstado ++) // retroceder inico de estado para volver al anterior con el caracter anterio
            {
                cadenaconcatenar = cadenaentrada[inicioEstado];

                switch(estadoPrincipal)
                {
                    case 0: // cuando es identificador


                        if (num.Contains(cadenaconcatenar) == true && lexema == " ")    //ver si el primero es num, el resto deve ser num 
                        {
                            lexema += cadenaconcatenar;
                            estadoPrincipal = 1;  // siempre quedar en 1 que es de numero
                        }


                        else if (num.Contains(cadenaconcatenar) == true)
                        {
                            lexema += cadenaconcatenar;
                            estadoPrincipal = 0;
                        }

                        else if (carac.Contains(cadenaconcatenar) == true)    //ver si el primero es carac puede seguirle num o carc
                        {
                            lexema += cadenaconcatenar;
                            estadoPrincipal = 0;
                        }

                        else if (esp.Contains(cadenaconcatenar) == true && lexema != " ")
                        {
                            lexemas[c] = lexema;
                            tipos[c] = "id";
                            lexemas[c + 1] = Convert.ToString(cadenaconcatenar);
                            tipos[c + 1] = Convert.ToString(cadenaconcatenar);
                            lexema = " ";
                            estadoPrincipal = 0;
                            c = c + 2;
                        }

                        else if (esp.Contains(cadenaconcatenar) == true && lexema == " " )
                        {
                            lexemas[c]= Convert.ToString(cadenaconcatenar);
                            tipos[c] = Convert.ToString(cadenaconcatenar);
                            estadoPrincipal = 0;
                            c++;


                        }



                        else if (op.Contains(cadenaconcatenar) == true && lexema != " ") // si es op guarda el numero(lexema) y dsp el op   
                        {
                            lexemas[c] = lexema;
                            tipos[c] = "id";
                            tipos[c + 1] = Convert.ToString(cadenaconcatenar);
                            lexemas[c + 1] = Convert.ToString(cadenaconcatenar);
                            lexema = " ";
                            estadoPrincipal = 0;
                            c = c + 2;
                        }

                        else if (op.Contains(cadenaconcatenar) == true && lexema == " ")
                        {
                            lexemas[c] = Convert.ToString(cadenaconcatenar);
                            tipos[c] = Convert.ToString(cadenaconcatenar);
                            estadoPrincipal = 0;
                            c++;


                        }




                        else if ("$".Contains(cadenaconcatenar) == true && lexema != " " )
                        {
                            lexemas[c] = lexema;
                            tipos[c] = "id";
                            tipos[c + 1] = "$";

                        }

                        else if ("$".Contains(cadenaconcatenar) == true && lexema == " ")
                        { tipos[c] = "$"; }






                        break;

                    case 1: // cuando es numero


                        if (num.Contains(cadenaconcatenar) == true)    //ver si el primero es num, el resto deve ser num 
                        {
                            lexema += cadenaconcatenar;
                            estadoPrincipal = 1;  // siempre quedar en 1 que es de numero
                        }

                        else if(carac.Contains(cadenaconcatenar)==true)
                        {
                            lexemas[c] = lexema;
                            tipos[c] = "num";
                            lexema =Convert.ToString(cadenaconcatenar);
                            estadoPrincipal = 0;
                            c ++;

                        }


                        else if(esp.Contains(cadenaconcatenar)==true)
                        {
                            lexemas[c] = lexema;
                            tipos[c] = "num";
                            lexemas[c + 1] = Convert.ToString(cadenaconcatenar);
                            tipos[c + 1] = Convert.ToString(cadenaconcatenar);
                            lexema = " ";
                            estadoPrincipal = 0;
                            c = c + 2;


                        }

                        else if (esp.Contains(cadenaconcatenar) == true && lexema == " ")
                        {
                            lexemas[c] = Convert.ToString(cadenaconcatenar);
                            tipos[c] = Convert.ToString(cadenaconcatenar);
                            estadoPrincipal = 0;
                            c++;


                        }

                        else if (op.Contains(cadenaconcatenar) == true && lexema != " ") // si es op guarda el numero(lexema) y dsp el op   
                        {
                            lexemas[c] = lexema;
                            tipos[c] = "num";
                            tipos[c + 1] = Convert.ToString(cadenaconcatenar);
                            lexemas[c + 1] = Convert.ToString(cadenaconcatenar);
                            lexema = " ";
                            estadoPrincipal = 0;
                            c = c + 2;
                        }

                        else if (op.Contains(cadenaconcatenar) == true && lexema == " ")
                        {
                            lexemas[c] = Convert.ToString(cadenaconcatenar);
                            tipos[c] = Convert.ToString(cadenaconcatenar);
                            estadoPrincipal = 0;
                            c++;


                        }

                        else if ("$".Contains(cadenaconcatenar) == true && lexema != " ")
                        {
                            lexemas[c] = lexema;
                            tipos[c] = "num";
                            tipos[c + 1] = "$";  // para marcar el fin de la cadena tipos


                        }

                        else if("$".Contains(cadenaconcatenar) == true && lexema == " ")
                        { tipos[c] = "$"; }


                        break;

                      
                    

                        
                }


            }



        }

        public void SetCadenaEntrada(string cadena)
        { cadenaentrada = cadena; }

        public string[] GetLexemas()
        { return lexemas; }

        public string[] GetTipos()
        { return tipos; }


    }
}
