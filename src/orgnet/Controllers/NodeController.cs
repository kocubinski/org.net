using System.Linq;
using System.Web.Mvc;
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

        public ActionResult Content(int id)
        {
            var node = dbContext.Tasks.Find(id);
            var content = (node == null || node.Content == null)
                              ? new Content()
                              : node.Content;
            return PartialView(content);
        }
    }
}
