using RepositorioGitHub.Dominio;
using RepositorioGitHub.Infra.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioGitHub.Infra.Repositorio
{
    public class ContextRepository : IContextRepository
    {
        public bool ExistsByCheckAlready(Favorite favorite)
        {
            return false;
        }

        public List<Favorite> GetAll()
        {
            return new List<Favorite>();
        }

        public bool Insert(Favorite favorite)
        {
            return true;
        }
    }
}
