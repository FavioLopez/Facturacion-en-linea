using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algoritmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos.Tests
{
    [TestClass()]
    public class AllegedRC4Tests
    {
        [TestMethod()]
        public void CifrarMensajeRC4Test()
        {
            AllegedRC4 rC4 = new AllegedRC4();
            Assert.AreEqual("EB-06-AE-F8-92", rC4.CifrarMensajeRC4("d3Ir6", "sesamo", false));
        }
    }
}