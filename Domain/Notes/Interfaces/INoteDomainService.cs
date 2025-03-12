using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Interfaces
{
    public interface INoteDomainService
    {
        Task<Note> CreateNoteAsync(string title, string content);
        Task UpdateNoteAsync(Guid id, string newTitle, string newContent);
        Task DeleteNoteAsync(Guid id);
    }
}
