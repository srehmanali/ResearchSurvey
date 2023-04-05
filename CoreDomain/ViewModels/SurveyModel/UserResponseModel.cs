using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDomain.ViewModels.SurveyModel
{
    public class UserResponseModel
    {
        public int? Id { get; set; }
        public string LatLong { get; set; }
        public string UserId { get; set; }
        public int LocationId { get; set; }
        public DateTime? ServerDateUTC { get; set; }
        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
        public DateTime StartTimeUTC { get; set; }
        public DateTime EndTimeUTC { get; set; }
        public string SurveyStatus { get; set; }

    }
}
