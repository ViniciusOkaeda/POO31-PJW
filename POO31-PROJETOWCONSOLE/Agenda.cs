using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO31_PROJETOWCONSOLE
{
    public class Agenda : IAgenda
    {
        List<Contato> contatinhos = new List<Contato>();
        private const string PATH = "Database/agenda.csv";
        
        public Agenda(){
            string pasta = PATH.Split('/')[0];
            
            //verifica se existe o diretório pasta, se nao existir ele cria o mesmo
            if(!Directory.Exists(pasta)){
            Directory.CreateDirectory(pasta);
            }
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }



        public List<Contato> Listar()
        {
            // Lemos o arquivo e transformamos em um array de linhas

            string[] linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas){
                
                // Separamos os dados de cada linha com Split

                string[] dado = linha.Split(";");

                // Criamos instâncias de produtos para serem colocados na lista
                Contato c = new Contato(dado[0] , dado[1]);

                contatinhos.Add(c);
            }

            // ordena o nome dos contatos por ordem alfabética
            contatinhos = contatinhos.OrderBy(y => y.Nome).ToList();
            return contatinhos; 
        }
        public void Cadastrar(Contato cont)
        {
            var linha = new string[] { PrepararLinha(cont) };
            File.AppendAllLines(PATH, linha);
        }


        public void Excluir(Contato cont)
        {
            List<string> linhas = new List<string>();

            LerCSV(linhas);

            // Removemos as linhas que tiverem o termo passado como argumento
            linhas.RemoveAll(l => l.Contains(cont.Nome));

            // Reescrevemos nosso csv do zero
            ReescreverCSV(linhas);
        }

        






        /// <summary>
        /// Refatoração para ler o csv.
        /// </summary>
        /// <param name="linhas">le o csv</param>
        private void LerCSV(List<string> linhas){
            // Utilizamos a bliblioteca StreamReader para ler nosso .csv
            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
        }
        
        private void ReescreverCSV(List<string> lines){
            // Reescrevemos nosso csv do zero
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in lines)
                {
                    output.Write(ln + "\n");
                }
            }   
        }
            private string Separar(string _coluna)
        {

            return _coluna.Split("=")[1];
        }
         private string PrepararLinha(Contato c)
        {
            return $"{c.Nome};{c.Telefone}";
        }

        
       
       
       
       
    }
}