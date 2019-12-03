using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MovieCruiserEFFramework.Model
{
    public partial class MovieCruiserContext : DbContext
    {
        public MovieCruiserContext()
        {
        }

        public MovieCruiserContext(DbContextOptions<MovieCruiserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<MovieList> MovieList { get; set; }
        public virtual DbSet<Users> User { get; set; }
        public virtual DbSet<Users2> Users2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=PC430723;Initial Catalog=MovieCruiser;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Favorites>(entity =>
            {
                entity.HasKey(e => e.FtId);

                entity.ToTable("favorites");

                entity.Property(e => e.FtId).HasColumnName("ft_id");

                entity.Property(e => e.FtMlId).HasColumnName("ft_ml_id");

                entity.Property(e => e.FtUsId).HasColumnName("ft_us_id");

                entity.HasOne(d => d.FtMl)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.FtMlId)
                    .HasConstraintName("ft_ml_fk");

                entity.HasOne(d => d.FtUs)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.FtUsId)
                    .HasConstraintName("ft_us_fk");
            });

            modelBuilder.Entity<MovieList>(entity =>
            {
                entity.HasKey(e => e.MlId);

                entity.ToTable("movie_list");

                entity.Property(e => e.MlId).HasColumnName("ml_id");

                entity.Property(e => e.MlActive)
                    .HasColumnName("ml_active")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MlBudget)
                    .HasColumnName("ml_budget")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.MlDateOfLaunch)
                    .HasColumnName("ml_date_of_launch")
                    .HasColumnType("date");

                entity.Property(e => e.MlGenre)
                    .HasColumnName("ml_genre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.MlHasTeaser)
                    .HasColumnName("ml_has_teaser")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MlTitle)
                    .HasColumnName("ml_title")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UsId);

                entity.ToTable("user");

                entity.Property(e => e.UsId).HasColumnName("us_id");

                entity.Property(e => e.UsName)
                    .HasColumnName("us_name")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users2>(entity =>
            {
                entity.HasKey(e => e.UsId);

                entity.Property(e => e.UsId).HasColumnName("us_id");

                entity.Property(e => e.UsName)
                    .IsRequired()
                    .HasColumnName("us_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsPassword)
                    .IsRequired()
                    .HasColumnName("us_password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
