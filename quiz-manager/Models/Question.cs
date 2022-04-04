using System.ComponentModel.DataAnnotations;

namespace quiz_manager.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid QuizId { get; set; }
        public string Content { get; set; }
        public Answer[] Answers { get; set; }   
    }
    public class Answer
    {
        [Key]
        public string Content { get; set; }
        public int isCorrect { get; set; }

    }
}
