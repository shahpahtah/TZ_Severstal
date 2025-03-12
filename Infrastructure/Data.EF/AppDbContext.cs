using Microsoft.EntityFrameworkCore;
using Notes.ModelsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    public class AppDbContext:DbContext
    {
        private static readonly DateTime InitialNoteDate = DateTime.Parse("2023-10-27T10:00:00Z");
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        Guid firstNoteId = Guid.Parse("a9a01887-92b4-4983-8468-e5a1a49769b1");
        public DbSet<NoteDb> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NoteDb>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Content).IsRequired();
            });

           
            modelBuilder.Entity<NoteDb>().HasData(
                new NoteDb
                {
                    Id = firstNoteId,
                    Title = "Первая заметка",
                    Content = "Моя первая заметка",
                    CreatedDate = InitialNoteDate,
                    ModifiedDate = InitialNoteDate
                }
            );
        }
}
}
