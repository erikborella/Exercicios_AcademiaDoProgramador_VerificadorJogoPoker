using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class VerificadorDeJogo
    {
        public Jogador jogador;

        public VerificadorDeJogo(Jogador jogador)
        {
            this.jogador = jogador;
        }

        public double Verificar()
        {
            if (jogador.TemRoyalFlush() != 0)
            {
                return 100;
            }
            else if (jogador.TemStraightFlush() != 0)
            {
                double valorCarta = jogador.TemStraightFlush();

                return valorCarta + 90;
            }
            else if (jogador.TemQuadra() != null)
            {
                string valorCarta = jogador.TemQuadra();

                double valor = jogador.CalcularValor(valorCarta);

                return valor + 80;
            }
            else if (jogador.TemFullHouse() != 0)
            {
                double valorCarta = jogador.TemFullHouse();

                return valorCarta + 70;
            }
            else if (jogador.TemFlush() != 0)
            {
                double valorCarta = jogador.TemFlush();

                return valorCarta + 60;
            }
            else if (jogador.TemSequencia() != 0)
            {
                double valorCarta = jogador.TemSequencia();

                return valorCarta + 50;
            }
            else if (jogador.TemTrinca() != null)
            {
                string valorCarta = jogador.TemTrinca();

                double valor = jogador.CalcularValor(valorCarta);

                return valor + 40;
            }
            else if (jogador.TemDoisPares() != null)
            {
                string valorCarta = jogador.TemDoisPares();

                double valor = jogador.CalcularValor(valorCarta);

                return valor + 30;
            }
            else if (jogador.TemPar() != null)
            {
                string valorCarta = jogador.TemPar();

                double valor = jogador.CalcularValor(valorCarta);

                return valor + 20;
            }

            else
            {
                double valor = jogador.CartaMaisAlta();

                return valor;
            }
        }

    }
}
