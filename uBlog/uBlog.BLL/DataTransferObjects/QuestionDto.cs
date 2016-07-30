using System.Collections.Generic;

namespace uBlog.BLL.DataTransferObjects
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }

        public string Text { get; set; }

        public virtual ICollection<AnswerDto> Answers { get; set; }
    }
}
