using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using orgnet.Models;

namespace orgnet.Controllers
{
    public class NodeController : Controller
    {
        private readonly OrgContext dbContext = new OrgContext();

        public ActionResult Index()
        {
            var topNodes = dbContext.Tasks.Where(n => n.Parent == null);
            return View(topNodes);            
        }

        //
        // GET: /Node/Tree/3

        public ActionResult Tree(int id, int? contentId)
        {
            var node = dbContext.Tasks.Find(id);
            if(contentId != null) 
                ViewBag.ContentId = contentId;
            return View(node);
        }

        public ActionResult ContentEdit(int id)
        {
            var node = dbContext.Contents.Find(id);
            return PartialView(node);
        }

        public ActionResult Contents(int id)
        {
            var task = dbContext.Tasks.Find(id);
            var content = task.Content;
            return PartialView(content);
        }

        public JsonResult GetTask(int id)
        {
            var task = dbContext.Tasks.Find(id);
            var res = new {
                id = task.Id,
                parent = task.Parent == null ? 0 : task.Parent.Id,
                content = task.Content == null ? 0 : task.Content.Id
            };
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}
