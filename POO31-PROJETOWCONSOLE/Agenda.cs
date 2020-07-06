using System.Collections.Generic;
using System.IO;

namespace POO31_PROJETOWCONSOLE
{
    public class Agenda : IAgenda
    {

        private const string PATH = "Database/agenda.csv";
        
        public Agenda(){
            string pasta = PATH.Split('/')[0];

            if(!Directory.Exists(pasta)){
            Directory.CreateDirectory(pasta);
            }
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public void Cadastrar(Contato cont)
        {
        }

        public List<Agenda> Listar()
        {
            List<Agenda> contatinhos = new List<Agenda>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach(string linha in linhas){
                string[] dado = linha.Split(";");

                Agenda c   = new Agenda();
                c.Telefone    = Int32.Parse( Separar(dado[0]) );
                c.Nome      = Separar(dado[1]);

                agenda.Add(c);
            }


        }

        public void Excluir(string _contato)
        {
        }

        void Cadastrar(Agenda c)
        {
            var linha = new string[] { PrepararLinha(c) };
            File.AppendAllLines(PATH, linha);
        }

        

            private string Separar(string _coluna)
        {

            return _coluna.Split("=")[1];
        }


         private string PrepararLinha(Contato c)
        {
            return $"nome={c.Nome};telefone={c.Telefone}";
        }

        
       
       
       
       
    }
}