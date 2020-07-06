namespace POO31_PROJETOWCONSOLE
{
    public class Contato : Mensagem
    {
        public string Nome {get; set;}

        public int Telefone {get; set;}    


        public Contato(){
            System.Console.WriteLine($"Nome:{Nome};Tel:{Telefone};");
            
        }
    }
}