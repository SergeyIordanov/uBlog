using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace uBlog.WEB.Models
{
    public class AnswerViewModel
    {
        [Required]
        public int AnswerId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [DisplayName("Votes")]
        public long VotesCount { get; set; }
    }
}