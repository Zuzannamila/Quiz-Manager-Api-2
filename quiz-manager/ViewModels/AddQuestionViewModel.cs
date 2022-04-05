namespace quiz_manager.ViewModels
{
    public class AddQuestionViewModel
    {
        public string Content { get; set; }
    }

    public class AddAnswerViewModel
    {
        public string Content { get; set; }
        public Boolean IsCorrect { get; set; }  
    }
}
