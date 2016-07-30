namespace uBlog.BLL.DataTransferObjects
{
    public class AnswerDto
    {
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }

        public string Text { get; set; }

        public long VotesCount { get; set; }
    }
}
