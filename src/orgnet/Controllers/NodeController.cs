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
            var topNodes = dbContext.Nodes.Where(n => n.Parent == null);
            return View(topNodes);            
        }

        //
        // GET: /Node/Tree/3

        public ActionResult Tree(int id)
        {
            var node = dbContext.Nodes.Find(id);
            return View(node);
        }
    }
}
