namespace FrameSeen.Models
{
    public class Diary
    {
        public int Id {get; set;}

        public int UserId {get; set;}

        public int SeriesId {get; set;}

        public int? Rating {get; set;}

        public DateTimeOffset WatchedAt {get; set;}

        public string? Review {get; set;}

        public DateTimeOffset CreatedAt {get; set;}
    }
}