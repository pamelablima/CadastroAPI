namespace CadastroDePessoasApi.ViewModel
{
    public class PessoaViewModel
    {
        public int pessoaId { get; set; }    
        public string primeiroNome {  get; set; }
        public object PrimeiroNome { get; internal set; }
        public string nomeMeio { get; set; }
        public string ultimoNome { get; set; }
        public string CPF { get; set;}
    }
}
