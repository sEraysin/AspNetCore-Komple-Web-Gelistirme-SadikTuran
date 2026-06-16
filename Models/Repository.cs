namespace AspNetCoreDersleri1.Models
{
    public class Repository
    {
        private static readonly List<Course> _courses = new List<Course>();

        static Repository()
        {
            _courses = new List<Course>()
            {
                new Course() {
                Id = 1,
                Title = "ASP.NET Core MVC Kursu",
                Description = "Controller, model ve view yapısını kullanarak dinamik web uygulamaları geliştirmeyi öğrenin.",
                Image = "3.jpg",
                Tags=new string[]{"aspnet core","mvc","web gelistirme"},
                isActive=true,
                isHome=true
            },
                 new Course()
                 {
                     Id = 2,
                     Title = "PHP Web Geliştirme Kursu",
                     Description = "PHP ile temel web sayfaları, formlar ve veritabanı işlemleri üzerine pratik yapın.",
                     Image = "5.jpg",
                     Tags=new string[]{"php","backend","web gelistirme"},
                     isActive=true,
                     isHome=true
                     
                 },
                  new Course()
                  {
                      Id = 3,
                      Title = "Django Kursu",
                      Description = "Python ve Django ile düzenli, yönetilebilir ve hızlı web projeleri oluşturun.",
                      Image = "3.jpg",
                       Tags=new string[]{"python","django","web gelistirme"},
                     isActive=true,
                     isHome=true
                  },
                   new Course()
                  {
                      Id = 4,
                      Title = "JavaScript Kursu",
                      Description = "Modern JavaScript ile etkileşimli arayüzler ve temel frontend mantığını geliştirin.",
                      Image = "4.jpg",
                      Tags=new string[]{"javascript","frontend","web gelistirme"},
                      
                     isActive=true,
                     isHome=true
                  },
                   new Course()
                  {
                      Id = 5,
                      Title = "HTML CSS Kursu",
                      Description = "Sayfa iskeleti, stillendirme ve responsive tasarım konularını adım adım pekiştirin.",
                      Image = "5.jpg",
                      Tags=new string[]{"html","css","responsive"},
                     isActive=true,
                     isHome=true
                  }
        };
            }
        public static List<Course> Courses
        {
            get { return _courses; }
        }

        public static Course? GetById(int? id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }
    }
}
