using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algoritmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos.Tests
{
    [TestClass()]
    public class Base64Tests
    {
        [TestMethod()]
        public void ObtenerBase64Test()
        {
            Base64 base64 = new Base64();

            Assert.AreEqual("tjDU/", base64.ObtenerBase64(934598591));
        }
    }
}