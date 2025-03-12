using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface INoteAppService
    {
        Task<NoteDto> GetNoteByIdAsync(Guid id);
        Task<IEnumerable<NoteDto>> GetAllNotesAsync();
        Task<NoteDto> CreateNoteAsync(string title, string content); 
        Task UpdateNoteAsync(Guid id, string title, string content); 
        Task DeleteNoteAsync(Guid id); 
    }
}
