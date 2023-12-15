using CadastroDePessoasApi.ViewModel;
using Dapper;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace CadastroDePessoasApi.Data

{
    public class Repository
    {
        string conexao = @"Data Source=(localdb)\mssqllocaldb;Database=CadastroPessoas;Trusted_Connection=True;MultipleActiveResultSets=True";
        private object ex;

        public IEnumerable<PessoaViewModel> GetAll() 
        {
            string query = "SELECT TOP 1000 * FROM PESSOA";
            using (SqlConnection con = new SqlConnection(conexao)) 
            {
                return con.Query<PessoaViewModel>(query);
            }
        }
        public PessoaViewModel GetById(int pessoaId)
        {
            string query = "SELECT * from pessoa WHERE pessoaId = @pessoaId ";
            using(SqlConnection con = new SqlConnection(conexao))
            {
                return con.Query<PessoaViewModel>(query, new { pessoaId = pessoaId}).FirstOrDefault();
            }  
        }
        public IEnumerable<PessoaViewModel> GetByprimeiroNome(string primeiroNome)
        {
            string query = "SELECT * FROM PESSOAS WHERE primeiroNome= @primeiroNome";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.Query<PessoaViewModel>(query, new { primeiroNome = primeiroNome });
            }
        }
        public void update(int pessoaId, string primeiroNome) //para atualizar o nome no banco de dados usando o id 
        {
            string query = "  UPDATE PESSOAS SET primeiroNome =@primeiroNome WHERE  pessoaId= @pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                con.Execute(query, new { primeiroNome = primeiroNome, pessoaId = pessoaId });//vai atualizar mas não vai retornar 
            }

        }
        public object GetEx()
        {
            return ex;
        }

        public string Create(PessoaViewModel pessoa, object ex)
        {
           
                string query = "INSERT INTO PESSOAS(primeiroNome, nomeMeio, ultimoNome, CPF) VALUES(@primeiroNome, @nomeMeio, @ultimoNome, @CPF)";
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    _ = con.Execute(query, new
                    {
                        primeiroNome = pessoa.primeiroNome,
                        nomeMeio = pessoa.nomeMeio,
                        cpf = pessoa.CPF,
                        ultimoNome = pessoa.ultimoNome,
                    });
                }
                return null;
            

        }
    }
}
