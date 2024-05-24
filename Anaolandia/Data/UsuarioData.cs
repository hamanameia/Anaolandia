using Anaolandia.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anaolandia.Data
{
    public class UsuarioData
    {
        private SQLiteAsyncConnection _ConexaoDB;

        public UsuarioData(SQLiteAsyncConnection conexaoDB)
        {
            _ConexaoDB = conexaoDB;
        }

        public Task<List<Usuario>> GetUsuariosAsync()
        {
            var lista = _ConexaoDB.Table<Usuario>().ToListAsync();
            return lista;
        }

        public Task<Usuario> ObtemUsuario(string nome, string senha)
        {
            var usuario = _ConexaoDB.Table<Usuario>().Where(u => u.Nome == nome && u.Senha == senha).FirstOrDefaultAsync();
            return usuario;
        }

        public Task<Usuario> ObtemIdUsuario(Guid Id)
        {
            var usuario = _ConexaoDB.Table<Usuario>().Where(u => u.Id == Id).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<int> SalvarUsuario(Usuario usuario)
        {
            var novoUsuario = await ObtemIdUsuario(usuario.Id);
            if (novoUsuario == null)
            {
                return await _ConexaoDB.InsertAsync(usuario);
            }
            else
            {
                return await _ConexaoDB.UpdateAsync(usuario);
            }
        }

        public async Task<int> DeletarUsuario(Usuario usuario)
        {
            return await _ConexaoDB.DeleteAsync(usuario);
        }
    }
}
