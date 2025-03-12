namespace Notes
{
    public class Note
    {
        public Guid Id { get; private set; } 
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime ModifiedDate { get; private set; }


        private Note(Guid id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
        }
        public static Note Create(string title, string content)
        {
            return new Note(Guid.NewGuid(), title, content);
        }
        public void UpdateContent(string newContent)
        {
            Content = newContent;
            ModifiedDate = DateTime.UtcNow;
        }
        public void UpdateTitle(string newTitle)
        {
            Title = newTitle;
            ModifiedDate = DateTime.UtcNow;
        }
    }
}
