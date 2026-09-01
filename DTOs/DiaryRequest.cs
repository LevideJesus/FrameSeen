namespace FrameSeen.Dtos
{
    public class DiaryRequest
    {
        public int SeriesId {get; set;}

        public int UserId {get; set;}

        public DateTimeOffset WatchedAt {get; set;}
        public int? Rating {get; set;}

        public string? Review {get; set;}


    }
}