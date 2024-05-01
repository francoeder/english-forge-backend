using EnglishForge.Domain.Enumerators;

namespace EnglishForge.Domain.Models.Application
{
    public class QuizzModel
    {
        public QuestionTypes Type { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }
}
