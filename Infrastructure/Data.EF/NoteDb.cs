using System.ComponentModel.DataAnnotations;

namespace Notes.ModelsDb
{
    public class NoteDb
    {
        [Key] 
        public Guid Id { get; set; }

        [Required] 
        [MaxLength(200)] 
        public string Title { get; set; }

        [Required] 
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
