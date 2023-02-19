using Newtonsoft.Json;
using RepositorioGitHub.Dominio;
using RepositorioGitHub.Dominio.Interfaces;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RepositorioGitHub.Infra.ApiGitHub
{
    public class GitHubApi : IGitHubApi
    {

        public ActionResult<GitHubRepository> GetRepository(string owner)
        {
            throw new NotImplementedException();
        }
                
        public ActionResult<RepositoryModel> GetRepositoryByName(string name)
        {
            throw new NotImplementedException();
        }

        public static async Task<RepositoryViewModel> GetApi()
        {
            using (HttpClient client = new HttpClient())
            {
                RepositoryViewModel repositoryViewModel = new RepositoryViewModel();
                client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
                var _response = client.GetAsync($"https://api.github.com/users/ninexe/repos").GetAwaiter().GetResult();

                if (_response.IsSuccessStatusCode)
                {
                    var json = await _response.Content.ReadAsStringAsync();
                    var repositories = JsonConvert.DeserializeObject<GitHubRepository[]>(json);
                    repositoryViewModel.TotalCount = repositories.Count();
                    repositoryViewModel.Repositories = new GitHubRepository[repositories.Count()];
                    for (int i = 0; i < repositories.Count();)
                    {
                        foreach (var item in repositories)
                        {
                            repositoryViewModel.Repositories[i] = item;
                            i++;
                        }
                    }
                    return repositoryViewModel;
                }
                return repositoryViewModel;
            }
        }
    }
}
