using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace uBlog.WEB.ViewModels
{
    public class QuestionViewModel
    {
        [Required]
        public int QuestionId { get; set; }

        [Required]
        [DisplayName("Question")]
        public string Text { get; set; }

        public virtual ICollection<AnswerViewModel> Answers { get; set; }
    }
}