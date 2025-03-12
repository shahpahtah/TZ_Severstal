using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes;
using Notes.Interfaces;
using Notes.ModelsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapperService _mapService;
        public NoteRepository(AppDbContext context,IMapperService service)
        {
            _context = context;
            _mapService = service;
        }
        public async Task AddAsync(Note note)
        {
            var noteDb = await _context.Notes.AddAsync(_mapService.Map<Note, NoteDb>(note));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Note note)
        {
            var noteDb = await _context.Notes.FindAsync(note.Id);
            if (noteDb == null)
            {
                return; 
            }
            _context.Notes.Remove(noteDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            var notes = await _context.Notes.ToListAsync();
            return notes.Select((i => _mapService.Map<NoteDb, Note>(i)));

        }

        public async Task<Note> GetByIdAsync(Guid id)
        {
            var noteDb =await _context.Notes.FindAsync(id);
            return _mapService.Map<NoteDb,Note>(noteDb);
        }

        public async Task UpdateAsync(Note note)
        {
            var noteDb = await _context.Notes.FindAsync(note.Id);
            noteDb.Content = note.Content;
            noteDb.ModifiedDate = DateTime.UtcNow;
            noteDb.Title = note.Title;
            _context.Notes.Update(noteDb);
            await _context.SaveChangesAsync();
        }
    }
}
