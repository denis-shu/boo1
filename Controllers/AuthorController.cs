using boo.Models;
using System.Web.Mvc;
using boo.Stabil;
using System.Data.Entity.Validation;

namespace boo.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        private readonly IBit _bit;

        public AuthorController(IBit bit)
        {
            _bit = bit;
        }


        public ActionResult Index()
        {

            return View();
        }


        public JsonResult List()
        {
            var list = _bit.Authors.List();

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetbyId(int id)
        {
            var author = _bit.Authors.GetbyId(id);

            return Json(author, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Add(Author author)
        {
            if (author == null)
                return HttpNotFound();

            if (author.Id == 0)
            {
                try
                {
                    _bit.Authors.AddContext(author);
                    _bit.Complete();

                    return Json(new { message = "Author saved" }, JsonRequestBehavior.AllowGet);
                }
                catch(DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {

                    }
                    throw;
                }
            }

            _bit.Authors.ModifyContext(author);
            _bit.Complete();

            return Json(new {message= "Author updated!" }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Delete(int id)
        {
            var author = _bit.Authors.AuthorToDelete(id);

            _bit.Authors.Remove(author);
            _bit.Complete();


            return Json(new {message="Author Deleted"}, JsonRequestBehavior.AllowGet);
        }



    }

}
