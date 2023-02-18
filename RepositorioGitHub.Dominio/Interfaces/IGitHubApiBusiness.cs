
using RepositorioGitHub.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioGitHub.Business.Contract
{
   public interface IGitHubApiBusiness
   {
        ActionResult<GitHubRepositoryViewModel> Get();
        ActionResult<RepositoryViewModel> GetByName(string name);
        ActionResult<GitHubRepositoryViewModel> GetById(long id);
        ActionResult<GitHubRepositoryViewModel> GetRepository(string owner, long id);
        ActionResult<FavoriteViewModel> GetFavoriteRepository();
        ActionResult<FavoriteViewModel> SaveFavoriteRepository(FavoriteViewModel view);
   }
}
