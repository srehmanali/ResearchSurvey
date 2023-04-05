using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.DataModels.Questionnaire
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public string AnswerText { get; set; }
        public int OrderNum { get; set; }

        public Question Question { get; set; }
        public ICollection<UserResponse> UserResponse { get; set; }
    }
}
