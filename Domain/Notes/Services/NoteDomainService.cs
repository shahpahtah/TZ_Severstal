using Notes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Services
{
    public class NoteDomainService : INoteDomainService
    {
        private readonly INoteRepository _noteRepository;
        public NoteDomainService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public async Task<Note> CreateNoteAsync(string title, string content)
        {
            var note = Note.Create(title, content);
             await _noteRepository.AddAsync(note);
            return note;
        }

        public async Task DeleteNoteAsync(Guid id)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note == null)
            {
                throw new Exception($"Заметка с ID {id} не найдена.");
            }
            await _noteRepository.DeleteAsync(note);
        }

        public async Task UpdateNoteAsync(Guid id, string newTitle, string newContent)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            note.UpdateTitle(newTitle); 
            note.UpdateContent(newContent);
            await _noteRepository.UpdateAsync(note);
        }
    }
}
