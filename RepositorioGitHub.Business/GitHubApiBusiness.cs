using RepositorioGitHub.Business.Contract;
using RepositorioGitHub.Dominio;
using RepositorioGitHub.Dominio.Interfaces;
using RepositorioGitHub.Infra.Contract;
using RepositorioGitHub.Infra.ApiGitHub;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Policy;
using System.Collections.Generic;

namespace RepositorioGitHub.Business
{
    public class GitHubApiBusiness: IGitHubApiBusiness
    {
        private readonly IContextRepository _context;
        private readonly IGitHubApi _gitHubApi;
        
        public GitHubApiBusiness(IContextRepository context, IGitHubApi gitHubApi)
        {
            _context = context;
            _gitHubApi = gitHubApi;
        }

       

        public RepositoryViewModel Get()
        {
            RepositoryViewModel repositoryViewModel = GitHubApi.GetApi().Result;
            return repositoryViewModel;
        }



        public GitHubRepository GetById(long id)
        {
            GitHubRepository repositories = new GitHubRepository();
            var _repositoryViewModel = this.Get();
            foreach (var item in _repositoryViewModel.Repositories)
            {
                if (item.Id == id)
                {
                    repositories = item;
                    break;
                }
            }
            return repositories;
        }
        [HttpGet]
        public RepositoryViewModel GetByName(string name)
        {
            RepositoryViewModel repositoryViewModel = new RepositoryViewModel();
            var _repositoryViewModel = this.Get();
            GitHubRepository[] repositories = new GitHubRepository[_repositoryViewModel.TotalCount];
            for(int i =0; i < _repositoryViewModel.TotalCount;)
            {
                foreach (var item in _repositoryViewModel.Repositories)
                {
                    if (item.Name.ToUpper().Contains(name.ToUpper()))
                    {
                        repositories[i] = item;
                    }
                    i++;
                }
            }

            List<GitHubRepository> listGitHubRepository = new List<GitHubRepository>(repositories);
            listGitHubRepository.RemoveAll(g => g == null);
            repositories = listGitHubRepository.ToArray();
            repositoryViewModel.Repositories = repositories;

            return repositoryViewModel;
        }

        public ActionResult<FavoriteViewModel> GetFavoriteRepository()
        {
            return new ActionResult<FavoriteViewModel>();
        }

        public ActionResult<GitHubRepositoryViewModel> GetRepository(string owner, long id)
        {
            return new ActionResult<GitHubRepositoryViewModel>();
        }

        public ActionResult<FavoriteViewModel> SaveFavoriteRepository(FavoriteViewModel view)
        {
            return new ActionResult<FavoriteViewModel>();
        }
    }
}
