using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FluentApiSection
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            // SQL will fire here
            var course = context.Courses.Single(c => c.Id == 2);

            // will fire here again to load the tags... because in the 'course' class, it identifies the tags as 'virtual':   public virtual ICollection<Tag> Tags { get; set; }
            // This is called 'lazy loading'
            foreach (var tag in course.Tags)
                Console.WriteLine(tag.Name);

            // AVOID LAZY LOADING IN WEB APPLICATIONS
            // better for desktop apps...
            // just don't declare navigation properties as 'virtual'
            // instead use a configuration setting in PlutoContext: this.Configuration.LazyLoadingEnabled = false;



            // To fix this, use eager loading
            // will join the courses table and the author table - BAD CODING PRACTICES
            //var courses = context.Courses.Include("Author").ToList();
            // Better practice
            var courses = context.Courses.Include(c => c.Author).ToList();

            // Another option = eager loading (don't use weird MSDN way with collections and stuff - do it this way:)
            var author = context.Authors.Single(a => a.Id == 1);
            context.Courses.Where(c => c.AuthorId == author.Id).Load();


        }
    }
}
