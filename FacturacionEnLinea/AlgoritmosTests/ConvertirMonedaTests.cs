using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algoritmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos.Tests
{
    [TestClass()]
    public class ConvertirMonedaTests
    {
        [TestMethod()]
        public void ConvertirTest()
        {
            ConvertirMoneda convertirMoneda = new ConvertirMoneda();
            Assert.AreEqual("CIENTO VEINTE Y OCHO MILLONES TRECIENTOS SETENTA Y NUEVE MIL DOSCIENTOS SETENTA Y TRES 23/100 BOLIVIANOS", convertirMoneda.Convertir("128379273.23", true));
        }
    }
}