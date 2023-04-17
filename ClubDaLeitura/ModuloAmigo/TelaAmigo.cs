using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubDaLeitura.Heritage;

namespace ClubDaLeitura.ModuloAmigo
{
    public class TelaAmigo : Tela
    {
        public RepositorioAmigo repositorioAmigo = null;
        public void MenuAmigo(string opcao)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("----Menu Amigo----\n");
                Console.WriteLine("1- Adicionar | 2- Todos os Amigos | 3- Atualizar Amigo | 4- Deleta amigo | S- Sair");
                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    Console.Clear();
                    AdicionaAmigo();
                }
                if (opcao == "2")
                {
                    Console.Clear();
                    MostraTodosOsAmigos();
                    Console.ReadKey();
                }
                if (opcao == "3")
                {
                    Console.Clear();
                    MostraTodosOsAmigos();
                    AtualizaAmigo();
                }
                if (opcao == "4")
                {
                    Console.Clear();
                    MostraTodosOsAmigos();
                    DeletaAmigo();
                }

            } while (opcao.ToUpper() != "S");

        }
        private void AdicionaAmigo()
        {
            Amigo novoAmigo = PegaDadosDoAmigo();
            repositorioAmigo.InseriraAmigo(novoAmigo);
        }
        public void MostraTodosOsAmigos()
        {
            Console.Clear();
            Console.WriteLine("Amigos: ");
            Console.WriteLine("____________________________________________________________________________");
            if (repositorioAmigo.RetornarTodosOsAmigos().Count == 0)
            {
                ApresentaMensagem("Nenhum Amigo Registradado", ConsoleColor.DarkYellow);
            }
            else
            {
                foreach (Amigo a in repositorioAmigo.RetornarTodosOsAmigos())
                {
                    Console.WriteLine($"id: {a.id} | Nome: {a.nome} | Nome do Responsavel: {a.nomeDoResponsavel} | Telefone: {a.telefone} | Rua: {a.endereco.rua} | Bairro: {a.endereco.bairro} | Cidade: {a.endereco.cidade}");
                }
            }
        }
        private void AtualizaAmigo()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Id para Editar: ");
            int idParaEditar = Convert.ToInt32(Console.ReadLine());
            Amigo amigo = PegaDadosDoAmigo();
            repositorioAmigo.AtualizarAmigos(idParaEditar, amigo);
        }
        private void DeletaAmigo()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Id para Deletar: ");
            int idParaDeletar = Convert.ToInt32(Console.ReadLine());
            repositorioAmigo.DeletarAmigos(idParaDeletar);
        }
        private Amigo PegaDadosDoAmigo()
        {
            Console.Clear();
            Amigo novoAmigo = new Amigo();
            Console.WriteLine("Nome do Amigo: ");
            novoAmigo.nome = Console.ReadLine();
            Console.WriteLine("Nome do Responsavel: ");
            novoAmigo.nomeDoResponsavel = Console.ReadLine();
            Console.WriteLine("Numero de Telefone: ");
            novoAmigo.telefone = Console.ReadLine();
            novoAmigo.endereco = new Endereco();
            Console.WriteLine("Rua: ");
            novoAmigo.endereco.rua = Console.ReadLine();
            Console.WriteLine("Bairro: ");
            novoAmigo.endereco.bairro = Console.ReadLine();
            Console.WriteLine("Cidade: ");
            novoAmigo.endereco.cidade = Console.ReadLine();
            Console.WriteLine("Numero da Casa: ");
            novoAmigo.endereco.numeroDaCasa = Convert.ToInt32(Console.ReadLine());
            return novoAmigo;
        }
    }
}
