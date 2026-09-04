namespace FrameSeen.Dtos
{
    public class ListResponse
    {
        public int Id {get; set;}

        public int UserId {get; set;}

        public string? Name {get; set;}

        public DateTimeOffset? CreatedAt {get; set;}
    }
}