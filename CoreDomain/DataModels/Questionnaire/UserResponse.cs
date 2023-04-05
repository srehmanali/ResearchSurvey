using CoreDomain.DataModels.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.DataModels.Questionnaire
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string LatLong { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public string SurveyStatus { get; set; }
        public string AnswerText { get; set; }
        public DateTime CreateDate { get; set; }
        public ApplicationUser User { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}
