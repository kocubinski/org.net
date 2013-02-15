using System.Web.Mvc;
using orgnet.mvc.Models;

namespace orgnet.mvc.Controllers
{
    public class NodeController : Controller
    {
        private readonly OrgContext dbContext = new OrgContext();

        //
        // GET: /Node/Tree/3

        public ActionResult Tree(int id)
        {
            var node = dbContext.Nodes.Find(id);
            return View(node);
        }
    }
}
