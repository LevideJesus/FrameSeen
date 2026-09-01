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

        public DiaryResponse AddDiary(DiaryRequest diaryRequest)
        {
            var diaries = new Diary
            {
                Id = 0,
                UserId = diaryRequest.UserId,
                SeriesId = diaryRequest.SeriesId,
                Rating = diaryRequest.Rating,
                WatchedAt = diaryRequest.WatchedAt,
                Review = diaryRequest.Review,
                CreatedAt = DateTimeOffset.UtcNow
                
            };

            var newDiary = context.Diaries.Add(diaries);
            context.SaveChanges();

            var response = new DiaryResponse
            {
                Id = newDiary.Entity.Id,
                UserId = newDiary.Entity.UserId,
                SeriesId = newDiary.Entity.SeriesId,
                Rating = newDiary.Entity.Rating,
                WatchedAt = newDiary.Entity.WatchedAt,
                Review = newDiary.Entity.Review,
                CreatedAt = newDiary.Entity.CreatedAt
            };

            return response;
        }

        public void DeleteDiary(int id)
        {
            var diary = context.Diaries.Find(id);

            if(diary != null)
            {
                context.Diaries.Remove(diary);
                context.SaveChanges();
            }
        }

        public void UpdateDiary(int id, Diary diaries)
        {
            var existingDiary = context.Diaries.Find(id);

            if(existingDiary != null)
            {
                existingDiary.UserId = diaries.UserId;
                existingDiary.SeriesId = diaries.SeriesId;
                existingDiary.Rating = diaries.Rating;
                existingDiary.WatchedAt = diaries.WatchedAt;
                existingDiary.Review = diaries.Review;
                existingDiary.CreatedAt = diaries.CreatedAt;
                context.SaveChanges();

            }
        }
    }
}