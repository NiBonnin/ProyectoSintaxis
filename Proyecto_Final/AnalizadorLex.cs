using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final
{
    class AnalizadorLex
    {
        string cadenaentrada; // obteniada del scaner (para facilitar se eliminan los espacios y salto de lineas y otros)
        char tokenconcatenar;  //componente a analizar
        string lexema = ""; 
        string num = "0123456789";
        string carac = "abcdefghijkmnñlopqrstuvwxyz";   // DIFERENCIA ENTRE MINUSCULA Y MAYUSCULA
        /*string op = "+-/*="; //el igual es de asignacion
        string[] op_relaciona = new string[] {"<",">","==","!="}; // ver si se usa esto con los otros
        string otros = ";[](),";*/
        int inicioEstado = 0;
        int estadoPrincipal = 0;
        List<string> lexemas;
        List<string> descripcion;
        List<string> analizar; // va a contener los que se va a pasar al sintactico detectando que no y eso
        bool estaLeyendo = false;

        public void AutomataReconocedor()
        {
            lexemas = new List<string>();
            descripcion = new List<string>();
            analizar = new List<string>();

            for (inicioEstado = 0; inicioEstado < cadenaentrada.Length; inicioEstado++)
            {
                tokenconcatenar = cadenaentrada[inicioEstado];
                if (!estaLeyendo && tokenconcatenar.Equals(' '))
                {
                    tokenconcatenar = '_';
                }
                switch(estadoPrincipal)
                {
                    case 0: // primero si es palabra reservada
                        switch((tokenconcatenar))
                        {
                            case 'I':   //IF
                                lexema += tokenconcatenar;
                                estadoPrincipal = 3; // reconocedor de IF
                                break;
                            case 'T':   //THEN
                                lexema += tokenconcatenar;
                                estadoPrincipal = 4;
                                break;
                            case 'E':  // END ELSE
                                lexema += tokenconcatenar;
                                estadoPrincipal = 5;
                                break;
                            case 'W':   // WHILE WRITE
                                lexema += tokenconcatenar;
                                estadoPrincipal = 6;
                                break;
                            case 'D': //DO
                                lexema += tokenconcatenar;
                                estadoPrincipal = 7;
                                break;
                            case 'N':  //NOT
                                lexema += tokenconcatenar;
                                estadoPrincipal = 8;
                                break;
                            case 'A':  //AND
                                lexema += tokenconcatenar;
                                estadoPrincipal = 9;
                                break;
                            case 'O':  //OR
                                lexema += tokenconcatenar;
                                estadoPrincipal = 10;
                                break;
                            case 'R':  //READ
                                lexema += tokenconcatenar;  
                                estadoPrincipal = 11;
                                break;
                            case 'S':
                                lexema += tokenconcatenar;
                                estadoPrincipal = 15;
                                break;
                            case '+':
                                lexema += tokenconcatenar;
                                lexemas.Add(lexema);
                                analizar.Add(lexema);
                                descripcion.Add(reconocer(lexema));
                                lexema = "";
                                estadoPrincipal = 0;
                                break;
                            case '-':
                                lexema += tokenconcatenar;
                                lexemas.Add(lexema);
                                analizar.Add(lexema);
                                descripcion.Add(reconocer(lexema));
                                lexema = "";
                                estadoPrincipal = 0;
                                break;
                            case '*':
                                lexema += tokenconcatenar;
                                lexemas.Add(lexema);
                                analizar.Add(lexema);
                                descripcion.Add(reconocer(lexema));
                                lexema = "";
                                estadoPrincipal = 0;
                                break;
                            case '/':
                                lexema += tokenconcatenar;
                                lexemas.Add(lexema);
                                analizar.Add(lexema);
                                descripcion.Add(reconocer(lexema));
                                lexema = "";
                                estadoPrincipal = 0;
                                break;
                            case '=': // para el == y =
                                lexema += tokenconcatenar;
                                estadoPrincipal = 12;
                                break;
                            case '<':
                                lexema += tokenconcatenar;
                                lexemas.Add(lexema);
                                analizar.Add("oprel");
                                descripcion.Add(reconocer(lexema));
                                lexema = "";
                                estadoPrincipal = 0;
                                break;
                            case '>':
                                lexema += tokenconcatenar;
                                lexemas.Add(lexema);
                                analizar.Add("oprel");
                                descripcion.Add(reconocer(lexema));
                                lexema = "";
                                estadoPrincipal = 0;
                                break;
                            case '!':  //para el !=
                                lexema += tokenconcatenar;
                                estadoPrincipal = 13;
                                break;
                            case ';':
                                lexema += tokenconcatenar;
                                lexemas.Add(lexema);
                                analizar.Add(lexema);
                                descripcion.Add(reconocer(lexema));
                                lexema = "";
                                estadoPrincipal = 0;
                                break;
                            case '[':
                                lexema += tokenconcatenar;
                                lexemas.Add(lexema);
                                analizar.Add(lexema);
                                descripcion.Add(reconocer(lexema));
                                lexema = "";
                                estadoPrincipal = 0;
                                break;
                            case ']':
                                lexema += tokenconcatenar;
                                lexemas.Add(lexema);
                                analizar.Add(lexema);
                                descripcion.Add(reconocer(lexema));
                                lexema = "";
                                estadoPrincipal = 0;
                                break;
                            case '(':
                                lexema += tokenconcatenar;
                                lexemas.Add(lexema);
                                analizar.Add(lexema);
                                descripcion.Add(reconocer(lexema));
                                lexema = "";
                                estadoPrincipal = 0;
                                break;
                            case ')':
                                lexema += tokenconcatenar;
                                lexemas.Add(lexema);
                                analizar.Add(lexema);
                                descripcion.Add(reconocer(lexema));
                                lexema = "";
                                estadoPrincipal = 0;
                                break;
                            case ',':
                                lexema += tokenconcatenar;
                                lexemas.Add(lexema);
                                analizar.Add(lexema);
                                descripcion.Add(reconocer(lexema));
                                lexema = "";
                                estadoPrincipal = 0;
                                break;
                            case '"':
                                lexema = "";
                                estadoPrincipal = 14;
                                break;
                            case '_':
                                break;
                            case '$':             // si es final de la cadena lo almaceno solo en la que le paso al anlizador sintactico
                                lexema += tokenconcatenar;
                                analizar.Add(lexema);
                                break;
                            default:  // verificar si es un numero
                                if (num.Contains(tokenconcatenar))
                                {
                                    estadoPrincipal = 1;
                                    lexema += tokenconcatenar;
                                }
                                else if(carac.Contains(tokenconcatenar))
                                {
                                    estadoPrincipal = 2;
                                    lexema += tokenconcatenar;

                                }
                               
                                else
                                { estadoPrincipal = 0;
                                    lexemas.Add(Convert.ToString(tokenconcatenar));
                                    descripcion.Add("Desconocido");

                                }
                                
                                break;

                                //si no  es ninguno retorceder for y pasar al sigueinte caso




                        }

                        break;

                    case 1:     // reconoce num
                        if(num.Contains(tokenconcatenar)==true ) // al final probar si reconoce num y string
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 1;
                        }
                       
                        else if (tokenconcatenar.Equals('$')) // si el ultimo guardo lexema y despues final cadena
                        {
                            lexemas.Add(lexema);
                            descripcion.Add("Numero");
                            analizar.Add("num");
                            lexema = Convert.ToString(tokenconcatenar);
                            analizar.Add(lexema);
                        }
                        else
                        {
                            lexemas.Add(lexema);
                            descripcion.Add("Numero");
                            analizar.Add("num");
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1; ;  //retrocede uno en el for y  ahora ve si es string
                            lexema = "";
                        }


                        break;
                    case 2:    // reconoce variable (numero o letras)
                        if(carac.Contains(tokenconcatenar) ==true || num.Contains(tokenconcatenar) ==true)
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 2;                        
                        }
                        else
                        {
                            lexemas.Add(lexema);
                            descripcion.Add("Identificador");
                            analizar.Add("id");
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                            lexema = "";
                        }

                  

                        break; 
                    case 3:   // reconocedor de IF
                        if (tokenconcatenar.Equals('F')) // reconoce if y lo almacena
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));  //reconoce de que tipo es el lexema
                            lexema = "";
                            estadoPrincipal = 0;
                                
                         }
                        else
                        {
                            lexemas.Add(lexema);  // si viene otro token va a dar desconocido
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                        }
                            break;
                    case 4:                                         // reconoce THEN
                        if (tokenconcatenar.Equals('H'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 4;
                        }
                        else if(tokenconcatenar.Equals('E'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 4;

                        }
                        else if(tokenconcatenar.Equals('N')) //estado de aceptacion
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;

                        }
                        else
                        {
                            lexemas.Add(lexema);  // si viene otro token va a dar desconocido
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                        }

                        break;
                    case 5:
                        if (tokenconcatenar.Equals('N'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 5;
                        }
                        else if (tokenconcatenar.Equals('D'))  // aceptacion de END
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema ="";
                            estadoPrincipal = 0;
                            estaLeyendo = true;
                        }
                       else if (tokenconcatenar.Equals('L'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 5;
                        }
                       else if (tokenconcatenar.Equals('S'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 5;
                        }
                       else if (tokenconcatenar.Equals('E'))
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);  // si viene otro token va a dar desconocido
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;

                        }
                        break;
                    case 6:
                        if (tokenconcatenar.Equals('H'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 6;
                        }
                        else if (tokenconcatenar.Equals('I'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 6;

                        }
                        else if (tokenconcatenar.Equals('L'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 6;

                        }
                        else if (tokenconcatenar.Equals('R'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 6;
                        }
                        else if (tokenconcatenar.Equals('T'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 6;
                        }
                        else if (tokenconcatenar.Equals('E'))
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);  // si viene otro token va a dar desconocido
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                        }
                        break;
                    case 7:
                        if (tokenconcatenar.Equals('O'))
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);  // si viene otro token va a dar desconocido
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                        }
                        break;
                    case 8:
                        if (tokenconcatenar.Equals('O'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 8;
                        }
                        else if (tokenconcatenar.Equals('T'))
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);  // si viene otro token va a dar desconocido
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                        }
                        break;
                    case 9:
                        if (tokenconcatenar.Equals('N'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 9;
                        }
                        else if (tokenconcatenar.Equals('D'))
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);  // si viene otro token va a dar desconocido
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                        }
                        break;
                    case 10:
                         if (tokenconcatenar.Equals('R'))
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);  // si viene otro token va a dar desconocido
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                        }
                        break;
                    case 11:
                        if (tokenconcatenar.Equals('E'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 11;
                        }
                        else if (tokenconcatenar.Equals('A'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 11;
                        }
                        else if (tokenconcatenar.Equals('D'))
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);  // si viene otro token va a dar desconocido
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                        }
                        break;
                    case 12:
                        if (tokenconcatenar.Equals('='))  // este par el ==
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add("oprel");
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);  //para el = solo
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0; // si viene otra letra a a fijarce si es string
                            inicioEstado = inicioEstado - 1;
                        }
                        break;
                    case 13:
                        if (tokenconcatenar.Equals('='))  // este par el ==
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add("oprel");
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);  // si viene otro token va a dar desconocido
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                        }
                        break;
                    case 14:
                        if(!tokenconcatenar.Equals('"'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 14;
                        }
                        else
                        {
                            lexemas.Add(lexema);
                            analizar.Add("STRING" + lexema);
                            descripcion.Add("STRING");
                            lexema = "";
                            estadoPrincipal = 0;
                        }
                        break;
                    case 15:
                        if (tokenconcatenar.Equals('T'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 15;
                        }
                       else if (tokenconcatenar.Equals('R'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 15;
                        }
                        else if (tokenconcatenar.Equals('I'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 15;
                        }
                       else if (tokenconcatenar.Equals('N'))
                        {
                            lexema += tokenconcatenar;
                            estadoPrincipal = 15;
                        }
                        else if (tokenconcatenar.Equals('G'))
                        {
                            lexema += tokenconcatenar;
                            lexemas.Add(lexema);
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                        }
                        else
                        {
                            lexemas.Add(lexema);  // si viene otro token va a dar desconocido
                            analizar.Add(lexema);
                            descripcion.Add(reconocer(lexema));
                            lexema = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                        }
                        break;
                }
            }
        }

        private String reconocer(String lexema)
        {
            const String PALABRARESERVADA = "P_Reservada";
            const String OPERADORARITMETICO = "Op_Aritmetico";
            const String OPERADORRELACIONAL = "Op_Relacional";
            const String ASIGNACION = "Asignacion";
            const String SIGPUNTUACION = "Sig_Puntuacion";
            const String DESCONOCIDO = "Desconocido";
            const String simboloAsignacion = "=";
            List<String> listaPalabrasReservadas = new List<String> { "IF", "THEN", "END", "ELSE", "WHILE", "DO", "NOT", "AND", "OR", "READ", "WRITE", "STRING" };
            List<String> listaOperadoresAritmeticos = new List<String> { "+", "-", "*", "/" };
            List<String> listaOperadoresRelacionales = new List<String> { "<", ">", "==", "!=" };
            List<String> listaSigPuntuacion = new List<String> { ";", "[", "]", "(", ")", "," };

            if (listaPalabrasReservadas.Contains(lexema))
            {
                return PALABRARESERVADA;
            }
            if (listaOperadoresAritmeticos.Contains(lexema))
            {
                return OPERADORARITMETICO;
            }
            if (listaOperadoresRelacionales.Contains(lexema))
            {
                return OPERADORRELACIONAL;
            }
            if (listaSigPuntuacion.Contains(lexema))
            {
                return SIGPUNTUACION;
            }
            if (simboloAsignacion.Equals(lexema))
            {
                return ASIGNACION;
            }
            return DESCONOCIDO;
        }

        public bool ContieneLexemaDesconocido()  //devuelve true si todo los lexemas son validos
        { return descripcion.Contains("Desconocido"); }

        public void SetCadenaEntrada(string cadena)
        { cadenaentrada = cadena; }

        public List<string> GetLexemas()
        { return lexemas; }

        public List<string> GetDescripcion()
        { return descripcion; }

        public List<string> GetAnalizar()
        { return analizar; }
    }
}
