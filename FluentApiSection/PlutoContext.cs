using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FluentApiSection.EntityConfigurations;

namespace FluentApiSection
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>()
            //    .Property(c => c.Name)
            //    .IsRequired()
            //    .HasMaxLength(255);

            //modelBuilder.Entity<Course>()
            //    .Property(c => c.Description)
            //    .IsRequired()
            //    .HasMaxLength(2000);

            //modelBuilder.Entity<Course>()
            //    .HasRequired(c => c.Author)
            //    .WithMany(a => a.Courses)
            //    .HasForeignKey(c => c.AuthorId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Tags)
            //    .WithMany(t => t.Courses)
            //    .Map(m => {
            //        m.ToTable("CourseTags");
            //        m.MapLeftKey("CourseId");
            //        m.MapRightKey("TagId");
            //    });

            //modelBuilder.Entity<Course>()
            //    .HasRequired(c => c.Cover)
            //    .WithRequiredPrincipal(c => c.Course);


            //base.OnModelCreating(modelBuilder);


            // now that we moved everything to the separate file...
            modelBuilder.Configurations.Add(new CourseConfiguration());
        }
    }
}
