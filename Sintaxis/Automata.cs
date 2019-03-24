using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sintaxis
{
    class Automata     // no se usa esta clase al finall
    {
        /*List<char> _numeros = new List<char>(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
        List<char> _variables = new List<char>(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'f', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' });
        List<char> _operadores = new List<char>(new char[] { '+', '-', '*', '/', '=' }); */
        //List<string> _palabrasReservadas = new List<string>(new string[] { "inicio", "fin" });
        string[] palabrasReservadas = new string[] { "inicio", "fin" };
        //List<string> lexemas = new List<string>(); // lista de lexemas reconocidos 
        // va a contener el texto obtenido del textbox
       
        string estado = "Aceptado";  // indica si el lecema es aceptado, hasta que el verficador prueba lo contrario
        string numeros = "0123456789";
        string variables = "abcdefghijklmnñopqrstuvwxyz";
        string operadores = "+-*/=";
            
        string[] tipo ;  // a que tipo pertenece
        string[] estados; // si es aceptado por el lenguaje el lexema



        public void Reconosedor(string[] lexemas) // ve de que tipo  es cada lexema  (se llama segundo) ***
        {
            int longlex = lexemas.Length;
            
            for (int c = 0; c < longlex; c++)  //cuenta lexemas en string
            {
                string lexema = lexemas[c];

                if (EspalReservada(lexema, palabrasReservadas) == true)
                { tipo[c] = "palReser "; }
                else if (VerificarTipo(lexema, numeros) == true)
                { tipo[c] = "num"; }
                else if (VerificarTipo(lexema, variables) == true)
                { tipo[c] = "var"; }
                else if (VerificarTipo(lexema, operadores) == true)
                { tipo[c] = "op"; }
                
                else
                { tipo[c] = "desconocido"; }






            }
        }





        public void AnalizarTexto(string[] lexemas)  // va a verifica si los lexams pertenecen al lenguaje ***
        {
            int longlexemas = lexemas.Length;
            for(int c= 0; c < longlexemas; c++)
            {
                Aceptador(lexemas[c]);
                estados[c] = estado;
                estado = "Aceptado";
            }
        }


        public void Aceptador(string palabra) // va a ver si los tokens pertenecen al lenguaue ****
        {
            int longpalabra = palabra.Length;
            for (int c =0; c < longpalabra; c++)
            { char a = Convert.ToChar(palabra.Substring(c, 1));
                VerificadorTokens(a);   // si no pertenece cambia estado a rechazado
            }
        }




        public void VerificadorTokens(char a)      // verifica si el caracter pertenece al lenguaje ***
        { if (Pertenece(a, numeros) == true)
            { }
          else if (Pertenece(a, variables) == true)
             {  }
          else if (Pertenece(a, operadores) == true)
            {  }
        else
            { estado = "Rechazado"; }

        }

        
        public bool Pertenece(char a, string cadena) // ve si un elemento se encuentra en una cadea (pasarle num,variable,operadores)***
        {
           string b=Char.ToString(a);

            if (cadena.Contains(b))
            { return true; }
            else
                return false;

        }

        public bool VerificarTipo(string lexema, string tipo)  // ve si el lexema es num, ver o op  ,***
        {
            bool resultado = true;
            int longleg = lexema.Length;

            for (int i = 0; i < longleg; i++)
            {
                char token = Convert.ToChar(lexema.Substring(i, 1));

                if(Pertenece(token,tipo)!=true)
                { resultado = false; }
            }

            return resultado;
        }

        public bool EspalReservada(string lexema, string[] palRes)
        {
            bool resultado = false;
            int longarray = palRes.Length;

            for(int c = 0; c < longarray; c++)
            {
                string aux = palRes[c];
                if (lexema.Contains(aux))
                { return true; }
                }
            return resultado;
            }

        

        public string[] GetTipo()
        { return tipo; }

        public string[] GetEstados()
        { return estados; }

        public void SetTipos(int longlexema)
        { this.tipo =new string[longlexema]; }

        public void SetEstados(int longlexema)
        { this.estados = new string[longlexema]; }

    }
}
