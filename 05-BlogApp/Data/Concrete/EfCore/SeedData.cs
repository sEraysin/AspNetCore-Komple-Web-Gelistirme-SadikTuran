using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context == null) return;

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            var tagWeb = new Tag { Text = "web programlama", Url = "web-programlama", Color = TagColors.warning };
            var tagBackend = new Tag { Text = "backend programlama", Url = "backend", Color = TagColors.success };
            var tagFrontend = new Tag { Text = "frontend", Url = "frontend", Color = TagColors.secondary };
            var tagFullstack = new Tag { Text = "fullstack", Url = "fullstack", Color = TagColors.primary };
            var tagPhp = new Tag { Text = "php", Url = "php", Color = TagColors.secondary };

            if (!context.Tags.Any())
            {
                context.Tags.AddRange(tagWeb, tagBackend, tagFrontend, tagFullstack, tagPhp);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { UserName = "sadikturan", Name = "Sadık Turan", Email = "info@sadikturan.com", Password = "123456", Image = "p1.jpg" },
                    new User { UserName = "cinarturan", Name = "Cınar Turan", Email = "info@cinarkturan.com", Password = "123456", Image = "p2.jpg" }

                );
                context.SaveChanges();
            }

            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post
                    {
                        Title = "asp net core",
                        Description= "asp net core dersleri",
                        Content = "asp net core dersleri",
                        Url = "aspnet-core",
                        IsActive = true,
                        Publishedon = DateTime.Now.AddDays(-10),
                        Tags = new List<Tag> { tagWeb, tagBackend, tagFrontend },
                        Image = "1.jpg",
                        UserId = 1,
                        Comments=new List<Comment>
                        {
                            new Comment{Tesxt="iyi bir kurs",PublishedOn=new DateTime(),UserId=1},
                            new Comment{Tesxt="cok faylandıgım bir kurs",PublishedOn=new DateTime(),UserId=2},
                        },
                    },
                    new Post
                    {
                        Title = "PHP core",
                        Description= "PHP dersleri",
                        Content = "PHP core dersler",
                        Url = "php",
                        IsActive = true,
                        Publishedon = DateTime.Now.AddDays(-20),
                        Tags = new List<Tag> { tagPhp, tagBackend },
                        Image = "2.jpg",
                        UserId = 1
                    },
                    new Post
                    {
                        Title = "Django",
                        Content = "Django dersleri",
                        Description = "Django dersleri",
                        Url = "django",
                        IsActive = true,
                        Publishedon = DateTime.Now.AddDays(-30),
                        Tags = new List<Tag> { tagBackend },
                        Image = "3.jpg",
                        UserId = 2
                    },
                    new Post
                    {
                        Title = "React Dersleri",
                        Content = "React dersleri",
                        Url = "react-dersleri",
                        IsActive = true,
                        Publishedon = DateTime.Now.AddDays(-40),
                        Tags = new List<Tag> { tagFrontend },
                        Image = "3.jpg",
                        UserId = 2
                    },
                    new Post
                    {
                        Title = "Angular",
                        Description="Angular dersleri",
                        Content = "Angular dersleri",
                        Url = "angular",
                        IsActive = true,
                        Publishedon = DateTime.Now.AddDays(-50),
                        Tags = new List<Tag> { tagFrontend },
                        Image = "3.jpg",
                        UserId = 2
                    },
                    new Post
                    {
                        Title = "Web Tasarım",
                        Description = "Web Tasarım dersleri",
                        Content = "Web Tasarım dersleri",
                        Url = "web-tasarim",
                        IsActive = true,
                        Publishedon = DateTime.Now.AddDays(-60),
                        Tags = new List<Tag> { tagWeb, tagFrontend },
                        Image = "3.jpg",
                        UserId = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}