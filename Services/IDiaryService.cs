using FrameSeen.Dtos;
using FrameSeen.Models;

namespace FrameSeen.Services
{
    public interface IDiaryService
    {
        IEnumerable<DiaryResponse> GetAllDiaries();

        DiaryResponse? GetDiaryById(int id);

        DiaryResponse AddDiary(DiaryRequest request);
        void UpdateDiary(int id, Diary diary);
        void DeleteDiary(int id);
    }
}