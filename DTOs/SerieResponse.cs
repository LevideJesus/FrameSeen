namespace FrameSeen.Dtos
{
    public class SerieResponse
    {
        public int Id {get; set;}
        public string Name {get; set;}

        public string? Overview {get; set;}

        public string? PosterPath {get; set;}
        public int NumberOfSeasons {get; set;}
        public int NumberOfEpisodes {get; set;}

        public int? EpisodeRunTime {get; set;}

        public string? Status {get; set;}

        public DateTime? FirstAirDate {get; set;}
    }
}