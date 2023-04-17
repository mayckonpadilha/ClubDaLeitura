using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubDaLeitura.Heritage;
using ClubDaLeitura.ModuloCaixa;


namespace ClubDaLeitura.ModuloRevista
{
    public class TelaRevista : Tela
    {
        public RespositorioRevista repositorioDeRevista = null;
        public RepositorioCaixa repositorioDeCaixas = null;
        public TelaCaixa telaCaixa = null;

        public void MenuRevista(string opcao)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("----Menu Revista----\n");
                Console.WriteLine("1- Adicionar | 2- Todos os Revista | 3- Atualizar Revista | 4- Deleta Revista | S- Sair");
                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    Console.Clear();
                    AdicionaRevista();
                }
                if (opcao == "2")
                {
                    Console.Clear();
                    MostraTodosAsRevistas();
                    Console.ReadKey();
                }
                if (opcao == "3")
                {
                    Console.Clear();
                    MostraTodosAsRevistas();
                    AtualizaRevista();
                }
                if (opcao == "4")
                {
                    Console.Clear();
                    MostraTodosAsRevistas();
                    DeletaRevista();
                }

            } while (opcao.ToUpper() != "S");

        }

        private void AdicionaRevista()
        {
            Revista revista = PegaDadosDaRevista();
            if (revista == null)
            {
                ApresentaMensagem("Erro Revista deve possuir uma caixa!", ConsoleColor.DarkRed);
            }
            else
            {
                repositorioDeRevista.InseriraRevista(revista);
                ApresentaMensagem("Adicionada com Sucesso!", ConsoleColor.Green);
            }

        }
        public void MostraTodosAsRevistas()
        {
            Console.WriteLine("Revistas: ");
            Console.WriteLine("____________________________________________________________________________");
            if (repositorioDeRevista.RetornarTodosAsRevistas().Count == 0)
            {
                ApresentaMensagem("Nenhuma Revista Registradada", ConsoleColor.DarkYellow);
            }
            else
            {
                foreach (Revista a in repositorioDeRevista.RetornarTodosAsRevistas())
                {
                    Console.WriteLine($"id: {a.id} | Edição: {a.edicao} | Coleção : {a.colecao} | Ano da Revista: {a.anoDaRevista.ToString("dd/MM/yyyy")} | Etique da Caixa :{a.caixa.etiqueta}");
                }
            }
        }
        private void AtualizaRevista()
        {
            Console.WriteLine("Id para Editar: ");
            int idParaEditar = Convert.ToInt32(Console.ReadLine());
            Revista revista = PegaDadosDaRevista();
            repositorioDeRevista.AtualizarRevistas(idParaEditar, revista);
        }
        private void DeletaRevista()
        {
            Console.WriteLine("Id para Deletar: ");
            int idParaDeletar = Convert.ToInt32(Console.ReadLine());
            repositorioDeRevista.DeletaRevista(idParaDeletar);
        }
        private Revista PegaDadosDaRevista()
        {
            Revista novaRevista = new Revista();
            novaRevista.estaEmprestada = false;
            Console.WriteLine("Colecao : ");
            novaRevista.colecao = Console.ReadLine();
            Console.WriteLine("Edicao : ");
            novaRevista.edicao = Console.ReadLine();
            Console.WriteLine("Ano da Revista");
            novaRevista.anoDaRevista = Convert.ToDateTime(Console.ReadLine());
            Console.Clear();
            telaCaixa.MostraTodasAsCaixas();
            Console.WriteLine("____________________________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("id da Caixa que deseja a Colocar a Revista");
            int id = Convert.ToInt32(Console.ReadLine());
            novaRevista.caixa = repositorioDeCaixas.BuscaCaixas(id);
            if (VerificaObjetosValidos(novaRevista.caixa) == true)
            {
                return novaRevista;
            }
            else
            {
                return null;
            }
        }
    }
}
