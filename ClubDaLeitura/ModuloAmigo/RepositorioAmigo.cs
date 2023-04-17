using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubDaLeitura.Heritage;

namespace ClubDaLeitura.ModuloAmigo
{
    public class RepositorioAmigo : Repositorio
    {
        public void InseriraAmigo(Amigo amigo)
        {
            amigo.id = id;
            listaEntidades.Add(amigo);
            IncrementaId();
        }
        public List<Object> RetornarTodosOsAmigos()
        {
            return listaEntidades;
        }
        public void AtualizarAmigos(int id, Amigo amigo)
        {
            foreach (Amigo a in listaEntidades)
            {
                if (BuscaAmigos(id).Equals(a))
                {
                    a.nome = amigo.nome;
                    a.nomeDoResponsavel = amigo.nomeDoResponsavel;
                    a.telefone = amigo.telefone;
                    a.endereco = amigo.endereco;

                }
            }
        }
        public Amigo BuscaAmigos(int id)
        {
            Amigo amigo = null;
            foreach (Amigo a in listaEntidades)
            {
                if (a.id == id)
                {
                    amigo = a;
                    return amigo;
                }
            }
            return amigo;
        }
        public void DeletarAmigos(int id)
        {
            foreach (Amigo a in listaEntidades)
            {
                if (BuscaAmigos(id).Equals(a))
                {
                    listaEntidades.Remove(a);
                    break;
                }
            }
        }
    }
}
