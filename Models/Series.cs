namespace FrameSeen.Models
{
    public class Series
    {
        public required int Id {get; set;}
        public required string Name {get; set;}

        public string? Overview {get; set;}

        public string? PosterPath {get; set;}
        public required int NumberOfSeasons {get; set;}
        public required int NumberOfEpisodes {get; set;}

        public int? EpisodeRunTime {get; set;}

        public string? Status {get; set;}

        public DateTime? FirstAirDate {get; set;}
    }
}