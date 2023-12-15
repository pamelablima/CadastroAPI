using CadastroDePessoasApi.Data;
using CadastroDePessoasApi.ViewModel;

namespace CadastroDePessoasApi.Service
{
    public class ServicePessoa
    {
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var repository = new Repository();// chamando os metados dentro da classe Repository
            return repository.GetAll().ToList();// Retorna nosso repository 
        }
        public PessoaViewModel GetById(int pessoaId)
        {
            var repository = new Repository();
            return repository.GetById(pessoaId);

        }
        public IEnumerable<PessoaViewModel> GetByprimeiroNome(string primeiroNome)
        {
            var repository = new Repository();
            return repository.GetByprimeiroNome(primeiroNome);
        }
        public void update(int pessoaId, string primeiroNome)
        {
            if (pessoaId > 0 && !string.IsNullOrEmpty(primeiroNome))// Regra para o id ser maior que zero, e o primeiro nome vazio 
            {
                var repository = new Repository();
                repository.update(pessoaId, primeiroNome);//Não tem retorno pois ele não retorna nada
            }
        }
        public string Create(PessoaViewModel pessoa)
        {
            if (pessoa == null)
                return "Os dados são obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.nomeMeio))
                return "O campo nomeMeio é obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.ultimoNome))
                return "O campo ultimoNome é obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.CPF))
                return "O campo CPF é obrigatorio";

            var repository = new Repository();
            return repository.Create(pessoa, repository.GetEx());


        }

        internal void Update(int pessoaId, string primeiroNome)
        {
            throw new NotImplementedException();
        }
    }
}
