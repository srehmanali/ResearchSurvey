using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.DataModels.Questionnaire
{
    public class Question
    {
        public int Id { get; set; }
        public int QuestionTypeId { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }
        public int OrderNum { get; set; }


        public ICollection<Answer> Answer { get; set; }
        public QuestionType QuestionType { get; set; }
        public ICollection<UserResponse> UserResponse { get; set; }
    }
}
