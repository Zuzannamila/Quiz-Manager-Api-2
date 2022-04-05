using System.ComponentModel.DataAnnotations;

namespace quiz_manager.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid QuizId { get; set; } 
    }
    public class Answer
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Boolean IsCorrect { get; set; }
        public Guid QuestionId { get; set; }  
    }
}
