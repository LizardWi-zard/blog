using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class ArticleDbInitializer : DropCreateDatabaseAlways<ArticleContext>
    {
        protected override void Seed(ArticleContext db)
        {
            db.Articles.Add(new Article { Name = "Про прошлое", 
                                          Content = " Начало моего пути в программирование...",
                                          MainContent = "Около двух лет назад я познакомился с Unity. " +
                                          "Тогда я понял, что всё чем я хочу  заниматься - это программирование",
                                         /* Date = DateTime.Now */ });
            db.Articles.Add(new Article { Name = "Про настоящее",
                                          Content = "Сейчас я стал изучать ASP.NET и пишу свой блог...",
                                          MainContent = "В данный момент мне предложили написать собственный блог. " +
                                          "Встречается много нового материала, а с ними появляются новые проблемы",
                                           /* Date = DateTime.Now */  });
            db.Articles.Add(new Article { Name = "Про будущее",
                                          Content = "В моих планах найти работу и зарекомендовать себя",
                                          MainContent = "<p>Hello&nbsp;<font color=\"#000000\" style=\"background-color: rgb(255, 255, 0);\"><span style=\"font-size: 1rem;\">Hello&nbsp;</span><span style=\"font-size: 1rem;\">Hello&nbsp;</span></font><span style=\"font-size: 1rem;\"><font color=\"#000000\" style=\"background-color: rgb(255, 255, 0);\">Hello</font>&nbsp;</span><span style=\"font-size: 1rem;\">Hello&nbsp;</span></p>",
                                          /* Date = DateTime.Now */
                                         });

            base.Seed(db);
        }
    }
}
