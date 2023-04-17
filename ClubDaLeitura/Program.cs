using System;
using ClubDaLeitura.ModuloAmigo;
using ClubDaLeitura.ModuloCaixa;
using ClubDaLeitura.ModuloRevista;
using ClubDaLeitura.ModuloEmprestimo;


namespace ClubDaLeitura
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Declaração de Repositorios e Telas
            string opcao = "";
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            RespositorioRevista respositorioRevista = new RespositorioRevista();
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
            //respositorioRevista.repositorioCaixa = repositorioCaixa;

            TelaAmigo telaAmigo = new TelaAmigo();
            telaAmigo.repositorioAmigo = repositorioAmigo;

            TelaCaixa telaCaixa = new TelaCaixa();
            telaCaixa.repositorioCaixa = repositorioCaixa;

            TelaRevista telaRevista = new TelaRevista();
            telaRevista.repositorioDeCaixas = repositorioCaixa;
            telaRevista.telaCaixa = telaCaixa;
            telaRevista.repositorioDeRevista = respositorioRevista;

            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
            telaEmprestimo.repositorioAmigo = repositorioAmigo;
            telaEmprestimo.repositorioRevista = respositorioRevista;
            telaEmprestimo.repositorioEmprestimo = repositorioEmprestimo;
            telaEmprestimo.telaAmigos = telaAmigo;
            telaEmprestimo.telaRevista = telaRevista;
            #endregion

            do
            {
                Console.Clear();
                Console.WriteLine("1- Menu Amigo | 2- Menu Revista | 3- Menu Caixa | 4- Menu Emprestimo | S- Sair");
                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    telaAmigo.MenuAmigo(opcao);
                }
                if (opcao == "2")
                {
                    telaRevista.MenuRevista(opcao);
                }
                if (opcao == "3")
                {
                    telaCaixa.MenuCaixa(opcao);
                }
                if (opcao == "4")
                {
                    telaEmprestimo.MenuEmprestimo(opcao);
                }

            }
            while (opcao.ToUpper() != "S");

        }

    }
    }
