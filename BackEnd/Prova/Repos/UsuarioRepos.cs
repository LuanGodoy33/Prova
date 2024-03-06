using Microsoft.EntityFrameworkCore;
using Prova.Data;
using Prova.Modelos;
using Prova.Repos.Interfaces;

namespace Prova.Repos
{
    public class UsuarioRepos : IUsuarioRepos

    {
        private readonly DataDbContext dBContex;
        public UsuarioRepos(DataDbContext _datadBContext)
        {
            dBContex = _datadBContext;
        }
        public async Task<UsuarioModelo> Adicionar(UsuarioModelo usuario)
        {
            await dBContex.Usuarios.AddAsync(usuario);
            await dBContex.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModelo> Alterar(UsuarioModelo usuario, int id)
        {
            UsuarioModelo usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"{id} Não foi encontrado");
            }

            usuarioPorId.Nome = usuario.Nome;

            dBContex.Usuarios.Update(usuarioPorId);
            await dBContex.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<UsuarioModelo> BuscarPorId(int id)
        {
            UsuarioModelo usuarioPorId = await dBContex.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

            if (usuarioPorId == null)
            {
                throw new Exception($"{id} Não foi encontrado");
            }

            return usuarioPorId;
        }

        public async Task<List<UsuarioModelo>> BuscarTodosUsuarios()
        {
            return await dBContex.Usuarios.ToListAsync();
        }

        public async Task<bool> Deletar(int id)
        {
            UsuarioModelo usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"{id} Não foi encontrado");
            }

            dBContex.Usuarios.Remove(usuarioPorId);
            await dBContex.SaveChangesAsync();

            return true;
        }

    }
}
