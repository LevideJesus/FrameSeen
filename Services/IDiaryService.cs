using FrameSeen.Dtos;
using FrameSeen.Models;

namespace FrameSeen.Services
{
    public interface IDiaryService
    {
        IEnumerable<DiaryResponse> GetAllDiaries(int userId);

        DiaryResponse? GetDiaryById(int id);

        DiaryResponse AddDiary(DiaryRequest request);
        DiaryResponse? UpdateDiary(int id, DiaryRequest request);
        void DeleteDiary(int id);
    }
}