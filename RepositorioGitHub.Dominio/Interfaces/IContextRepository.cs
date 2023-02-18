using RepositorioGitHub.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioGitHub.Infra.Contract
{
    public interface IContextRepository
    {
        bool Insert(Favorite favorite);
        List<Favorite> GetAll();
        bool ExistsByCheckAlready(Favorite favorite);

    }
}
