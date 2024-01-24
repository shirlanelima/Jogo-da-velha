using System;

namespace JogoDaVelha
{
    class Program
    {
        static char[,] tabuleiro = new char[3, 3];
        static char jogadorAtual = 'X';
        static bool jogoAcabou = false;

        static void Main(string[] args)
        {
            InicializarTabuleiro();

            while (!jogoAcabou)
            {
                ExibirTabuleiro();
                FazerJogada();
                VerificarFimDeJogo();
                AlternarJogador();
            }
        }

        static void InicializarTabuleiro()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = '-';
                }
            }
        }

        static void ExibirTabuleiro()
        {
            Console.WriteLine("-----");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(tabuleiro[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----");
        }

        static void FazerJogada()
        {
            Console.WriteLine("Jogador " + jogadorAtual + ", faça sua jogada.");

            Console.WriteLine("Digite a linha: ");
            int linha = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a coluna: ");
            int coluna = Convert.ToInt32(Console.ReadLine());

            if (tabuleiro[linha, coluna] == '-')
            {
                tabuleiro[linha, coluna] = jogadorAtual;
            }
            else
            {
                Console.WriteLine("Essa posição já está ocupada. Tente novamente.");
                FazerJogada();
            }
        }

        static void VerificarFimDeJogo()
        {
            if (VerificarVencedor())
            {
                ExibirTabuleiro();
                Console.WriteLine("Jogador " + jogadorAtual + " venceu!");
                jogoAcabou = true;
            }
            else if (VerificarEmpate())
            {
                ExibirTabuleiro();
                Console.WriteLine("O jogo empatou.");
                jogoAcabou = true;
            }
        }

        static bool VerificarVencedor()
        {
            // Verificar linhas
            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[i, 0] == jogadorAtual && tabuleiro[i, 1] == jogadorAtual && tabuleiro[i, 2] == jogadorAtual)
                {
                    return true;
                }
            }

            // Verificar colunas
            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[0, i] == jogadorAtual && tabuleiro[1, i] == jogadorAtual && tabuleiro[2, i] == jogadorAtual)
                {
                    return true;
                }
            }

            // Verificar diagonais
            if ((tabuleiro[0, 0] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 2] == jogadorAtual) ||
                (tabuleiro[0, 2] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 0] == jogadorAtual))
            {
                return true;
            }

            return false;
        }

        static bool VerificarEmpate()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro[i, j] == '-')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void AlternarJogador()
        {
            jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
        }
    }
}