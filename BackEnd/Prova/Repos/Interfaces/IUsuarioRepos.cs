using Prova.Modelos;

namespace Prova.Repos.Interfaces
{
    public interface IUsuarioRepos
    {
        Task<UsuarioModelo> Adicionar(UsuarioModelo usuario);
        Task<UsuarioModelo> Alterar(UsuarioModelo usuario, int id);
        Task<UsuarioModelo> BuscarPorId(int id);
        Task<List<UsuarioModelo>> BuscarTodosUsuarios();
        Task<bool> Deletar(int id);
    }
}
