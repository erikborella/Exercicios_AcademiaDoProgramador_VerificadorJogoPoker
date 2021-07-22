using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using Poker;

namespace PokerTestws
{
    [TestClass]
    public class JogadorTest
    {
        [TestMethod]
        public void DeveCriarDeck()
        {
            string deck = "AD 6C TH QS 2H";

            Jogador jogador = new Jogador(deck);

            Assert.AreEqual("A", jogador.deck[0].valor);
            Assert.AreEqual("D", jogador.deck[0].naipe);

            Assert.AreEqual("6", jogador.deck[1].valor);
            Assert.AreEqual("C", jogador.deck[1].naipe);

            Assert.AreEqual("T", jogador.deck[2].valor);
            Assert.AreEqual("H", jogador.deck[2].naipe);

            Assert.AreEqual("Q", jogador.deck[3].valor);
            Assert.AreEqual("S", jogador.deck[3].naipe);

            Assert.AreEqual("2", jogador.deck[4].valor);
            Assert.AreEqual("H", jogador.deck[4].naipe);
        }
        [TestMethod]
        public void DeveRetornarCartaMaisAltaA()
        {
            Jogador jogador = new Jogador("KH KC AS 5D 7S");
            VerificadorDeJogo verificadorDeJogo = new VerificadorDeJogo(jogador);

            Assert.AreEqual(1.3, jogador.CartaMaisAlta());
        }

        [TestMethod]
        public void DeveRetornarParComReis()
        {
            Jogador jogador = new Jogador("KH KC AS 5D 7S");
            VerificadorDeJogo verificadorDeJogo = new VerificadorDeJogo(jogador);

            Assert.AreEqual("K", jogador.TemPar());
        }

        [TestMethod]
        public void DeveRetornarDoisParesDamaEValete()
        {
            Jogador jogador = new Jogador("QH QC JS JD 7S");
            VerificadorDeJogo verificadorDeJogo = new VerificadorDeJogo(jogador);

            Assert.AreEqual("Q", jogador.TemDoisPares());
        }

        [TestMethod]
        public void DeveRetornarTrincaDeDez()
        {
            Jogador jogador = new Jogador("TD TH TC 6D 8H");
            VerificadorDeJogo verificadorDeJogo = new VerificadorDeJogo(jogador);

            Assert.AreEqual("T", jogador.TemTrinca());
        }

        [TestMethod]
        public void DeveRetornarSequencia()
        {
            Jogador jogador = new Jogador("TD 9H 8C 7D 6H");
            VerificadorDeJogo verificadorDeJogo = new VerificadorDeJogo(jogador);

            Assert.AreEqual(0.9, jogador.TemSequencia());
        }

        [TestMethod]
        public void DeveRetornarFlush()
        {
            Jogador jogador = new Jogador("AD 9D 8D 7D 6D");
            VerificadorDeJogo verificadorDeJogo = new VerificadorDeJogo(jogador);

            Assert.AreEqual(1.3, jogador.TemFlush());
        }

        [TestMethod]
        public void DeveRetornarFullHouse()
        {
            Jogador jogador = new Jogador("AD AH AC 7D 7D");
            VerificadorDeJogo verificadorDeJogo = new VerificadorDeJogo(jogador);

            Assert.AreEqual(1.3, jogador.TemFullHouse());
        }

        [TestMethod]
        public void DeveRetornarQuadra()
        {
            Jogador jogador = new Jogador("AS AH AC AD 7D");
            VerificadorDeJogo verificadorDeJogo = new VerificadorDeJogo(jogador);

            Assert.AreEqual("A", jogador.TemQuadra());
        }

        [TestMethod]
        public void DeveRetornarStraightFlush()
        {
            Jogador jogador = new Jogador("6S 7S 8S 9S TS");
            VerificadorDeJogo verificadorDeJogo = new VerificadorDeJogo(jogador);

            Assert.AreEqual(0.9, jogador.TemStraightFlush());
        }

        [TestMethod]
        public void DeveRetornarRoyakFlush()
        {
            Jogador jogador = new Jogador("AS KS QS JS TS");
            VerificadorDeJogo verificadorDeJogo = new VerificadorDeJogo(jogador);

            Assert.AreEqual(1.3, jogador.TemRoyalFlush());
        }
    }
}
