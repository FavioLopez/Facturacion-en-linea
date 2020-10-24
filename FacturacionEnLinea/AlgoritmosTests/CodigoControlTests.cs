using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algoritmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos.Tests
{
    [TestClass()]
    public class CodigoControlTests
    {
        [TestMethod()]
        public void GenerarCodigoControlTest()
        {
            CodigoControl codigoControl = new CodigoControl();
            Assert.AreEqual("FB-A6-E4-78", codigoControl.GenerarCodigoControl("79040011859", "152", "1026469026", "20070728", "135", "A3Fs4s$)2cvD(eY667A5C4A2rsdf53kw9654E2B23s24df35F5"));
        }
    }
}