using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Identity.Models;

namespace INStudio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<AboutSkilsSection> AboutSkilsSections { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Gallery> Gallerys { get; set; }
        public DbSet<GalleryINMedia> GalleryINMedias { get; set; }
        public DbSet<INMedia> INMedias { get; set; }
        public DbSet<INMediaCategory> INMediaCategories { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<INServices> INServices { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Skils> Skils { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PostCategory>()
                .HasKey(pc => new{pc.BlogPostId, pc.CategoryId});

            builder.Entity<PostCategory>()
            .HasOne<BlogPost>(pc => pc.Post)
            .WithMany(bp => bp.PostCategories)
            .HasForeignKey(pc => pc.BlogPostId);

            builder.Entity<PostCategory>()
            .HasOne<Category>(pc => pc.Category)
            .WithMany(c => c.PostCategories)
            .HasForeignKey(pc => pc.CategoryId);




            builder.Entity<INMediaCategory>()
            .HasKey(ic => new {ic.INMediaId, ic.CategoryId});

            builder.Entity<INMediaCategory>()
            .HasOne<INMedia>(ic => ic.INMedia)
            .WithMany(i => i.INMediaCategories)
            .HasForeignKey(ic => ic.INMediaId);

            builder.Entity<INMediaCategory>()
            .HasOne<Category>(ic => ic.Category)
            .WithMany(c => c.INMediCategories)
            .HasForeignKey(ic => ic.CategoryId);





            builder.Entity<GalleryINMedia>()
            .HasKey(gc => new{gc.GalleryId, gc.INMediaId});

            builder.Entity<GalleryINMedia>()
            .HasOne<INMedia>(gi => gi.INMedia)
            .WithMany(i => i.GalleryINMedias)
            .HasForeignKey(gi => gi.INMediaId);

            builder.Entity<GalleryINMedia>()
            .HasOne<Gallery>(gi => gi.Gallery)
            .WithMany(g => g.GalleryINMedias)
            .HasForeignKey(gi => gi.GalleryId);




            builder.Entity<Comment>()
            .HasOne<BlogPost>(c => c.BlogPost)
            .WithMany(b => b.Comments)
            .HasForeignKey(c => c.BlogPostId);

            builder.Entity<Comment>()
            .HasOne<AppUser>(c => c.Author)
            .WithMany(au => au.Comments)
            .HasForeignKey(c => c.AppUserId);

            builder.Entity<BlogPost>()
            .HasOne<AppUser>(bp => bp.Author)
            .WithMany(au => au.Posts)
            .HasForeignKey(bp => bp.AppUserId);

            builder.Entity<INMedia>()
            .HasOne<MediaType>(im => im.Type)
            .WithMany(mt => mt.INMedias)
            .HasForeignKey(im => im.TypeId);
            

        }
    }
}
