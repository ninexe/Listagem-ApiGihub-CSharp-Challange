using Newtonsoft.Json;
using RepositorioGitHub.Business;
using RepositorioGitHub.Business.Contract;
using RepositorioGitHub.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace RepositorioGitHub.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGitHubApiBusiness _business;
        
        public HomeController(IGitHubApiBusiness business)
        {
            _business = business;
        }

        public ActionResult Index()
        {
            var model = _business.Get();
            return View(model);
        }

        public ActionResult Details(long id)
        {
            var model = _business.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult GetRepositorie(string name)
        {
            RepositoryViewModel model = new RepositoryViewModel();

            if (string.IsNullOrEmpty(name))
            {
                return View(model);
            }
            else
            {
                model = _business.GetByName(name);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult GetRepositorie()
        {
            RepositoryViewModel model = new RepositoryViewModel();
            return View(model);
        }

        public ActionResult DetailsRepository(long id)
        {
            var model = _business.GetById(id);
            return View(model);
        }

        public ActionResult Favorite()
        {

            ActionResult<FavoriteViewModel> model = new ActionResult<FavoriteViewModel>();

            var response = _business.GetFavoriteRepository();
           
            model = response;

            if (model.IsValid)
            {
                TempData["success"] = model.Message;
            }
            else
            {
                TempData["warning"] = model.Message;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult FavoriteSave(string owner, string name, string language, string lastUpdat, string description)
        {     
            ActionResult< FavoriteViewModel> model = new ActionResult<FavoriteViewModel>();

            if(string.IsNullOrEmpty(owner) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(language)
                && string.IsNullOrEmpty(lastUpdat)&& string.IsNullOrEmpty(description))
            {
                model.IsValid = false;
                model.Message = "Não foi possivel realizar esta operação";

                
                

                return Json(new
                {
                    Data = model
                }, JsonRequestBehavior.AllowGet);


            }
            else
            {
                
                FavoriteViewModel view = new FavoriteViewModel() 
                { 
                    Description = description,
                    Language = language,
                    Owner = owner,
                    UpdateLast =  DateTime.Parse(lastUpdat),
                    Name = name
                    
                };

              var response = _business.SaveFavoriteRepository(view);

                if (model.IsValid)
                {
                    TempData["success"] = model.Message;
                }
                else
                {
                    TempData["warning"] = model.Message;
                }

                return Json(new
                {
                    Data = response
                }, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}