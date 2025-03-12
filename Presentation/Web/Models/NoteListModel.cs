using App.Models;

namespace Web.Models
{
    public class NoteListModel
    {
        public List<NoteDto> Notes { get; set; } = new List<NoteDto>();
    }
}
