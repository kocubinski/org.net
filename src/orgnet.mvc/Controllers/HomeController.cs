using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using orgnet.mvc.Models;

namespace orgnet.mvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private readonly OrgContext dbContext = new OrgContext();

        public ActionResult Index()
        {
            var topNodes = dbContext.Nodes.Where(n => n.Parent == null);
            return View(topNodes);
        }
    }
}
