using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos
{
    public class Base64
    {
        public string ObtenerBase64(int valor)
        {
            string[] diccionario = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
                                "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
                                "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d",
                                "e", "f", "g", "h", "i", "j", "k", "l", "m", "n",
                                "o", "p", "q", "r", "s", "t", "u", "v", "w", "x",
                                "y", "z", "+", "/" };
            int cosciente = 1;
            int resto;
            string palabra = "";

            while (cosciente > 0)
            {
                cosciente = valor / 64;
                resto = valor % 64;
                palabra = diccionario[resto] + palabra;
                valor = cosciente;

            }
            return palabra;
        }
    }
}
