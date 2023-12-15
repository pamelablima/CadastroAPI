document.addEventListener('DOMContentLoaded', function() {

    const pessoaLista = document.getElementById('pessoa-Lista');

    function renderTable(date){
        pessoaLista.innerHTML = '';

        data.array.forEach(pessoa => {
            const row = document.createElement('tr');
            row.innerHTML = `
            
                <td>${pessoa.pessoaId}</td>
                <td>${pessoa.primeiroNome}</td>
                <td>${pessoa.nomeMeio}</td>
                <td>${pessoa.ultimoNome}</td>
                <td>${pessoa.CPF}</td>
                <td>
                    <button>Editar</button>
                    <button>Excluir</button>
                </td>
            `;
            pessoaLista.appendChild(row);
        })

    }

    function feachPessoas(){
        fetch('http://localhost:5006/api/Pessoa/GetAll')
        .then(response => response.json())
        .then(data => renderTable(data))
        .catch(error => console.error('Erro ao buscar dados da Api'))

    }    
    feachPessoas();
})