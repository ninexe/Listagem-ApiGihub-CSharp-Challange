using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioGitHub.Dominio.Interfaces
{
    public interface IGitHubApi
    {
        ActionResult<GitHubRepository> GetRepository(string owner);
        ActionResult<RepositoryModel> GetRepositoryByName(string name);     
    }
}
