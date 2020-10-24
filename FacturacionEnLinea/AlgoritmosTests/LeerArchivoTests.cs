using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algoritmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos.Tests
{
    [TestClass()]
    public class LeerArchivoTests
    {
        [TestMethod()]
        public void leerLineasTest()
        {
            int cont = 0;
            string linea;
            List<string> valorEsperado = new List<string>();
            // leer el archivo y mostrar linea por linea
            System.IO.StreamReader archivo = new System.IO.StreamReader("D:/CODIGOFACTURA/5000CasosPruebaCCVer7.txt");
            while ((linea = archivo.ReadLine()) != null)
            {
                if (cont != 0)
                {
                    String[] result = linea.Split('|');
                    valorEsperado.Add(result[result.Length - 2]);
                }
                cont++;
            }
            archivo.Close();
            var lector = new LeerArchivo();
            List<string> ValorResultado = lector.leerLineas();
            CollectionAssert.AreEqual(valorEsperado, ValorResultado);
        }
    }
}