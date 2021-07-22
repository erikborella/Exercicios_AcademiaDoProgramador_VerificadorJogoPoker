using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Jogador
    {
        public Carta[] deck;

        public Jogador(string cartas)
        {
            List<Carta> cartasTemp = new List<Carta>();
            foreach (string carta in cartas.Split(' '))
            {
                Carta novaCarta = new Carta(carta);
                cartasTemp.Add(novaCarta);
            }

            deck = cartasTemp.ToArray();
        }
        public double CalcularValor(string valor)
        {
            switch (valor)
            {
                case "A":
                    return 1.3;
                case "K":
                    return 1.2;
                case "Q":
                    return 1.1;
                case "J":
                    return 1;
                case "T":
                    return 0.9;
                case "9":
                    return 0.8;
                case "8":
                    return 0.7;
                case "7":
                    return 0.6;
                case "6":
                    return 0.5;
                case "5":
                    return 0.4;
                case "4":
                    return 0.3;
                case "3":
                    return 0.2;
                case "2":
                    return 0.1;
            }
            return 0;
        }

        public string TemPar(Carta[] cartas = null)
        {
            if (cartas == null)
                cartas = this.deck;

            for (int i = 0; i < cartas.Length; i++)
            {
                for (int j = 0; j < cartas.Length; j++)
                {
                    if (i != j)
                    {
                        Carta carta1 = cartas[i];
                        Carta carta2 = cartas[j];

                        if (carta1.valor == carta2.valor)
                        {
                            return carta1.valor;
                        }
                    }
                }
            }
            return null;
        }

        public string TemPar(out int parI, out int parJ)
        {
            for (int i = 0; i < deck.Length; i++)
            {
                for (int j = 0; j < deck.Length; j++)
                {
                    if (i != j)
                    {
                        Carta carta1 = deck[i];
                        Carta carta2 = deck[j];

                        if (carta1.valor == carta2.valor)
                        {
                            parI = i;
                            parJ = j;
                            return carta1.valor;
                        }
                    }
                }
            }

            parI = 0;
            parJ = 0;
            return null;
        }

        public string TemDoisPares()
        {
            List<Carta> cartasTemp = new List<Carta>(deck);

            int i, j;

            string valorPar1 = TemPar(out i, out j);

            if (valorPar1 == null)
                return null;

            cartasTemp.RemoveAt(j);
            cartasTemp.RemoveAt(i);

            string valorPar2 = TemPar(cartasTemp.ToArray());

            if (valorPar2 == null)
                return null;

            string valorMaisAlto =
                (CalcularValor(valorPar1) > CalcularValor(valorPar2))
                ? valorPar1 : valorPar2;

            return valorMaisAlto;
        }

        public double CartaMaisAlta()
        {
            double valor = CalcularValor(deck[0].valor);

            for (int i = 0; i < deck.Length; i++)
            {
                if (CalcularValor(deck[i].valor) > valor)
                {
                    valor = CalcularValor(deck[i].valor);
                }
            }
            return valor;
        }

        public string TemTrinca()
        {
            Dictionary<string, int> contador = new Dictionary<string, int>();
            for (int i = 0; i < deck.Length; i++)
            {
                if (contador.ContainsKey(deck[i].valor))
                {
                    contador[deck[i].valor]++;
                }
                else
                {
                    contador.Add(deck[i].valor, 1);
                }

            }
            foreach (var item in contador)
            {
                if (item.Value == 3)
                {
                    return item.Key;
                }
            }
            return null;
        }
        public string TemQuadra()
        {
            Dictionary<string, int> contador = new Dictionary<string, int>();
            for (int i = 0; i < deck.Length; i++)
            {
                if (contador.ContainsKey(deck[i].valor))
                {
                    contador[deck[i].valor]++;
                }
                else
                {
                    contador.Add(deck[i].valor, 1);
                }

            }
            foreach (var item in contador)
            {
                if (item.Value == 4)
                {
                    return item.Key;
                }
            }
            return null;
        }

        public double TemSequencia()
        {
            Carta[] cartasTemp = OrdernarCartas(deck);

            for (int i = 1; i < cartasTemp.Length; i++)
            {
                Carta carta1 = cartasTemp[i - 1];
                Carta carta2 = cartasTemp[i];

                double valorCarta1 = CalcularValor(carta1.valor) * 10;
                double valorCarta2 = CalcularValor(carta2.valor) * 10;

                double temp = valorCarta1 - valorCarta2;
                if (valorCarta1 - valorCarta2 != 1)
                {
                    return 0;
                }
            }
            return CartaMaisAlta();
        }

        public double TemFlush()
        {
            string naipeReferencia = deck[0].naipe;

            for (int i = 0; i < deck.Length; i++)
            {
                Carta carta = deck[i];

                if (carta.naipe != naipeReferencia)
                    return 0;
            }

            return CartaMaisAlta();
        }

        public double TemFullHouse()
        {
            string valorTrinca = TemTrinca();

            if (valorTrinca == null)
                return 0;

            List<Carta> cartasTemp = new List<Carta>(deck);

            cartasTemp = cartasTemp.Where(c => c.valor != valorTrinca).ToList();


            string valorPar = TemPar(cartasTemp.ToArray());

            if (valorPar == null)
                return 0;

            return CalcularValor(valorTrinca);
        }
        public double TemStraightFlush()
        {
            double valorSequencia = TemSequencia();

            if (valorSequencia == 0)
                return 0;

            double valorFlush = TemFlush();

            if (valorFlush == 0)
                return 0;

            return valorSequencia;
        }

        public double TemRoyalFlush()
        {
            double valorStraightFlush = TemStraightFlush();

            if (valorStraightFlush == 0)
                return 0;
            if (valorStraightFlush == 1.3)
            {
                return valorStraightFlush;
            }
            return 0;
        }

        public Carta[] OrdernarCartas(Carta[] cartas)
        {
            return cartas.OrderByDescending(c => CalcularValor(c.valor)).ToArray();
        }
    }
}

