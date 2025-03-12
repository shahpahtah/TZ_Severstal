using App.Interfaces;
using App.Models;
using AutoMapper;
using Notes;
using Notes.Interfaces;

namespace Services
{
    public class NoteAppService : INoteAppService
    {
        private readonly INoteDomainService _noteDomainService;
        private readonly INoteRepository _noteRepository;
        private readonly IMapperService _mapperService;
        public NoteAppService(INoteDomainService noteDomainService,INoteRepository noteRepository, IMapperService mapperService)
        {
            _noteDomainService = noteDomainService;
            _noteRepository = noteRepository;
            _mapperService = mapperService; 
        }
        public async Task<NoteDto> CreateNoteAsync(string title, string content)
        {
            var note = await _noteDomainService.CreateNoteAsync(title, content);
            return _mapperService.Map<Note, NoteDto>(note);
        }

        public async  Task DeleteNoteAsync(Guid id)
        {
            await _noteDomainService.DeleteNoteAsync(id);
        }

        public async Task<IEnumerable<NoteDto>> GetAllNotesAsync()
        {
            var notes = await _noteRepository.GetAllAsync();
            return notes.Select(i=>_mapperService.Map<Note, NoteDto>(i));
        }

        public async Task<NoteDto> GetNoteByIdAsync(Guid id)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note == null)
            {
                return null;
            }
            return _mapperService.Map<Note, NoteDto>(note);
        }

        public async Task UpdateNoteAsync(Guid id, string title, string content)
        {
            await _noteDomainService.UpdateNoteAsync(id, title, content);
        }
    }
}
