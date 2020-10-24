using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos
{
    public class AllegedRC4
    {
        public string CifrarMensajeRC4(string mensaje, string key, Boolean unscripted)
        {
            int[] state = new int[256];
            int x = 0;
            int y = 0;
            int index1 = 0;
            int index2 = 0;
            int nmen;
            string MensajeCifrado = "";

            for (int i = 0; i <= 255; i++)
            {
                state[i] = i;
            }

            for (int i = 0; i <= 255; i++)
            {
                index2 = (((int)key[index1]) + state[i] + index2) % 256;
                int aux = state[i];
                state[i] = state[index2];
                state[index2] = aux;
                index1 = (index1 + 1) % key.Length;
            }
            for (int i = 0; i < mensaje.Length; i++)
            {
                x = (x + 1) % 256;
                y = (state[x] + y) % 256;
                int aux = state[x];
                state[x] = state[y];
                state[y] = aux;
                nmen = ((int)mensaje[i]) ^ state[(state[x] + state[y]) % 256];
                String nmenHex = nmen.ToString("X").ToUpper();
                MensajeCifrado = MensajeCifrado + ((unscripted) ? "" : "-") + ((nmenHex.Length == 1) ? ("0" + nmenHex) : nmenHex);
            }

            return (unscripted) ? MensajeCifrado : MensajeCifrado.Substring(1, MensajeCifrado.Length - 1);
        }
    }
}
