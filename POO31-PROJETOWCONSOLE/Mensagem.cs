namespace POO31_PROJETOWCONSOLE
{
    public class Mensagem
    {
        public string Texto {get; set;}

        public void Destinatario (Contato _contato){
            
            System.Console.WriteLine(Texto);
        }
    }
}