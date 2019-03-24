using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Sintaxis
{
    class Automata
    {
        string _textoIma;
        int _edoAct;
        string lenguaje;

        public string TextoIma { get => _textoIma; set => _textoIma = value; }

        char SigCar(ref int i)
        {
            if (i == TextoIma.Length)
            {
                i++;
                return '\0';
            }
            else
                return TextoIma[i++];
        }
        public bool Reconoce(string texto, int iniToken, ref int i, int noAuto)
        {
            char c;
            TextoIma = texto;
            
            switch (noAuto)
            {
                //-------------- Automata delim--------------
                case 0:
                    _edoAct = 0;
                    break;
                //-------------- Automata id--------------
                case 1:
                    _edoAct = 3;
                    break;
                //-------------- Automata num--------------
                case 2:
                    _edoAct = 6;
                    break;
                //-------------- Automata otros--------------
                case 3:
                    _edoAct = 9;
                    break;
            }
            while (i <= TextoIma.Length)
                switch (_edoAct)
                {
                    //-------------- Automata delim--------------
                    case 0:
                        c = SigCar(ref i);
                        if ((lenguaje = " \n\r\t").IndexOf(c) >= 0) _edoAct = 1;
                        else
                        {
                            i = iniToken;
                            return false;
                        }
                        break;
                    case 1:
                        c = SigCar(ref i);
                        if ((lenguaje = " \n\r\t").IndexOf(c) >= 0) _edoAct = 1;
                        else
                        if ((lenguaje = "!\"#$%&\'()*+,-./ 0123456789:;<=>? @ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\] ^ _`abcdefghijklmnopqrstuvwxyz{|}~€‚ƒ„…†‡ˆ‰Š‹ŒŽ‘’“”•–—˜™š›œžŸ ¡¢£¤¥¦§¨©ª«¬-®¯°±²³´µ¶·¸¹º»¼½¾¿\f").IndexOf(c)>=0) _edoAct=2; else
                {
                            i = iniToken;
                            return false;
                        }
                        break;
                    case 2:
                        i--;
                        return true;
                       
                    //-------------- Automata id--------------
                    case 3:
                        c = SigCar(ref i);
                        if ((lenguaje = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz").IndexOf(c) >= 0)
                            _edoAct = 4;
                        else
                        {
                            i = iniToken;
                            return false;
                        }
                        break;
                    case 4:
                        c = SigCar(ref i);
                        if ((lenguaje = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz").IndexOf(c) >= 0)
                            _edoAct = 4;
                        else
                        if ((lenguaje = "0123456789").IndexOf(c) >= 0) _edoAct = 4;
                        else
                        if ((lenguaje = "_").IndexOf(c) >= 0) _edoAct = 4;
                        else
                        if ((lenguaje = " !\"#$%&\'()*+,-./:;<=>?@[\\]^`{|}~€‚ƒ„…†‡ˆ‰Š‹ŒŽ‘’“”•–—˜™š›œžŸ ¡¢£¤¥¦§¨©ª«¬-®¯°±²³´µ¶·¸¹º»¼½¾¿\n\t\r\f").IndexOf(c)>=0) _edoAct=5; else
                    {
                            i = iniToken;
                            return false;
                        }
                        break;
                    case 5:
                        i--;
                        return true;
                        
                    //-------------- Automata num--------------
                    case 6:
                        c = SigCar(ref i);
                        if ((lenguaje = "0123456789").IndexOf(c) >= 0) _edoAct = 7;
                        else
                        {
                            i = iniToken;
                            return false;
                        }
                        break;
                    case 7:
                        c = SigCar(ref i);
                        if ((lenguaje = "0123456789").IndexOf(c) >= 0) _edoAct = 7;
                        else
                        if ((lenguaje = " !\"#$%&\'()*+,-./:;<=>? @ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\] ^ _`abcdefghijklmnopqrstuvwxyz{|}~€‚ƒ„…†‡ˆ‰Š‹ŒŽ‘’“”•–—˜™š›œžŸ ¡¢£¤¥¦§¨©ª«¬-®¯°±²³´µ¶·¸¹º»¼½¾¿\n\t\r\f").IndexOf(c)>=0) _edoAct=8; else
                {
                            i = iniToken;
                            return false;
                        }
                        break;
                    case 8:
                        i--;
                        return true;
                        
                    //-------------- Automata otros--------------
                    case 9:
                        c = SigCar(ref i);
                        if ((lenguaje = ";").IndexOf(c) >= 0) _edoAct = 10;
                        else
                        if ((lenguaje = ",").IndexOf(c) >= 0) _edoAct = 10;
                        else
                        if ((lenguaje = "[").IndexOf(c) >= 0) _edoAct = 10;
                        else
                        if ((lenguaje = "]").IndexOf(c) >= 0) _edoAct = 10;
                        else
                        {
                            i = iniToken;
                            return false;
                        }
                        break;
                    case 10:
                        return true;
                        
                }
            switch (_edoAct)
            {
                case 2: // Autómata delim
                case 5: // Autómata id
                case 8: // Autómata num
                    --i;
                    return true;
            }
            return false;
        }
    }
} // fin de la clase Automata





