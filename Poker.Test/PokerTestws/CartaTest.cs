using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Poker;

namespace PokerTestws
{
    [TestClass]
    public class CartaTest
    {
        [TestMethod]
        public void DeveCriarCartaReiDePaus()
        {
            string cartaValor = "KD";

            Carta carta = new Carta(cartaValor);

            Assert.AreEqual("K", carta.valor);
            Assert.AreEqual("D", carta.naipe);
        }
    }
}
