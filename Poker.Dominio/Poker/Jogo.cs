using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Jogo
    {

        Jogador jogador1;
        Jogador jogador2;

        public Jogo(Jogador jogador1, Jogador jogador2)
        {
            this.jogador1 = jogador1;
            this.jogador2 = jogador2;
        }

        public Jogador Vencedor()
        {
            double valorTotalJogador1 = new VerificadorDeJogo(jogador1).Verificar();
            double valorTotalJogador2 = new VerificadorDeJogo(jogador2).Verificar();

            if (valorTotalJogador1 > valorTotalJogador2)
                return jogador1;
            else if (valorTotalJogador1 == valorTotalJogador2)
                return ResolverEmpate();
            else
                return jogador2;
        }

        private Jogador ResolverEmpate()
        {
            RemoverCartasMaisAltas(jogador1);
            RemoverCartasMaisAltas(jogador2);

            double cartaMaisAltaJogador1 = new VerificadorDeJogo(jogador1).Verificar();
            double cartaMaisAltaJogador2 = new VerificadorDeJogo(jogador2).Verificar();

            if (cartaMaisAltaJogador1 > cartaMaisAltaJogador2)
                return jogador1;
            else
                return jogador2;
        }

        private void RemoverCartasMaisAltas(Jogador jogador)
        {
            Carta[] deck = jogador.deck;

            VerificadorDeJogo verificadorDeJogo = new VerificadorDeJogo(jogador);

            double cartaMaisAlta = jogador.CartaMaisAlta();

            jogador.deck = deck.Where(c => 
            jogador.CalcularValor(c.valor) != cartaMaisAlta).ToArray();
        }
    }
}
