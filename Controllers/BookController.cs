using boo.Models;
using boo.Stabil;
using System.Data.Entity.Validation;
using System.Web.Mvc;

namespace boo.Controllers
{
    public class BookController : Controller
    {


        private readonly IBit _bit;
        

        public BookController(IBit bit)
        {
            _bit = bit;
        }

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Genres()
        {
            var list=_bit.Books.Genres();

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult List()
        {
            var list = _bit.Books.List();//_context.Books.Include("Genre").ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetbookId(int id)
        {
            var book = _bit.Books.GetbookId(id);

            return Json(book, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Add(Book book)
        {

            var genre = _bit.Books.GenreType(book);

            book.Genre = genre;

            if (book.Id == 0)
            {
                try
                {
                    _bit.Books.AddContext(book);
                    _bit.Complete();
                    var jsonA = new { message = "Added!" };
                    return Json(jsonA, JsonRequestBehavior.AllowGet);
                }
                catch(DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                       
                    }
                    throw;
                }
            }
            book.GenreId = genre.Id;

            _bit.Books.ModifyContext(book);
            _bit.Complete();
           
            return Json(new { message = "Updated!" }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(int id)
        {
            var book = _bit.Books.Delete(id);
            _bit.Books.RemoveContext(book);
            _bit.Complete();
        
            return Json(new { message = "Delte!"}, JsonRequestBehavior.AllowGet);
        }


       
    }
}