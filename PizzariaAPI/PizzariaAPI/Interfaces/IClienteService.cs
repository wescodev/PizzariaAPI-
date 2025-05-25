using PizzariaAPI.DTOS;

namespace PizzariaAPI.Interfaces
{
    public interface IClienteService
    {
        Task<string> CriarCadastroClienteAsync(ClienteCadastroDTO cadastro);
        Task<EnderecoDTO> ObterEnderecoFormatadoDoClienteAsync(int idCliente);
    }
}
