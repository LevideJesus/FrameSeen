using FrameSeen.Data;
using FrameSeen.Dtos;
using FrameSeen.Models;

namespace FrameSeen.Services
{
    public class DiaryService : IDiaryService
    {
        private readonly AppDbContext context;
        
        public DiaryService(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public IEnumerable<DiaryResponse> GetAllDiaries()
        {
            var diaries = context.Diaries.ToList();

            var response = diaries.Select(d => new DiaryResponse
            {
                Id = d.Id,
                UserId = d.UserId,
                SeriesId = d.SeriesId,
                Rating = d.Rating,
                WatchedAt = d.WatchedAt,
                Review = d.Review,
                CreatedAt = d.CreatedAt
            });

            return response;
        }

        public DiaryResponse? GetDiaryById(int id)
        {
            var diary = context.Diaries.Find(id);

            var response = diary == null ? null : new DiaryResponse
            {
                Id = diary.Id,
                UserId = diary.UserId,
                SeriesId = diary.SeriesId,
                Rating = diary.Rating,
                WatchedAt = diary.WatchedAt,
                Review = diary.Review,
                CreatedAt = diary.CreatedAt
            };

            return response;

            
        }
    }
}