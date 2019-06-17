using Entitiy;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SightseeingContext : IdentityDbContext<ApplicationUser>
    {
        public SightseeingContext()
            : base("SightseeingContext", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ToDoList> ToDoLists { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ListActivity> ListActivities { get; set; }
        public virtual DbSet<ActivityExtension> ActivityExtensions { get; set; }

        public static SightseeingContext Create()
        {
            return new SightseeingContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region TableOpts

            modelBuilder.Entity<Activity>()
                .HasKey(x => x.ActivityId);

            modelBuilder.Entity<ToDoList>()
                .HasKey(x => x.ToDoListId);

            modelBuilder.Entity<Category>()
                .HasKey(x => x.CategoryId);

            modelBuilder.Entity<ListActivity>()
                .HasKey(x => x.ListActivityId);

            modelBuilder.Entity<ActivityExtension>()
                .HasKey(x => x.ActivityExtensionId);

            #endregion

            #region PropertyOpts

            modelBuilder.Entity<Activity>()
                .Property(x => x.ActivityDescryption)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Activity>()
                .Property(x => x.ActivityName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            modelBuilder.Entity<ToDoList>()
                .Property(x => x.ToDoListName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Category>()
               .Property(x => x.CategoryName)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("nvarchar");

            modelBuilder.Entity<ToDoList>()
                .Property(x => x.IsDone)
                .HasColumnAnnotation("Default", false);


            #endregion

            #region Relationships

            modelBuilder.Entity<ListActivity>()
                .HasRequired(x => x.ActivityExtension)
                .WithRequiredPrincipal(x => x.ListActivity);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.ToDoLists)
                .WithRequired(x => x.ApplicationUser)
                .HasForeignKey(x => x.refUserId);

            modelBuilder.Entity<ToDoList>()
                .HasMany(x => x.ListActivities)
                .WithRequired(x => x.ToDoList)
                .HasForeignKey(x => x.refToDoListId);

            modelBuilder.Entity<ListActivity>()
                .HasRequired(x => x.Activity)
                .WithMany(x => x.ListActivities)
                .HasForeignKey(x => x.refActivityId);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Activities)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.refCategoryId);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}

