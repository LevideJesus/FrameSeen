namespace FrameSeen.Dtos
{
    public class TvMazeShowDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Summary { get; set; }
        public string? Status { get; set; }
        public string? Premiered { get; set; }
        public int? Runtime { get; set; }
        public ImageDto? Image { get; set; }
    }

    public class ImageDto
    {
        public string? Medium { get; set; }
        public string? Original { get; set; }
    }
}