using System.Collections.Generic;

namespace POO31_PROJETOWCONSOLE
{
    public interface IAgenda
    {
         void Cadastrar (Contato cont);

         void Excluir(string _contato);

         List<Agenda> Listar();
    }
}