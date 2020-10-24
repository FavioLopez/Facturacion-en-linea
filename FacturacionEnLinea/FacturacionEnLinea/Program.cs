
using Algoritmos;
using System;

namespace FacturacionEnLinea
{
    class Program
    {
        static void Main(string[] args)
        {
            CodigoControl codigoControl = new CodigoControl();

            Console.WriteLine(codigoControl.GenerarCodigoControl("79040011859", "152", "1026469026", "20070728", "135", "A3Fs4s$)2cvD(eY667A5C4A2rsdf53kw9654E2B23s24df35F5"));

        }
    }
}
