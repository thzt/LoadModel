using System;
using System.Web.Mvc;

using LoadModel.Tools;
using LoadModel.Models;

namespace LoadModel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InitPage(int index)
        {
            ModelManager modelManager = new ModelManager(Server);

            string viewName = modelManager.GetViewName(index);
            string modelName = modelManager.GetModelName(index);

            object model = modelManager.CreateModel(modelName);
            ((ILoadModelInterface)model).Init(index);

            ViewBag.ModelType = modelName;
            return PartialView(viewName, model);
        }

        [HttpPost]
        public JsonResult Save(string type, string json)
        {
            try
            {
                object model = JsonOperation.Deserialize(type, json);
                ((ILoadModelInterface)model).Save();

                return Json(new
                {
                    status = true,
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    content = ex.Message
                });
            }
        }
    }
}