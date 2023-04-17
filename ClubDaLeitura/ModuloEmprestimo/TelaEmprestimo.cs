using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ClubDaLeitura.ModuloAmigo;
using ClubDaLeitura.ModuloCaixa;
using ClubDaLeitura.ModuloRevista;
using ClubDaLeitura.ModuloEmprestimo;
using ClubDaLeitura.Heritage;

namespace ClubDaLeitura.ModuloEmprestimo
{
    public class TelaEmprestimo : Tela
    {
        public RepositorioEmprestimo repositorioEmprestimo = null;
        public RespositorioRevista repositorioRevista = null;
        public RepositorioAmigo repositorioAmigo = null;
        public TelaAmigo telaAmigos = null;
        public TelaRevista telaRevista = null;
        public void MenuEmprestimo(string opcao)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("----Menu Emprestimo----\n");
                Console.WriteLine("1- Adicionar | 2- Todos os Emprestimos | 3- Atualizar Emprestimo | 4- Deleta Emprestimo | 5- Fecha Emprestimo | 6- Mostra Emprestimos Abertos | 7- Mostra Emprestimos Fechados | S- Sair");
                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    Console.Clear();
                    AdicionaEmprestimo();
                }
                if (opcao == "2")
                {
                    Console.Clear();
                    MostraTodosOsEmprestimos();
                    Console.ReadKey();
                }
                if (opcao == "3")
                {
                    Console.Clear();
                    MostraTodosOsEmprestimos();
                    AtualizaEmprestimo();
                }
                if (opcao == "4")
                {
                    Console.Clear();
                    MostraTodosOsEmprestimos();
                    DeletaEmprestimo();
                }
                if (opcao == "5")
                {
                    Console.Clear();
                    MostraTodosOsEmprestimos();
                    FechaEmprestimo();
                }
                if (opcao == "6")
                {
                    Console.Clear();
                    MostraTodosOsEmprestimosEmAberto();
                    Console.ReadKey();
                }
                if (opcao == "7")
                {
                    Console.Clear();
                    MostraTodosOsEmprestimosFechados();
                    Console.ReadKey();

                }
            } while (opcao.ToUpper() != "S");
        }
        private void AdicionaEmprestimo()
        {
            Emprestimo emprestimo = PegaDadosDoEmprestimo();
            if (emprestimo == null)
            {
                ApresentaMensagem("Emprestimo com erro, verefique se amigo e a revista estão registadros", ConsoleColor.DarkRed);
            }
            else
            {
                if (emprestimo.revistaEmprestada.estaEmprestada == true)
                {
                    ApresentaMensagem("Revista ja emprestada!", ConsoleColor.DarkRed);
                }
                else
                {
                    emprestimo.revistaEmprestada.estaEmprestada = true;
                    repositorioEmprestimo.InserirEmprestimo(emprestimo);
                    ApresentaMensagem("Emprestimo Registrado com sucesso!", ConsoleColor.Green);
                }

            }
        }
        private void MostraTodosOsEmprestimos()
        {
            Console.WriteLine("Emprestimos: ");
            Console.WriteLine("____________________________________________________________________________");
            if (repositorioEmprestimo.RetornarTodososEmprestimos().Count == 0)
            {
                ApresentaMensagem("Nenhum Emprestimo Registradado", ConsoleColor.DarkYellow);
            }
            else
            {
                foreach (Emprestimo e in repositorioEmprestimo.RetornarTodososEmprestimos())
                {
                    Console.WriteLine($"id: {e.id} | Amigo: {e.amigoQueEmprestou.nome} | Edição da Revista : {e.revistaEmprestada.edicao} | Ano da Revista: {e.revistaEmprestada.anoDaRevista.ToString("dd/MM/yyyy")} | Data do Emprestimo :{e.dataDoEmpresimo.ToString("dd/MM/yyyy")} |  Data da Devolução :{e.dataDeDevolução.ToString("dd/mm/yyyy")} | Em aberto: {e.emAberto} ");
                }

            }
        }
        private void MostraTodosOsEmprestimosEmAberto()
        {
            Console.WriteLine("Emprestimos em aberto: ");
            Console.WriteLine("____________________________________________________________________________");
            if (repositorioEmprestimo.RetornarTodososEmprestimos().Count == 0)
            {
                ApresentaMensagem("Nenhum Emprestimo Registradado", ConsoleColor.DarkYellow);
            }
            else
            {
                foreach (Emprestimo e in repositorioEmprestimo.RetornarTodososEmprestimos())
                {
                    if (e.emAberto == true)
                    {
                        Console.WriteLine($"id: {e.id} | Amigo: {e.amigoQueEmprestou.nome} | Edição da Revista : {e.revistaEmprestada.edicao} | Ano da Revista: {e.revistaEmprestada.anoDaRevista.ToString("dd/MM/yyyy")} | Data do Emprestimo :{e.dataDoEmpresimo.ToString("dd/MM/yyyy")} |  Data da Devolução :{e.dataDeDevolução.ToString("dd/mm/yyyy")} | Em aberto: {e.emAberto} ");
                    }
                }

            }
        }
        private void MostraTodosOsEmprestimosFechados()
        {
            Console.WriteLine("Emprestimos em aberto: ");
            Console.WriteLine("____________________________________________________________________________");
            if (repositorioEmprestimo.RetornarTodososEmprestimos().Count == 0)
            {
                ApresentaMensagem("Nenhum Emprestimo Registradado", ConsoleColor.DarkYellow);
            }
            else
            {
                foreach (Emprestimo e in repositorioEmprestimo.RetornarTodososEmprestimos())
                {
                    if (e.emAberto == false)
                    {
                        Console.WriteLine($"id: {e.id} | Amigo: {e.amigoQueEmprestou.nome} | Edição da Revista : {e.revistaEmprestada.edicao} | Ano da Revista: {e.revistaEmprestada.anoDaRevista.ToString("dd/MM/yyyy")} | Data do Emprestimo :{e.dataDoEmpresimo.ToString("dd/MM/yyyy")} |  Data da Devolução :{e.dataDeDevolução.ToString("dd/mm/yyyy")} | Em aberto: {e.emAberto} ");
                    }
                }

            }
        }
        private void AtualizaEmprestimo()
        {
            Console.WriteLine("Id para Editar: ");
            int idParaEditar = Convert.ToInt32(Console.ReadLine());
            Emprestimo emprestimo = PegaDadosDoEmprestimo();
            repositorioEmprestimo.AtualizaEmprestimo(idParaEditar, emprestimo);

        }
        private void DeletaEmprestimo()
        {
            Console.WriteLine("Id para Deletar: ");
            int idParaDeletar = Convert.ToInt32(Console.ReadLine());
            repositorioEmprestimo.DeletaEmprestimo(idParaDeletar);
        }
        private void FechaEmprestimo()
        {
            Console.WriteLine("Id para Fechar: ");
            int idParaFechar = Convert.ToInt32(Console.ReadLine());
            repositorioEmprestimo.FechaEmprestimo(idParaFechar);
        }
        private Emprestimo PegaDadosDoEmprestimo()
        {
            Emprestimo novoEmprestimo = new Emprestimo();
            novoEmprestimo.emAberto = true;
            Console.Clear();
            telaAmigos.MostraTodosOsAmigos();
            Console.WriteLine("____________________________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("id do amigo que emprestou : ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());
            novoEmprestimo.amigoQueEmprestou = repositorioAmigo.BuscaAmigos(idAmigo);
            Console.Clear();
            telaRevista.MostraTodosAsRevistas();
            Console.WriteLine("____________________________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("id da revista para emprestar : ");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            novoEmprestimo.revistaEmprestada = repositorioRevista.BuscaRevista(idRevista);
            Console.WriteLine("Data do emprestimo: ");
            novoEmprestimo.dataDoEmpresimo = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Data da Devolução: ");
            novoEmprestimo.dataDeDevolução = Convert.ToDateTime(Console.ReadLine());

            if (VerificaObjetosValidos(novoEmprestimo.amigoQueEmprestou) == true || VerificaObjetosValidos(novoEmprestimo.amigoQueEmprestou) == true)
            {
                return novoEmprestimo;
            }
            else
            {
                return null;
            }
        }
    }
}
