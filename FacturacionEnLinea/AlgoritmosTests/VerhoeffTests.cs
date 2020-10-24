using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos.Tests
{
    [TestClass()]
    public class VerhoeffTests
    {
        [TestMethod()]
        public void ObtenerVerhoeffTest()
        {
            Verhoeff verhoeff = new Verhoeff();

            Assert.AreEqual(7, verhoeff.ObtenerVerhoeff("12083"));

        }
    }
}