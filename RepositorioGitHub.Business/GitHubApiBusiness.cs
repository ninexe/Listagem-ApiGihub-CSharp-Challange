using RepositorioGitHub.Business.Contract;
using RepositorioGitHub.Dominio;
using RepositorioGitHub.Dominio.Interfaces;
using RepositorioGitHub.Infra.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace RepositorioGitHub.Business
{
    public class GitHubApiBusiness: IGitHubApiBusiness
    {
        public GitHubApiBusiness() { 
        
        }
        private readonly IContextRepository _context;
        private readonly IGitHubApi _gitHubApi;
        public GitHubApiBusiness(IContextRepository context, IGitHubApi gitHubApi)
        {
            _context = context;
            _gitHubApi = gitHubApi;
        }

        [HttpGet]
        public ActionResult<GitHubRepositoryViewModel> Get()
        {
            return new ActionResult<GitHubRepositoryViewModel>(); 
        }

        public ActionResult<GitHubRepositoryViewModel> GetById(long id)
        {
            return new ActionResult<GitHubRepositoryViewModel>();
        }


        public ActionResult<RepositoryViewModel> GetByName(string name)
        {
            return new ActionResult<RepositoryViewModel>();
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
