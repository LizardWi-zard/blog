using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using Blog.Models;


namespace Blog.Controllers
{
    public class HomeController : AccountController
    {
        ArticleContext db = new ArticleContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Article> articles = db.Articles;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Articles = articles;
            // возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult ReadArticle(int id)
        {
            IEnumerable<Article> articles = db.Articles;
            ViewBag.Articles = articles;
            ViewBag.ArticleId = id;

            return View();
        }

       [Authorize(Roles = "admin")]
        public ActionResult Admin()
        {
            IEnumerable<Article> articles = db.Articles;
            ViewBag.Articles = articles;
            return View();
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult EditArticle(int? id)
        {
            if (id == null)
            {
                return Index();
            }
            Article article = db.Articles.Find(id);
            if (article != null)
            {
                return View(article);
            }
            return Index();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]

        public ActionResult EditArticle(Article article)
        {
            db.Entry(article).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Admin");
        }

          [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateArticle()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateInput(false)]
        
        public ActionResult CreateArticle(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();

            return RedirectToAction("Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult DeleteArticle(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }

            IEnumerable<Article> articles = db.Articles;
            ViewBag.Articles = articles;
            ViewBag.ArticleId = id;
            
            return View(article);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("DeleteArticle")]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }

        /*
         public async Task<ActionResult> CreateArticle(Article givenArticle)
         {

             Article article = await db.Articles.FirstOrDefaultAsync(u => u.Name == givenArticle.Name && u.Content == givenArticle.Content && u.MainContent == givenArticle.MainContent);

             if (article.Name != null || article.Content != null || article.MainContent != null)
             {
                 db.Articles.Add(givenArticle);
                 db.SaveChanges();

                 return RedirectToAction("Admin");
             }
             else
             {
                 ModelState.AddModelError("", "Заполните пустое пространство.");
             }

             return View(givenArticle);
         }
         */
    }   
}