using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Poker;

namespace PokerTestws
{
    [TestClass]
    public class JogoTest
    {
        [TestMethod]
        public void VericarParDeCincoEParDeOito()
        {
            Jogador jogador1 = new Jogador("5H 5C 6S 7S KD");
            Jogador jogador2 = new Jogador("2C 3S 8S 8D TD");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador2);
        }
        [TestMethod]
        public void VerificarCartaMaisAlta()
        {
            Jogador jogador1 = new Jogador("5D 8C 9S JS AC");
            Jogador jogador2 = new Jogador("2C 5C 7D 8S QH");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador1);
        }

        [TestMethod]
        public void VerificarDoisPares()
        {
            Jogador jogador1 = new Jogador("5D 8C 9S JS 5C");
            Jogador jogador2 = new Jogador("2C 2C 7D 7S QH");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador2);
        }

        [TestMethod]
        public void VerificarTrincaEDoisPares()
        {
            Jogador jogador1 = new Jogador("5D 8C 8S JS 8C");
            Jogador jogador2 = new Jogador("2C 7D 7S 2D QH");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador1);
        }

        [TestMethod]
        public void VerificarSequencia()
        {
            Jogador jogador1 = new Jogador("TD 6C 8S 7S 9C");
            Jogador jogador2 = new Jogador("7C 7D 7S 2D QH");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador1);
        }

        [TestMethod]
        public void VerificarFlushESequencia()
        {
            Jogador jogador1 = new Jogador("5H 5H 6H 7H KH");
            Jogador jogador2 = new Jogador("TD 6C 8S 7S 9C");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador1);
        }

        [TestMethod]
        public void VerificarFullHouseEFlush()
        {
            Jogador jogador1 = new Jogador("AH KC AS KD AH");
            Jogador jogador2 = new Jogador("5H 5H 6H 7H KH");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador1);
        }

        [TestMethod]
        public void VerificarQuadraEFullHouse()
        {
            Jogador jogador1 = new Jogador("5H 5H 5H 7S 5H");
            Jogador jogador2 = new Jogador("AH KC AS KD AH");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador1);
        }

        [TestMethod]
        public void VerificarStrainghtFlushEQuadra()
        {
            Jogador jogador1 = new Jogador("TH 9H 8H 7H 6H");
            Jogador jogador2 = new Jogador("5H 5H 5H 7S 5H");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador1);
        }
        [TestMethod]
        public void VerificarRoyalFlushEStraightFlush()
        {
            Jogador jogador1 = new Jogador("AH KH QH JH TH");
            Jogador jogador2 = new Jogador("TH 9H 8H 7H 6H");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador1);
        }

        [TestMethod]
        public void VerificarFlushETrinca()
        {
            Jogador jogador1 = new Jogador("2D 9C AS AH AC");
            Jogador jogador2 = new Jogador("3D 6D 7D TD QD");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador2);
        }

        [TestMethod]
        public void VerificarEmpateParCartaMaisAlta()
        {
            Jogador jogador1 = new Jogador("4D 6S 9H QH QC");
            Jogador jogador2 = new Jogador("3D 6D 7H QD QS");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador1);
        }

        [TestMethod]
        public void EmpateDeFullHouse()
        {
            Jogador jogador1 = new Jogador("2H 2D 4C 4D 4S");
            Jogador jogador2 = new Jogador("3C 3D 3S 9S 9D");

            Jogo jogo = new Jogo(jogador1, jogador2);

            Assert.AreEqual(jogo.Vencedor(), jogador1);
        }
    }
}
