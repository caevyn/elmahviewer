using System.Web;
using System.Web.Mvc;
using ElmahViewer.Models;
using ElmahViewer;

namespace ElmahViewer.Controllers
{
    public class ElmahViewerController : Controller
    {
        private readonly IErrorDetailsViewModelFactory _detailsModelFactory;
        private readonly IErrorListViewModelFactory _listModelFactory;

        public ElmahViewerController(IErrorDetailsViewModelFactory detailsModelFactory, IErrorListViewModelFactory listModelFactory)
        {
            _detailsModelFactory = detailsModelFactory;
            _listModelFactory = listModelFactory;
        }

        public ActionResult Index(string applicationId, string errorId, int index = 0, int size = 15)
        {
            if (!string.IsNullOrEmpty(applicationId))
            {
                //shonky url encoding for forward slash in url parameter. For default elmah names e.g. /LM/W3SVC/... etc
                applicationId = Url.ForwardSlashDecode(applicationId);
            }
            if (!string.IsNullOrEmpty(errorId))
            {
                var details = _detailsModelFactory.Create(applicationId, errorId);
                return View("Details", details);
            }
            var model = _listModelFactory.Create(applicationId, index, size);
            return View(model);
        }
    }
}
