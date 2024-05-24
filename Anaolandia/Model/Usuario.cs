using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anaolandia.Model
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Cartao { get; set; }

        public Usuario()
        {
            Id = Guid.NewGuid();
        }
    }
}
