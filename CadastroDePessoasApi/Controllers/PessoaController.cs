using CadastroDePessoasApi.Service;
using CadastroDePessoasApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDePessoasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase


    {
        [HttpGet("GetAll")]
        public IEnumerable<PessoaViewModel> GetALL()
        {
            var service = new ServicePessoa();
            return service.GetAll();
        }
        [HttpGet("GetById/{pessoaId}")]
        public PessoaViewModel GetById(int pessoaId)
        {
            var service = new ServicePessoa();
            return service.GetById(pessoaId);
        }
        [HttpGet("GetByprimeiroNome")]// para pegar apenas um dados especificos no caso o nome 

        public IEnumerable<PessoaViewModel> GetByprimeiroNome(string primeiroNome)
        {
            var service = new ServicePessoa();
            return service.GetByprimeiroNome(primeiroNome);
        }

        [HttpPut("update/{pessoasId}/{primeiroNome}")] // Para atualizar o nome 
        public void Update(int pessoaId, string primeiroNome)
        {
            var service = new ServicePessoa();
            service.Update(pessoaId, primeiroNome); // Não tem retorno 
        }

        [HttpPost("Create")] // Dar a opção de criar um cadastro novo 

        public IActionResult Create(PessoaViewModel pessoa)
        {
            var service = new ServicePessoa();
            var resultado = service.Create(pessoa);

            var result = new
            {
                Succes = true,
                Data = "Cadastro Feito",

            };
            return Ok (result);
        }
    }
}
